

var dataTable;

$(document).ready(function () {

    $('#datepicker').datetimepicker({

        defaultDate: new Date(),
        format: 'DD/MM/YYYY'

    });

 
    dataTable = $('#tblGroup').DataTable({
        responsive: true,
        "columns": [
            { "data": "amount", "width": "20%" },
            { "data": "description", "width": "20%" }
        ],

    });




    $('#AddProdBtn').click(function () {

        var Mainarr = [];
        var arr = {};
        arr["amount"] = $('#txtamount').val();
        arr["description"] = $('#txtamount').val();

        Mainarr.push(arr);

        for (var i = 0; i < Mainarr.length; i++) {
            dataTable.row.add(Mainarr[i]).draw(false);
        }


    });

})


