namespace LinkEcommerce.ServiceDefaults.Contexts;

public class BaseEntity
{
    [Key]
    public Guid Id {get;set;}
    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTimeOffset? ModifiedDate { get; set; }
    public bool State { get; set; }
}