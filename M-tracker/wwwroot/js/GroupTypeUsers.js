
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
            { "data": "isActive", "width": "20%" },
            { "data": "isAdmin", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                        <a onclick="EditGroup('${data}')"
                        class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i>Edit</a>
                           <a onClick=Delete('/Customer/GroupType/Delete/${data}')
                        class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
					</div>
                        `
                },
                "width": "30%"
            }
        ],

    });

}



