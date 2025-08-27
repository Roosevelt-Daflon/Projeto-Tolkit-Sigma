namespace Projeto_Tolkit_Sigma.Dominio.Modelos;

public class FormulaProposicional
{
    public int Id { get; init; }
    public string Nome { get; init; } = "";
    public string Expressao { get; init; } = "";
    public Func<bool, bool, bool, bool> Avaliador { get; init; } = (_,_,_) => false;
}