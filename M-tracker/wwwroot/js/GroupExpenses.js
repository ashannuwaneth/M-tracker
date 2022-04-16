
var dataTable;

$(document).ready(function () {

    $('#txtDateFrom').datepicker();
    $('#txtDateTo').datepicker();

    InitDataTable();
    InitDisableItems();

    $("#txtDateTo").change(EnableFields);
    $('#drpGroup').change(Dropdiable);
    $('#AddProdBtn').click(AddToGrid);
    $('#ClearBtn').click(ClearForm);





});

var MainArr = [];

function Dropdiable() {

    $('#drpGroup').attr('disabled', true);

}

function InitDisableItems() {

    $('#drpGroup').attr('disabled', true);
    $('#drpExpenses').attr('disabled', true);
    $('#txtDescription').attr('disabled', true);
    $('#txtamount').attr('disabled', true);
}

function InitDataTable() {

    dataTable = $('#tblGroup').DataTable({
        responsive: true,
        "columns": [
            { "data": "group", "width": "20%" },
            { "data": "type", "width": "20%" },
            { "data": "description", "width": "20%" },
            { "data": "amount", "width": "20%" }
        ],
    });
}

function EnableFields() {

    $("#drpGroup").removeAttr("disabled");
    $("#drpExpenses").removeAttr("disabled");
    $("#txtDescription").removeAttr("disabled");
    $("#txtamount").removeAttr("disabled");


    $("#TxtFrom").attr("disabled", true);
    $("#TxtTo").attr("disabled", true);

}

function AddToGrid() {

    var TempArr = {};
    TempArr["group"] = $('#drpGroup :selected').text();
    TempArr["type"] = $('#drpExpenses :selected').text();
    TempArr["description"] = $('#txtDescription').val() == "" ? $('#drpExpenses :selected').text() : $('#txtDescription').val();
    TempArr["amount"] = $('#txtamount').val();

    MainArr.push(TempArr);
    dataTable.clear().draw();



    for (var i = 0; i < MainArr.length; i++) {
        dataTable.row.add(MainArr[i]).draw(false);
    }

    var TotalAmount=0;

    for (var j = 0; j < MainArr.length; j++) {

        var amount = MainArr[j]["amount"];

        TotalAmount = parseFloat(amount) + parseFloat(TotalAmount);
    }


    $('#txtalert').text(parseFloat(TotalAmount));

}

function ClearForm() {


}