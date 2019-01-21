//search inside gridview

function Search_Gridview(strKey, strGV) {
        var strData = strKey.value.toLowerCase().split(" ");
    var tblData = document.getElementById(strGV);
    var rowData;
        for (var i = 1; i < tblData.rows.length; i++) {
        rowData = tblData.rows[i].innerHTML;
    var styleDisplay = 'none';
            for (var j = 0; j < strData.length; j++) {
                if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
        styleDisplay = '';
                else {
        styleDisplay = 'none';
    break;
}
}
tblData.rows[i].style.display = styleDisplay;
}
}

//function calculate() {
//    var numVal1 = parseInt(document.getElementById("Kilo").value);
//    var numVal2 = parseInt(document.getElementById("Money_of_kilo").value);
//    var result = document.getElementById('result');
//    document.getElementById("Total_all").value = numVal1 * numVal2;
//}

function calculate() {
    var myBox1 = document.getElementById('Kilo').value;
    var myBox2 = document.getElementById('Money_of_kilo').value;
    var result = document.getElementById('Total_all');
    var myResult = myBox1 * myBox2;
    document.getElementById('Total_all').value = myResult;
}