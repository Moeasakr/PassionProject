window.onload = function () {
    "use strict";

    //Variable declarations
    var pairingArea = document.getElementById("PairingArea");
    var isFirst = true;
    var successCounter = 0;
    var pairsArray = pairingArea.children;
    var pairCount = (pairsArray.length - 2) / 2;
    var header = document.getElementById("pairingH2");
    var numberOfFails = 0;
    var status;

    //Variables for the styling
    var firstSelectionColor = '#F4EBD0';
    var successfulMatchColor = 'green';
    var unsuccessfulMatchColor = 'red';
    var defaultColor = '';

    //Clicked button value storage variables
    var firstButtonClickedClass;
    var secondButtonClickedClass;
    var firstButtonClickedId;
    var secondButtonClickedId;


    pairingArea.addEventListener('click', (event) => {
        const isButton = event.target.nodeName === 'BUTTON';
        if (!isButton) {
            return;
        } else {
            if (isFirst) {//Checks to see if it is the first button click
                firstButtonClickedClass = event.target.className;
                firstButtonClickedId = event.target.id;
                isFirst = false;
                //Styling after first click
                document.getElementById(firstButtonClickedId).style.backgroundColor = firstSelectionColor;
            } else { //Enters if it is the second button clicked
                secondButtonClickedClass = event.target.className;
                secondButtonClickedId = event.target.id;
                if (firstButtonClickedId === secondButtonClickedId) { //Enters if the first button is pressed twice
                    //Resets the color and variable for the first selection
                    document.getElementById(firstButtonClickedId).style.backgroundColor = defaultColor;

                } else if (firstButtonClickedClass === secondButtonClickedClass) { //Enters on successful pairing
                    //Styling the correct pairing
                    document.getElementById(firstButtonClickedId).style.backgroundColor = successfulMatchColor;
                    document.getElementById(secondButtonClickedId).style.backgroundColor = successfulMatchColor;

                    document.getElementById(firstButtonClickedId).disabled = 'true';
                    document.getElementById(secondButtonClickedId).disabled = 'true';
                    setTimeout(function myfunction() {
                        document.getElementById(firstButtonClickedId).style.backgroundColor = "grey";
                        document.getElementById(secondButtonClickedId).style.backgroundColor = "grey";
                        SuccessfulPairing();
                    }, 500)
                } else { //Enters on unsuccessful pairing
                    document.getElementById(firstButtonClickedId).style.backgroundColor = unsuccessfulMatchColor;
                    document.getElementById(secondButtonClickedId).style.backgroundColor = unsuccessfulMatchColor;

                    numberOfFails++;

                    setTimeout(function myfunction() {
                        document.getElementById(firstButtonClickedId).style.backgroundColor = defaultColor;
                        document.getElementById(secondButtonClickedId).style.backgroundColor = defaultColor;
                    }, 500)
                }
                isFirst = true;
            }
        }
    });

    function SuccessfulPairing() {
        successCounter++;
        if (successCounter === pairCount) {
            postDataForStatistics();
            EndRound();
        }
    }

    function EndRound() {
        for (var i = 0; i < pairsArray.length; i++) {
            if (!pairsArray[i].classList.contains('hiddenButtons')) {
                pairsArray[i].classList.add('hiddenButtons');
            } else {
                pairsArray[i].classList.remove('hiddenButtons');
            }
        }
        header.innerHTML = "Well done!";
        header.classList.add('SuccessfulRound');
    }

    //Refernece: https://stackoverflow.com/questions/34362510/c-sharp-mvc-post-model-and-additional-data-to-controller-from-js
    function postDataForStatistics() {
        if (numberOfFails >= 1) {
            status = 0;
        } else {
            status = 1;
        }
        $.post("/Statistics/AddStatistic",
            {
                numberOfPairs: pairCount,
                status: status,
                fails: numberOfFails
            });
    }
}