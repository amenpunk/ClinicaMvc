// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('#myModal').on('shown.bs.modal', function () {
  $('#myInput').trigger('focus')
})

function toggleClass(){
  //console.log("cambio");
  var valor = document.getElementById("mySelect").value;
  //console.log(valor);
  if(valor == 1){
    $('#cobro').removeClass('d-none');
  }
  else{

    $('#cobro').addClass('d-none');
  } 
}
