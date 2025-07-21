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
}