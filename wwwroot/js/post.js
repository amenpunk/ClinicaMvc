$('button').click(function(){
	var action = this.id;
	var titulo = document.title;
	var nombre = $('#userid').text()
	var user = 5190161514;
	var datos = JSON.stringify({
		"app":user,
		"usuario":nombre,
		"pagename":titulo,
		"actionname":action
	})
	
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
});


$('a').click(function(){
	var action = $(this).text();
	var destiny = $(this).attr('href');
	var nombre = $('#userid').text()
	var user = 5190161514;
	var datos = JSON.stringify({
		"app":user,
		"usuario":nombre,
		"actionname":action,
		"destiny" : destiny
	})
	
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
	
});