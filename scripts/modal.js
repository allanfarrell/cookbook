// Get the modal
var modalI = document.getElementById('modalIngredient');
var modalM = document.getElementById('modalMethod');

// Get the button that opens the modal
var btnI = document.getElementById("ingredientBtn");
var btnM = document.getElementById("methodBtn");

// When the user clicks on the button, open the modal 
btnI.onclick = function () {
    modalI.style.display = "block";
}
btnM.onclick = function () {
    modalM.style.display = "block";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modalI) {
        modalI.style.display = "none";
        location.reload(true);
    }
    if (event.target == modalM) {
        modalM.style.display = "none";
        location.reload(true);
    }
}