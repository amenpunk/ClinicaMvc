$.getJSON("/js/array.json",
	function (json) {

		$.each(json,
			function (key, value) {
				$("#cie").append("<option value='" + value.c + "'>" + value.d + "</option>");
			});
	});


function openCity(evt, cityName) {
	var i, tabcontent, tablinks;
	tabcontent = document.getElementsByClassName("tabcontent");
	for (i = 0; i < tabcontent.length; i++) {
		tabcontent[i].style.display = "none";
	}
	tablinks = document.getElementsByClassName("tablinks");
	for (i = 0; i < tablinks.length; i++) {
		tablinks[i].className = tablinks[i].className.replace(" active", "");
	}
	document.getElementById(cityName).style.display = "block";
	evt.currentTarget.className += " active";
}

var idcuen = $('#idcon').attr('name')

$.getJSON("/api/OrdenLabApi/" + idcuen, function (res) {
	$.each(res,
		function (key, value) {
			//console.log(value)

			var tbody = document.getElementById('bexam');
			var tr = document.createElement('tr')
			tr.innerHTML = `<tr>
    		   <td >
				${value.nombreExamen}
				<a style="float:right" href="/OrdenLab/Delete/${value.idOrden}"><i class="fas fa-minus-circle"></i></a>
    		   </td> 
    		</tr>`
			tbody.appendChild(tr);

		});
});


var btn = document.getElementById('agregarEx');
var dire = document.getElementById('dire');
var todos = [];
btn.onclick = function () {
	//console.log(dire.value)
	var tbody = document.getElementById('bexam');
	var tr = document.createElement('tr')
	tr.innerHTML = `<tr>
    		   <td>
    		    ${dire.value}
    		   </td> 
    		</tr>`
	tbody.appendChild(tr);
	todos.push(dire.value)
	//console.log(todos)
}

var sva = document.getElementById('saveTable')

sva.onclick = function () {

	todos.forEach(element => {

		$.ajax({
			url: "/api/OrdenLabApi",
			data: {
				idConsulta: idcuen,
				nombreExamen: element
			},
			type: "POST"
		}).done(function (result) {
			if (result != null) {
				alert("Registro guardado");
			}
			else {
				alert("Algo Salio Mal");
			}
		}).fail(function (xhr, status, error) { })
	});
	todos = [];
}



//cargar la tabla de diagnostico
$.getJSON("/api/DiagnosticoApi/" + idcuen, function (res) {
	$.each(res,
		function (key, value) {
			//console.log(value)
			//console.log(getCie(value.idCie))
			var tbody = document.getElementById('biag');
			var tr = document.createElement('tr')
			tr.innerHTML = `<tr>
    		   <td>
				${value.idCie}
				<a style="float:right" href="/Diagnostico/Delete/${value.idDiagnostico}"><i class="fas fa-minus-circle"></i></a>
				
    		   </td> 
    		</tr>`
			tbody.appendChild(tr);

		});
});

var enf = [];
$('#agregarDiag').on('click', function () {
	var paci = $("#cie option:selected").val();
	//console.log(paci)
	var tbody = document.getElementById('biag');
	var tr = document.createElement('tr')
	tr.innerHTML = `<tr>
    		   <td>
    		    ${paci}
    		   </td> 
    		</tr>`
	tbody.appendChild(tr);
	enf.push(paci)
	console.log(enf)

});

diagsave = document.getElementById('saveDiag')

diagsave.onclick = function () {

	enf.forEach(element => {

		$.ajax({
			url: "/api/DiagnosticoApi",
			data: {
				idConsulta: idcuen,
				idCie: element
			},
			type: "POST"
		}).done(function (result) {
			if (result != null) {
				alert("Registro guardado");
			}
			else {
				alert("Algo Salio Mal");
			}
		}).fail(function (xhr, status, error) { })
	});
	todos = [];
}