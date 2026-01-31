namespace AWSBuildingBlocks.Core.Exceptions;

/// <summary>
/// Exceção lançada quando um serviço interno ou externo
/// encontra-se temporariamente indisponível,
/// impossibilitando a execução da operação solicitada.
///
/// Indica uma condição transitória da infraestrutura ou dependência,
/// como manutenção, sobrecarga, falhas momentâneas de rede
/// ou interrupções controladas.
///
/// Esta exceção representa um fluxo esperado da plataforma
/// e normalmente é elegível a retry automático com política
/// de backoff e circuit breaker.
/// </summary>
public sealed class ServiceUnavailableException : PlatformException
{
    public ServiceUnavailableException(string serviceName)
        : base(
            code: "SERVICE_UNAVAILABLE",
            messageTemplate:
                "O serviço '{serviceName}' encontra-se indisponível no momento.",
            isExpected: true,
            context: new Dictionary<string, object>
            {
                ["serviceName"] = serviceName
            })
    {
    }
}
