namespace ServerMVC.Models.Repository
{
    public class MoistmeterRepository : IMoistmeterRepository
    {
        private ApplicationDbContext _context;
        public MoistmeterRepository (ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<agro_moist> Moistmeters => _context.agro_moist;
    }
}
