using System.Linq;

namespace ServerMVC.Models.Repository
{
    public interface IMeasurementRepository
    {
        IQueryable<meteo1> Measurements { get; }
    }
}
