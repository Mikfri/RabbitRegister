﻿using RabbitRegister.MockData;
using RabbitRegister.Model;
using RabbitRegister.Services.UserService;

namespace RabbitRegister.Services.BreederService
{
    public class BreederService : IBreederService
    {
        public List<Breeder> Breeders { get; set; }
        public Breeder Breeder { get; set; }
        private DbGenericService<Breeder> _dbService;

        public BreederService(DbGenericService<Breeder> dbService)
        {
            _dbService = dbService;
            Breeders = MockBreeder.GetMockBreeders();
            _dbService.SaveObjects(Breeders);
            //Breeders = _dbService.GetObjectsAsync().Result.ToList();

        }

        public async Task AddUserAsync(Breeder breeder)
        {
            Breeders.Add(breeder);
            await _dbService.AddObjectAsync(breeder);
        }
        public Breeder GetBreedByBreederRegNo(int breederRegNo)
        {
            //return DbService.GetObjectByIdAsync(username).Result;
            return Breeders.Find(breeder => breeder.BreederRegNo == breederRegNo);
        }

		public List<Breeder> GetBreeders() { return Breeders; }

		public Breeder GetBreeder(int breederRegNo)
		{
			foreach (Breeder b in Breeders)
			{
				if (b.BreederRegNo == breederRegNo)
					return b;
			}
			return null;
		}

		public void UpdateBreederAsync(Breeder breeder, int breederRegNo)
		{
			if (breeder != null)
			{
				foreach (Breeder i in Breeders)
				{
					if (i.BreederRegNo == breeder.BreederRegNo && i.Name == breeder.Name)
					{
						
						i.Adress = breeder.Adress;
						i.ZipCode= breeder.ZipCode;
						i.Email = breeder.Email;
						i.Phone = breeder.Phone;
						i.isAdmin = breeder.isAdmin;
						break;
					}
				}
				_dbService.UpdateObjectAsync(breeder);
			}
		}

		public async Task<Breeder> DeleteBreederAsync(int? breederRegNo)
		{
			Breeder breederToBeDeleted = null;
			foreach (Breeder breeder in Breeders)
			{
				if (breeder.BreederRegNo == breederRegNo)
				{
					breederToBeDeleted = breeder;
					break;
				}
			}

			if (breederToBeDeleted != null)
			{
				Breeders.Remove(breederToBeDeleted);
				await _dbService.DeleteObjectAsync(breederToBeDeleted);
			}
			return breederToBeDeleted;

		}
	}
}
