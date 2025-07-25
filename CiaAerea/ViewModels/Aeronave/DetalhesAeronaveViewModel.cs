namespace CIAArea.ViewModels;

public class DetalhesAeronaveViewModel
{

    // Sao as mesmas informações que possuem nas entidades, algumas viewsModels não precisam de certos dados
    public DetalhesAeronaveViewModel(int id, string fabricante, string modelo, string codigo)
    {
        Id = id;
        Fabricante = fabricante;
        Modelo = modelo;
        Codigo = codigo;
    }

    public int Id { get; set; }
    public string Fabricante { get; set; }
    public string Modelo { get; set; }
    public string Codigo { get; set; }
}