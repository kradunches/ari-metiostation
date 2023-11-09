$(function () {
    var sensChart;
    var calendarButton = document.querySelector(".main-header__calendar");
    renderChart = function () {
        $.ajax({
            type: "GET",
            url: "/FieldMap/GetData",
            data: {
                date: calendarButton.value
            },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessResult,
            error: OnError
        });
        function OnSuccessResult(temperatureChart) {
            var chartLabels = temperatureChart[0];
            var chartValsChan1 = temperatureChart[1];
            var chartValsChan2 = temperatureChart[2];
            var chartValsChan3 = temperatureChart[3];
            var chartValsChan4 = temperatureChart[4];
            var chartValsChan5 = temperatureChart[5];

            var options = {
                series: [
                    {
                        name: 'Chan1',
                        data: chartValsChan1
                    },
                    {
                        name: 'Chan2',
                        data: chartValsChan2
                    },
                    {
                        name: 'Chan3',
                        data: chartValsChan3
                    },
                    {
                        name: 'Chan4',
                        data: chartValsChan4
                    },
                    {
                        name: 'Chan5',
                        data: chartValsChan5
                    }
                ],
                chart: {
                    type: 'area',
                    height: 350,
                    stacked: true,
                    events: {
                        selection: function (chart, e) {
                            console.log(new Date(e.xaxis.min))
                        }
                    },
                },
                colors: ['#008FFB', '#00E396', '#CED4DC', 'yellow', 'gray'],
                dataLabels: {
                    enabled: false
                },
                stroke: {
                    curve: 'smooth'
                },
                fill: {
                    type: 'gradient',
                    gradient: {
                        opacityFrom: 0.6,
                        opacityTo: 0.8,
                    }
                },
                legend: {
                    position: 'top',
                    horizontalAlign: 'left'
                },
                xaxis: {
                    categories: chartLabels
                },
            };

            sensChart = new ApexCharts(document.querySelector(".field-map__chart"), options);
            sensChart.render();
        }
        function OnError(err) {

        }
    }
    
    updateChart = function (sensorName) {
        $.ajax({
            type: "GET",
            url: "/FieldMap/GetData",
            data: {
                date: calendarButton.value,
                sensorName: sensorName
            },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessResult,
            error: OnError
        });
        function OnSuccessResult(temperatureChart) {
            sensChart.updateOptions({
                xaxis: {
                    categories: temperatureChart[0]
                },
                series: [
                    {
                        name: 'Chan1',
                        data: temperatureChart[1]
                    },
                    {
                        name: 'Chan2',
                        data: temperatureChart[2]
                    },
                    {
                        name: 'Chan3',
                        data: temperatureChart[3]
                    },
                    {
                        name: 'Chan4',
                        data: temperatureChart[4]
                    },
                    {
                        name: 'Chan5',
                        data: temperatureChart[5]
                    }
                ]
            })
        }
        function OnError(err) {

        }
    }

    $(".main-header__calendar").on("change", function () {
        updateChart();
    });

    $(".field-map__sensor-button").on("click", function () {
        updateChart(this.value);
        updateChart(this.value);
    });

    $(document).ready(function () {
        renderChart();
    });
});