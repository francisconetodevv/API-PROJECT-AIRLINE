using CIAAerea.Validators.Voo;
using CIAAerea.ViewModels.Voo;
using CIAArea.Contexts;
using FluentValidation;
using CIAArea.Entities;
using Microsoft.EntityFrameworkCore;
using CIAArea.ViewModels;
using CIAAerea.ViewModels.Piloto;

namespace CIAAerea.Services;

public class VooService
{
    private readonly CiaAereaContext _context;
    private readonly AdicionarVooValidator _adicionarVooValidator;
    private readonly AtualizarVooValidator _atualizarVooValidator;
    private readonly ExcluirVooValidator _excluirVooValidator;

    public VooService(CiaAereaContext context, AdicionarVooValidator adicionarVooValidator, AtualizarVooValidator atualizarVooValidator, ExcluirVooValidator excluirVooValidator)
    {
        _context = context;
        _adicionarVooValidator = adicionarVooValidator;
        _atualizarVooValidator = atualizarVooValidator;
        _excluirVooValidator = excluirVooValidator;
    }

    public DetalhesVooViewModel AdicionarVoo(AdicionarVooViewModel dados)
    {
        _adicionarVooValidator.ValidateAndThrow(dados);

        var voo = new Voo
        (
            dados.Origem,
            dados.Destino,
            dados.DataHoraPartida,
            dados.DataHoraChegada,
            dados.AeronaveId,
            dados.PilotoId
        );

        _context.Add(voo);
        _context.SaveChanges();

        return ListarVooPeloId(voo.Id)!;
    }

    public IEnumerable<ListarVooViewModel> ListarVoo(string? origem, string? destino, DateTime? partida, DateTime? chegada)
    {
        // Aplicando filtros opcionais
        var filtroOrigem = (Voo voo) => string.IsNullOrWhiteSpace(origem) || voo.Origem == origem;
        var filtroDestino = (Voo voo) => string.IsNullOrEmpty(destino) || voo.Destino == destino;
        var filtroPartida = (Voo voo) => !partida.HasValue || voo.DataHoraPartida >= partida;
        var filtroChegada = (Voo voo) => !chegada.HasValue || voo.DataHoraChegada <= chegada;

        return _context.Voos
                    .Where(filtroOrigem)
                    .Where(filtroDestino)
                    .Where(filtroPartida)
                    .Where(filtroChegada)
                    .Select(v => new ListarVooViewModel
                    (
                        v.Id,
                        v.Origem,
                        v.Destino,
                        v.DataHoraPartida,
                        v.DataHoraChegada
                    ));
    }

    public DetalhesVooViewModel? ListarVooPeloId(int id)
    {
        var voo = _context.Voos.Include(v => v.Aeronave)
                               .Include(v => v.Piloto)
                               .FirstOrDefault(v => v.Id == id);
        if (voo != null)
        {
            var resultado = new DetalhesVooViewModel(
                voo.Id,
                voo.Origem,
                voo.Destino,
                voo.DataHoraPartida,
                voo.DataHoraChegada,
                voo.AeronaveId,
                voo.PilotoId
            );

            resultado.Aeronave = new DetalhesAeronaveViewModel(
                voo.Aeronave.Id,
                voo.Aeronave.Fabricante,
                voo.Aeronave.Modelo,
                voo.Aeronave.Codigo
            );

            resultado.Piloto = new DetalhesPilotoViewModel(
                voo.Piloto.Id,
                voo.Piloto.Nome,
                voo.Piloto.Matricula
            );

            return resultado;
        }

        return null;
    }

    public DetalhesVooViewModel? AtualizarVoo(AtualizarVooViewModel dados)
    {
        _atualizarVooValidator.ValidateAndThrow(dados);

        var voo = _context.Voos.Find(dados.Id);

        if (voo != null)
        {
            voo.Origem = dados.Origem;
            voo.Destino = dados.Destino;
            voo.DataHoraPartida = dados.DataHoraPartida;
            voo.DataHoraChegada = dados.DataHoraChegada;
            voo.AeronaveId = dados.AeronaveId;
            voo.PilotoId = dados.PilotoId;

            _context.Update(voo);
            _context.SaveChanges();

            return ListarVooPeloId(voo.Id);
        }

        return null;
    }

    public void ExcluirVoo(int id)
    {
        _excluirVooValidator.ValidateAndThrow(id);

        var voo = _context.Voos.Find(id);

        if (voo != null)
        {
            _context.Remove(voo);
            _context.SaveChanges();
        }
    }
}