using Microsoft.AspNetCore.Mvc;
using CIAAerea.Services;
using CIAAerea.ViewModels.Manutencao;

namespace CIAAerea.Controllers;

[Route("api/manutencoes")]
[ApiController]
public class ManutencaoController : ControllerBase
{
    private readonly ManutencaoService _manutencaoService;

    public ManutencaoController(ManutencaoService manutencaoService)
    {
        _manutencaoService = manutencaoService;
    }

    [HttpPost]
    public IActionResult AdicionarManutencao(AdicionarManutencaoViewModel dados)
    {
        var manutencao = _manutencaoService.AdicionarManutencao(dados);
        return Ok(manutencao);
    }
}