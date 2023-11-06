using System.Linq;

namespace ServerMVC.Models.Repository
{
    public interface IMeasurementRepository
    {
        IQueryable<Measurement> Measurements { get; }
    }
}
