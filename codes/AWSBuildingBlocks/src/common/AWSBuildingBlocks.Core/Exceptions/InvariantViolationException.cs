namespace AWSBuildingBlocks.Core.Exceptions;

/// <summary>
/// Exceção lançada quando uma invariante fundamental do domínio
/// é violada, indicando que o sistema entrou em um estado inválido.
///
/// Normalmente representa erro de implementação, corrupção de estado
/// ou quebra de garantias internas do domínio, e não deve ser tratada
/// como fluxo esperado da aplicação.
/// </summary>
public sealed class InvariantViolationException : PlatformException
{
    public InvariantViolationException(string invariant)
        : base(
            code: "INVARIANT_VIOLATION",
            messageTemplate: "A invariante '{invariant}' foi violada.",
            isExpected: false,
            context: new Dictionary<string, object>
            {
                ["invariant"] = invariant
            })
    {
    }
}
