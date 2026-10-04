using System;
using System.Collections.Generic;
using PersonalExpenseTracker.Domains;

namespace PersonalExpenseTracker.Utils
{
    /// <summary>A payment method paired with the name a person would say out loud.</summary>
    public sealed class PaymentMethodOption
    {
        public PaymentMethodOption(PaymentMethod method, string label)
        {
            Method = method;
            Label = label;
        }

        public PaymentMethod Method { get; }

        public string Label { get; }

        public override string ToString() => Label;
    }

    /// <summary>
    /// Display names for <see cref="PaymentMethod"/>. Kept in one place so the
    /// transaction form, the transaction filter and the payment-method report
    /// all spell the same method the same way. Bind a combo to
    /// <see cref="Options"/> rather than to raw enum values, so a name and the
    /// value it stands for can never drift apart.
    /// </summary>
    public static class PaymentMethods
    {
        private static readonly PaymentMethodOption[] OptionsList = BuildOptions();

        public static IReadOnlyList<PaymentMethodOption> Options => OptionsList;

        public static string Label(PaymentMethod method)
        {
            foreach (var option in OptionsList)
            {
                if (option.Method == method)
                    return option.Label;
            }

            return method.ToString();
        }

        private static PaymentMethodOption[] BuildOptions()
        {
            var values = (PaymentMethod[])Enum.GetValues(typeof(PaymentMethod));
            var options = new PaymentMethodOption[values.Length];

            for (int i = 0; i < values.Length; i++)
                options[i] = new PaymentMethodOption(values[i], Name(values[i]));

            return options;
        }

        private static string Name(PaymentMethod method)
        {
            return method switch
            {
                PaymentMethod.CASH => "Cash",
                PaymentMethod.BANK_TRANSFER => "Bank Transfer",
                PaymentMethod.DEBIT_CARD => "Debit Card",
                PaymentMethod.CREDIT_CARD => "Credit Card",
                PaymentMethod.MOBILE_WALLET => "Mobile Wallet",
                _ => "Other"
            };
        }
    }
}
