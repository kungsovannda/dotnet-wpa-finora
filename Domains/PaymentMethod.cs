namespace PersonalExpenseTracker.Domains
{
    /// <summary>
    /// How money physically moved. An enum rather than free text so spending
    /// can be aggregated by method without a pile of near-duplicate spellings
    /// such as "cash", "Cash" and "CASH".
    /// </summary>
    public enum PaymentMethod
    {
        CASH,
        BANK_TRANSFER,
        DEBIT_CARD,
        CREDIT_CARD,
        MOBILE_WALLET,
        OTHER
    }
}
