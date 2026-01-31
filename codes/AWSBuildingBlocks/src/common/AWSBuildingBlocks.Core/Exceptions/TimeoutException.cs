namespace AWSBuildingBlocks.Core.Exceptions;

/// <summary>
/// Exceção lançada quando uma operação ultrapassa
/// o tempo máximo permitido para sua execução.
///
/// Indica que a solicitação é válida, porém não pôde
/// ser concluída dentro dos limites temporais definidos
/// por políticas de timeout da plataforma.
///
/// Esta exceção normalmente representa uma condição transitória
/// e pode ser elegível a retry, dependendo do tipo de operação
/// e do contexto de execução.
/// </summary>
public sealed class TimeoutException : PlatformException
{
    public TimeoutException(string operation)
        : base(
            code: "OPERATION_TIMEOUT",
            messageTemplate:
                "A operação '{operation}' excedeu o tempo limite permitido.",
            isExpected: true,
            context: new Dictionary<string, object>
            {
                ["operation"] = operation
            })
    {
    }
}
