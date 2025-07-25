namespace CIAAerea.ViewModels.Cancelamento;

public class CancelarVooViewModel
{
    public CancelarVooViewModel(string motivoCancelamento, DateTime dataHoraNotificacao, int vooId)
    {
        MotivoCancelamento = motivoCancelamento;
        DataHoraNotificacao = dataHoraNotificacao;
        VooId = vooId;
    }

    public string MotivoCancelamento { get; set; }
    public DateTime DataHoraNotificacao { get; set; }
    public int VooId { get; set; }
}