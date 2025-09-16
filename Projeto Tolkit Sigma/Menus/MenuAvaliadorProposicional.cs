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
        Console.WriteLine("Formulas válidas:");
        Console.WriteLine("conjunção: (p ∧ q ∧ r) - 1");
        Console.WriteLine("disjunção: (p ∨ q ∨ r) - 2");
        Console.WriteLine("implicação: ((p ∧ q) → r) - 3");
        Console.Write("Escolha a fórmula: ");

        var op = Console.ReadLine();
        if (op is not ("1" or "2" or "3"))
        {
            Console.WriteLine("Opção inválida. voltando ao menu principal...");
            Console.ReadLine();
            _servicoMenu.AlterarMenu(new MenuPrincipal(_servicoMenu));
        }
        
        switch (op)
        {
            case "1":
                AvaliarConjuncao();
                break;
            case "2":
                AvaliarDisjuncao();
                break;
            case "3":
                AvaliarImplicacao();
                break;
        }
    }

    private void AvaliarImplicacao()
    {
        Console.WriteLine("Você escolheu a implicação ((p ∧ q) → r).");
        Console.Write("Digite o valor de p (V/F): ");
        var pInput = Console.ReadLine()?.Trim().ToUpper();
        Console.Write("Digite o valor de q (V/F): ");
        var qInput = Console.ReadLine()?.Trim().ToUpper();
        Console.Write("Digite o valor de r (V/F): ");
        var rInput = Console.ReadLine()?.Trim().ToUpper();
        Console.Write("Digite o resultado esperado (V/F): ");
        try
        {
            var p = _servico.TratarValorProposicional(pInput);
            var q = _servico.TratarValorProposicional(qInput);
            var r = _servico.TratarValorProposicional(rInput);
            var resultadoCalculado = _servico.AvaliarImplicacao(p, q, r);
            Console.WriteLine($"\nResultado calculado: {(resultadoCalculado ? "V" : "F")}");
            ImprimirTabelaVerdadeImplicacao();
        }
        catch (Exception e)
        {
            Console.WriteLine("\n" + e.Message);
            AvaliarImplicacao();
            return;
        }
    }

    private void ImprimirTabelaVerdadeImplicacao()
    {
        Console.WriteLine("\nTabela Verdade para ((p ∧ q) → r):");
        Console.WriteLine("P\tQ\tR\tResultado");
        Console.WriteLine("-------------------------------");
        var valores = new[] { true, false };
        foreach (var p in valores)
        {
            foreach (var q in valores)
            {
                foreach (var r in valores)
                {
                    var resultado = _servico.AvaliarImplicacao(p, q, r);
                    Console.WriteLine($"{(p ? "V" : "F")}\t{(q ? "V" : "F")}\t{(r ? "V" : "F")}\t{(resultado ? "V" : "F")}");
                }
            }
        }
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
        _servicoMenu.AlterarMenu(new MenuPrincipal(_servicoMenu));
    }

    private void AvaliarDisjuncao()
    {
        Console.WriteLine("Você escolheu a disjunção (p ∨ q ∨ r).");
        Console.Write("Digite o valor de p (V/F): ");
        var pInput = Console.ReadLine()?.Trim().ToUpper();
        Console.Write("Digite o valor de q (V/F): ");
        var qInput = Console.ReadLine()?.Trim().ToUpper();
        Console.Write("Digite o valor de r (V/F): ");
        var rInput = Console.ReadLine()?.Trim().ToUpper();
        Console.Write("Digite o resultado esperado (V/F): ");

        var p = _servico.TratarValorProposicional(pInput);
        var q = _servico.TratarValorProposicional(qInput);
        var r = _servico.TratarValorProposicional(rInput);
        var resultadoCalculado = _servico.AvaliarDisjuncao(p, q, r);
        Console.WriteLine($"\nResultado calculado: {(resultadoCalculado ? "V" : "F")}");
        ImprimirTabelaVerdadeDejuncao();
    }

    private void ImprimirTabelaVerdadeDejuncao()
    {
        Console.WriteLine("\nTabela Verdade para (p ∨ q ∨ r):");
        Console.WriteLine("P\tQ\tR\tResultado");
        Console.WriteLine("-------------------------------");
        var valores = new[] { true, false };
        foreach (var p in valores)
        {
            foreach (var q in valores)
            {
                foreach (var r in valores)
                {
                    var resultado = _servico.AvaliarDisjuncao(p, q, r);
                    Console.WriteLine($"{(p ? "V" : "F")}\t{(q ? "V" : "F")}\t{(r ? "V" : "F")}\t{(resultado ? "V" : "F")}");
                }
            }
        }
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
        _servicoMenu.AlterarMenu(new MenuPrincipal(_servicoMenu));
    }

    public void AvaliarConjuncao()
    {
        Console.WriteLine("Você escolheu a conjunção (p ∧ q ∧ r).");
        Console.Write("Digite o valor de p (V/F): ");
        var pInput = Console.ReadLine()?.Trim().ToUpper();
        Console.Write("Digite o valor de q (V/F): ");
        var qInput = Console.ReadLine()?.Trim().ToUpper();
        Console.Write("Digite o valor de r (V/F): ");
        var rInput = Console.ReadLine()?.Trim().ToUpper();
        Console.Write("Digite o resultado esperado (V/F): ");
        try
        {
            var p = _servico.TratarValorProposicional(pInput);
            var q = _servico.TratarValorProposicional(qInput);
            var r = _servico.TratarValorProposicional(rInput);
            var resultadoCalculado = _servico.AvaliarConjuncao(p, q, r);
            Console.WriteLine($"\nResultado calculado: {(resultadoCalculado ? "V" : "F")}");


            ImprimirTabelaVerdadeConjuncao();
        }
        catch (Exception e)
        {
            Console.WriteLine("\n" + e.Message);
            AvaliarConjuncao();
            return;
        }
    }

    private void ImprimirTabelaVerdadeConjuncao()
    {
        Console.WriteLine("\nTabela Verdade para (p ∧ q ∧ r):");
        Console.WriteLine("P\tQ\tR\tResultado");
        Console.WriteLine("-------------------------------");
        var valores = new[] { true, false };
        foreach (var p in valores)
        {
            foreach (var q in valores)
            {
                foreach (var r in valores)
                {
                    var resultado = _servico.AvaliarConjuncao(p, q, r);
                    Console.WriteLine($"{(p ? "V" : "F")}\t{(q ? "V" : "F")}\t{(r ? "V" : "F")}\t{(resultado ? "V" : "F")}");
                }
            }
        }
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
        _servicoMenu.AlterarMenu(new MenuPrincipal(_servicoMenu));
    }
}