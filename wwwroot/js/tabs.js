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
    		   <td>
    		    ${value.nombreExamen}
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
}