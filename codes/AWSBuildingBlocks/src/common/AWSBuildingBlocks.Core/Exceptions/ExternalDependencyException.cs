namespace AWSBuildingBlocks.Core.Exceptions;

/// <summary>
/// Exceção lançada quando ocorre uma falha ao interagir com
/// uma dependência externa à plataforma.
///
/// Representa um erro esperado de integração, normalmente causado por
/// indisponibilidade, timeout, falha de comunicação ou resposta inválida
/// de serviços externos como APIs, filas, bancos ou provedores cloud.
/// </summary>
public sealed class ExternalDependencyException : PlatformException
{
    public ExternalDependencyException(string dependency)
        : base(
            code: "EXTERNAL_DEPENDENCY_FAILURE",
            messageTemplate:
                "Falha ao interagir com a dependência externa '{dependency}'.",
            isExpected: true,
            context: new Dictionary<string, object>
            {
                ["dependency"] = dependency
            })
    {
    }
}
