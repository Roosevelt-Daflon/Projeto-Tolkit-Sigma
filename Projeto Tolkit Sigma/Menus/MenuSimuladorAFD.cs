using System.Collections.Generic;
using Projeto_Tolkit_Sigma.Servicos;

namespace Projeto_Tolkit_Sigma.Menus;

public class MenuSimuladorAFD : BaseMenu
{
    private readonly ServicoMenu _servicoMenu;
    public override string Titulo => "Simulador de AFD (Σ={a,b})";

    public MenuSimuladorAFD(ServicoMenu servicoMenu) : base(servicoMenu)
    {
        _servicoMenu = servicoMenu;
    }

    public override void MostarOpcoes()
    {
        Console.WriteLine("AFD fixo: L_par_a = { w | #a é par }.");
        Console.Write("Digite w (apenas 'a' e 'b'): ");
        string w = Console.ReadLine() ?? string.Empty;
        if (!AlfabetoValido(w))
        {
            Console.WriteLine("Alfabeto inválido.");
            Pausa();
            return;
        }

        // Definição do AFD
        string estadoInicial = "q0"; // par
        HashSet<string> aceitacao = new HashSet<string> { "q0" };
        Dictionary<(string, char), string> delta = new()
        {
            { ("q0", 'a'), "q1" },
            { ("q0", 'b'), "q0" },
            { ("q1", 'a'), "q0" },
            { ("q1", 'b'), "q1" },
        };

        string estado = estadoInicial;
        Console.WriteLine($"Estado inicial: {estado}");
        for (int i = 0; i < w.Length; i++)
        {
            char s = w[i];
            if (!delta.TryGetValue((estado, s), out string? prox))
            {
                Console.WriteLine($"Transição indefinida em ({estado}, {s}). REJEITA");
                Pausa();
                return;
            }
            Console.WriteLine($"{estado} --{s}--> {prox}");
            estado = prox;
        }

        bool aceita = aceitacao.Contains(estado);
        Console.WriteLine($"\n{(aceita ? "ACEITA" : "REJEITA")}");
        Pausa();
    }

    private static bool AlfabetoValido(string? w)
    {
        if (w is null) return false;
        foreach (char c in w)
            if (c != 'a' && c != 'b') return false;
        return true;
    }

    private void Pausa()
    {
        Console.WriteLine("\nPressione qualquer tecla para voltar...");
        Console.ReadKey();
        _servicoMenu.AlterarMenu(new MenuAV2(_servicoMenu));
    }
}
