using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class ObservacoesRepositorio : IObservacoesRepositorio
    {
        private readonly Contexto _dbContext;

        public ObservacoesRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ObservacoesModel>> GetAll()
        {
            return await _dbContext.Observacoes.ToListAsync();
        }

        public async Task<ObservacoesModel> GetById(int id)
        {
            return await _dbContext.Observacoes.FirstOrDefaultAsync(x => x.ObservacoesId == id);
        }

        public async Task<ObservacoesModel> InsertObservacoes(ObservacoesModel observacoes)
        {
            await _dbContext.Observacoes.AddAsync(observacoes);
            await _dbContext.SaveChangesAsync();
            return observacoes;
        }

        public async Task<ObservacoesModel> UpdateObservacoes(ObservacoesModel observacoes, int id)
        {
            ObservacoesModel observacoess = await GetById(id);
            if(observacoess == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                observacoess.ObservacaoDescricao = observacoes.ObservacaoDescricao;
                observacoess.ObservacaoLocal = observacoes.ObservacaoLocal;
                observacoess.ObservacaoData = observacoes.ObservacaoData;
                observacoess.AnimalId = observacoes.AnimalId;
                observacoess.UsuarioId = observacoes.UsuarioId;
                _dbContext.Observacoes.Update(observacoess);
                await _dbContext.SaveChangesAsync();
            }
            return observacoess;
           
        }

        public async Task<bool> DeleteObservacoes(int id)
        {
            ObservacoesModel observacoess = await GetById(id);
            if (observacoess == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Observacoes.Remove(observacoess);
            await _dbContext.SaveChangesAsync();
            return true;
        }    
       
    }
}
