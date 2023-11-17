using RabbitRegister.Model;

namespace RabbitRegister.Services.RabbitService
{
    public interface IRabbitService
    {
        Rabbit GetRabbit(int originRegNo, int rabbitRegNo);
        //Rabbit GetRabbit(int id);
        List<Rabbit> GetAllRabbits();
        Task AddRabbitAsync(RabbitDTO dto, Breeder breeder);
        //Task AddRabbitAsync(Rabbit rabbit, Breeder breeder);
        //Task UpdateRabbitAsync(Rabbit rabbit, int id);
        Task UpdateRabbitAsync(RabbitDTO rabbitDTO, int originRegNo, int rabbitRegNo);
        Task<Rabbit> DeleteRabbitAsync(int? originRegNo, int? rabbitRegNo);
        IEnumerable<Rabbit> SearchByName(string str, int breederRegNo);
        IEnumerable<Rabbit> RatingFilter(int breederRegNo, int? maxRating = null, int? minRating = null);
        IEnumerable<Rabbit> SearchByRegNo(int? originRegNo, int? rabbitRegNo, int breederRegNo);
        IEnumerable<Rabbit> SortById();
        IEnumerable<Rabbit> SortByIdDescending();
        IEnumerable<Rabbit> SortByName();
        IEnumerable<Rabbit> SortByNameDescending();
        IEnumerable<Rabbit> SortByRating();
        IEnumerable<Rabbit> SortByRatingDescending();
        List<Rabbit> GetOwnedAliveRabbits(int breederRegNo);
        List<Rabbit> GetOwnedDeadRabbits(int breederRegNo);
        List<Rabbit> GetAllRabbitsWithConnectionsToMe(int breederRegNo);
        List<Rabbit> GetAllRabbitsWithOwner(int Owner);
        List<Rabbit> GetNotOwnedRabbitsWithMyBreederRegNo(int breederRegNo);
        List<Rabbit> GetIsForSaleRabbits();
    }
}
