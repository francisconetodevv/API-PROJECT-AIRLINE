using CIAAerea.Services;
using CIAAerea.ViewModels.Piloto;
using CIAArea.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CIAAerea.Controllers;

[Route("api/pilotos")]
[ApiController]
public class PilotoController : ControllerBase
{
    private readonly PilotoService _pilotoService;

    public PilotoController(PilotoService pilotoService)
    {
        _pilotoService = pilotoService;
    }

    // POST
    [HttpPost]
    public IActionResult AdicionarPiloto(AdicionarPilotoViewModel dados)
    {
        var piloto = _pilotoService.AdicionarPiloto(dados);
        return Ok(piloto);
    }

    // GET
    [HttpGet]
    public IActionResult ListarPilotos()
    {
        return Ok(_pilotoService.ListarPilotos());
    }

    // GET - Id
    [HttpGet("{id}")]
    public IActionResult ListarPilotoPeloId(int id)
    {
        var piloto = _pilotoService.ListarPilotoPeloId(id);

        if (piloto != null)
        {
            return Ok(piloto);
        }

        return NotFound();
    }

    // PUT
    [HttpPut]
    public IActionResult AtualizarPiloto(int id, AtualizarPilotoViewModel dados)
    {
        if (id != dados.Id)
        {
            return BadRequest("Id do piloto não confere com o Id dos dados enviados.");
        }

        var piloto = _pilotoService.AtualizarPiloto(dados);
        return Ok(piloto);
    }
}