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


$.getJSON("/js/array.json", //parametro tipo_cuenta que le envio al servlet lleva llaves por es json
  function (json) {
      $.each(json,
              function (key, value) {
                  $("#cie").append("<option value='" + value.c + "'>" + value.d + "</option>");
              });
});