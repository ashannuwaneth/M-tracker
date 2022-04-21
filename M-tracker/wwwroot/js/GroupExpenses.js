 
var dataTable;

$(document).ready(function () {

    $('#txtDateFrom').datepicker({
        format: "mm-yyyy",
        startView: "months",
        minViewMode: "months"
    });
    $('#txtDateTo').datepicker({
        format: "mm-yyyy",
        startView: "months",
        minViewMode: "months"
    });

    InitDataTable();
    InitDisableItems();

    $("#txtDateTo").change(EnableFields);
    $('#drpGroup').change(Dropdiable);
    $('#AddProdBtn').click(AddToGrid);
    $('#ClearBtn').click(ClearForm);
    $('#btnSave').click(SaveDetails);

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

    document.getElementById("AddProdBtn").disabled = true;
    document.getElementById("ClearBtn").disabled = true;
    document.getElementById("btnSave").disabled = true;
}

function InitDataTable() {

    dataTable = $('#tblGroup').DataTable({
        responsive: true,
        "columns": [
            { "data": "group", "width": "20%" },
            { "data": "type", "width": "20%" },
            { "data": "description", "width": "20%" },
            { "data": "amount", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                           <a onClick=Delete('${data}')
                        class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
					</div>
                        `
                },
                "width": "20%"
            }
        ],
    });
}

function EnableFields() {

    $("#drpGroup").removeAttr("disabled");
    $("#drpExpenses").removeAttr("disabled");
    $("#txtDescription").removeAttr("disabled");
    $("#txtamount").removeAttr("disabled");
    document.getElementById("AddProdBtn").disabled = false;
    document.getElementById("ClearBtn").disabled = false;
    document.getElementById("btnSave").disabled = false;

    $("#TxtFrom").attr("disabled", true);
    $("#TxtTo").attr("disabled", true);

}

function AddToGrid() {

    const element = document.getElementById('txtamount');

    if ($('#txtamount').val() == "" || $('#txtamount').val() == 0) {
        $("#txterror").html('*** Amount Can not be Empty ***');
        element.classList.add('border-danger');

    }
    else {

        if (element.classList.contains('border-danger')) {
            element.classList.remove('border-danger');
        }
        $("#txterror").html('');

        var TempArr = {};
        var CountId = MainArr.length == 0 ? 1 : (MainArr.length + 1);
        var DateFrom = $('#TxtFrom').val();
        var DateTo = $('#TxtTo').val();
        /* var month = $('#txtDateFrom').datepicker('getDate').getMonth() + 1;*/ // get only month
        

       // TempArr["id"] = CountId.toString();
        TempArr["group"] = $('#drpGroup :selected').text();
        TempArr["groupTypeId"] = parseInt($('#drpGroup :selected').val());
        TempArr["type"] = $('#drpExpenses :selected').text();
        TempArr["expensesTypeId"] = parseInt($('#drpExpenses :selected').val());
        TempArr["description"] = $('#txtDescription').val() == "" ? $('#drpExpenses :selected').text() : $('#txtDescription').val();
        TempArr["amount"] = parseFloat($('#txtamount').val());
        TempArr["DateFrom"] = DateFrom;
        TempArr["DateTo"] = DateTo;

        MainArr.push(TempArr);
        dataTable.clear().draw();

        LoadGrid();
        CalculateAmount();
    }


}

function LoadGrid() {

          dataTable.clear().draw();

        for (var i = 0; i < MainArr.length; i++) {
            dataTable.row.add(MainArr[i]).draw(false);
        }
   
}

function CalculateAmount() {
    var TotalAmount = 0;

    for (var j = 0; j < MainArr.length; j++) {

        var amount = MainArr[j]["amount"];

        TotalAmount = parseFloat(amount) + parseFloat(TotalAmount);
    }
    $('#txtalert').text(parseFloat(TotalAmount));
}

function ClearForm() {

    location.reload();

}

function Delete(data) {

    for (var i = 0; i < MainArr.length;i++){

        if (data == MainArr[i]["id"]) {

            MainArr.splice((data - 1), 1);
            break;
        }
    }
    LoadGrid();
    CalculateAmount();
}

function SaveDetails() {

    



    $.ajax({
        url: "/Customer/GroupExpenses/Save",
        type: 'POST',
        dataType: 'json',
        data: JSON.stringify(MainArr),
        contentType: 'application/json; charset=utf-8',
        success: function () {

            //console.log("Savesuccessful");
            //console.log(data);
            alert("Record Save Succesfully");

            //$(".loader").hide();
        },
        error: function (error) {
            alert("Error is occured");
            //console.log("My errror values:", error);

        }
    });


}