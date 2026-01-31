namespace AWSBuildingBlocks.Core.Exceptions;

/// <summary>
/// Exceção lançada quando uma operação falha de forma genérica,
/// sem que seja possível classificá-la imediatamente como
/// erro de validação, conflito de estado ou falha de dependência externa.
///
/// Normalmente indica uma falha técnica ou lógica inesperada
/// durante a execução de uma operação válida, podendo envolver
/// erros internos, estados inconsistentes ou exceções não mapeadas.
///
/// Deve ser utilizada como último recurso, quando não há
/// uma exceção mais específica que represente corretamente
/// a causa da falha.
/// </summary>
public sealed class OperationFailedException : PlatformException
{
    public OperationFailedException(string operation)
        : base(
            code: "OPERATION_FAILED",
            messageTemplate: "A operação '{operation}' falhou.",
            isExpected: false,
            context: new Dictionary<string, object>
            {
                ["operation"] = operation
            })
    {
    }
}
