namespace AWSBuildingBlocks.Core.Exceptions;

/// <summary>
/// Exceção lançada quando um recurso esperado não é localizado
/// durante a execução de uma operação da plataforma.
///
/// Indica que a requisição é válida e bem-formada, porém o estado
/// atual do sistema não contém o recurso solicitado.
///
/// Esta exceção representa um fluxo esperado de negócio,
/// normalmente não elegível a retry automático,
/// pois a ausência do recurso tende a ser determinística.
/// </summary>
public sealed class NotFoundException : PlatformException
{
    public NotFoundException(
        string resourceType,
        string resourceIdentifier)
        : base(
            code: "RESOURCE_NOT_FOUND",
            messageTemplate:
                "Recurso do tipo '{resourceType}' com identificador '{resourceIdentifier}' não foi encontrado.",
            isExpected: true,
            context: new Dictionary<string, object>
            {
                ["resourceType"] = resourceType,
                ["resourceIdentifier"] = resourceIdentifier
            })
    {
    }
}
