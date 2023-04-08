namespace StoreProject.Api.DAL.Entities
{
    public sealed record PropertyValue(Guid Id, Guid PropertyId, Guid ProductId, string Value);
}
