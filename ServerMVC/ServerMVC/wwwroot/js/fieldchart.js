var chartTwind;
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
        var _data = temperatureChart;
        var _chartLables = _data[0];
        var _chartData = _data[1];
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
                    data: _chartData
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
                categories: _chartLables
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
        var _data = temperatureChart;
        var _chartLables = _data[0];
        var _chartData = _data[1];
        chartTwind.updateOptions({
            xaxis: {
                categories: _chartLables
            },
            series: [
                {
                    data: _chartData
                }
            ]
        })
    }
    function OnError(err) {

    }
}

$(document).ready(function () {
    renderTW();
})

$(function () {
    $("input[type=radio][name=TW]").change(() => updateTW());
});


//var chartTwind = new ApexCharts(document.querySelector(".form__chart--twind"), twind);
//chartTwind.render();

var pwind = {
    chart: {
        type: 'line'
    },
    series: [{
        name: 'влажность',
      data: [{
            x: 'Сентябрь',
            y: 54
        }, {
            x: 'Октябрь',
            y: 66
        }],
    }],
    xaxis: {
        type: 'Даты'
    }
}

var tsoil = {
    chart: {
        type: 'line'
    },
    series: [{
        name: 'температура',
        data: [{
            x: 'Сентябрь',
            y: 54
        }, {
            x: 'Октябрь',
            y: 66
        }],
    }],
    xaxis: {
        type: 'Даты'
    }
}

var precipitation = {
    chart: {
        type: 'line'
    },
    series: [{
        name: 'осадки',
        data: [{
            x: 'Сентябрь',
            y: 54
        }, {
            x: 'Октябрь',
            y: 66
        }],
    }],
    xaxis: {
        type: 'Даты'
    }
}

var chartPwind = new ApexCharts(document.querySelector(".form__chart--pwind"), pwind);
var chartTsoil = new ApexCharts(document.querySelector(".form__chart--tsoil"), tsoil);
var chartPrecipitaion = new ApexCharts(document.querySelector(".form__chart--precipitation"), precipitation);

chartPwind.render();
chartTsoil.render();
chartPrecipitaion.render();