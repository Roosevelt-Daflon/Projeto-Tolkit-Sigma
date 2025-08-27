using Projeto_Tolkit_Sigma.Dominio.Modelos;

namespace Projeto_Tolkit_Sigma.Servicos;

public class ServicoAvaliadorProposicional
{
    private readonly List<FormulaProposicional> _formulas = new()
    {
        new FormulaProposicional
        {
            Id = 1,
            Nome = "Conjunção",
            Expressao = "P ∧ Q",
            Avaliador = (p,q,r) => p && q
        },
        new FormulaProposicional
        {
            Id = 2,
            Nome = "Disjunção",
            Expressao = "P ∨ Q ∨ R",
            Avaliador = (p,q,r) => p || q || r
        },
        new FormulaProposicional
        {
            Id = 3,
            Nome = "Implicação",
            Expressao = "(P ∧ Q) → R",
            Avaliador = (p,q,r) => !(p && q) || r
        }
    };

    public IEnumerable<FormulaProposicional> Listar() => _formulas;

    public FormulaProposicional? Obter(int id) => _formulas.FirstOrDefault(f => f.Id == id);

    public bool Avaliar(FormulaProposicional f, bool p, bool q, bool r) => f.Avaliador(p, q, r);

    public IEnumerable<(bool P,bool Q,bool R,bool Resultado)> GerarTabela(FormulaProposicional f)
    {
        for (int i = 0; i < 8; i++)
        {
            bool p = (i & 0b100) != 0;
            bool q = (i & 0b010) != 0;
            bool r = (i & 0b001) != 0;
            yield return (p, q, r, f.Avaliador(p,q,r));
        }
    }
}