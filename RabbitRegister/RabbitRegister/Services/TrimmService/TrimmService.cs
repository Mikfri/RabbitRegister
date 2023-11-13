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
        }

        public TrimmService() { }

        public List<Trimm> GetAllTrimmsByRabbit(int rabbitRegNo, int originRegNo)
        {
            return _trimmsList.Where(trimming => trimming.RabbitRegNo == rabbitRegNo && trimming.OriginRegNo == originRegNo).ToList();
        }

        public Trimm GetTrimm(int trimmId, int rabbitRegNo, int originRegNo)
        {
            return _trimmsList.Find(t => t.Id == trimmId && t.RabbitRegNo == rabbitRegNo && t.OriginRegNo == originRegNo);
        }

        public async Task AddTrimmAsync(TrimmDTO dto, Rabbit rabbit)
        {
            Trimm newTrimm = new Trimm();

            newTrimm.RabbitRegNo = dto.RabbitRegNo;
            newTrimm.OriginRegNo = dto.OriginRegNo;
            newTrimm.Date = dto.Date;
            newTrimm.TimeUsed = dto.TimeUsed;
            newTrimm.HairLengthByDayNinety = dto.HairLengthByDayNinety;
            newTrimm.WoolDensity = dto.WoolDensity;
            newTrimm.FirstSortmentWeight = dto.FirstSortmentWeight;
            newTrimm.SecondSortmentWeight = dto.SecondSortmentWeight;
            newTrimm.DisposableWoolWeight = dto.DisposableWoolWeight;

            _trimmsList.Add(newTrimm);
            await _dbGenericService.AddObjectAsync(newTrimm);

            if (rabbit.Trimms == null)
            {
                rabbit.Trimms = new List<Trimm>();
            }

            rabbit.Trimms.Add(newTrimm);
        }

        public async Task UpdateTrimmAsync(TrimmDTO trimmDTO, int trimmId, int rabbitRegNo, int originRegNo)
        {
            if (trimmDTO != null)
            {
                Trimm existingTrimm = _trimmsList.Find(t => t.Id == trimmId && t.RabbitRegNo == rabbitRegNo && t.OriginRegNo == originRegNo);
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

        public async Task DeleteTrimmAsync(int trimmId, int rabbitRegNo, int originRegNo)
        {
            Trimm trimToBeDeleted = GetTrimm(trimmId, rabbitRegNo, originRegNo);
            var trimm = await _dbGenericService.GetObjectByIdAsync(trimmId);
            if (trimm != null)
            {
                await _dbGenericService.DeleteObjectAsync(trimm);
            }
        }
    }
}
