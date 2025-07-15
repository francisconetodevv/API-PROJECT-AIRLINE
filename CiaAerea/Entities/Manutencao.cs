using CIAArea.Entities.Enums;

namespace CIAArea.Entities;

public class Manutencao
{
    public Manutencao(DateTime dataHoraManutencao, TipoManutencao tipo, int aeronaveId, string? observacoes = null)
    {
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
    public Aeronave Aeronave { get; set; } = null!;
}