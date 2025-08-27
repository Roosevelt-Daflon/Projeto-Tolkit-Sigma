using Projeto_Tolkit_Sigma.Servicos;

namespace Projeto_Tolkit_Sigma.Menus;

public class MenuReconhecedorLinguagensSimples : BaseMenu
{
    private readonly ServicoMenu _servicoMenu;
    private readonly ServicoReconhecedorLinguagensSimples _servico = new();
    public override string Titulo => "Reconhecedor Σ={a,b}: L_par_a e a b*";

    public MenuReconhecedorLinguagensSimples(ServicoMenu servicoMenu) : base(servicoMenu)
    {
        _servicoMenu = servicoMenu;
    }

    public override void MostarOpcoes()
    {
        Console.WriteLine("Linguagens:");
        Console.WriteLine("1 - L_par_a = { w | w tem número par de 'a' }");
        Console.WriteLine("2 - L = { w | w = a b* }");
        Console.Write("Escolha a linguagem (1/2): ");
        var op = Console.ReadLine();

        if (op is not ("1" or "2"))
        {
            Console.WriteLine("Opção inválida.");
            Voltar();
            return;
        }

        Console.Write("Digite a cadeia w: ");
        var w = Console.ReadLine() ?? "";

        if (!_servico.AlfabetoValido(w))
        {
            Console.WriteLine("\nAlfabeto inválido (use apenas 'a' ou 'b'). REJEITA");
            Pausa();
            return;
        }

        bool aceita = op == "1"
            ? _servico.PertenceLParA(w)
            : _servico.PertenceAbEstrela(w);

        Console.WriteLine($"\n{(aceita ? "ACEITA" : "REJEITA")}");
        Pausa();
    }

    private void Pausa()
    {
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
        Voltar();
    }

    private void Voltar() => _servicoMenu.AlterarMenu(new MenuPrincipal(_servicoMenu));
}