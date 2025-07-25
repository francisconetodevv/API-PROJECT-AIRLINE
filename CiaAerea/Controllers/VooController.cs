using CIAAerea.Services;
using CIAAerea.ViewModels.Voo;
using Microsoft.AspNetCore.Mvc;

namespace CIAAerea.Controllers;

[Route("api/voos")]
[ApiController]
public class VooController : ControllerBase
{
    private readonly VooService _vooService;

    public VooController(VooService vooService)
    {
        _vooService = vooService;
    }

    [HttpPost]
    public IActionResult AdicionarVoo(AdicionarVooViewModel dados)
    {
        var voo = _vooService.AdicionarVoo(dados);

        return Ok(voo);
    }

    [HttpGet]
    public IActionResult ListarVoos(string? origem, string? destino, DateTime? partida, DateTime? chegada)
    {
        return Ok(_vooService.ListarVoo(origem, destino, partida, chegada));
    }

    [HttpGet("{id}")]
    public IActionResult ListarVooPeloId(int id)
    {
        var voo = _vooService.ListarVooPeloId(id);

        if (voo != null)
        {
            return Ok(voo);
        }

        return NotFound();
    }
}