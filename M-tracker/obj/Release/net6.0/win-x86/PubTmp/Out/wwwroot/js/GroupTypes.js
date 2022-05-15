var dataTable;

$(document).ready(function () {

    loadGropTypes();

})


function loadGropTypes() {

    dataTable = $('#tblGroup').DataTable({
        responsive: true,
        "ajax": {
            "url": "/Customer/GroupType/GetAllGroup"
        },
        "columns": [
            { "data": "type", "width": "20%" },
            { "data": "description", "width": "20%" },
            { "data": "createdDate", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                        <a onclick="EditGroup('${data}')"
                        class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i>Edit</a>
                           <button onClick=Delete('/Customer/GroupType/Delete/${data}')
                        class="btn btn-danger mx-2" type="button" disabled> <i class="bi bi-trash-fill"></i> Delete</button>
					</div>
                        `
                },
                "width": "40%"
            }
        ],

    });
}

showInPopup = (url, title) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
            // to make popup draggable
            $('.modal-dialog').draggable({
                handle: ".modal-header"
            });
        }
    })
}

function EditGroup(data) {
    var url = "/Customer/GroupType/CreateGroup/" + data;
    $.get(url, null, function (data) {
        $('#form-modal .modal-body').html(data);
        $('#form-modal').modal('show');
        // to make popup draggable
        $('.modal-dialog').draggable({
            handle: ".modal-header"
        });
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