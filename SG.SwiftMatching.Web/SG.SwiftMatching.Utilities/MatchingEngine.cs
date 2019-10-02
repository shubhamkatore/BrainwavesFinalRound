using SG.SwiftMatching.Models;

namespace SG.SwiftMatching.Utilities
{
    public class MatchingEngine
    {
        public static string Match(Message clentData, Message sgMessage)
        {
            if (    clentData.PartA == sgMessage.PartB &&
                    clentData.ISDADate == sgMessage.ISDADate &&
                    clentData.ContractDate == sgMessage.ContractDate &&
                    clentData.ValueDate == sgMessage.ValueDate &&
                    clentData.ExchangeRate == sgMessage.ExchangeRate &&
                    clentData.WeBuy == sgMessage.WeSell &&
                    clentData.Intermed1 == sgMessage.Intermed2 &&
                    clentData.Settle1 == sgMessage.Settle2 &&
                    clentData.Ben1 == sgMessage.Ben2
                    ) return "Matched";

            if (clentData.PartA == sgMessage.PartB &&
                    clentData.ISDADate == sgMessage.ISDADate &&
                    clentData.ContractDate == sgMessage.ContractDate &&
                    clentData.Intermed1 == sgMessage.Intermed2 &&
                    clentData.Settle1 == sgMessage.Settle2 &&
                    clentData.Ben1 == sgMessage.Ben2
                    ) {
                var valDate = clentData.ValueDate == sgMessage.ValueDate;
                var excData = clentData.ExchangeRate == sgMessage.ExchangeRate;
                var buySell = clentData.WeBuy == sgMessage.WeSell;
                if ((valDate && excData)||(excData && buySell) || (valDate && buySell) )
                return "Mismatch";
            }

            return "Unmatched";
        }
    }
}
