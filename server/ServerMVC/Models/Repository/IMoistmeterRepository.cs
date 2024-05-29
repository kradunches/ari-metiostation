namespace ServerMVC.Models.Repository
{
    public interface IMoistmeterRepository
    {
        IQueryable<agro_moist> Moistmeters { get; }
    }
}
