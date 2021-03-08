namespace BancoPan.Domain.Domain.Aggregate.Ibge
{
    public class Municipio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Microrregiao Microrregiao { get; set; }
        public RegiaoImediata RegiaoImediata { get; set; }

    }
    public class Microrregiao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Mesorregiao Mesorregiao { get; set; }
    }

    public class Mesorregiao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public UF UF { get; set; }
    }

    public class UF
    {
        public int Id { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public Regiao Regiao { get; set; }
    }

    public class RegiaoImediata
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public RegiaoIntermediaria RegiaoIntermediaria { get; set; }
    }

    public class RegiaoIntermediaria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public UF UF { get; set; }
    }

}
