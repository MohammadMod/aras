
//This function is for calculating the values of new invoice form
function getValues() {
    var numVal1 = parseInt(document.getElementById("KiloTextBox").value);
    var numVal2 = parseInt(document.getElementById("CostOfKiloTextBox").value);
    var numVal3 = parseInt(document.getElementById("DiscountTextBox").value);

    document.getElementById("TotallAllTextBox").value = numVal1 * numVal2 - numVal3;
    document.getElementById("TotallTextBox").value = numVal1 * numVal2;
}