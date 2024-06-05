using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IObservacoesRepositorio
    {
        Task<List<ObservacoesModel>> GetAll();

        Task<ObservacoesModel> GetById(int id);

        Task<ObservacoesModel> InsertObservacoes(ObservacoesModel observacoes);

        Task<ObservacoesModel> UpdateObservacoes(ObservacoesModel observacoes, int id);

        Task<bool> DeleteObservacoes(int id);
    }
}
