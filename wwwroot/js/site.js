// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var today = new Date();
var dd = String(today.getDate()).padStart(2, '0');
var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
var yyyy = today.getFullYear();


var dateS = yyyy + "-" + mm + "-" + dd + "T00:00:00"
var dateF = yyyy + "-" + mm + "-" + dd + "T12:59:59"
var dateN = yyyy + "/" + mm + "/" + dd;


var date;
date = new Date();
date = date.getUTCFullYear() + '-' +
  ('00' + (date.getUTCMonth() + 1)).slice(-2) + '-' +
  ('00' + date.getUTCDate()).slice(-2) + ' ' +
  ('00' + date.getUTCHours()).slice(-2) + ':' +
  ('00' + date.getUTCMinutes()).slice(-2) + ':' +
  ('00' + date.getUTCSeconds()).slice(-2);


$('#myModal').on('shown.bs.modal', function () {
  $('#myInput').trigger('focus')
})

function toggleClass() {

  var valor = document.getElementById("mySelect").value;

  if (valor == 1) {
    $('#cobro').removeClass('d-none');
  }
  else {

    $('#cobro').addClass('d-none');
  }
}


$('.message a').click(function () {
  $('form').animate({ height: "toggle", opacity: "toggle" }, "slow");
});

$.getJSON("/api/PacienteApi", function (res) {
  $.each(res,
    function (key, value) {
      $("#IdPacienteCita").append("<option value='" + value.idPaciente + "'>" + value.primerNombre + " " + value.segundoNombre + " " + value.primerApellido + " " + value.segundoApellido + "</option>");
    });
});


var std = $("select option:selected").val();

$("#IdPacienteCita").on('change', function () {
  std = $(this).find(":selected").val()
});


$("#expSec").on('click', function () {
  $('#tipoExp').empty();
  $.getJSON("/api/ExpedienteApi/" + std+"?estado=0", function (res) {
    $.each(res,
      function (key, value) {
        $("#tipoExp").append("<option value='" + value.idExpediente + "'>" + value.fechaGen + "</option>");
      });
  });
});


$('#nuevoExp').on('click', function () {
  //var expe = $("#tipoExp option:selected").val();
  var paci = $("#IdPacienteCita option:selected").val();
  //alert(expe+ " paciente "+ paci + " fecha : " + date);
  $.ajax({
    url: "/api/ExpedienteApi",
    data: {
      IdPaciente: paci,
      FechaGen: dateS,
      estado:0
    },
    type: "POST"
  }).done(function (result) {
    if (result != null) {
      alert("Expediente Generado");
    }
    else {
      alert("Algo Salio Mal");
    }
  }).fail(function (xhr, status, error) { })
});


var ciente = $(".ciente")

ciente.each(function () {
  var op = this;
  var id = $(this).attr('value');
  //console.log(id);

  $.getJSON("/api/PacienteApi/" + id, function (res) {
    op.innerHTML = res.primerNombre + " " + res.segundoNombre + " " + res.primerApellido + " " + res.segundoApellido;
  });
})


$.getJSON("/api/DoctorApi", function (res) {
  $.each(res,
    function (key, value) {
      $("#IdDocCon").append("<option value='" + value.idDoctor + "'>" + value.nombre + "</option>");
    });
});

var expa = document.getElementById('expa')
$.getJSON("/api/ExpedienteApi/", function (res) {
  $.each(res,
    function (key, value) {
      //console.log(value.idPaciente)
      id = value.idPaciente;
      $.getJSON("/api/PacienteApi/" + id, function (res) {
        //console.log("value:" + value.fechaGen + " " + res.primerNombre + " " + res.segundoNombre + " " + res.primerApellido + " " + res.segundoApellido);
        if(value.estado == 0){

        nombre = value.fechaGen.substr(0,10) + "-" + res.primerNombre + " " + res.segundoNombre + " " + res.primerApellido + " " + res.segundoApellido +"-"+value.idExpediente
        $("#expa").append("<option value='" + value.idExpediente + "'>" + nombre + "</option>");
        //expa.options[x] = "value:"+ value.fechaGen+" " + res.primerNombre + " " + res.segundoNombre + " " + res.primerApellido + " " + res.segundoApellido;
        }
      });

    });
});

$.getJSON("/api/JoinApi", function (res) {
  $.each(res,
    function (key, value) {
      $("#secreto").append("<option value='" + value.idexp + "'>" + value.nombre + " " + value.nombre2 + " " + value.apellido + " " + value.apellido2+ "-" +value.fechaexp.substr(0,10)+"-"+value.idexp + "</option>");
    });
});

