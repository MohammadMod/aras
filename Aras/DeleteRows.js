// delete table rows 
function deleteRows(mytable, aspfunction)
{
    var rows = selected.length;

    var confrimMessage = "Are you sure to delete " + rows + " rows ?";
    var errorMessage = "You have not selected any rows.";

    if (rows > 0) {
        var result = confirm(confrimMessage);
        if (result) {

         
        }
    }
    else
        alert(errorMessage);

    
}


// create DIV element and append to the table cell
function createCell(cell, text, style) {
    if (text == 0)
    {
        var div = document.createElement('div');

        div.innerText = "Select"
        div.setAttribute('class', style);
        div.setAttribute('className', style);
        cell.appendChild(div);

    }
    else
    {
        var check = document.createElement('input');

        check.type = "checkbox"
        check.id = "check" + (text - 1);
        check.setAttribute('class', style);
        check.setAttribute('className', style);
        check.addEventListener('change', function () {
            selecteList("row"+(text-1), this.checked)
 
        });
        cell.appendChild(check);
        
    }
}

function selecteList(id, triger)
{
    if (triger == true)
        selected.push(id);
    else
    {
        selected = arrayRemove(selected, id);
    }
}
function arrayRemove(arr, value) {

    return arr.filter(function (ele) {
        return ele != value;
    });

}



function appendColumn( mytable , style = 'col' , array)
{

    var tbl = document.getElementById(mytable), // table reference
        i;
    // open loop for each row and append cell
    for (i = 0; i < tbl.rows.length; i++) {
        createCell(tbl.rows[i].insertCell(tbl.rows[i].cells.length), i, style);
        tbl.rows[i].id = "row" + i;
    }
}