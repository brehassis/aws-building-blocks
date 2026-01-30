using AWSBuildingBlocks.Core.Enums;

namespace AWSBuildingBlocks.Core.Responses;

/// <summary>
/// Representa um erro estruturado retornado por uma operação da plataforma.
/// Não contém detalhes técnicos como stack trace.
/// </summary>
public sealed record ErrorResponse(
    ErrorCodeResponse Code,
    string Message,
    EErrorCategory Category,
    IReadOnlyDictionary<string, object>? Metadata = null
);
