namespace AWSBuildingBlocks.Core.Exceptions;

/// <summary>
/// Exceção lançada quando uma mensagem válida é corretamente desserializada,
/// porém ocorre uma falha durante sua execução dentro do handler.
///
/// Indica erro de regra de negócio, dependência indisponível,
/// falha transitória ou condição inesperada durante o processamento.
/// 
/// Diferente de erros de desserialização, esta exceção ocorre
/// após a mensagem já ter sido aceita pela plataforma.
/// Normalmente é considerada um erro esperado e pode ser elegível
/// a retry automático, dependendo da causa raiz.
/// </summary>
public sealed class MessageProcessingException : PlatformException
{
    public MessageProcessingException(
        string messageType,
        string handler)
        : base(
            code: "MESSAGE_PROCESSING_FAILED",
            messageTemplate:
                "Falha ao processar mensagem do tipo '{messageType}' no handler '{handler}'.",
            isExpected: true,
            context: new Dictionary<string, object>
            {
                ["messageType"] = messageType,
                ["handler"] = handler
            })
    {
    }
}
