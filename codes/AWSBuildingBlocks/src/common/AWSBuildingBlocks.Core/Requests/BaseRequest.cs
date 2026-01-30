namespace AWSBuildingBlocks.Core.Requests;

/// <summary>
/// Representa a requisição padronizada de uma operação executada
/// pela plataforma.
/// </summary>
/// <typeparam name="TEntity">
/// Tipo do dado necessário para executar a operação.
/// Para operações sem payload, utilize <see cref="object"/> ou um tipo Unit.
/// </typeparam>
/// <remarks>
/// Esta classe faz parte do Core compartilhado da arquitetura.
/// É completamente agnóstica de transporte e não deve conter
/// qualquer informação relacionada a HTTP, mensageria ou protocolos externos.
/// </remarks>
public sealed class BaseRequest<TEntity>
{
    /// <summary>
    /// Dados necessários para a execução da operação.
    /// Pode ser <c>default</c> para operações sem payload.
    /// </summary>
    public TEntity? Data { get; }

    /// <summary>
    /// Identificador de correlação da execução.
    /// Usado para rastreamento distribuído e observabilidade.
    /// </summary>
    public string CorrelationId { get; }

    /// <summary>
    /// Identificador de idempotência da operação.
    /// Usado para evitar execuções duplicadas em cenários distribuídos.
    /// </summary>
    public string? IdempotencyKey { get; }

    /// <summary>
    /// Metadados técnicos associados à requisição.
    /// Podem ser utilizados para logging, diagnóstico, auditoria
    /// ou controle de comportamento da execução.
    /// </summary>
    public IReadOnlyDictionary<string, string> Metadata { get; }

    /// <summary>
    /// Data e hora (UTC) em que a requisição foi criada.
    /// </summary>
    public DateTimeOffset Timestamp { get; }

    /// <summary>
    /// Tempo máximo esperado para a execução da operação.
    /// Pode ser utilizado por handlers, workers ou orquestradores.
    /// </summary>
    public TimeSpan? Timeout { get; }

    private BaseRequest(
        TEntity? data,
        string correlationId,
        string? idempotencyKey,
        IDictionary<string, string>? metadata,
        TimeSpan? timeout)
    {
        Data = data;
        CorrelationId = correlationId;
        IdempotencyKey = idempotencyKey;
        Metadata = new Dictionary<string, string>(metadata ?? new Dictionary<string, string>());
        Timeout = timeout;
        Timestamp = DateTimeOffset.UtcNow;
    }

    #region Factories

    /// <summary>
    /// Cria uma requisição sem payload.
    /// </summary>
    public static BaseRequest<TEntity> Create(
        string correlationId,
        string? idempotencyKey = null,
        IDictionary<string, string>? metadata = null,
        TimeSpan? timeout = null)
        => new(
            data: default,
            correlationId: correlationId,
            idempotencyKey: idempotencyKey,
            metadata: metadata,
            timeout: timeout);

    /// <summary>
    /// Cria uma requisição contendo os dados informados.
    /// </summary>
    public static BaseRequest<TEntity> Create(
        TEntity data,
        string correlationId,
        string? idempotencyKey = null,
        IDictionary<string, string>? metadata = null,
        TimeSpan? timeout = null)
        => new(
            data: data,
            correlationId: correlationId,
            idempotencyKey: idempotencyKey,
            metadata: metadata,
            timeout: timeout);

    #endregion
}
