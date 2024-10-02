window.onbeforeunload = function (e) {
    showSpinner();
}

$(document).ready(function () {
    hideSpinner();
});

function hideSpinner() {
    document.getElementById('pageLoader').style.display = 'none';
}

function showSpinner() {

    document.getElementById('pageLoader').style.display = 'block';
}