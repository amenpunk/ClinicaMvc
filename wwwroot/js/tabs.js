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
	//console.log(enf)

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

//cargar el select
$.getJSON("/api/RecetaApi/" + idcuen, function (res) {
	$.each(res,
		function (key, value) {
			$("#receta").append("<option value='" + value.idReceta + "'>" + "consul-" + value.idConsulta + "-rec-" + value.idReceta + "</option>");
		});
});

//generar new
$('#genew').on('click', function () {

	$.ajax({
		url: "/api/RecetaApi",
		data: {
			idConsulta: idcuen,
		},
		type: "POST"
	}).done(function (result) {
		if (result != null) {
			alert("Receta Generada");
			$('#receta').empty()
			$.getJSON("/api/RecetaApi/" + idcuen, function (res) {
				$.each(res,
					function (key, value) {
						$("#receta").append("<option value='" + value.idReceta + "'>" + "consul-" + value.idConsulta + "-rec-" + value.idReceta + "</option>");
					});
			});

		}
		else {
			alert("Algo Salio Mal");
		}
	}).fail(function (xhr, status, error) { })

});


var receta = $("#receta option:selected").val();
//selecionar segun seleccionado
$('#selecres').on('click', function () {
	receta = $("#receta option:selected").val();
	var btnmod = document.getElementById('btnmodal')
	btnmod.classList.remove("btn-novi");
	console.log(receta)
	//traer de la api la lista de medicamentos
	https://localhost:5001/api/DescripcionRecetaApi
	$.getJSON("/api/DescripcionRecetaApi/" + receta, function (res) {
		$.each(res,
			function (key, value) {
				//console.log(value)

				var tbody = document.getElementById('boceta');
				var tr = document.createElement('tr')
				tr.innerHTML = `<tr>
    		   <td >
				${value.medicamento}
			   </td>
			   <td >
				${value.cantidad}
			   </td> 
			   <td >
				${value.dosis}
				<a style="float:right" href="/DescripcionReceta/Delete/${value.idDescripcion}"><i class="fas fa-minus-circle"></i></a>
    		   </td> 
    		</tr>`
				tbody.appendChild(tr);

			});
	});


});

/// agregar desde la modal
var medica = [];
$('#addMedi').on('click', function () {
	//var paci = $("#cie option:selected").val();
	var medi = document.getElementById('medi').value
	var cant = document.getElementById('cant').value
	var dosi = document.getElementById('dosi').value
	//console.log(paci)
	var obj = ({"medicamento": medi, "cantidad" : cant, "dosis": dosi})
	var tbody = document.getElementById('boceta');
	var tr = document.createElement('tr')
	tr.innerHTML = `<tr>
    		   <td>
    		    ${medi}
			   </td>
			   <td>
    		    ${cant}
			   </td> 
			   <td>
    		    ${dosi}
    		   </td> 
    		</tr>`
	tbody.appendChild(tr);
	medica.push(obj)
	alert("Registro agregado a la tabla");
	$("#medi").val('');
	$("#cant").val('');
	$("#dosi").val('');
});

var saveMedi = document.getElementById('saveMedi');

saveMedi.onclick = function () {

	medica.forEach(element => {
		
		$.ajax({
			url: "/api/DescripcionRecetaApi",
			data: {
				idReceta: receta,
				medicamento: element["medicamento"],
				cantidad: element["cantidad"],
				dosis: element["dosis"],
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
	
	medica = [];
	//console.log(element["medicamento"])	
}


