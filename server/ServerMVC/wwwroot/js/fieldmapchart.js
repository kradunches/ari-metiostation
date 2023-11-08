$(function () {
    window.Apex = {
        chart: {
            height: 260,
        },
        dataLables: {
            enabled: false
        }
    }
    var sensChart1;
    var sensChart2;
    var sensChart3;
    var sensChart4;
    var sensChart5;
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

            var optionsLine1 = {
                series: [{
                    name: "Ch1",
                    data: chartValsChan1
                }],
                colors: ['#00E396'],
                chart: {
                    id: 'sensor1',
                    group: 'sensors',
                    type: 'line',
                },
                xaxis: {
                    categories: chartLabels,
                    labels: {
                        show: false
                    }
                },
                yaxis: {
                    lables: {
                        minWidth: 40
                    }
                }
            };
            sensChart1 = new ApexCharts(document.querySelector(".field-map__chart-sensor1"), optionsLine1)
            sensChart1.render()

            var optionsLine2 = {
                series: [{
                    name: "Ch2",
                    data: chartValsChan2
                }],
                colors: ['#008FFB'],
                chart: {
                    id: 'sensor2',
                    group: 'sensors',
                    type: 'line',
                },
                xaxis: {
                    categories: chartLabels,
                    labels: {
                        show: false
                    }
                },
                yaxis: {
                    labels: {
                        minWidth: 40
                    }
                }
            };
            sensChart2 = new ApexCharts(document.querySelector(".field-map__chart-sensor2"), optionsLine2)
            sensChart2.render()

            var optionsLine3 = {
                series: [{
                    name: "Ch3",
                    data: chartValsChan3
                }],
                colors: ['#C71585'],
                chart: {
                    id: 'sensor3',
                    group: 'sensors',
                    type: 'line',
                },
                xaxis: {
                    categories: chartLabels,
                    labels: {
                        show: false
                    }
                },
                yaxis: {
                    labels: {
                        minWidth: 40
                    }
                }
            };
            sensChart3 = new ApexCharts(document.querySelector(".field-map__chart-sensor3"), optionsLine3)
            sensChart3.render()

            var optionsLine4 = {
                series: [{
                    name: "Ch4",
                    data: chartValsChan4
                }],
                colors: ['#000000'],
                chart: {
                    id: 'sensor4',
                    group: 'sensors',
                    type: 'line',
                },
                xaxis: {
                    categories: chartLabels,
                    labels: {
                        show: false
                    }
                },
                yaxis: {
                    labels: {
                        minWidth: 40
                    }
                }
            };
            sensChart4 = new ApexCharts(document.querySelector(".field-map__chart-sensor4"), optionsLine4)
            sensChart4.render()

            var optionsLine5 = {
                series: [{
                    name: "Ch5",
                    data: chartValsChan5
                }],
                colors: ['#FF0000'],
                chart: {
                    id: 'sensor5',
                    group: 'sensors',
                    type: 'line',
                },
                xaxis: {
                    categories: chartLabels
                },
                yaxis: {
                    labels: {
                        minWidth: 40
                    }
                }
            };
            sensChart5 = new ApexCharts(document.querySelector(".field-map__chart-sensor5"), optionsLine5)
            sensChart5.render()
        }
        function OnError(err) {

        }
    }
    
    updateChart = function () {
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
            sensChart1.updateOptions({
                xaxis: {
                    categories: chartLabels
                },
                colors: ['#FF0000'],
                series: [
                    {
                        data: temperatureChart[2]
                    }
                ]
            })
            
            console.log(temperatureChart[1]);
            console.log(temperatureChart[2]);
            console.log(temperatureChart[3]);
            console.log(temperatureChart[4]);
            console.log(temperatureChart[5]);
        }
        function OnError(err) {

        }
    }

    $(".main-header__calendar").on("change", function () {
        updateChart();
    });

    $(".field-map__sensor-button").on("click", function () {

    });

    $(document).ready(function () {
        renderChart();
    });
});