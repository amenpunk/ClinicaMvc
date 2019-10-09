// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('#myModal').on('shown.bs.modal', function () {
  $('#myInput').trigger('focus')
})

function toggleClass(){

  var valor = document.getElementById("mySelect").value;
 
  if(valor == 1){
    $('#cobro').removeClass('d-none');
  }
  else{

    $('#cobro').addClass('d-none');
  } 
}

function obtenerCie(){

  $.getJSON("/js/array.json", 
    function (json) {
        
      $.each(json,
        function (key, value) {
//          $("#cie").append("<option value='" + value.c + "'>" + value.d + "</option>");
  
    });
  
  });

}

$('.message a').click(function(){
   $('form').animate({height: "toggle", opacity: "toggle"}, "slow");
});

$.getJSON("/api/PacienteApi",function (res) {
    $.each(res,
            function (key, value) {
                $("#IdPacienteCita").append("<option value='" + value.idPaciente + "'>" + value.primerNombre +" "+ value.segundoNombre + " " + value.primerApellido +" "+ value.segundoApellido + "</option>");
            });
});


var std = $("select option:selected").val();

$("#IdPacienteCita").on('change', function(){
    std = $(this).find(":selected").val()
});


$("#expSec").on('click', function(){
    $('#tipoExp').empty();
    $.getJSON("/api/ExpedienteApi/"+std,function (res) {
    $.each(res,
            function (key, value) {
                $("#tipoExp").append("<option value='" + value.idExpediente + "'>" + value.fechaGen + "</option>");
            });
    });
}); 


$('#nuevoExp').on('click', function(){
    //var expe = $("#tipoExp option:selected").val();
    var paci = $("#IdPacienteCita option:selected").val();
    var date;
    date = new Date();
    date = date.getUTCFullYear() + '-' +
        ('00' + (date.getUTCMonth()+1)).slice(-2) + '-' +
        ('00' + date.getUTCDate()).slice(-2) + ' ' + 
        ('00' + date.getUTCHours()).slice(-2) + ':' + 
        ('00' + date.getUTCMinutes()).slice(-2) + ':' + 
        ('00' + date.getUTCSeconds()).slice(-2);
    //console.log(date);

    //alert(expe+ " paciente "+ paci + " fecha : " + date);
    $.ajax({
      url : "/api/ExpedienteApi",
      data: { 
              IdPaciente: paci,
              FechaGen: date
            },
      type : "POST"
    }).done(function (result) {
      if (result != null) {
        alert("Expediente Generado");
      }
      else {
        alert("Algo Salio Mal");
        }
      }).fail(function (xhr, status, error) {  })
});


var ciente = $(".ciente")

ciente.each(function(){
    var op = this;
    var id = $(this).attr('value');
    //console.log(id);
    
    $.getJSON("/api/PacienteApi/"+id,function (res) {
        op.innerHTML = res.primerNombre+" " + res.segundoNombre +" "+ res.primerApellido +" "+ res.segundoApellido;
    });
})


