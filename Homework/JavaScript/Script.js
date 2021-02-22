function dateTime() {
    var today = new Date();
    var date = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();
    var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
    var dateTime = date + ' ' + time;
    alert(dateTime);
}
function guessNumber(number = 13) {
    var randomNumber = Math.max(21);
    if (randomNumber === number) {
        return "Correct!"
    } else {
        if (number > randomNumber) {
            alert("Incorrect!  Your number is bigger than true number");
        } else {
            alert("Incorrect! Your number is smaller than true number");
        }
    }
}
function getCurrectUrl() {
    alert(document.URL);
}
function setPy(currentString = "String") {
    if (String.prototype.startsWith("Py")) {
        alert(currentString);
    } else {
        alert("Py" + currentString);
    }
}
function checkArray(array = [1,2,4,6,8,2]) {
    if (array[0] === 1 || array[array.Length - 1] === 1) {
        alert("true");
    } else {
        alert("false");
    }
}
function lastElementsOfArray(array = [1,2,46,7,1,2,55,68,2], amount = 2) {
    let arr = new Array();
    var numbers = "";
    for (i = 0; i < amount; i++) {
        numbers += " " + array[array.length - i - 1];
    }
    alert(numbers);
}
function combine(array = ["Name", "Sirname"], symbol = "***") {
    var stringResult = "";
    for (i = 0; i <= array.length; i++) {
        stringResult += array[i] + symbol;
    }
    alert(stringResult);
}
function removeDublicates(array) {
    alert(Array.from(new Set(array)));
}
function calculateSquare() {
    var nInit = 4;
    var n = nInit;
    var S = 0;
    while (n >= 1) {
        if (n == nInit) {
            S += n * 2 - 1;
        }
        else {
            S += n* 4 - 2;
        }
        n--;
    }
    alert(S);
}