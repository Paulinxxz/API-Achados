using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IAnimaisRepositorio
    {
        Task<List<AnimaisModel>> GetAll();

        Task<AnimaisModel> GetById(int id);

        Task<AnimaisModel> InsertAnimais(AnimaisModel animais);

        Task<AnimaisModel> UpdateAnimais(AnimaisModel animais, int id);

        Task<bool> DeleteAnimais(int id);
    }
}
