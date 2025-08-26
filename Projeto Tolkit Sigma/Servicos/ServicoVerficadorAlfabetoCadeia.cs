namespace Projeto_Tolkit_Sigma.Servicos;

public class ServicoVerficadorAlfabetoCadeia
{
    public char[] TratarAlfabeto(String? alfabeto)
    {
        if(string.IsNullOrEmpty(alfabeto))
            throw new Exception("Alfabeto nulo ou vazio");
        
        var listaAlfabeto = alfabeto.Split(' ');
        if (listaAlfabeto.Length == 0)
            throw new Exception("Alfabeto inválido");
        if(listaAlfabeto.Any(x => x.Length > 1))
            throw new Exception("Alfabeto inválido, cada símbolo deve ter apenas um caracter");
        
        return listaAlfabeto.Select(x => x[0]).ToArray();
    }

    public string TratarCadeia(string? cadeiaInput)
    {
        if(string.IsNullOrEmpty(cadeiaInput))
            throw new Exception("Cadeia nula ou vazia");
        
        if(cadeiaInput.Any(x => x == ' '))
            throw new Exception("Cadeia inválida, não deve conter espaços");
        
        return cadeiaInput;
    }
    
    public bool VerificarCadeiaNoAlfabeto(char[] alfabeto, string cadeia)
    {
        foreach (var caracter in cadeia)
        {
            if(!alfabeto.Contains(caracter))
                return false;
        }

        return true;
    }
}