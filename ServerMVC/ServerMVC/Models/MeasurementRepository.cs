using System.Collections.Generic;
using System.Linq;

namespace ServerMVC.Models
{
    public class MeasurementRepository : IMeasurementRepository
    {
        public IQueryable<Measurement> Measurements => new List<Measurement> {
            new Measurement {measure_date = new DateTime(2023, 09, 01, 10, 00, 00), t_pow = 1, far = 1, rh = 1, t = 1, winddir = 1, wind = 1 },
            new Measurement {measure_date = new DateTime(2023, 09, 02, 11, 30, 30), t_pow = 2, far = 2, rh = 2, t = 2, winddir = 2, wind = 2 },
            new Measurement {measure_date = new DateTime(2023, 09, 03, 23, 59, 59), t_pow = 3, far = 3, rh = 3, t = 3, winddir = 3, wind = 3 }
        }.AsQueryable<Measurement>();
    }
}