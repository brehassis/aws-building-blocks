namespace AWSBuildingBlocks.Core.Exceptions;

/// <summary>
/// Exceção lançada quando dados de entrada fornecidos à plataforma
/// não atendem às regras de validação definidas pelo domínio,
/// contratos ou políticas de uso.
///
/// Indica erro de uso da API, comando ou mensagem,
/// onde a solicitação é estruturalmente válida,
/// porém semanticamente incorreta.
///
/// Esta exceção representa uma falha esperada,
/// não deve ser elegível a retry automático
/// e normalmente exige correção da entrada pelo consumidor.
/// </summary>
public sealed class ValidationException : PlatformException
{
    public ValidationException(
        string target,
        string reason,
        Exception? innerException = null)
        : base(
            code: "VALIDATION_FAILED",
            messageTemplate:
                "Falha de validação no alvo '{target}'. Motivo: {reason}.",
            isExpected: true,
            context: new Dictionary<string, object>
            {
                ["target"] = target,
                ["reason"] = reason
            },
            innerException: innerException)
    {
    }
}
