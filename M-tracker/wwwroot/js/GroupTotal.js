var dataTable;

$(document).ready(function () {

    $("#drpGroupType").change(SelectMonths);
    $("#btnProcess").click(ProcessStart);
    LoadGroupTotal();
})

var MainArr = [];

function SelectMonths() {

    LoadTotalEx();
    var TypeId = $("#drpGroupType").val();

    $.ajax({
        url: "/Customer/GroupTotal/LoadMonths",
        data: { TypeIdGet: TypeId },
        type: 'GET',
        success: function (data) {
            $(data).each(function (index, emp) {

                var TempArr = {};
                var TempData = emp.data;
                $("#txtMonths").empty();
                for (var i = 0; i < TempData.length; i++) {

                    $("#txtMonths").append("<option value='" + TempData[i].expensesDate + "'>" + TempData[i].expensesDate + "</option>");
                }
            });
        },
        error: function (error) {

        }
    });
}

function ProcessStart() {

    var Date = $("#txtMonths option:selected").text();
    var GroupId = $("#drpGroupType").val();

    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, Process it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: "/Customer/GroupTotal/ExpensesProcess",
                data: { txtGroupId: GroupId, txtDate: Date },
                type: 'POST',
                success: function (data) {
                    if (data.success) {

                        toastr.success(data.message);
                        LoadTotalEx();

                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })

}

function LoadGroupTotal() {

    dataTable = $('#tblGroupTotal').DataTable({
        responsive: true,
        "columns": [
            { "data": "submitDate", "width": "15%" },
            { "data": "amount", "width": "15%" },
            { "data": "dueAmount", "width": "15%" },
            { "data": "totalAmount", "width": "15%" },
            { "data": "processDate", "width": "15%" },
            { "data": "userName", "width": "15%" }
        ],
    });

}

function LoadTotalEx() {

    var GroupId = $("#drpGroupType").val();

    $.ajax({
        url: "/Customer/GroupTotal/LoadGroupTotalData",
        type: 'GET',
        data: { GroupId: GroupId},
        success: function (data) {

            $(data).each(function (index, emp) {
          
                var TempData = {};
                MainArr = [];

                 TempData = emp.data;

                for (var i = 0; i < TempData.length; i++) {

                    MainArr.push(TempData[i]);
                }

            });

            LoadGrid();
        },
        error: function (err) {
            alert(err);
        }

    });
}

function LoadGrid() {


    var table = $('#tblGroupTotal').DataTable();

    table.clear().draw();

    for (var i = 0; i < MainArr.length; i++) {
        dataTable.row.add(MainArr[i]).draw(false);
    }

}