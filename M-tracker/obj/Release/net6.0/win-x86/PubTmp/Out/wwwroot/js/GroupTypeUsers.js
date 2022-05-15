
var dataTable;

$(document).ready(function (){

    SearchUser();
    LoadGroupUsers();
});

function SearchUser() {
    $("#txtSearch").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Customer/GroupUser/search',
                data: { "prefix": request.term },
                dataType: "json",
                type: "POST",
                success: function (data) {
                 
                    response($.map(data, function (item) {
                        return {
                            label: item.label,
                            val: item.value

                        }
                    }))
                },
                error: function (response) {
                    alert(response.responseText);
                },
                failure: function (response) {
                    alert(response.responseText);
                }
            });
        },
        select: function (e, i) {
            
            $("#txtSearchid").val(i.item.val);
        },
        minLength: 1
    });
}

function LoadGroupUsers() {
    dataTable = $('#tblGroupUser').DataTable({
        responsive: true,
                "ajax": {
                    "url": "/Customer/GroupUser/UserList"
        },
        "columns": [
            { "data": "groupName", "width": "30%" },
            { "data": "typeName", "width": "20%" },
            { "data": "isActive", "width": "10%" },
            { "data": "isAdmin", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                         <div class="w-75 btn-group" role="group">
                        <a href="/Customer/GroupUser/Index?id=${data}"
                        class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Edit</a>
                           <a onClick=Delete('/Customer/GroupUser/Delete/${data}')
                        class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
					</div>
                        `
                },
                "width": "30%"
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