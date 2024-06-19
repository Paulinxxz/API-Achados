using Api.Models;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObservacoesController : ControllerBase
    {
        private readonly IObservacoesRepositorio _observacoessRepositorio;

        public ObservacoesController(IObservacoesRepositorio observacoessRepositorio)
        {
            _observacoessRepositorio = observacoessRepositorio;
        }

        [HttpGet("GetAllObservacoess")]
        public async Task<ActionResult<List<ObservacoesModel>>> GetAllObservacoess()
        {
            List<ObservacoesModel> observacoess = await _observacoessRepositorio.GetAll();
            return Ok(observacoess);
        }

        [HttpGet("GetObservacoesId/{id}")]
        public async Task<ActionResult<ObservacoesModel>> GetObservacoesId(int id)
        {
            ObservacoesModel observacoes = await _observacoessRepositorio.GetById(id);
            return Ok(observacoes);
        }

        [HttpPost("InsertObservacoes")]
        public async Task<ActionResult<ObservacoesModel>> InsertObservacoes([FromBody] ObservacoesModel observacoesModel)
        {
            ObservacoesModel observacoes = await _observacoessRepositorio.InsertObservacoes(observacoesModel);
            return Ok(observacoes);
        }

        [HttpPut("UpdateObservacoes/{id:int}")]
        public async Task<ActionResult<ObservacoesModel>> UpdateObservacoes(int id, [FromBody] ObservacoesModel observacoesModel)
        {
            observacoesModel.ObservacoesId = id;
            ObservacoesModel observacoes = await _observacoessRepositorio.UpdateObservacoes(observacoesModel, id);
            return Ok(observacoes);
        }
        [HttpDelete("DeleteObservacoes/{id:int}")]
        public async Task<ActionResult<ObservacoesModel>> DeleteObservacoes(int id)
        {
            bool deleted = await _observacoessRepositorio.DeleteObservacoes(id);
            return Ok(deleted);
        }

    }
}
