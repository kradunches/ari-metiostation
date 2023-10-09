//var twind = {
//    chart: {
//        type: 'line'
//    },
//    series: [{
//        name: 'температура',
//        data: [{
//            x: 'Сентябрь',
//            y: 54
//        }, {
//            x: 'Октябрь',
//            y: 66
//        }],
//    }],
//    xaxis: {
//        type: 'Даты'
//    }
//}

$(function () {
    //$("#ID").click(function () {
    $("input[type=radio][id=oneTW]").change(function () {
        $.ajax({
            type: "POST",
            url: "/Home/GetTwindData",
            data: "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessResult,
            error: OnError
        });
        function OnSuccessResult(data) {
            var _data = data;
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
            var chartTwind = new ApexCharts(document.querySelector(".form__chart--twind"), twind);
            chartTwind.render();
        }
        function OnError(err) {

        }
    });
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