namespace CIAAerea.ViewModels.Cancelamento;

public class DetalhesCancelamentoVooViewModel
{
    public DetalhesCancelamentoVooViewModel(int id, string motivoCancelamento, DateTime dataHoraNotificacao, int vooId)
    {
        Id = id;
        MotivoCancelamento = motivoCancelamento;
        DataHoraNotificacao = dataHoraNotificacao;
        VooId = vooId;
    }

    public int Id { get; set; }
    public string MotivoCancelamento { get; set; }
    public DateTime DataHoraNotificacao { get; set; }
    public int VooId { get; set; }
}