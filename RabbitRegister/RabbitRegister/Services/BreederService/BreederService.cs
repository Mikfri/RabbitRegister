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
            Breeders = _dbService.GetObjectsAsync().Result.ToList();

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
    }
}
