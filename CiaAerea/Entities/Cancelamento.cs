namespace CIAArea.Entities;

public class Cancelamento
{
    public Cancelamento(string motivoCancelamento, DateTime dataHoraNotificacao, int vooId)
    {
        MotivoCancelamento = motivoCancelamento;
        DataHoraNotificacao = dataHoraNotificacao;
        VooId = vooId;
    }

    public int Id { get; set; }
    public string MotivoCancelamento { get; set; }
    public DateTime DataHoraNotificacao { get; set; }
    public int VooId { get; set; }
    public Voo Voo { get; set; } = null!;
}