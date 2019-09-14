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
          $("#cie").append("<option value='" + value.c + "'>" + value.d + "</option>");
  
    });
  
  });

}

$('.message a').click(function(){
   $('form').animate({height: "toggle", opacity: "toggle"}, "slow");
});