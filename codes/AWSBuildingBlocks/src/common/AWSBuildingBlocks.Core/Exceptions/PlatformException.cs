namespace AWSBuildingBlocks.Core.Exceptions;

/// <summary>
/// Representa a exceção base da plataforma.
/// </summary>
/// <remarks>
/// <para>
/// Esta classe define o contrato central de erros da plataforma,
/// garantindo padronização, previsibilidade e rastreabilidade
/// em todos os contextos de execução (APIs, mensageria, jobs e serviços).
/// </para>
/// <para>
/// A <see cref="PlatformException"/> é responsável por:
/// <list type="bullet">
/// <item>Definir um código de erro estável e semanticamente significativo.</item>
/// <item>Classificar falhas como esperadas ou inesperadas.</item>
/// <item>Construir mensagens descritivas a partir de templates.</item>
/// <item>Normalizar metadados para logging, tracing e observabilidade.</item>
/// </list>
/// </para>
/// <para>
/// Exceções concretas NÃO devem conter lógica de formatação de mensagens
/// nem de composição de metadados. Elas apenas descrevem o contexto do erro.
/// </para>
/// </remarks>
public abstract class PlatformException : Exception
{
    /// <summary>
    /// Código único e estável que identifica o tipo de erro
    /// dentro da plataforma.
    /// </summary>
    public string Code { get; }

    /// <summary>
    /// Indica se a exceção representa uma falha esperada do domínio
    /// ou um erro inesperado da plataforma.
    /// </summary>
    /// <remarks>
    /// Exceções esperadas normalmente não disparam alertas críticos
    /// e podem ser tratadas de forma controlada, como:
    /// validações, conflitos de estado ou violações de acesso.
    /// </remarks>
    public bool IsExpected { get; }

    /// <summary>
    /// Metadados estruturados associados à exceção.
    /// </summary>
    /// <remarks>
    /// Estes dados são utilizados para observabilidade,
    /// diagnóstico, auditoria e correlação de eventos
    /// em ambientes distribuídos.
    /// </remarks>
    public IReadOnlyDictionary<string, object> Metadata { get; }


    protected PlatformException(
        string code,
        string messageTemplate,
        bool isExpected,
        IReadOnlyDictionary<string, object>? context = null,
        Exception? innerException = null)
        : base(BuildMessage(messageTemplate, context), innerException)
    {
        Code = code;
        IsExpected = isExpected;
        Metadata = BuildMetadata(context);
    }

    /// <summary>
    /// Constrói a mensagem final da exceção a partir de um template
    /// e de um contexto semântico.
    /// </summary>
    private static string BuildMessage(
        string template,
        IReadOnlyDictionary<string, object>? context)
    {
        if (context == null || context.Count == 0)
            return template;

        foreach (var item in context)
        {
            var value = item.Value?.ToString() ?? string.Empty;
            template = template.Replace($"{{{item.Key}}}", value);
        }

        return template;
    }

    /// <summary>
    /// Normaliza e materializa os metadados da exceção,
    /// garantindo isolamento e imutabilidade semântica.
    /// </summary>
    private static IReadOnlyDictionary<string, object> BuildMetadata(
        IReadOnlyDictionary<string, object>? context)
    {
        return context == null
            ? new Dictionary<string, object>()
            : new Dictionary<string, object>(context);
    }
}
