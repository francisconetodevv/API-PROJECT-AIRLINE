using CIAArea.Entities.Enums;

namespace CIAAerea.ViewModels.Manutencao;

public class AtualizarManutencaoViewModel
{
    public AtualizarManutencaoViewModel(int id, DateTime dataHoraManutencao, string? observacoes, TipoManutencao tipo, int aeronaveId)
    {
        Id = id;
        DataHoraManutencao = dataHoraManutencao;
        Observacoes = observacoes;
        Tipo = tipo;
        AeronaveId = aeronaveId;
    }

    public int Id { get; set; }
    public DateTime DataHoraManutencao { get; set; }
    public string? Observacoes { get; set; } // Tornando o campo nullable
    public TipoManutencao Tipo { get; set; }
    public int AeronaveId { get; set; }
}