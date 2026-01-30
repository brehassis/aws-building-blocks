namespace AWSBuildingBlocks.Core.Responses;

/// <summary>
/// Representa um código de erro semântico e estável.
/// Os códigos devem ser definidos por cada contexto da plataforma.
/// </summary>
public readonly record struct ErrorCodeResponse(string Value)
{
    /// <inheritdoc />
    public override string ToString() => Value;
}
