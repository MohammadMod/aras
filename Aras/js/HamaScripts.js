//This function is for calculating the values of new invoice form
function getValues() {
    var numVal1 = parseInt(document.getElementById("KiloTextBox").value);
    var numVal2 = parseInt(document.getElementById("CostOfKiloTextBox").value);
    var numVal3 = parseInt(document.getElementById("DiscountTextBox").value);

    document.getElementById("TotallAllTextBox").value = numVal1 * numVal2 - numVal3;
    document.getElementById("TotallTextBox").value = numVal1 * numVal2;
}

//This function is for calculating the kilo and the cost in purchase form
function calculate() {
    var myBox1 = document.getElementById('KiloTextBox').value;
    var myBox2 = document.getElementById('CostTextBox').value;
    var result = document.getElementById('TotallAllTextBox');
    var myResult = myBox1 * myBox2;
    document.getElementById('TotallAllTextBox').value = myResult;
}

//show clock script
function startTime() {
    var today = new Date();
    var h = today.getHours();
    var m = today.getMinutes();
    var s = today.getSeconds();
    m = checkTime(m);
    s = checkTime(s);
    document.getElementById('txt').innerHTML =
        h + ":" + m + ":" + s;
    var t = setTimeout(startTime, 500);
}
function checkTime(i) {
    if (i < 10) { i = "0" + i };  
    return i;
}


