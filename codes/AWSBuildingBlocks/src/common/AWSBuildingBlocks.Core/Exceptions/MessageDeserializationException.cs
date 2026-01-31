namespace AWSBuildingBlocks.Core.Exceptions;

/// <summary>
/// Exceção lançada quando ocorre falha na desserialização de uma mensagem
/// recebida pela plataforma.
///
/// Normalmente indica incompatibilidade de contrato, schema inválido,
/// versão incorreta da mensagem ou dados corrompidos.
/// Não deve ser tratada como fluxo esperado e, em geral, NÃO é elegível
/// a retry automático, pois o erro ocorre antes da execução do handler.
/// </summary>
public sealed class MessageDeserializationException : PlatformException
{
    public MessageDeserializationException(string messageType)
        : base(
            code: "MESSAGE_DESERIALIZATION_FAILED",
            messageTemplate: "Falha ao desserializar mensagem do tipo '{messageType}'.",
            isExpected: false,
            context: new Dictionary<string, object>
            {
                ["messageType"] = messageType
            })
    {
    }
}
