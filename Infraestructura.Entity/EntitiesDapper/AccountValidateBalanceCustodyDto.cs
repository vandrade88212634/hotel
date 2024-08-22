namespace Infraestructura.Entity.EntitiesDapper
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class AccountValidateBalanceCustodyDto
    {
        public DateTime? TransactionDate { get; set; }

        public string AccountNumber { get; set; }

        public string ShortName { get; set; }

        public string AgentCode { get; set; }

        public decimal? frozenMonth { get; set; }

        public decimal? frozenTIES { get; set; }

        public decimal? ReturnTIES { get; set; }

        public decimal? frozenTIESEXTRA { get; set; }

        public decimal? ValueTransfer { get; set; }

        public decimal? balance { get; set; }

        public string identificada { get; set; }
    }
}
