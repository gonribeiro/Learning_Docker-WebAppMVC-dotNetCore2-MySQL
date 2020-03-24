using System;
using Lims.Domain.Entities;
using Lims.Domain.Interfaces.Repositories;

namespace Lims.Domain.Services
{
    public class AmostraService
    {
        protected IAmostraRepository _amostraRepository;

        public AmostraService(IAmostraRepository amostraRepository)
        {
            _amostraRepository = amostraRepository;
        }

        /// <summary>
        /// Função cadastra amostra recebida verificando se data 
        /// da coleta foi informada corretamente
        /// </summary>
        /// <param name="sample"></param>
        public bool AdicionarAmostra(Amostra sample)
        {
            if (sample.DataColeta > DateTime.Now)
            {
                return false;
            }

            sample.Id = Guid.NewGuid();
            return _amostraRepository.Create(sample);
        }

        /// <summary>
        /// Função rejeita amostra cadastrada quando informação codAtleta não é cadastrado
        /// </summary>
        /// <param name="samplereject"></param>
        public bool RejeitarAmostra(Atleta samplereject)
        {
            Amostra ams = new Amostra();

            if(samplereject.CodAtleta == null)
            {
                return false;
            }

            return _amostraRepository.Update(ams);
        }

        /// <summary>
        /// Função permite deletar amostra caso amostra tenha mais de 30 dias de registro
        /// </summary>
        /// <param name="sampledel"></param>
        public bool DeletarAmostra(Amostra sampledel)
        {
            if (DateTime.Now > sampledel.DataColeta.AddDays(30))
            {
                return false;                
            }           
            
            return _amostraRepository.Delete(sampledel);
        }
    }
}
