﻿$(function () {
    var chartTwind;
    var chartPwind;
    var chartTpov;
    var charWindSpeed;
    var calendarButton = document.querySelector(".main-header__calendar");
    renderChart = function (type) {
        var actionStr = "";
        var seriesName = "";
        var chartClass;
        switch (type) {
            case "Twind":
                actionStr = "Twind";
                seriesName = "t воздуха";
                chartClass = document.querySelector(".form__chart--twind");
                break;
            case "Pwind":
                actionStr = "Rh";
                seriesName = "p воздуха";
                chartClass = document.querySelector(".form__chart--pwind");
                break;
            case "Tpov":
                actionStr = "Tpov";
                seriesName = "t поверхности почвы";
                chartClass = document.querySelector(".form__chart--tpov");
                break;
            case "WindSpeed":
                actionStr = "Wind";
                seriesName = "скорость ветра";
                chartClass = document.querySelector(".form__chart--precipitation");
                break;
        }
        $.ajax({
            type: "GET",
            url: "/Home/Get" + actionStr + "Data1",
            data: {
                date: calendarButton.value
            },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessResult,
            error: OnError
        });
        function OnSuccessResult(temperatureChart) {
            var chartLables = temperatureChart[0];
            var chartData = temperatureChart[1];
            var chartMatter = {
                chart: {
                    height: 280,
                    type: "area"
                },
                dataLabels: {
                    enabled: false
                },
                series: [
                    {
                        name: seriesName,
                        data: chartData
                    }
                ],
                fill: {
                    type: "gradient",
                    gradient: {
                        shadeIntensity: 1,
                        opacityFrom: 0.7,
                        opacityTo: 0.9,
                        stops: [0, 90, 100]
                    }
                },
                xaxis: {
                    categories: chartLables,
                    labels: {
                        rotate: -90
                    }
                }
            };

            switch (type) {
                case "Twind":
                    chartTwind = new ApexCharts(chartClass, chartMatter);
                    chartTwind.render();
                    break;
                case "Pwind":
                    chartPwind = new ApexCharts(chartClass, chartMatter);
                    chartPwind.render();
                    break;
                case "Tpov":
                    chartTpov = new ApexCharts(chartClass, chartMatter);
                    chartTpov.render();
                    break;
                case "WindSpeed":
                    charWindSpeed = new ApexCharts(chartClass, chartMatter);
                    charWindSpeed.render();
                    break;
            }
        }
        function OnError(err) {

        }
    }

    updateChart = function (type) {
        var chart;
        var actionStr = "";
        var chartName = "";
        switch (type) {
            case "Twind":
                actionStr = "Twind";
                chartName = "TW";
                chart = chartTwind;
                break;
            case "Pwind":
                actionStr = "Rh";
                chartName = "PW";
                chart = chartPwind;
                break;
            case "Tpov":
                actionStr = "Tpov";
                chartName = "TS";
                chart = chartTpov;
                break;
            case "WindSpeed":
                actionStr = "Wind";
                chartName = "PC";
                chart = charWindSpeed;
                break;
        }
        var a = "/Home/Get" + actionStr + "Data1";
        var tRadio = document.querySelector("input[name=" + chartName + "]:checked");
        if (tRadio.value == 1) {
            a = "/Home/Get" + actionStr + "Data1";
        }
        else if (tRadio.value == 3) {
            a = "/Home/Get" + actionStr + "Data3";
        }
        $.ajax({
            type: "GET",
            url: a,
            data: {
                date: calendarButton.value
            },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessResult,
            error: OnError
        });
        function OnSuccessResult(temperatureChart) {
            var chartLables = temperatureChart[0];
            var chartData = temperatureChart[1];
            chart.updateOptions({
                xaxis: {
                    categories: chartLables
                },
                series: [
                    {
                        data: chartData
                    }
                ]
            })
        }
        function OnError(err) {

        }
    }


    $("input[type=radio][name=TW]").change(() => updateChart("Twind"));
    $("input[type=radio][name=PW]").change(() => updateChart("Pwind"));
    $("input[type=radio][name=TS]").change(() => updateChart("Tpov"));
    $("input[type=radio][name=PC]").change(() => updateChart("WindSpeed"));

    $(".main-header__calendar").on("change", function () {
        updateChart("Twind");
        updateChart("Pwind");
        updateChart("Tpov");
        updateChart("WindSpeed");
    });

    $(document).ready(function () {
        renderChart("Twind");
        renderChart("Pwind");
        renderChart("Tpov");
        renderChart("WindSpeed");
    })
});

//var calendarButton = document.querySelector(".main-header__calendar");
//$(".main-header__calendar").on("change", function () {
//    var calendarValue = this.value;
//    var url = "/Home/GetCalendarDate";
//    $.get(url, { date: calendarValue });
//});


//calendarButton.addEventListener("change", function () {
//    var calendarValue = document.querySelector(".main-header__calendar").value;
//    var url = "/Home/GetCalendarDate";
//    $.get(url, { date: calendarValue });
//    console.log(calendarValue);
//    window.location.reload();
//});