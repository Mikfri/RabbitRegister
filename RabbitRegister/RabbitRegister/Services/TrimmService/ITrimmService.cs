using RabbitRegister.Model;

namespace RabbitRegister.Services.TrimmService
{
    public interface ITrimmService
    {
        List<Trimm> GetAllTrimmsByRabbit(int originRegNo, int rabbitRegNo);
        Trimm GetTrimm(int id, int originRegNo, int rabbitRegNo);
        Task AddTrimmAsync(TrimmDTO trimmDTO, Rabbit rabbit);
        Task UpdateTrimmAsync(TrimmDTO trimmDTO, int id, int originRegNo, int rabbitRegNo);
        Task DeleteTrimmAsync(int id, int originRegNo, int rabbitRegNo);
    }
}
