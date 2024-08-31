namespace LinkEcommerce.Services.Identity.Models;

public class Card : BaseEntity
{
	public required string Number { get; set; }
	public DateTime ExpirationDate { get; set; }
	public CardType CardType { get; set; }
}

public enum CardType
{
	Credit,
	Debit,
}