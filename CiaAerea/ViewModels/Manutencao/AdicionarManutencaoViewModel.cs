using CIAArea.Entities.Enums;

namespace CIAAerea.ViewModels.Manutencao;

public class AdicionarManutencaoViewModel
{
    public AdicionarManutencaoViewModel(DateTime dataHoraManutencao, string? observacoes, TipoManutencao tipo, int aeronaveId)
    {
        DataHoraManutencao = dataHoraManutencao;
        Observacoes = observacoes;
        Tipo = tipo;
        AeronaveId = aeronaveId;
    }

    public DateTime DataHoraManutencao { get; set; }
    public string? Observacoes { get; set; } // Tornando o campo nullable
    public TipoManutencao Tipo { get; set; }
    public int AeronaveId { get; set; }
}