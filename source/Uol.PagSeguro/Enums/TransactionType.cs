// Copyright [2011] [PagSeguro Internet Ltda.]
//
//   Licensed under the Apache License, Version 2.0 (the "License"),
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.


namespace Uol.PagSeguro.Enums
{
    /// <summary>
    /// Defines a list of known transaction types.
    /// </summary>
    /// <remarks>
    /// This class is not an enum to enable the introduction of new shipping types
    /// without breaking this version of the library.
    /// </remarks>
    public enum TransactionType
    {
        /// <summary>
        /// Payment
        /// </summary>
        Payment = 1,

        /// <summary>
        /// Transfer
        /// </summary>
        Transfer = 2,

        /// <summary>
        /// Fund addition
        /// </summary>
        FundAddition = 3,

        /// <summary>
        /// Withdraw
        /// </summary>
        Withdraw = 4,

        /// <summary>
        /// Charge
        /// </summary>
        Charge = 5,
        
        /// <summary>
        /// Donation
        /// </summary>
        Donation = 6,

        /// <summary>
        /// Bonus
        /// </summary>
        Bonus = 7,

        /// <summary>
        /// Bonus repass
        /// </summary>
        BonusRepass = 8,

        /// <summary>
        /// Operational
        /// </summary>
        Operational = 9,

        /// <summary>
        /// Political donation
        /// </summary>
        PoliticalDonation = 10,
    }
}
