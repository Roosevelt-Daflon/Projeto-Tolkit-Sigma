using Projeto_Tolkit_Sigma.Dominio.Modelos;

namespace Projeto_Tolkit_Sigma.Servicos;

public class ServicoAvaliadorProposicional
{
    public bool TratarValorProposicional(string? pInput)
    {
        if (string.IsNullOrWhiteSpace(pInput))
            return false;
        pInput = pInput.Trim().ToLower();
        return pInput == "v" || pInput == "true" || pInput == "1" || pInput == "sim" || pInput == "s";
    }

    public bool AvaliarConjuncao(bool b, bool b1, bool b2)
    {
        return b && b1 && b2;
    }

    public bool AvaliarDisjuncao(bool b, bool b1, bool b2)
    {
        return b || b1 || b2;
    }

    public bool AvaliarImplicacao(bool b, bool b1, bool b2)
    {          
        return !(b && b1) || b2;
    }
}