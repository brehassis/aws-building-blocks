namespace AWSBuildingBlocks.Core.Exceptions;

/// <summary>
/// Exceção lançada quando se tenta criar, registrar ou provisionar
/// um recurso que já existe na plataforma.
///
/// Indica um conflito de estado onde a operação solicitada é válida,
/// porém não pode ser concluída porque o recurso alvo já foi
/// previamente criado ou registrado.
///
/// Esta exceção representa uma falha esperada do fluxo de negócio,
/// normalmente NÃO é elegível a retry automático
/// e requer ação corretiva do consumidor.
/// </summary>
public sealed class AlreadyExistsException : PlatformException
{
    public AlreadyExistsException(
        string resourceType,
        string resourceIdentifier,
        string? details = null)
        : base(
            code: "RESOURCE_ALREADY_EXISTS",
            messageTemplate:
                "O recurso do tipo '{resourceType}' com identificador '{resourceIdentifier}' já existe.{details}",
            isExpected: true,
            context: new Dictionary<string, object>
            {
                ["resourceType"] = resourceType,
                ["resourceIdentifier"] = resourceIdentifier,
                ["details"] = string.IsNullOrWhiteSpace(details)
                    ? string.Empty
                    : $" Detalhes: {details}"
            })
    {
    }
}
