namespace AWSBuildingBlocks.Core.Exceptions;

/// <summary>
/// Representa uma violação de contrato entre componentes da plataforma.
/// </summary>
/// <remarks>
/// Indica quebra de pré ou pós-condição.
/// Geralmente aponta erro de programação.
/// </remarks>
public sealed class ContractViolationException : PlatformException
{
    public ContractViolationException(
        string contractName,
        string details,
        Exception? innerException = null)
        : base(
            code: "CONTRACT_VIOLATION",
            messageTemplate: "Violação do contrato '{contractName}'. Detalhes: {details}.",
            isExpected: false,
            context: new Dictionary<string, object>
            {
                ["contractName"] = contractName,
                ["details"] = details
            },
            innerException: innerException)
    {
    }
}
