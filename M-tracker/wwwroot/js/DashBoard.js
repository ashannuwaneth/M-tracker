                                                                   
$(document).ready(function () {
    LoadGroupAmount();
    LoadAllExpensesCat();
    LoadExpenses();
    LoadIncome();
    


})

var Amount = [];
var Years = [];

var ExAmount = [];
var ExLabels = [];

var ExIncomeAmount = [];
var ExIncomeLabels = [];

var IncomeAmount = [];
var IncomeLabels = [];

function LoadGroupAmount() {                                   

    $.ajax({
        url: "/Customer/DashBoard/LoadGroupAmount",
        type: 'GET',
        success: function (data) {
            $(data).each(function (index, emp) {

                var list = emp.data;
                Amount = [];
                Years = [];
                for (var i = 0; i < list.length; i++) {

                    Amount.push(list[i].totalAmount);
                    Years.push(list[i].processDate);
                }
                initchart();
            });
        },
        error: function (error) {
        }
    });
}

function LoadAllExpensesCat() {

    $.ajax({
        url: "/Customer/DashBoard/LoadAllExpensesTypes",
        type: 'GET',
        success: function (data) {
            $(data).each(function (index, emp) {

                var list = emp.data;
                 ExAmount = [];
                 ExLabels = [];

                for (var i = 0; i < list.length; i++) {

                    ExAmount.push(list[i].amount);
                    ExLabels.push(list[i].type);
                }
                initExpenseschart();
            });
        },
        error: function (error) {
        }
    });
}

function LoadExpenses() {

    $.ajax({
        url: "/Customer/DashBoard/LoadExpensesIncome",
        type: 'GET',
        success: function (data) {
            $(data).each(function (index, emp) {
                var list = emp.data;

                 ExIncomeAmount = [];
                 ExIncomeLabels = [];


                for (var i = 0; i < list.length; i++) {

                    ExIncomeAmount.push(list[i].total);
                    ExIncomeLabels.push(list[i].date);
                }
  
            });
        },
        error: function (error) {
        }
    });

}

function LoadIncome() {

    $.ajax({
        url: "/Customer/DashBoard/LoadIncome",
        type: 'GET',
        success: function (data) {
            $(data).each(function (index, emp) {
                var list = emp.data;

                 IncomeAmount = [];
                 IncomeLabels = [];


                for (var i = 0; i < list.length; i++) {

                    IncomeAmount.push(list[i].total);
                    IncomeLabels.push(list[i].date);
                }

                initExIncomeChart();

            });
        },
        error: function (error) {
        }
    });

}

function initExIncomeChart() {


    var combineLabel = ExIncomeLabels.concat(IncomeLabels.filter((item) => ExIncomeLabels.indexOf(item) < 0))

    const labels = combineLabel
    const data = {
        labels: labels,
        datasets: [
            {
                label: 'Expenses',
                data: ExIncomeAmount,
                borderColor: "red",
                backgroundColor: "red",
                hoverBorderWidth: 5,
                hoverBorderColor: 'green',
            },
            {
                label: 'Income',
                data: IncomeAmount,
                borderColor: "blue",
                backgroundColor: "blue",
                hoverBorderWidth: 5,
                hoverBorderColor: 'green',
            }
        ]
    };

    let delayed;
    const config = {
        type: 'bar',
        data: data,
        options: {
            responsive: true,
            animation: {
                onComplete: () => {
                    delayed = true;
                },
                delay: (context) => {
                    let delay = 0;
                    if (context.type === 'data' && context.mode === 'default' && !delayed) {
                        delay = context.dataIndex * 1500 + context.datasetIndex * 800;
                    }
                    return delay;
                },
            },
            plugins: {
                legend: {
                    position: 'top',
                },
                title: {
                    display: true,
                    text: 'Income-Expenses '
                }
            }
        },
    };




    const myChart = new Chart(
        document.getElementById('myExIncomeChart'),
        config
    );

}

function initExpenseschart() {

    const labels = ExLabels;
    const data = {
        labels: labels,
        datasets: [
            {
                label: 'Expenses Categories',
                data: ExAmount,
                backgroundColor: ["red", "blue", "green", "blue", "red", "blue"],
            },
        ]
    };

    let delayed;
    const config = {
        type: 'doughnut',
        data: data,
        options: {
            responsive: true,
            animation: {
                onComplete: () => {
                    delayed = true;
                },
                delay: (context) => {
                    let delay = 0;
                    if (context.type === 'data' && context.mode === 'default' && !delayed) {
                        delay = context.dataIndex * 1500 + context.datasetIndex * 800;
                    }
                    return delay;
                },
            },
            plugins: {
                legend: {
                    position: 'top',
                },
                title: {
                    display: true,
                    text: 'Expenses Categories'
                }
            }
        },
    };

    const myChart = new Chart(
        document.getElementById('myExChart'),
        config
    );


}



function initchart() {

    const DATA_COUNT = 7;
    const NUMBER_CFG = { count: DATA_COUNT, min: -100, max: 100 };

    const labels = Years;
    const data = {
        labels: labels,
        datasets: [
            {
                label: 'Group Total',
                data: Amount,
                backgroundColor: 'rgba(255, 99, 132, 0.2)',
                borderColor: 'rgb(255, 99, 132)',
                borderWidth: 1,
            },
        ]
    };

    let delayed;
    const config = {
        type: 'bar',
        data: data,
        options: {
            animation: {
                onComplete: () => {
                    delayed = true;
                },
                delay: (context) => {
                    let delay = 0;
                    if (context.type === 'data' && context.mode === 'default' && !delayed) {
                        delay = context.dataIndex * 1500 + context.datasetIndex * 800;
                    }
                    return delay;
                },
            },
            scales: {
                x: {
                    stacked: true,
                },
                y: {
                    stacked: true
                }
            }
        }
    };

    const myChart = new Chart(
        document.getElementById('myChart'),
        config
    );

}