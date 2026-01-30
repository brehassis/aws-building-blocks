namespace AWSBuildingBlocks.Core.Enums;

/// <summary>
/// Representa a categoria de alto nível de uma falha ocorrida
/// durante a execução de uma operação da plataforma.
/// </summary>
public enum EErrorCategory
{
    Unknown = 0,
    Validation = 1,
    Business = 2,
    NotFound = 3,
    Conflict = 4,
    Security = 5,
    Infrastructure = 6,
    Configuration = 7,
    Timeout = 8,
    Unavailable = 9,
    
}
