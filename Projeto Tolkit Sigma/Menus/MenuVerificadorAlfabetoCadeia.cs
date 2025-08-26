using Projeto_Tolkit_Sigma.Servicos;

namespace Projeto_Tolkit_Sigma.Menus;

public class MenuVerificadorAlfabetoCadeia : BaseMenu
{
    private readonly ServicoMenu _servicoMenu;
    public override string Titulo
    {
        get => "Verificador de Alfabeto e Cadeia";
    }
    private static readonly ServicoVerficadorAlfabetoCadeia ServicoVerficador = new();

    public MenuVerificadorAlfabetoCadeia(ServicoMenu servicoMenu) : base(servicoMenu)
    {
        _servicoMenu = servicoMenu;
    }

    public override void MostarOpcoes()
    {
         var listaAlfabeto =  PegarAlfabeto();


        var cadeia = PegarCadeia();
        var resultado = ServicoVerficador.VerificarCadeiaNoAlfabeto(listaAlfabeto, cadeia);
        Console.WriteLine($"\nA cadeia '{cadeia}' é {(resultado ? "" : "in")}válida para o alfabeto informado.");
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
        _servicoMenu.AlterarMenu(new MenuPrincipal(_servicoMenu));
        
    }

    private char[] PegarAlfabeto()
    {
        try
        {
            Console.Write("Digite o alfabeto (separado por espaços): ");
            var alfabetoInput = Console.ReadLine();
            return ServicoVerficador.TratarAlfabeto(alfabetoInput);
        }
        catch (Exception e)
        {
            
            Console.WriteLine("\n" + e.Message);
            return PegarAlfabeto();
        }
        
    }
    
    private string PegarCadeia()
    {
        try
        {
            Console.Write("Digite a cadeia ou apenas um caracter: ");
            var cadeiaInput = Console.ReadLine();
            return ServicoVerficador.TratarCadeia(cadeiaInput);
        }
        catch (Exception e)
        {
            
            Console.WriteLine("\n" + e.Message);
            return PegarCadeia();
        }
        
    }
}