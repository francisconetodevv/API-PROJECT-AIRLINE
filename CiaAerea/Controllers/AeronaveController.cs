using CIAArea.Services;
using CIAArea.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CIAArea.Controllers;

[Route("api/aeronaves")]
[ApiController]

public class AeronaveControllers : ControllerBase
{
    private readonly AeronaveServices _aeronaveService;

    public AeronaveControllers(AeronaveServices aeronaveService)
    {
        _aeronaveService = aeronaveService;
    }

    [HttpPost]
    public IActionResult AdicionarAeronave(AdicionarAeronaveViewModel dados)
    {
        var aeronave = _aeronaveService.AdicionarAeronave(dados);

        return CreatedAtAction(nameof(ListarAeronavePeloId), new { id = aeronave.Id}, aeronave);
    }

    [HttpGet]
    public IActionResult ListarAeronaves()
    {
        return Ok(_aeronaveService.ListarAeronaves());
    }

    [HttpGet("{id}")]
    public IActionResult ListarAeronavePeloId(int id)
    {
        var aeronave = _aeronaveService.ListarAeronavePeloId(id);

        if (aeronave != null)
        {
            return Ok(aeronave);
        }

        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarAeronave(int id, AtualizarAeronaveViewModel dados)
    {
        if (id != dados.Id)
        {
            return BadRequest("O Id informado na URL é diferente do id informado no corpo da requisição");
        }

        var aeronave = _aeronaveService.AtualizarAeronave(dados);

        return Ok(aeronave);
    }

    [HttpDelete("{id}")]
    public IActionResult ExcluirAeronave(int id)
    {
        _aeronaveService.ExcluirAeronave(id);

        return NoContent();
    }
}