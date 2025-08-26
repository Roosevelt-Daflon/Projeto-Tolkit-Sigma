using Projeto_Tolkit_Sigma.Servicos;

namespace Projeto_Tolkit_Sigma.Menus;

public class MenuPrincipal : BaseMenu
{
    private readonly ServicoMenu _servicoMenu;
    public override string Titulo { get => "Menu Principal"; } 
  

    public MenuPrincipal(ServicoMenu servicoMenu) : base(servicoMenu)
    {
        _servicoMenu = servicoMenu;
        Opcoes.Add(new MenuVerificadorAlfabetoCadeia(servicoMenu));
    }
    public override void MostarOpcoes()
    {
        Console.WriteLine("1 - Verficador de Alfabeto e Cadeia");
        Console.Write("Escolha uma opção: ");
        var opcaoInput = Console.ReadLine();

        var opcao = 0;
        
        if(!int.TryParse( opcaoInput, out opcao))
        {
            Console.WriteLine("Opção inválida. Tente novamente.");
            Console.ReadKey();
            _servicoMenu.AlterarMenu(this);
        }

        _servicoMenu.AlterarMenu(Opcoes[opcao-1]);

    }
}