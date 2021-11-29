using MarvelVsDC.Dominio;
using MarvelVsDC.DTO;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelVsDC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControllerCombate : ControllerBase
    {
        public MongoClient mongoClient = new MongoClient("mongodb://localhost:27017");

        [HttpPost("combater")]
        public async Task<dynamic> _ControllerCombate(RequisicaoCombate objeto)
        {
            var database = mongoClient.GetDatabase("UniversoHeroisAberto");

            var item1 = (await database.GetCollection<Heroi>("Heroi").FindAsync(x => x.Id == objeto.IdHeroi)).FirstOrDefault();
            var item2 = (await database.GetCollection<Vilao>("Vilao").FindAsync(x => x.Id == objeto.idVilao)).FirstOrDefault();

            int quantidadeDeGolpes = 0;

            do
            {
                quantidadeDeGolpes = quantidadeDeGolpes + 1;
                int forcaTotal1 = 0;
                var totalPowder2 = 0;
                foreach (var dano in item1.Power)
                forcaTotal1 += dano.Value;

                for (int i = 0; i < item2.Power.Count; i++)
                {
                    totalPowder2 = totalPowder2 + item2.Power[i].Value;
                }

                item1.Life = item1.Life - totalPowder2;
                item2.Life -= forcaTotal1;
            } while (item1.Life > 0 && item2.Life > 0);

            return new {
                heroi = new
                {
                    heroiId = item1.Id,
                    life = item1.Life,
                    taVivo = item1.Life > 0
                },
                vilao = new
                {
                    iD = item2.Id,
                    life = item2.Life,
                    taVivo = item2.Life > 0
                },
                rounds = quantidadeDeGolpes
            };

        }
    }
}
