using Projeto_Tolkit_Sigma.Servicos;
using Projeto_Tolkit_Sigma.Dominio.Modelos;

namespace Projeto_Tolkit_Sigma.Menus;

public class MenuAvaliadorProposicional : BaseMenu
{
    private readonly ServicoMenu _servicoMenu;
    private readonly ServicoAvaliadorProposicional _servico = new();
    public override string Titulo => "Avaliador Proposicional";

    public MenuAvaliadorProposicional(ServicoMenu servicoMenu) : base(servicoMenu)
    {
        _servicoMenu = servicoMenu;
    }

    public override void MostarOpcoes()
    {
        var formula = SelecionarFormula();
        if (formula == null)
        {
            Voltar();
            return;
        }

        Console.WriteLine($"\nFórmula escolhida: {formula.Expressao}");

        var p = LerBool("Valor de P (T/F): ");
        var q = LerBool("Valor de Q (T/F): ");
        var r = LerBool("Valor de R (T/F): ");

        var resultado = _servico.Avaliar(formula, p, q, r);
        Console.WriteLine($"\nResultado: {formula.Expressao} = {BoolStr(resultado)}");

        Console.Write("\nGerar tabela-verdade completa? (S/N): ");
        var opt = Console.ReadLine()?.Trim().ToUpper();
        if (opt == "S")
            ImprimirTabela(formula);

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
        Voltar();
    }

    private FormulaProposicional? SelecionarFormula()
    {
        Console.WriteLine("\nFormulas disponíveis:");
        foreach (var f in _servico.Listar())
            Console.WriteLine($"{f.Id} - {f.Nome} ({f.Expressao})");

        Console.Write("Escolha o id: ");
        var input = Console.ReadLine();
        if (!int.TryParse(input, out var id))
            return null;
        return _servico.Obter(id);
    }

    private bool LerBool(string msg)
    {
        while (true)
        {
            Console.Write(msg);
            var txt = Console.ReadLine()?.Trim().ToUpper();
            if (txt is "T" or "1" or "V") return true;
            if (txt is "F" or "0") return false;
            Console.WriteLine("Entrada inválida. Use T/F.");
        }
    }

    private void ImprimirTabela(FormulaProposicional f)
    {
        Console.WriteLine($"\nTabela-verdade de {f.Expressao}:");
        Console.WriteLine("P Q R | F");
        Console.WriteLine("-------------");
        foreach (var linha in _servico.GerarTabela(f))
            Console.WriteLine($"{BoolStr(linha.P)} {BoolStr(linha.Q)} {BoolStr(linha.R)} | {BoolStr(linha.Resultado)}");
    }

    private string BoolStr(bool b) => b ? "T" : "F";

    private void Voltar() => _servicoMenu.AlterarMenu(new MenuPrincipal(_servicoMenu));
}