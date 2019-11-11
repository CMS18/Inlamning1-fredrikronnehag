namespace InlamningEtt.WebUI.Models
{
    public class TransactionViewModel
    {
        public decimal Deposit { get; set; } = 0M;
        public decimal Withdraw { get; set; } = 0M;
        public int AccountID { get; set; }
    }
}
