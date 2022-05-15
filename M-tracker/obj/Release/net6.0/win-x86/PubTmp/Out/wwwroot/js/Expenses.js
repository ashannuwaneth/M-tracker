var dataTable;

$(document).ready(function () {

    $('#TxtExDate').datepicker({

    });
    LoadExpensesTbl();

})

function LoadExpensesTbl() {

    dataTable = $('#tblExpenses').DataTable({
        responsive: true,
        "ajax": {
            "url": "/Customer/Expenses/GetAllExpenses"
        },
        "columns": [
            { "data": "expensesDate", "width": "20%" },
            { "data": "amount", "width": "20%" },
            { "data": "type", "width": "20%" },
            { "data": "incomeTypes", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                         <div class="w-75 btn-group" role="group">
                        <a href="/Customer/Expenses/Index?id=${data}"
                        class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Edit</a>
                           <a onClick=Delete('/Customer/Expenses/Delete/${data}')
                        class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
					</div>
                        `
                },
                "width": "40%"
            }
        ],
    });
}

function Delete(data) {

    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: data,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })

}