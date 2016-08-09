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

        private static PagSeguroConfigurationSection configuration = (PagSeguroConfigurationSection)ConfigurationManager.GetSection("PagSeguro");

        /// <summary>
        /// 
        /// </summary>
        public static AccountCredentials Credentials(bool sandbox)
        {
            if (configuration == null)
                return PagSeguroConfigSerializer.GetAccountCredentials(LoadXmlConfig(), sandbox);

            return new AccountCredentials(configuration.Credential.SandboxEmail.Value.ToString(), configuration.Credential.SandboxToken.Value.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sandbox"></param>
        /// <returns></returns>
        public static ApplicationCredentials ApplicationCredentials(bool sandbox)
        {
            if (configuration == null)
                return PagSeguroConfigSerializer.GetApplicationCredentials(LoadXmlConfig(), sandbox);

            return sandbox ?
                new Domain.ApplicationCredentials(appId: configuration.Credential.SandboxAppId.ToString(), appKey: configuration.Credential.SandboxAppKey.ToString()) :
                new Domain.ApplicationCredentials(appId: configuration.Credential.AppId.ToString(), appKey: configuration.Credential.AppKey.ToString());
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
                if (configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.Notification));

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
                if (configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.Payment));

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
                if (configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.PaymentRedirect));

                return new Uri(configuration.Urls.PaymentRedirect.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri SearchUri
        {
            get
            {
                if (configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.Search));

                return new Uri(configuration.Urls.Search.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri SearchAbandonedUri
        {
            get
            {
                if (configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.SearchAbandoned));

                return new Uri(configuration.Urls.SearchAbandoned.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri CancelUri
        {
            get
            {
                if (configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.Cancel));

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
                if (configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.Refund));

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
                if (configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.PreApproval));

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
                if (configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.PreApprovalRedirect));

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
                if (configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.PreApprovalNotification));

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
                if (configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.PreApprovalSearch));

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
                if (configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.PreApprovalCancel));

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
                if (configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.PreApprovalPayment));

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
                if (configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.Session));

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
                if (configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.Transactions));

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
                if (configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.Installment));

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
                if (configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.AuthorizationRequest));

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
                if (configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.Authorization));

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
                if (configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.AuthorizationSearch));

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
                if (configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.AuthorizationNotification));

                return new Uri(configuration.Urls.Authorization.AuthorizationNotification.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static int RequestTimeout
        {
            get
            {
                if (configuration == null)
                    return Convert.ToInt32(GetDataConfiguration(PagSeguroConfigSerializer.RequestTimeout));

                return Convert.ToInt32(configuration.Configuration.RequestTimeout.ToString());
            }
        }



        /// <summary>
        /// 
        /// </summary>
        public static string FormUrlEncoded
        {
            get
            {
                if (configuration == null)
                    return GetDataConfiguration(PagSeguroConfigSerializer.FormUrlEncoded);

                return configuration.Configuration.FormUrlEncoded.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string Encoding
        {
            get
            {
                if (configuration == null)
                    return GetDataConfiguration(PagSeguroConfigSerializer.Encoding);

                return configuration.Configuration.Encoding.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string LibVersion
        {
            get
            {
                if (configuration == null)
                    return GetDataConfiguration(PagSeguroConfigSerializer.LibVersion);

                return configuration.Configuration.LibVersion.ToString();
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
