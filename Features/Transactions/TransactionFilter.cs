using System;
using PersonalExpenseTracker.Domains;

namespace PersonalExpenseTracker.Features.Transactions
{
    /// <summary>Ordering options for the transaction list, applied in the database.</summary>
    public enum TransactionSort
    {
        NewestFirst,
        OldestFirst,
        HighestAmount,
        LowestAmount
    }

    /// <summary>
    /// Every optional clause the transaction list can apply. Null members mean
    /// "no restriction", which is what the unfiltered call site passes.
    /// </summary>
    public class TransactionFilter
    {
        /// <summary>Free text matched against description, reference, merchant and category name.</summary>
        public string? Search { get; set; }

        public TransactionType? Type { get; set; }

        public long? CategoryId { get; set; }

        public PaymentMethod? PaymentMethod { get; set; }

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }

        public TransactionSort Sort { get; set; } = TransactionSort.NewestFirst;
    }
}
