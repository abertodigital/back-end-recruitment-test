namespace MarvelVsDC.Dominio
{
    public class WeakPoint
    {
        public TipoDoPontoFraco Type { get; set; }
        public string name { get; set; }
        public string Description { get; set; }
        public double Damage { get; set; }
    }

    public enum TipoDoPontoFraco
    {
        Love,
        Joia,
        Place,
        Artefato,
        Inimigo
    }
}