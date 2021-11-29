using MarvelVsDC.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelVsDC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroHeroiController : ControllerBase
    {
        private readonly ILogger<CadastroHeroiController> _logger;
        private MongoClient mongoClient;

        public CadastroHeroiController(ILogger<CadastroHeroiController> logger, MongoClient mongoClient)
        {
            this.mongoClient = mongoClient;
            _logger = logger;
        }

        [HttpPost("cadastrar")]
        public string Controller([FromBody] Heroi hero)
        {
            hero.Id = Guid.NewGuid().ToString();
            mongoClient.GetDatabase("UniversoHeroisAberto").GetCollection<Heroi>("Hero").InsertOne(hero);
            return hero.Id;
        }

        [HttpPost("cadastrar-vilao")]
        public string Controller2([FromBody] Vilao Villain)
        {
            Villain.Id = new Random().Next().ToString();
            mongoClient.GetDatabase("UniversoHeroisAberto").GetCollection<Vilao>("Vilao").InsertOne(Villain);
            return Villain.Id;
        }
    }
}

