// Copyright [2011] [PagSeguro Internet Ltda.]
//
//   Licensed under the Apache License, Version 2.0 (the "License");
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

using System;
using System.Configuration;
using System.Xml;
using Uol.PagSeguro.Configuration;
using Uol.PagSeguro.Domain;
using Uol.PagSeguro.XmlParse;

namespace Uol.PagSeguro.Resources
{
    /// <summary>
    /// 
    /// </summary>
    public static class PagSeguroConfiguration
    {
        //PagSeguro .NET Library Tests
        private static string urlXmlConfiguration = ".../.../Configuration/PagSeguroConfig.xml";

        //Website
        //private static string urlXmlConfiguration = HttpRuntime.AppDomainAppPath + "PagSeguroConfig.xml";

        private static string _moduleVersion;
        private static string _cmsVersion;

        /// <summary>
        /// 
        /// </summary>
        public static AccountCredentials Credentials(bool sandbox)
        {
            //return PagSeguroConfigSerializer.GetAccountCredentials(LoadXmlConfig(), sandbox);
            var configuration = (PagSeguroConfigurationSection)ConfigurationManager.GetSection("PagSeguro");
            return new AccountCredentials(configuration.Credential.SandboxEmail.Value.ToString(), configuration.Credential.SandboxToken.Value.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        public static string UrlXmlConfiguration
        {
            get
            {
                return urlXmlConfiguration;
            }
            set
            {
                urlXmlConfiguration = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string ModuleVersion
        {
            get
            {
                return _moduleVersion;
            }

            set
            {
                _moduleVersion = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string CmsVersion
        {
            get
            {
                return _cmsVersion;
            }

            set
            {
                _cmsVersion = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string LanguageEngineDescription
        {
            get
            {
                return Environment.Version.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri NotificationUri
        {
            get
            {
                var configuration = (PagSeguroConfigurationSection)ConfigurationManager.GetSection("PagSeguro");
                // return new Uri(GetUrlValue(PagSeguroConfigSerializer.Notification));
                return new Uri(configuration.Urls.Notification.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri PaymentUri
        {
            get
            {
                var configuration = (PagSeguroConfigurationSection)ConfigurationManager.GetSection("PagSeguro");
                // return new Uri(GetUrlValue(PagSeguroConfigSerializer.Payment));
                return new Uri(configuration.Urls.Payment.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri PaymentRedirectUri
        {
            get
            {
                return new Uri(GetUrlValue(PagSeguroConfigSerializer.PaymentRedirect));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri SearchUri
        {
            get
            {
                return new Uri(GetUrlValue(PagSeguroConfigSerializer.Search));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri SearchAbandonedUri
        {
            get
            {
                return new Uri(GetUrlValue(PagSeguroConfigSerializer.SearchAbandoned));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri CancelUri
        {
            get
            {
                var configuration = (PagSeguroConfigurationSection)ConfigurationManager.GetSection("PagSeguro");
                // return new Uri(GetUrlValue(PagSeguroConfigSerializer.Cancel));
                return new Uri(configuration.Urls.Cancel.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri RefundUri
        {
            get
            {
                var configuration = (PagSeguroConfigurationSection)ConfigurationManager.GetSection("PagSeguro");
                // return new Uri(GetUrlValue(PagSeguroConfigSerializer.Refund));
                return new Uri(configuration.Urls.Refund.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri PreApprovalUri
        {
            get
            {
                var configuration = (PagSeguroConfigurationSection)ConfigurationManager.GetSection("PagSeguro");
                // return new Uri(GetUrlValue(PagSeguroConfigSerializer.PreApproval));
                return new Uri(configuration.Urls.PreApproval.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri PreApprovalRedirectUri
        {
            get
            {
                var configuration = (PagSeguroConfigurationSection)ConfigurationManager.GetSection("PagSeguro");
                // return new Uri(GetUrlValue(PagSeguroConfigSerializer.PreApprovalRedirect));
                return new Uri(configuration.Urls.PreApproval.PreApprovalRedirect.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri PreApprovalNotificationUri
        {
            get
            {
                var configuration = (PagSeguroConfigurationSection)ConfigurationManager.GetSection("PagSeguro");
                // return new Uri(GetUrlValue(PagSeguroConfigSerializer.PreApprovalNotification));
                return new Uri(configuration.Urls.PreApproval.PreApprovalNotification.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri PreApprovalSearchUri
        {
            get
            {
                var configuration = (PagSeguroConfigurationSection)ConfigurationManager.GetSection("PagSeguro");
                // return new Uri(GetUrlValue(PagSeguroConfigSerializer.PreApprovalSearch));
                return new Uri(configuration.Urls.PreApproval.PreApprovalSearch.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri PreApprovalCancelUri
        {
            get
            {
                var configuration = (PagSeguroConfigurationSection)ConfigurationManager.GetSection("PagSeguro");
                // return new Uri(GetUrlValue(PagSeguroConfigSerializer.PreApprovalCancel));
                return new Uri(configuration.Urls.PreApproval.PreApprovalCancel.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri PreApprovalPaymentUri
        {
            get
            {
                var configuration = (PagSeguroConfigurationSection)ConfigurationManager.GetSection("PagSeguro");
                // return new Uri(GetUrlValue(PagSeguroConfigSerializer.PreApprovalPayment));
                return new Uri(configuration.Urls.PreApproval.PreApprovalPayment.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri SessionUri
        {
            get
            {
                var configuration = (PagSeguroConfigurationSection)ConfigurationManager.GetSection("PagSeguro");
                // return new Uri(GetUrlValue(PagSeguroConfigSerializer.Session));
                return new Uri(configuration.Urls.DirectPayment.Session.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri TransactionsUri
        {
            get
            {
                var configuration = (PagSeguroConfigurationSection)ConfigurationManager.GetSection("PagSeguro");
                // return new Uri(GetUrlValue(PagSeguroConfigSerializer.Transactions));
                return new Uri(configuration.Urls.DirectPayment.Transactions.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri InstallmentUri
        {
            get
            {
                var configuration = (PagSeguroConfigurationSection)ConfigurationManager.GetSection("PagSeguro");
                // return new Uri(GetUrlValue(PagSeguroConfigSerializer.Installment));
                return new Uri(configuration.Urls.DirectPayment.Installment.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri AuthorizarionRequestUri
        {
            get
            {
                var configuration = (PagSeguroConfigurationSection)ConfigurationManager.GetSection("PagSeguro");
                // return new Uri(GetUrlValue(PagSeguroConfigSerializer.AuthorizationRequest));
                return new Uri(configuration.Urls.Authorization.AuthorizationRequest.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri AuthorizarionUri
        {
            get
            {
                var configuration = (PagSeguroConfigurationSection)ConfigurationManager.GetSection("PagSeguro");
                // return new Uri(GetUrlValue(PagSeguroConfigSerializer.Authorization));
                return new Uri(configuration.Urls.Authorization.AuthorizationURL.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri AuthorizarionSearchUri
        {
            get
            {
                var configuration = (PagSeguroConfigurationSection)ConfigurationManager.GetSection("PagSeguro");
                // return new Uri(GetUrlValue(PagSeguroConfigSerializer.AuthorizationSearch));
                return new Uri(configuration.Urls.Authorization.AuthorizationSearch.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri AuthorizationNotificationUri
        {
            get
            {
                var configuration = (PagSeguroConfigurationSection)ConfigurationManager.GetSection("PagSeguro");
                return new Uri(GetUrlValue(PagSeguroConfigSerializer.AuthorizationNotification));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static int RequestTimeout
        {
            get
            {
                return Convert.ToInt32(GetDataConfiguration(PagSeguroConfigSerializer.RequestTimeout));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string FormUrlEncoded
        {
            get
            {
                return GetDataConfiguration(PagSeguroConfigSerializer.FormUrlEncoded);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string Encoding
        {
            get
            {
                return GetDataConfiguration(PagSeguroConfigSerializer.Encoding);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string LibVersion
        {
            get
            {
                return GetDataConfiguration(PagSeguroConfigSerializer.LibVersion);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static string GetUrlValue(string url)
        {
            return PagSeguroConfigSerializer.GetWebserviceUrl(LoadXmlConfig(), url);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static string GetDataConfiguration(string data)
        {
            return PagSeguroConfigSerializer.GetDataConfiguration(LoadXmlConfig(), data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static XmlDocument LoadXmlConfig()
        {
            XmlDocument xml = new XmlDocument();
            using (xml as IDisposable)
            {
                xml.Load(urlXmlConfiguration);
            }
            return xml;
        }
    }
}
