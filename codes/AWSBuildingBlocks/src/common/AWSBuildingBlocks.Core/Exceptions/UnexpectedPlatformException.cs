namespace AWSBuildingBlocks.Core.Exceptions;

/// <summary>
/// Exceção lançada quando ocorre uma falha inesperada e não classificada
/// dentro da plataforma.
///
/// Representa erros que escapam das categorias conhecidas do domínio,
/// infraestrutura ou integração, normalmente indicando bugs,
/// estados inválidos não previstos ou falhas internas graves.
///
/// Esta exceção deve ser utilizada exclusivamente como último recurso,
/// geralmente no boundary da aplicação, para encapsular exceções
/// não mapeadas e garantir padronização de observabilidade e resposta.
/// </summary>
public sealed class UnexpectedPlatformException : PlatformException
{
    public UnexpectedPlatformException(Exception innerException)
        : base(
            code: "UNEXPECTED_ERROR",
            messageTemplate: "Ocorreu um erro inesperado na plataforma.",
            isExpected: false,
            context: null,
            innerException: innerException)
    {
    }
}
