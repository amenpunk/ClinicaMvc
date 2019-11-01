$("button").click(function(){
    console.log('click en un boton');
});


$( document ).ready(function() {
	var titulo = document.title;
	var nombre = $('#userid').text()
	
	var user = 5190161514;
	var datos = JSON.stringify({
		"app":user,
		"usuario":nombre,
		"pagename":titulo
	})

	console.table(datos)
	/*
	$.ajax({
		type: "POST",
		url: "https://us-east-1.aws.webhooks.mongodb-stitch.com/api/client/v2.0/app/hackathon-gmoid/service/API/incoming_webhook/analitica",
		data: datos,
		contentType: 'application/json',
	}).done(function (result) {
		if (result != null) {
			console.log("POST REALIZADO")
		}
		else {
			console.log("Algo Salio Mal")
		}
	}).fail(function (xhr, status, error) { })
	*/
});