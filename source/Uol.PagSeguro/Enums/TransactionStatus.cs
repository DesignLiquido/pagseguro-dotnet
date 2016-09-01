using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uol.PagSeguro.Enums
{
    /// <summary>
    /// Defines a list of known transaction statuses.
    /// </summary>
    /// <remarks>
    /// This class is not an enum to enable the introduction of new transaction statuses
    /// without breaking this version of the library.
    /// </remarks>
    public enum TransactionStatus
    {
        /// <summary>
        /// Initiated
        /// </summary>
        Initiated = 0,

        /// <summary>
        /// Waiting payment
        /// </summary>
        WaitingPayment = 1,

        /// <summary>
        /// In analysis
        /// </summary>
        InAnalysis = 2,

        /// <summary>
        /// Paid
        /// </summary>
        Paid = 3,

        /// <summary>
        /// Available
        /// </summary>
        Available = 4,

        /// <summary>
        /// In dispute
        /// </summary>
        InDispute = 5,

        /// <summary>
        /// Refunded
        /// </summary>
        Refunded = 6,

        /// <summary>
        /// Cancelled
        /// </summary>
        Cancelled = 7,
    }
}
