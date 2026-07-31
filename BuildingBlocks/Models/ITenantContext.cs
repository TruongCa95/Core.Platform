namespace BuildingBlocks.Models;

public interface ITenantContext
{
    string? TenantId { get; set; }
}
