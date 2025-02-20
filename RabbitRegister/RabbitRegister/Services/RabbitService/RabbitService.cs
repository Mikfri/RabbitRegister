using Microsoft.EntityFrameworkCore;
﻿using RabbitRegister.MockData;
using RabbitRegister.Model;
using RabbitRegister.Services.BreederService;
using RabbitRegister.Utilities;

namespace RabbitRegister.Services.RabbitService
{
    public class RabbitService : IRabbitService
    {
        public static List<Rabbit> _rabbits;

        private DbGenericService<Rabbit> _dbGenericService;
        private IBreederService _breederService;

      
        public RabbitService(DbGenericService<Rabbit> dbGenericService, IBreederService breederService)
        {
            _breederService = breederService;
            _dbGenericService = dbGenericService;
            _rabbits = _dbGenericService.GetObjectsAsync().Result.ToList();

            //_rabbits = MockRabbit.GetMockRabbits(); //DB tom? Ved første Debug kør denne kode, og udkommenter igen derefter
            //foreach (var rabbit in _rabbits)
            //{
            //    _dbGenericService.AddObjectAsync(rabbit).Wait();
            //}
        }
        public RabbitService() {  }

        /// <summary>
        /// Konvertere brugerens input til at passe med: class Rabbit 
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="breeder"></param>
        /// <returns></returns>
        public async Task AddRabbitAsync(RabbitDTO dto, Breeder breeder)
        {
            Rabbit newRabbit = new Rabbit();

            newRabbit.RabbitRegNo = dto.RabbitRegNo;
            newRabbit.OriginRegNo = dto.OriginRegNo;
            newRabbit.Owner = dto.Owner;
            newRabbit.Name = dto.Name;
            newRabbit.Race = dto.Race;
            newRabbit.Color = dto.Color;
            newRabbit.DateOfBirth = dto.DateOfBirth;
            newRabbit.DeadOrAlive = dto.DeadOrAlive;
            newRabbit.Sex = dto.Sex;
            newRabbit.IsForSale = dto.IsForSale;
            //newRabbit.ImageString = dto.ImageString;
            newRabbit.ImagePath = dto.ImagePath;
            
            _rabbits.Add(newRabbit);
            await _dbGenericService.AddObjectAsync(newRabbit);                    
        }

    
        public Rabbit GetRabbit(int originRegNo,int rabbitRegNo)
        {
            return _rabbits.Find(r => r.RabbitRegNo == rabbitRegNo && r.OriginRegNo == originRegNo);
        }

        public List<Rabbit> GetAllRabbits()
        {
            return _rabbits.ToList();
            //return _dbGenericService.GetObjectsAsync().Result.ToList();
        }      

        public async Task UpdateRabbitAsync(RabbitDTO rabbitDTO, int originRegNo, int rabbitRegNo)
        {
            if (rabbitDTO != null)
            {
                Rabbit existingRabbit = _rabbits.FirstOrDefault(r => r.RabbitRegNo == rabbitRegNo && r.OriginRegNo == originRegNo);
                if (existingRabbit != null)
                {                   
                    // Kopier data fra RabbitDTO til det eksisterende Rabbit-objekt
                    existingRabbit.Name = rabbitDTO.Name;
                    existingRabbit.Race = rabbitDTO.Race;
                    existingRabbit.Color = rabbitDTO.Color;
                    existingRabbit.Sex = rabbitDTO.Sex;
                    existingRabbit.DateOfBirth = rabbitDTO.DateOfBirth;
                    existingRabbit.Weight = rabbitDTO.Weight;
                    existingRabbit.Rating = rabbitDTO.Rating;
                    existingRabbit.DeadOrAlive = rabbitDTO.DeadOrAlive;
                    existingRabbit.IsForSale = rabbitDTO.IsForSale;
                    existingRabbit.SuitableForBreeding = rabbitDTO.SuitableForBreeding;
                    existingRabbit.CauseOfDeath = rabbitDTO.CauseOfDeath;
                    existingRabbit.Comments = rabbitDTO.Comments;
                    existingRabbit.ImagePath = rabbitDTO.ImagePath;

                    await _dbGenericService.UpdateObjectAsync(existingRabbit);
                }
            }
        }

        public async Task ChangeOwnership(Rabbit rabbit, int oldOwner, int newOwner)
        {

        }

