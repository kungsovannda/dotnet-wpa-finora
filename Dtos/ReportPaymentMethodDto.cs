using System;
using PersonalExpenseTracker.Domains;

namespace PersonalExpenseTracker.Dtos
{
    public class ReportPaymentMethodDto
    {
        public PaymentMethod PaymentMethod { get; set; }

        public string Label { get; set; } = string.Empty;

        public decimal Total { get; set; }

        public int Count { get; set; }
    }
}
