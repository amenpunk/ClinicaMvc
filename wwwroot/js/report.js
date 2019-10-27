
$.getJSON("/api/PacienteApi", function (res) {
  $.each(res,
    function (key, value) {
      $('#paciente').append("<option value='" + value.idPaciente + "'>" + value.primerNombre + " " + value.segundoNombre + " " + value.primerApellido + " " + value.segundoApellido + "</option>");
    });
});


var std = $("#paciente option:selected").val();
var estado = 1;

$("#paciente").on('change', function () {
  std = $(this).find(":selected").val()
  $('#expSec').empty();
  $.getJSON("/api/ExpedienteApi/" + std+"?estado="+estado, function (res) {

    $.each(res,
      function (key, value) {
        $("#expSec").append("<option value='" + value.idExpediente + "'>" +  value.fechaGen.substr(0,10)+"-"+value.idExpediente + "</option>");
      });
  });
});