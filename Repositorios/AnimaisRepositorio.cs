using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class AnimaisRepositorio : IAnimaisRepositorio
    {
        private readonly Contexto _dbContext;

        public AnimaisRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AnimaisModel>> GetAll()
        {
            return await _dbContext.Animais.ToListAsync();
        }

        public async Task<AnimaisModel> GetById(int id)
        {
            return await _dbContext.Animais.FirstOrDefaultAsync(x => x.AnimalId == id);
        }

        public async Task<AnimaisModel> InsertAnimais(AnimaisModel animais)
        {
            await _dbContext.Animais.AddAsync(animais);
            await _dbContext.SaveChangesAsync();
            return animais;
        }

        public async Task<AnimaisModel> UpdateAnimais(AnimaisModel animais, int id)
        {
            AnimaisModel animaiss = await GetById(id);
            if(animaiss == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                animaiss.AnimalNome = animais.AnimalNome;
                animaiss.AnimalRaca = animais.AnimalRaca;
                animaiss.AnimalTipo = animais.AnimalTipo;
                animaiss.AnimalCor = animais.AnimalCor;
                animaiss.AnimalSexo = animais.AnimalSexo;
                animaiss.AnimalObservacao = animais.AnimalObservacao;
                animaiss.AnimalFoto = animais.AnimalFoto;
                animaiss.AnimalDtDesaparecimento = animais.AnimalDtDesaparecimento;
                animaiss.AnimalDtEncontro = animais.AnimalDtEncontro;
                animaiss.AnimalStatus = animais.AnimalStatus;
                animaiss.UsuarioId = animais.UsuarioId;
                _dbContext.Animais.Update(animaiss);
                await _dbContext.SaveChangesAsync();
            }
            return animaiss;
           
        }

        public async Task<bool> DeleteAnimais(int id)
        {
            AnimaisModel animaiss = await GetById(id);
            if (animaiss == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Animais.Remove(animaiss);
            await _dbContext.SaveChangesAsync();
            return true;
        }    
       
    }
}
