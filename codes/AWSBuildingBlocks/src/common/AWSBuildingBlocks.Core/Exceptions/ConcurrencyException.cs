namespace AWSBuildingBlocks.Core.Exceptions;

/// <summary>
/// Exceção lançada quando ocorre um conflito de concorrência
/// durante a execução de uma operação sobre um recurso compartilhado.
///
/// Indica que o estado do recurso foi alterado por outro processo,
/// thread ou instância concorrente entre a leitura e a tentativa
/// de gravação da operação atual.
///
/// Esta exceção representa uma falha esperada em sistemas concorrentes
/// e distribuídos e normalmente é elegível a retry automático,
/// desde que a operação seja idempotente.
/// </summary>
public sealed class ConcurrencyException : PlatformException
{
    public ConcurrencyException(
        string resourceType,
        string resourceIdentifier,
        string operation,
        Exception? innerException = null)
        : base(
            code: "CONCURRENCY_CONFLICT",
            messageTemplate:
                "Conflito de concorrência ao executar a operação '{operation}' no recurso '{resourceType}' com identificador '{resourceIdentifier}'.",
            isExpected: true,
            context: new Dictionary<string, object>
            {
                ["resourceType"] = resourceType,
                ["resourceIdentifier"] = resourceIdentifier,
                ["operation"] = operation
            },
            innerException: innerException)
    {
    }
}
