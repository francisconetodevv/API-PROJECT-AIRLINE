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

        return CreatedAtAction(nameof(ListarVooPeloId), new { voo.Id }, voo);
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

    [HttpPut("{id}")]
    public IActionResult AtualizarVoo(int id, AtualizarVooViewModel dados)
    {
        if (id != dados.Id)
        {
            return BadRequest("O ID informado na URL é diferente do ID no corpo da requisição.");
        }
        var voo = _vooService.AtualizarVoo(dados);

        if (voo != null)
        {
            return Ok(voo);
        }

        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult ExcluirVoo(int id)
    {
        _vooService.ExcluirVoo(id);

        return NoContent();
    }
}