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
        return Ok(aeronave);
    }

    [HttpGet]
    public IActionResult ListarAeronaves()
    {
        return Ok(_aeronaveService.ListarAeronaves());
    }

}