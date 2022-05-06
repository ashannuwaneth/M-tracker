                                                                   
$(document).ready(function () {
    LoadGroupAmount();


})

var Amount = [];
var Years = [];

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
                backgroundColor: 'rgb(255, 99, 132)',
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