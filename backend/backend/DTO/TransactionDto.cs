namespace backend.DTO;

public class TransactionDto
{
    decimal Amount { get; set; }
    private string Category { get; set; }
    public string Date { get; set; }
    public string Note { get; set; }
}