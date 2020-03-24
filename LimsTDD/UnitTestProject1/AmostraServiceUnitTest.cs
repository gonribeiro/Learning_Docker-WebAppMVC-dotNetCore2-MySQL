using System;
using System.Collections.Generic;
using System.Text;
using Lims.Domain.Entities;
using Lims.Domain.Enum;
using Lims.Domain.Interfaces.Repositories;
using Lims.Domain.Services;
using Lims.Infra.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Lims.UnitTest
{
    [TestClass]
    public class AmostraServiceUnitTest
    {
        [TestMethod]
        public void AdicionarAmostraPositiva()
        {
            //Preparação
            IAmostraRepository laudoRepository = new AmostraMemDB();
            var laudoPositivo = new LaudoService(laudoRepository);

            Analista analista = new Analista
            {
                Id = Guid.NewGuid(),
                Nome = "Tiago"
            };


            Modalidade sport = new Modalidade
            {
                Id = Guid.NewGuid(),
                Nome = "LOL"
            };

            Atleta atleta = new Atleta
            {
                CodAtleta = "1285266fsga4",
                Sexo = Sexo.Masculino,
                Modalidade = sport
            };

            Amostra sample = new Amostra
            {
                Id = Guid.NewGuid(),
                Atleta = atleta,
                DataColeta = DateTime.Now.AddDays(-3),
                Substancia = "THC",
                Matriz = Matriz.Urina
            };

            var ams = laudoPositivo.Positiva(sample);

            //Validação
            Assert.IsTrue(ams);
        }

        [TestMethod]
        public void AdicionarAmostraNegativa()
        {
            IAmostraRepository laudoRepository = new AmostraMemDB();
            var laudoNegativo = new LaudoService(laudoRepository);

            Analista analista = new Analista
            {
                Id = Guid.NewGuid(),
                Nome = "Guy"
            };

            Modalidade sport = new Modalidade
            {
                Id = Guid.NewGuid(),
                Nome = "LOL"
            };

            Atleta atleta = new Atleta
            {
                CodAtleta = "887455jta4",
                Sexo = Sexo.Masculino,
                Modalidade = sport
            };

            Amostra sample = new Amostra
            {
                Id = Guid.NewGuid(),
                Atleta = atleta,
                DataColeta = DateTime.Now.AddDays(-3),
                Substancia = "Sibutramina",
                Matriz = Matriz.Sangue
            };

            var ams = laudoNegativo.Negativa(sample);

            //Validação
            Assert.IsTrue(ams);
        }
        [TestMethod]
        public void RejeitarAmostraFaltaInfo()
        {
            IAmostraRepository amostraRepository = new AmostraMemDB();
            var rejeitarAmostra = new AmostraService(amostraRepository);

            Analista analista = new Analista
            {
                Id = Guid.NewGuid(),
                Nome = "Tiago"
            };

            Modalidade sport = new Modalidade
            {
                Id = Guid.NewGuid(),
                Nome = "Futebol"
            };

            Atleta atleta = new Atleta
            {
                CodAtleta = null,
                Sexo = Sexo.Masculino,
                Modalidade = sport
            };

            Amostra sample = new Amostra
            {
                Id = Guid.NewGuid(),
                Atleta = atleta,
                DataColeta = DateTime.Now.AddDays(-30)
            };

            var ams = rejeitarAmostra.RejeitarAmostra(atleta);

            //Validação
            Assert.IsFalse(ams);
        }
        [TestMethod]
        public void DeletarAmostraComTempo()
        {
            IAmostraRepository amostraRepository = new AmostraMemDB();
            var deletarAmostra = new AmostraService(amostraRepository);
            DateTime d = DateTime.Now;

            Analista analista = new Analista
            {
                Id = Guid.NewGuid(),
                Nome = "Guy"
            };

            Modalidade sport = new Modalidade
            {
                Id = Guid.NewGuid(),
                Nome = "Futebol"
            };

            Atleta atleta = new Atleta
            {
                CodAtleta = "4fg463fe34",
                Sexo = Sexo.Masculino,
                Modalidade = sport
            };

            Amostra sample = new Amostra
            {
                Id = Guid.NewGuid(),
                Atleta = atleta,
                DataColeta = DateTime.Now.AddDays(-30),
                Substancia = "Sibutramina"
            };

            var ams = deletarAmostra.DeletarAmostra(sample);

            //Validação
            Assert.IsFalse(ams);
        }
    }
}
