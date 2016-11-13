
// Get the <span> element that closes the modal
var span = document.getElementById("iClose");
var spanTwo = document.getElementById("mClose");
// When the user clicks on <span> (x), close the modal
if (span) {
    span.onclick = function () {
        modalI.style.display = "none";
    }
}
if (spanTwo) {
    spanTwo.onclick = function () {
        modalM.style.display = "none";
    }
}