namespace AWSBuildingBlocks.Core.Responses;

/// <summary>
/// Representa a resposta padronizada de uma operação executada
/// pela plataforma, podendo ou não retornar dados.
/// </summary>
/// <typeparam name="TEntity">
/// Tipo da entidade ou dado retornado pela operação.
/// Para operações sem retorno, utilize <see cref="object"/> ou um tipo Unit.
/// </typeparam>
/// <remarks>
/// Esta classe faz parte do Core compartilhado da arquitetura.
/// É completamente agnóstica de transporte e não deve conter
/// qualquer informação relacionada a HTTP, mensageria ou protocolos externos.
/// </remarks>
public sealed class BaseResponse<TEntity>
{
    /// <summary>
    /// Indica se a operação foi concluída com sucesso.
    /// </summary>
    public bool Success { get; }

    /// <summary>
    /// Dados retornados pela operação quando bem-sucedida.
    /// Será <c>default</c> quando a operação não possuir retorno
    /// ou quando <see cref="Success"/> for <c>false</c>.
    /// </summary>
    public TEntity? Data { get; }

    /// <summary>
    /// Informações detalhadas do erro quando a operação falha.
    /// Será <c>null</c> quando <see cref="Success"/> for <c>true</c>.
    /// </summary>
    public ErrorResponse? Error { get; }

    /// <summary>
    /// Lista de avisos gerados durante a execução da operação.
    /// Avisos não indicam falha.
    /// </summary>
    public IReadOnlyCollection<string> Warnings { get; }

    /// <summary>
    /// Identificador de correlação da execução.
    /// Usado para rastreamento distribuído e observabilidade.
    /// </summary>
    public string CorrelationId { get; }

    /// <summary>
    /// Metadados técnicos associados à execução da operação.
    /// Podem ser utilizados para logging, diagnóstico ou auditoria.
    /// </summary>
    public IReadOnlyDictionary<string, string> Metadata { get; }

    /// <summary>
    /// Data e hora (UTC) em que a resposta foi criada.
    /// </summary>
    public DateTimeOffset Timestamp { get; }

    private BaseResponse(
        bool success,
        TEntity? data,
        ErrorResponse? error,
        IEnumerable<string>? warnings,
        IDictionary<string, string>? metadata,
        string correlationId)
    {
        Success = success;
        Data = data;
        Error = error;
        Warnings = warnings?.ToArray() ?? Array.Empty<string>();
        Metadata = new Dictionary<string, string>(metadata ?? new Dictionary<string, string>());
        CorrelationId = correlationId;
        Timestamp = DateTimeOffset.UtcNow;
    }

    // ----------------- FACTORIES -----------------

    #region Factories

    /// <summary>
    /// Cria uma resposta de sucesso sem retorno de dados.
    /// </summary>
    public static BaseResponse<TEntity> Ok(string correlationId)
        => new(
            success: true,
            data: default,
            error: null,
            warnings: null,
            metadata: null,
            correlationId: correlationId);

    /// <summary>
    /// Cria uma resposta de sucesso contendo os dados informados.
    /// </summary>
    public static BaseResponse<TEntity> Ok(
        TEntity data,
        string correlationId,
        IEnumerable<string>? warnings = null,
        IDictionary<string, string>? metadata = null)
        => new(
            success: true,
            data: data,
            error: null,
            warnings: warnings,
            metadata: metadata,
            correlationId: correlationId);

    /// <summary>
    /// Cria uma resposta de falha contendo as informações do erro.
    /// </summary>
    public static BaseResponse<TEntity> Fail(
        ErrorResponse error,
        string correlationId,
        IDictionary<string, string>? metadata = null)
        => new(
            success: false,
            data: default,
            error: error,
            warnings: null,
            metadata: metadata,
            correlationId: correlationId);

    #endregion  
}
