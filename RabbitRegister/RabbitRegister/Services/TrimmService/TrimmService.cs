using Microsoft.EntityFrameworkCore;
using RabbitRegister.Model;
using RabbitRegister.Services.RabbitService;

namespace RabbitRegister.Services.TrimmService
{
    public class TrimmService : ITrimmService
    {
        private readonly DbGenericService<Trimm> _dbGenericService;
        public static List<Trimm> _trimmsList;
        //private IRabbitService _rabbitService;


        public TrimmService(DbGenericService<Trimm> dbGenericService)
        {
            _dbGenericService = dbGenericService;
            _trimmsList = _dbGenericService.GetObjectsAsync().Result.ToList();
        }

        //public TrimmService() { }

        public List<Trimm> GetAllTrimmsByRabbit(int originRegNo, int rabbitRegNo)
        {
            return _trimmsList.Where(trimming => trimming.RabbitRegNo == rabbitRegNo && trimming.OriginRegNo == originRegNo).ToList();
        }

        public Trimm GetTrimm(int id, int originRegNo, int rabbitRegNo)
        {
            return _trimmsList.Find(t => t.Id == id && t.OriginRegNo == originRegNo && t.RabbitRegNo == rabbitRegNo);
        }

        public async Task AddTrimmAsync(TrimmDTO trimmDTO, Rabbit rabbit)
        {
            Trimm newTrimm = new Trimm();

            newTrimm.RabbitRegNo = trimmDTO.RabbitRegNo;
            newTrimm.OriginRegNo = trimmDTO.OriginRegNo;
            newTrimm.Date = trimmDTO.Date;
            newTrimm.TimeUsed = trimmDTO.TimeUsed;
            newTrimm.HairLengthByDayNinety = trimmDTO.HairLengthByDayNinety;
            newTrimm.WoolDensity = trimmDTO.WoolDensity;
            newTrimm.FirstSortmentWeight = trimmDTO.FirstSortmentWeight;
            newTrimm.SecondSortmentWeight = trimmDTO.SecondSortmentWeight;
            newTrimm.DisposableWoolWeight = trimmDTO.DisposableWoolWeight;

            _trimmsList.Add(newTrimm);
            await _dbGenericService.AddObjectAsync(newTrimm);            
        }

        

        public async Task UpdateTrimmAsync(TrimmDTO trimmDTO, int id, int originRegNo, int rabbitRegNo)
        {
            if (trimmDTO != null)
            {
                Trimm existingTrimm = _trimmsList.Find(t => t.Id == id && t.OriginRegNo == originRegNo && t.RabbitRegNo == rabbitRegNo);
                if (existingTrimm != null)
                {
                    existingTrimm.Date = trimmDTO.Date;
                    existingTrimm.TimeUsed = trimmDTO.TimeUsed;
                    existingTrimm.HairLengthByDayNinety = trimmDTO.HairLengthByDayNinety;
                    existingTrimm.WoolDensity = trimmDTO.WoolDensity;
                    existingTrimm.FirstSortmentWeight = trimmDTO.FirstSortmentWeight;
                    existingTrimm.SecondSortmentWeight = trimmDTO.SecondSortmentWeight;
                    existingTrimm.DisposableWoolWeight = trimmDTO.DisposableWoolWeight;

                    await _dbGenericService.UpdateObjectAsync(existingTrimm);
                }
            }
        }

        public async Task DeleteTrimmAsync(int id, int originRegNo, int rabbitRegNo)
        {
            Trimm trimToBeDeleted = GetTrimm(id, originRegNo, rabbitRegNo);
            if (trimToBeDeleted != null)
            {
                _trimmsList.Remove(trimToBeDeleted);
                await _dbGenericService.DeleteObjectAsync(trimToBeDeleted);
            }
        }

        //---: NEXT ID IDÉ FOR TRIMM TABLE :---

        //public async Task<int> GetNextIdForRabbitAndOriginAsync(int rabbitRegNo, int originRegNo)
        //{
        //    var existingTrimm = await ItemdbContext.Trimms
        //        .FirstOrDefaultAsync(t => t.RabbitRegNo == rabbitRegNo && t.OriginRegNo == originRegNo);

        //    if (existingTrimm == null)
        //    {
        //        // If no existing Trimm for the given combination, assign a new Id
        //        return await GetNextIdAsync();
        //    }
        //    else
        //    {
        //        // If a Trimm exists for the given combination, return its Id
        //        return existingTrimm.Id;
        //    }
        //}

        //private async Task<int> GetNextIdAsync()
        //{
        //    // Logic to retrieve the next available Id
        //    // You might use your own logic here to determine the next available Id
        //    // Perhaps by querying the existing maximum Id and incrementing it
        //    // Or by keeping track of assigned Ids for each combination elsewhere
        //    // This could vary based on your database schema and business logic
        //    // For demonstration, here's a basic example:

        //    var maxId = await _dbContext.Trimms.MaxAsync(t => (int?)t.Id);
        //    return maxId.HasValue ? maxId.Value + 1 : 1;
        //}

    }
}