        /// <summary>
        /// Sletter en kanin baseret på dens angivne composite-key.
        /// 
        /// Første kodeblok finder, og definere den specifikke kanin som skal slettes via dets Key.
        /// Anden kodeblok fjerner kaninen fra listen _rabbits, og afventer asynkront på objektet
        /// kan slettes fra DB
        /// </summary>
        /// <param name="rabbitRegNo">Første nøgle-del for kaninens composite key(RabbitRegNo)</param>
        /// <param name="originRegNo">Anden nøgle-del for kaninens composite key</param>
        /// <returns>Task, der repræsenterer sletningsoperationen</returns>
        public async Task<Rabbit> DeleteRabbitAsync(int? originRegNo, int? rabbitRegNo)
        {
            Rabbit rabbitToBeDeleted = null;
            foreach (Rabbit rabbit in _rabbits)
            {
                if (rabbit.RabbitRegNo == rabbitRegNo && rabbit.OriginRegNo == originRegNo)
                {
                    rabbitToBeDeleted = rabbit;
                    break;      //Dette optimere koden så den ikke fortsætter med at iterere igennem
                }
            }

            if (rabbitToBeDeleted != null)
            {
                if (!string.IsNullOrEmpty(rabbitToBeDeleted.ImagePath))
                {
                    ImageHelper.DeleteImage(rabbitToBeDeleted.ImagePath);
                }

                _rabbits.Remove(rabbitToBeDeleted);
                await _dbGenericService.DeleteObjectAsync(rabbitToBeDeleted);
            }

            return rabbitToBeDeleted;
        }

        /// <summary>
        /// Intern filter søgefunktion for avlerens egne kaniner.
        /// 
        /// Denne søgefunktion finder kaniner hvis navn passer med søgestrengen.
        /// Der søges kun blandt de kaniner som avleren ejer(+ døde) eller kaniner som stammer fra avleren.
        /// </summary>
        /// <param name="str">Søge kriterie for navn</param>
        /// <param name="breederRegNo">Avler-ID reference</param>
        /// <returns></returns>
        public IEnumerable<Rabbit> SearchByName(string str, int breederRegNo)
        {
            var rabbitsWithConnections = GetAllRabbitsWithConnectionsToMe(breederRegNo);

            if (string.IsNullOrEmpty(str))
            {
                return rabbitsWithConnections;
            }

            return rabbitsWithConnections
                .Where(rabbit => rabbit.Name.ToLower().Contains(str.ToLower()));
        }


        public IEnumerable<Rabbit> RatingFilter(int breederRegNo, int? maxRating = null, int? minRating = null)
        {
            var rabbitsWithConnections = GetAllRabbitsWithConnectionsToMe(breederRegNo);

            return rabbitsWithConnections
                .Where(rabbit =>
                    (!minRating.HasValue || rabbit.Rating >= minRating) &&
                    (!maxRating.HasValue || rabbit.Rating <= maxRating)
                );
        }

        public IEnumerable<Rabbit> SearchByRegNo(int? originRegNo, int? rabbitRegNo, int breederRegNo)
        {
            var rabbitsWithConnections = GetAllRabbitsWithConnectionsToMe(breederRegNo);

            return rabbitsWithConnections
                .Where(rabbit =>
                    (!rabbitRegNo.HasValue || rabbit.RabbitRegNo == rabbitRegNo) &&
                    (!originRegNo.HasValue || rabbit.OriginRegNo == originRegNo)
                );
        }

        //----: ENDNU IKKE IMPLEMENTERET KODE. FORTSAT RELEVANT? :---- 
        public IEnumerable<Rabbit> SortById()     //LINQ & LAMBDA
        {
            return _rabbits.OrderBy(r => r.RabbitRegNo);   // bemærk: default er ascending(stigende.. fra 0 til 10)
        }

        public IEnumerable<Rabbit> SortByIdDescending()   //LINQ & LAMBDA 
        {
            return _rabbits.OrderByDescending(r => r.RabbitRegNo);
        }

        public IEnumerable<Rabbit> SortByName() //LINQ (for SQL og C# folket)
        {
            return from rabbit in _rabbits
                   orderby rabbit.Name
                   select rabbit;
        }

        public IEnumerable<Rabbit> SortByNameDescending() //LAMBDA
        {
            return _rabbits.OrderByDescending(obj => obj.Name);
        }

        //public IEnumerable<Rabbit> SortByNameDescending() //LINQ (for SQL og C# folket)
        //{
        //    return from rabbit in _rabbits
        //           orderby rabbit.Name descending
        //           select rabbit;
        //}

