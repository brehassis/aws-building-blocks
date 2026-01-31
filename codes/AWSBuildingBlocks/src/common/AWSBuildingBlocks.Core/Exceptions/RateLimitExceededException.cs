namespace AWSBuildingBlocks.Core.Exceptions;

/// <summary>
/// Exceção lançada quando um limite de requisições é excedido,
/// conforme políticas de rate limiting definidas pela plataforma.
///
/// Indica que a operação solicitada é válida, porém foi recusada
/// temporariamente para proteger recursos, garantir estabilidade
/// do sistema ou aplicar políticas de uso justo.
///
/// Esta exceção representa um fluxo esperado e normalmente
/// é elegível a retry com backoff, respeitando o tempo de espera
/// imposto pelo mecanismo de limitação.
/// </summary>
public sealed class RateLimitExceededException : PlatformException
{
    public RateLimitExceededException(string limiter)
        : base(
            code: "RATE_LIMIT_EXCEEDED",
            messageTemplate:
                "O limite de requisições definido por '{limiter}' foi excedido.",
            isExpected: true,
            context: new Dictionary<string, object>
            {
                ["limiter"] = limiter
            })
    {
    }
}
