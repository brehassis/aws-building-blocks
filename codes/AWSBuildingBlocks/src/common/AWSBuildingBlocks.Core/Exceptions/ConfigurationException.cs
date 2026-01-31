namespace AWSBuildingBlocks.Core.Exceptions;

/// <summary>
/// Exceção lançada quando uma configuração obrigatória da plataforma
/// está ausente, inválida ou malformada, impedindo a execução correta do sistema.
/// 
/// Normalmente indica erro de ambiente, infraestrutura ou provisionamento,
/// e não deve ser tratada como fluxo esperado da aplicação.
/// </summary>
public sealed class ConfigurationException : PlatformException
{
    public ConfigurationException(string configurationKey)
        : base(
            code: "INVALID_CONFIGURATION",
            messageTemplate:
                "Configuração inválida, ausente ou malformada para a chave '{configurationKey}'.",
            isExpected: false,
            context: new Dictionary<string, object>
            {
                ["configurationKey"] = configurationKey
            })
    {
    }
}
