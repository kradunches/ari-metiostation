namespace ServerMVC.Models
{
    public class ChoiceRepository : IChoiceRepository
    {
        Choice IChoiceRepository.Choice => new Choice(1, 3);
    }
}
