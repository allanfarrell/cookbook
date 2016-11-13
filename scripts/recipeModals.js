
var modalD = document.getElementById('modalDelete');
var modalDet = document.getElementById('modalDetails');
var modalAdd = document.getElementById('modalAdd');

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];
var spanTwo = document.getElementsByClassName("close")[1];

// When the user clicks on <span> (x), close the modal
span.onclick = function () {
    modalD.style.display = "none";
}
spanTwo.onclick = function () {
    modalDet.style.display = "none";
}
// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modalD) {
        modalD.style.display = "none";
    }
    if (event.target == modalDet) {
        modalDet.style.display = "none";
    }
    if (event.target == modalAdd) {
        modalAdd.style.display = "none";
        location.reload(true);
    }
}

var deleteBtn = document.getElementsByClassName("deleteBtn");
var detailsBtn = document.getElementsByClassName("detailsBtn");
var addBtn = document.getElementById("addBtn");

// Loop through records and set multiple event listeners
for (var i = 0; i < deleteBtn.length; i++) {
    deleteBtn[i].addEventListener('click', ShowDeleteModal, false);
}
for (var i = 0; i < detailsBtn.length; i++) {
    detailsBtn[i].addEventListener('click', ShowDetailsModal, false);
}
addBtn.addEventListener('click', ShowAddModal, false);

function ShowDeleteModal() {
    modalD.style.display = "block";
    var url = $(this).data(url).url;
    $('#deleteModalContent').load(url);
}

function ShowDetailsModal() {
    modalDet.style.display = "block";
    var url = $(this).data(url).url;
    $('#detailsModalContent').load(url);
}

function ShowAddModal() {
    modalAdd.style.display = "block";
    var url = $(this).data(url).url;
    $('#addModalContent').load(url);
}