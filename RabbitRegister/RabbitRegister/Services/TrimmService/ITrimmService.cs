using RabbitRegister.Model;

namespace RabbitRegister.Services.TrimmService
{
    public interface ITrimmService
    {
        List<Trimm> GetAllTrimmsByRabbit(int rabbitRegNo, int originRegNo);
        Trimm GetTrimm(int trimmId, int rabbitRegNo, int originRegNo);
        Task AddTrimmAsync(TrimmDTO dto, Rabbit rabbit);
        Task UpdateTrimmAsync(TrimmDTO trimmDTO, int trimmId, int rabbitRegNo, int originRegNo);
        Task DeleteTrimmAsync(int trimmId, int rabbitRegNo, int originRegNo);
    }
}
