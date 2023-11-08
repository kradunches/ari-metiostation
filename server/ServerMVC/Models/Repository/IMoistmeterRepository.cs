namespace ServerMVC.Models.Repository
{
    public interface IMoistmeterRepository
    {
        IQueryable<Moistmeter> Moistmeters { get; }
    }
}
