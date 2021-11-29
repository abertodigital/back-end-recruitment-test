using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelVsDC.Dominio
{
    public class Vilao
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public bool IsMarvel { get; set; }
        public bool IsDC { get; set; }
        public List<Poder> Power { get; set; }
        public List<WeakPoint> PontoFraco { get; set; }
        public int Life { get; set; }
        public string LocalDeorigem { get; set; }
    }
}
