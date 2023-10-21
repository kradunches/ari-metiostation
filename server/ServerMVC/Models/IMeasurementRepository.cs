using System.Linq;
namespace ServerMVC.Models
{
    public interface IMeasurementRepository
    {
        IQueryable<Measurement> Measurements { get; }
    }
}
