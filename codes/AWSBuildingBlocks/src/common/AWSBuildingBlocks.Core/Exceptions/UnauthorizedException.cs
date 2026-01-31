namespace AWSBuildingBlocks.Core.Exceptions;

/// <summary>
/// Exceção lançada quando uma operação é solicitada
/// por uma identidade não autenticada ou com credenciais inválidas.
///
/// Indica que não foi possível estabelecer a identidade do ator
/// que originou a requisição, seja por ausência de credenciais,
/// credenciais expiradas ou falha no processo de autenticação.
///
/// Esta exceção representa um fluxo esperado de segurança
/// e não deve ser tratada como erro da aplicação.
/// </summary>
public sealed class UnauthorizedException : PlatformException
{
    public UnauthorizedException(string actor)
        : base(
            code: "UNAUTHORIZED",
            messageTemplate:
                "A identidade '{actor}' não está autenticada.",
            isExpected: true,
            context: new Dictionary<string, object>
            {
                ["actor"] = actor
            })
    {
    }
}
