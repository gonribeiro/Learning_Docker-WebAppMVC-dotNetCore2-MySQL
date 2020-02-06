using Lims.Domain.Entities;
using Lims.Domain.Interfaces.Repositories;

namespace Lims.Domain.Services
{
    public class LaudoService
    {
        protected IAmostraRepository _laudoRepository;
        
        public LaudoService(IAmostraRepository laudoRepository)
        {
            _laudoRepository = laudoRepository;
        }

        /// <summary>
        /// Laudo da amostra é registrada como negativa (quando não há substâncias suspeitas)
        /// </summary>
        /// <param name="sample"></param>
        public bool Negativa(Amostra sample)
        {            
            if (sample.Substancia == "Sibutramina" && sample.Atleta.Modalidade.Nome == "LOL")
            {
                return true;
            }

            return _laudoRepository.Update(sample);
        }

        /// <summary>
        /// Laudo da amostra é registrada como positiva (quando há substâncias suspeitas)
        /// </summary>
        /// <param name="sample"></param>
        public bool Positiva(Amostra sample)
        {
            if (sample.Substancia == "THC" && sample.Atleta.Modalidade.Nome == "LOL")
            {
                return true;
            }

            return _laudoRepository.Update(sample);
        }
    }
}

