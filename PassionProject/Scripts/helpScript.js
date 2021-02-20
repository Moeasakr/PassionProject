window.onload = function () {
    "use strict";

    var helpButton = document.getElementById('helpButton');
    var closeButton = document.getElementById('closeOverlay');
    var overlay = document.getElementById('overlay');

    helpButton.onclick = function () {
        overlay.style.display = "block";
    }

    closeButton.onclick = function () {
        overlay.style.display = "none";
    }
}