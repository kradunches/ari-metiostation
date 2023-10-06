var twind = {
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

var chartTwind = new ApexCharts(document.querySelector(".form__chart--twind"), twind);
var chartPwind = new ApexCharts(document.querySelector(".form__chart--pwind"), pwind);
var chartTsoil = new ApexCharts(document.querySelector(".form__chart--tsoil"), tsoil);
var chartPrecipitaion = new ApexCharts(document.querySelector(".form__chart--precipitation"), precipitation);

chartTwind.render();
chartPwind.render();
chartTsoil.render();
chartPrecipitaion.render();