var chartTwind;
var chartPwind;
var chartTpov;
var charWindSpeed;

//TWwind chart
renderTW = function () {
    $.ajax({
        type: "POST",
        url: "/Home/GetTwindData1",
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessResult,
        error: OnError
    });
    function OnSuccessResult(temperatureChart) {
        var chartLables = temperatureChart[0];
        var chartData = temperatureChart[1];
        var twind = {
            chart: {
                height: 280,
                type: "area"
            },
            dataLabels: {
                enabled: false
            },
            series: [
                {
                    name: "t воздуха",
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
                categories: chartLables
            }
        };
        
        chartTwind = new ApexCharts(document.querySelector(".form__chart--twind"), twind);
        chartTwind.render();
    }
    function OnError(err) {

    }
}

updateTW = function () {
    var a = "/Home/GetTwindData1";
    var tRadio = document.querySelector('input[name=TW]:checked');
    if (tRadio.value == 1) {
        a = "/Home/GetTwindData1";
    }
    else if (tRadio.value == 3) {
        a = "/Home/GetTwindData3";
    }
    $.ajax({
        type: "POST",
        url: a,
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessResult,
        error: OnError
    });
    function OnSuccessResult(temperatureChart) {
        var chartLables = temperatureChart[0];
        var chartData = temperatureChart[1];
        chartTwind.updateOptions({
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

//PWind chart
renderPW = function () {
    $.ajax({
        type: "POST",
        url: "/Home/GetRhData1",
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessResult,
        error: OnError
    });
    function OnSuccessResult(temperatureChart) {
        var chartLables = temperatureChart[0];
        var chartData = temperatureChart[1];
        var pwind = {
            chart: {
                height: 280,
                type: "area"
            },
            dataLabels: {
                enabled: false
            },
            series: [
                {
                    name: "p воздуха",
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
                categories: chartLables
            }
        };

        chartPwind = new ApexCharts(document.querySelector(".form__chart--pwind"), pwind);
        chartPwind.render();
    }
    function OnError(err) {

    }
}

updatePW = function () {
    var a = "/Home/GetRhData1";
    var tRadio = document.querySelector('input[name=PW]:checked');
    if (tRadio.value == 1) {
        a = "/Home/GetRhData1";
    }
    else if (tRadio.value == 3) {
        a = "/Home/GetRhData3";
    }
    $.ajax({
        type: "POST",
        url: a,
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessResult,
        error: OnError
    });
    function OnSuccessResult(temperatureChart) {
        var chartLables = temperatureChart[0];
        var chartData = temperatureChart[1];
        chartPwind.updateOptions({
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

//TPov chart
renderTpov = function () {
    $.ajax({
        type: "POST",
        url: "/Home/GetTpovData1",
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessResult,
        error: OnError
    });
    function OnSuccessResult(temperatureChart) {
        var chartLables = temperatureChart[0];
        var chartData = temperatureChart[1];
        var tpov = {
            chart: {
                height: 280,
                type: "area"
            },
            dataLabels: {
                enabled: false
            },
            series: [
                {
                    name: "t поверхности почвы",
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
                categories: chartLables
            }
        };

        chartTpov = new ApexCharts(document.querySelector(".form__chart--tpov"), tpov);
        chartTpov.render();
    }
    function OnError(err) {

    }
}
updateTpov = function () {
    var a = "/Home/GetTpovData1";
    var tRadio = document.querySelector('input[name=TS]:checked');
    if (tRadio.value == 1) {
        a = "/Home/GetTpovData1";
    }
    else if (tRadio.value == 3) {
        a = "/Home/GetTpovData3";
    }
    $.ajax({
        type: "POST",
        url: a,
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessResult,
        error: OnError
    });
    function OnSuccessResult(temperatureChart) {
        var chartLables = temperatureChart[0];
        var chartData = temperatureChart[1];
        chartTpov.updateOptions({
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

//WindSpeed chart
renderPC = function () {
    $.ajax({
        type: "POST",
        url: "/Home/GetWindData1",
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessResult,
        error: OnError
    });
    function OnSuccessResult(temperatureChart) {
        var chartLables = temperatureChart[0];
        var chartData = temperatureChart[1];
        var pc = {
            chart: {
                height: 280,
                type: "area"
            },
            dataLabels: {
                enabled: false
            },
            series: [
                {
                    name: "скорость ветра",
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
                categories: chartLables
            }
        };

        charWindSpeed = new ApexCharts(document.querySelector(".form__chart--precipitation"), pc);
        charWindSpeed.render();
    }
    function OnError(err) {

    }
}

updatePC = function () {
    var a = "/Home/GetWindData1";
    var tRadio = document.querySelector('input[name=PC]:checked');
    if (tRadio.value == 1) {
        a = "/Home/GetWindData1";
    }
    else if (tRadio.value == 3) {
        a = "/Home/GetWindData3";
    }
    $.ajax({
        type: "POST",
        url: a,
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessResult,
        error: OnError
    });
    function OnSuccessResult(temperatureChart) {
        var chartLables = temperatureChart[0];
        var chartData = temperatureChart[1];
        charWindSpeed.updateOptions({
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

$(function () {
    $("input[type=radio][name=TW]").change(() => updateTW());
    $("input[type=radio][name=PW]").change(() => updatePW());
    $("input[type=radio][name=TS]").change(() => updateTpov());
    $("input[type=radio][name=PC]").change(() => updatePC());
});

var calendarButton = document.getElementById("calendar-submit");

$(document).ready(function () {
    renderTW();
    renderPW();
    renderTpov();
    renderPC();
})

calendarButton.addEventListener("click", function () {
    var calendarValue = document.querySelector(".main-header__calendar").value;
    var url = "/Home/GetCalendarDate";
    var name = calendarValue;
    $.get(url, { input: name });
    window.location.reload();
});