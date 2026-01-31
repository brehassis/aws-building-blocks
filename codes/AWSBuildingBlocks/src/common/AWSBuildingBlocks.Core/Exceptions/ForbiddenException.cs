namespace AWSBuildingBlocks.Core.Exceptions;

/// <summary>
/// Exceção lançada quando uma identidade autenticada tenta executar
/// uma operação para a qual não possui autorização.
///
/// Representa uma violação de política de acesso (authorization),
/// e não um erro de autenticação ou falha técnica da plataforma.
/// </summary>
/// <remarks>
/// Normalmente mapeada para HTTP 403 (Forbidden).
/// É considerada uma falha esperada e controlável pelo domínio
/// ou pela camada de aplicação.
/// </remarks>
public sealed class ForbiddenException : PlatformException
{
    public ForbiddenException(
        string actor,
        string operation,
        string resource)
        : base(
            code: "FORBIDDEN_OPERATION",
            messageTemplate:
                "A identidade '{actor}' não possui permissão para executar a operação '{operation}' no recurso '{resource}'.",
            isExpected: true,
            context: new Dictionary<string, object>
            {
                ["actor"] = actor,
                ["operation"] = operation,
                ["resource"] = resource
            })
    {
    }
}
