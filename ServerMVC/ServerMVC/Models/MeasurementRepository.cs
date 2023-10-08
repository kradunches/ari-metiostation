using System.Collections.Generic;
using System.Linq;

namespace ServerMVC.Models
{
    public class MeasurementRepository : IMeasurementRepository
    {
        private ApplicationDbContext _context;
        public MeasurementRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Measurement> Measurements => _context.Measurement;
    }
}