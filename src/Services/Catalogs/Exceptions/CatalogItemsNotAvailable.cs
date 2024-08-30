namespace LinkEcommerce.Services.Catalogs.Exceptions;

public class CatalogItemNotAvailableException : Exception
{
    public CatalogItemNotAvailableException()
    {
    }

    public CatalogItemNotAvailableException(string? message) : base(message)
    {
    }

    public CatalogItemNotAvailableException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected CatalogItemNotAvailableException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}