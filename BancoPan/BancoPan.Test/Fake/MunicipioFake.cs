using BancoPan.Domain.Domain.Aggregate.Ibge;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoPan.Test.Fake
{
    public static class MunicipioFake
    {
        public static List<Municipio> GetMunicipiosValid()
        {
            return new List<Municipio>()
            {
                new Municipio()
                {
                    Id =1,
                    Nome = "Sei la",
                    Microrregiao = GetMicrorregiao(1,"Microrregiao")
                }
            };
        }

        public static Microrregiao GetMicrorregiao(int id, string nome )
        {
            return new Microrregiao()
            {
                Id = id,
                Nome = nome,
                Mesorregiao = GetMesorregiao(1, "Mesorregiao")
            };
        }

        public static Mesorregiao GetMesorregiao(int id, string nome)
        {
            return new Mesorregiao()
            {
                Id = id,
                Nome = nome,
                UF = GetUF(1,"UF1","Sigla1")
            };
        }

        public static UF GetUF(int id, string nome, string sigla)
        {
            return new UF()
            {
                Id = id,
                Nome = nome,
                Sigla = sigla,
                Regiao = GetRegiao(1, "Regiao1", "Sigla1")
            };
        }

        public static Regiao GetRegiao(int id, string nome, string sigla)
        {
            return new Regiao()
            {
                Id = 1,
                Nome = nome,
                Sigla = sigla
            };
        }
    }
}
