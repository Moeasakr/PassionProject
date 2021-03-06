window.onload = function () {
    //Variables
    var in_lowSuccess = document.getElementById("lowSuccessRateCheckbox");
    var in_NumberOfPairs = document.getElementsByName("pairAmount");
    var formHandler = document.forms.settingsForm;
    var out_SuccessRate;
    var out_NumberOfPairs;
    var numberOfPairsID;

    formHandler.onsubmit = postData;

    function postData() {
        if (in_lowSuccess.checked === true) {
            out_SuccessRate = 1;
        } else {
            out_SuccessRate = 1;
        }

        //Reference: https://www.geeksforgeeks.org/how-to-get-value-of-selected-radio-button-using-javascript/
        for (var i = 0; i < in_NumberOfPairs.length; i++) {
            if (in_NumberOfPairs[i].checked) {
                numberOfPairsID = in_NumberOfPairs[i].value;
            }
        }

        if (numberOfPairsID === "Default") {
            out_NumberOfPairs = 5;
        } else if (numberOfPairsID === "Random") {
            out_NumberOfPairs = 2;
        }
        console.log(out_SuccessRate);
        console.log(in_NumberOfPairs[1].value);
        console.log(out_NumberOfPairs);

        //Refernece: https://stackoverflow.com/questions/34362510/c-sharp-mvc-post-model-and-additional-data-to-controller-from-js
        $.post("/Settings/UpdateSettings",
            {
                pairs: out_NumberOfPairs,
                successRate: out_SuccessRate
            });
        console.log('reached');
    }
    
}