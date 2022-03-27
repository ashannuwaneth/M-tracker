var dataTable;

$(document).ready(function () {
    loadExpensesTable();

})

function loadExpensesTable() {
    dataTable = $('#tblTypes').DataTable({
        responsive: true
    });
}