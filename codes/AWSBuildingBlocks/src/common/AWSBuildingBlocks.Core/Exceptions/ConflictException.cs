namespace AWSBuildingBlocks.Core.Exceptions;

/// <summary>
/// Exceção lançada quando o estado atual de um recurso
/// entra em conflito com a execução de uma operação solicitada,
/// impedindo sua realização.
///
/// Representa uma condição esperada de negócio ou de orquestração,
/// normalmente causada por pré-condições não atendidas.
/// </summary>
public sealed class ConflictException : PlatformException
{
    public ConflictException(
        string operation,
        string reason)
        : base(
            code: "STATE_CONFLICT",
            messageTemplate:
                "Conflito de estado ao executar a operação '{operation}'. Motivo: {reason}.",
            isExpected: true,
            context: new Dictionary<string, object>
            {
                ["operation"] = operation,
                ["reason"] = reason
            })
    {
    }
}
