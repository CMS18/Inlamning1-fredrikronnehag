using System;
using System.ComponentModel.DataAnnotations;

namespace InlamningEtt.WebUI.Models
{
    public class TransactionViewModel
    {
        public DepositDto Deposit { get; set; }
        public WithdrawDto Withdraw { get; set; }
    }

    public abstract class TransactionDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int AccountID { get; set; }

        [Required]
        [Range(1.0, double.MaxValue)]
        public decimal Amount { get; set; }
    }

    public class DepositDto : TransactionDto
    {

    }

    public class WithdrawDto : TransactionDto
    {

    }
}
