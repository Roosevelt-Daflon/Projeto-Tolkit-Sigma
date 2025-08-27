using Projeto_Tolkit_Sigma.Servicos;

namespace Projeto_Tolkit_Sigma.Menus;

public class MenuPrincipal : BaseMenu
{
    private readonly ServicoMenu _servicoMenu;
    public override string Titulo { get => "Menu Principal"; } 

    public MenuPrincipal(ServicoMenu servicoMenu) : base(servicoMenu)
    {
        _servicoMenu = servicoMenu;
        Opcoes.Clear();
        Opcoes.Add(new MenuVerificadorAlfabetoCadeia(servicoMenu));
        Opcoes.Add(new MenuClassificadorTIM(servicoMenu));
        Opcoes.Add(new MenuAvaliadorProposicional(servicoMenu));
        Opcoes.Add(new MenuReconhecedorLinguagensSimples(servicoMenu)); // novo
    }

    public override void MostarOpcoes()
    {
        Console.WriteLine("1 - Verficador de Alfabeto e Cadeia");
        Console.WriteLine("2 - Classificador T/I/N por JSON");
        Console.WriteLine("3 - Avaliador Proposicional");
        Console.WriteLine("4 - Reconhecedor Σ={a,b}");
        Console.Write("Escolha uma opção: ");
        var opcaoInput = Console.ReadLine();

        if(!int.TryParse(opcaoInput, out var opcao) || opcao < 1 || opcao > Opcoes.Count)
        {
            Console.WriteLine("Opção inválida. Tente novamente.");
            Console.ReadKey();
            _servicoMenu.AlterarMenu(this);
            return;
        }

        _servicoMenu.AlterarMenu(Opcoes[opcao-1]);
    }
}