using SustainableEnergyAPI.DTO;
using SustainableEnergyAPI.Models;
using SustainableEnergyAPI.Repositories;

namespace SustainableEnergyAPI.Services
{
    public class EnergyProcessService
    {
        private readonly IEnergyProcessRepository _repository;

        public EnergyProcessService(IEnergyProcessRepository repository)
        {
            _repository = repository;
        }

        // Método para recuperar todos os processos de energia
        public IEnumerable<EnergyProcess> GetAll()
        {
            return _repository.GetAll();
        }

        // Método para recuperar um processo de energia específico pelo ID
        public EnergyProcess GetById(string id)
        {
            return _repository.GetById(id);  // O repositório deve ter essa implementação
        }

        // Método para criar um novo processo de energia
        public EnergyProcess Create(EnergyProcessDTO processDTO)
        {
            var process = new EnergyProcess(processDTO.Name, processDTO.Efficiency);
            _repository.Create(process);
            return process;
        }

        // Método para atualizar um processo de energia
        public EnergyProcess Update(string id, EnergyProcessDTO processDTO)
        {
            var process = _repository.GetById(id);  // Primeiro, recuperamos o processo

            if (process == null)
            {
                return null;  // Retorna null se o processo não for encontrado
            }

            process.Name = processDTO.Name;
            process.Efficiency = processDTO.Efficiency;

            _repository.Update(process);  // Atualiza o processo no repositório
            return process;
        }

        // Método para atualizar parcialmente um processo de energia
        public EnergyProcess Patch(string id, EnergyProcessDTO partialUpdate)
        {
            var process = _repository.GetById(id);  // Recupera o processo

            if (process == null)
            {
                return null;  // Retorna null se o processo não for encontrado
            }

            // Atualiza apenas os campos fornecidos
            if (!string.IsNullOrEmpty(partialUpdate.Name))
            {
                process.Name = partialUpdate.Name;
            }

            if (partialUpdate.Efficiency > 0)
            {
                process.Efficiency = partialUpdate.Efficiency;
            }

            _repository.Update(process);  // Atualiza o processo no repositório
            return process;
        }

        // Método para deletar um processo de energia
        public bool Delete(string id)
        {
            var process = _repository.GetById(id);  // Recupera o processo

            if (process == null)
            {
                return false;  // Retorna false se o processo não for encontrado
            }

            _repository.Delete(id);  // Deleta o processo do repositório
            return true;
        }
    }
}
