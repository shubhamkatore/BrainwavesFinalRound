using System;
using System.Collections.Generic;
using System.Text;

namespace SG.SwiftMatching.Models
{
    public class Message
    {
        public string ourRef { get; set; }
        /// <summary>
        /// :82
        /// </summary>
        public string PartA { get; set; }
        /// <summary>
        /// :87
        /// </summary>
        public string PartB { get; set; }
        /// <summary>
        /// :77H
        /// </summary>
        public string ISDADate { get; set; }
        /// <summary>
        /// :30T
        /// </summary>
        public string ContractDate { get; set; }
        /// <summary>
        /// :30V
        /// </summary>
        public string ValueDate { get; set; }
        /// <summary>
        /// :36
        /// </summary>
        public string ExchangeRate { get; set; }
        /// <summary>
        /// :32B
        /// </summary>
        public string WeBuy { get; set; }
        /// <summary>
        /// :56
        /// </summary>
        public string Intermed1 { get; set; }
        /// <summary>
        /// :57
        /// </summary>
        public string Settle1 { get; set; }
        /// <summary>
        /// :58
        /// </summary>
        public string Ben1 { get; set; }
        /// <summary>
        /// :33B
        /// </summary>
        public string WeSell { get; set; }
        /// <summary>
        /// :56
        /// </summary>
        public string Intermed2 { get; set; }
        /// <summary>
        /// :57
        /// </summary>
        public string Settle2 { get; set; }
        /// <summary>
        /// :58
        /// </summary>
        public string Ben2 { get; set; }

    }
}
