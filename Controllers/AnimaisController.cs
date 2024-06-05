using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimaisController : ControllerBase
    {
        private readonly IAnimaisRepositorio _animaissRepositorio;

        public AnimaisController(IAnimaisRepositorio animaissRepositorio)
        {
            _animaissRepositorio = animaissRepositorio;
        }

        [HttpGet("GetAllAnimaiss")]
        public async Task<ActionResult<List<AnimaisModel>>> GetAllAnimaiss()
        {
            List<AnimaisModel> animaiss = await _animaissRepositorio.GetAll();
            return Ok(animaiss);
        }

        [HttpGet("GetAnimaisId/{id}")]
        public async Task<ActionResult<AnimaisModel>> GetAnimaisId(int id)
        {
            AnimaisModel animais = await _animaissRepositorio.GetById(id);
            return Ok(animais);
        }

        [HttpPost("CreateAnimais")]
        public async Task<ActionResult<AnimaisModel>> InsertAnimais([FromBody]AnimaisModel animaisModel)
        {
            AnimaisModel animais = await _animaissRepositorio.InsertAnimais(animaisModel);
            return Ok(animais);
        }

    }
}