        public IEnumerable<Rabbit> SortByRating()  //LINQ (for SQL og C# folket)
        {
            return from rabbit in _rabbits
                   orderby rabbit.Rating
                   select rabbit;
        }

        public IEnumerable<Rabbit> SortByRatingDescending() //LAMBDA (for C# og Java folket)
        {
            return _rabbits.OrderByDescending(obj => obj.Rating);
        }
        //END: ENDNU IKKE IMPLEMENTERET KODE. FORTSAT RELEVANT? :---- 


        //---: SEKTION FOR ONGET() METODER :---

        /// <summary>
        /// Henter alle de kaniner som Avleren har specificeret er til salg via. LAMBDA og LINQ
        /// </summary>
        /// <returns>En liste af kaniner som forskellige avlerere har sat til salg</returns>
        public List<Rabbit> GetIsForSaleRabbits()
        {
            return _rabbits.Where(rabbit => rabbit.IsForSale == IsForSale.Ja).ToList();
        }

        /// <summary>
        /// Default OnGet() metoden som kaldes når en avler tilgår GetAllRabbits siden.
        /// 
        /// Tager udgangspunkt i brugerens avler-ID og kæder det sammen med de kaniner,
        /// avleren ejer, som er i live.
        /// </summary>
        /// <param name="breederRegNo">Brugerens avler-ID</param>
        /// <returns>En liste af avlerens ejede kaniner, som er levende</returns>
        public List<Rabbit> GetOwnedAliveRabbits(int breederRegNo)
        {
            var rabbits = _rabbits.Where(rabbit => rabbit.Owner == breederRegNo && rabbit.DeadOrAlive == DeadOrAlive.Levende).ToList();

            foreach (var rabbit in rabbits)
            {
                if (!string.IsNullOrEmpty(rabbit.ImagePath) && !rabbit.ImagePath.StartsWith("/"))
                {
                    rabbit.ImagePath = Path.Combine("/", rabbit.ImagePath);
                }
            }

            return rabbits;
        }

        /// <summary>
        /// Funktion som tilgåes via knappen "Filter Kaniner" på GetAllRabbits siden.
        /// 
        /// Tager udgangspunkt i brugerens avler-ID og kæder det sammen med de kaniner,
        /// avleren ejer, som er døde.
        /// </summary>
        /// <param name="breederRegNo">Brugerens avler-ID</param>
        /// <returns>En liste af avlerens ejede kaniner, som er døde</returns>
        public List<Rabbit> GetOwnedDeadRabbits(int breederRegNo)
        {
            return _rabbits.Where(rabbit => rabbit.Owner == breederRegNo && rabbit.DeadOrAlive == DeadOrAlive.Død).ToList();
        }

        /// <summary>
        /// Funktion som tilgåes via knappen "Filter Kaniner" på GetAllRabbits siden.
        /// 
        /// Tager udgangspunkt i brugerens avler-ID og kæder det sammen med de kaniner,
        /// avleren ejer ELLER har forbindelse til (kaniner med avlerens ID)
        /// </summary>
        /// <param name="breederRegNo">Brugerens avler-ID</param>
        /// <returns>En liste af avlerens ejede kaniner, og kaniner med avlerens ID</returns>
        public List<Rabbit> GetAllRabbitsWithConnectionsToMe(int breederRegNo)
        {
            return _rabbits.Where(rabbit => rabbit.Owner == breederRegNo || rabbit.OriginRegNo == breederRegNo).ToList();
        }

        public virtual List<Rabbit> GetAllRabbitsWithOwner(int Owner)
        {
            return _rabbits.Where(rabbit => rabbit.Owner == Owner).ToList();
        }

        /// <summary>
        /// Funktion som tilgåes via knappen "Filter Kaniner" på GetAllRabbits siden.
        /// 
        /// Tager udgangspunkt i alle kaniner som kommer fra avlerens stald,
        /// men som ikke længere ejes af avleren.
        /// </summary>
        /// <param name="breederRegNo">Brugerens avler-ID</param>
        /// <returns>En liste af kaniner, som avleren IKKE ejer, men er rigistreret med avlerens avler-ID</returns>
        public List<Rabbit> GetNotOwnedRabbitsWithMyBreederRegNo(int breederRegNo)
        {
            return _rabbits.Where(rabbit => rabbit.Owner != breederRegNo && rabbit.OriginRegNo == breederRegNo).ToList();
        }


    }
}
