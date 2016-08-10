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



        private static PagSeguroConfigurationSection _configuration;

        private static PagSeguroConfigurationSection Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    _configuration = (PagSeguroConfigurationSection)ConfigurationManager.GetSection("PagSeguro");


                    if (_configuration != null && Convert.ToBoolean(_configuration.Configuration.Sandbox.Value))
                    {
                        string pagseguroUrl = "pagseguro.uol";
                        string sandboxUrl = "sandbox.pagseguro.uol";

                        _configuration.Urls.Authorization.AuthorizationRequest.Link.Value = _configuration.Urls.Authorization.AuthorizationRequest.Link.Value.Replace(pagseguroUrl, sandboxUrl);
                        _configuration.Urls.Authorization.AuthorizationURL.Link.Value = _configuration.Urls.Authorization.AuthorizationURL.Link.Value.Replace(pagseguroUrl, sandboxUrl);
                        _configuration.Urls.Authorization.AuthorizationSearch.Link.Value = _configuration.Urls.Authorization.AuthorizationSearch.Link.Value.Replace(pagseguroUrl, sandboxUrl);
                        _configuration.Urls.Authorization.AuthorizationSearch.Link.Value = _configuration.Urls.Authorization.AuthorizationSearch.Link.Value.Replace(pagseguroUrl, sandboxUrl);
                        _configuration.Urls.Authorization.AuthorizationNotification.Link.Value = _configuration.Urls.Authorization.AuthorizationNotification.Link.Value.Replace(pagseguroUrl, sandboxUrl);

                        _configuration.Urls.Cancel.Link.Value = _configuration.Urls.Cancel.Link.Value.Replace(pagseguroUrl, sandboxUrl);
                        
                        _configuration.Urls.DirectPayment.Session.Link.Value = _configuration.Urls.DirectPayment.Session.Link.Value.Replace(pagseguroUrl, sandboxUrl);
                        _configuration.Urls.DirectPayment.Installment.Link.Value = _configuration.Urls.DirectPayment.Installment.Link.Value.Replace(pagseguroUrl, sandboxUrl);
                        _configuration.Urls.DirectPayment.Transactions.Link.Value = _configuration.Urls.DirectPayment.Transactions.Link.Value.Replace(pagseguroUrl, sandboxUrl);

                        _configuration.Urls.Payment.Link.Value = _configuration.Urls.Payment.Link.Value.Replace(pagseguroUrl, sandboxUrl);

                        _configuration.Urls.PaymentRedirect.Link.Value = _configuration.Urls.PaymentRedirect.Link.Value.Replace(pagseguroUrl, sandboxUrl);

                        _configuration.Urls.Notification.Link.Value = _configuration.Urls.Notification.Link.Value.Replace(pagseguroUrl, sandboxUrl);

                        _configuration.Urls.Search.Link.Value = _configuration.Urls.Search.Link.Value.Replace(pagseguroUrl, sandboxUrl);

                        _configuration.Urls.SearchAbandoned.Link.Value = _configuration.Urls.SearchAbandoned.Link.Value.Replace(pagseguroUrl, sandboxUrl);

                        _configuration.Urls.Refund.Link.Value = _configuration.Urls.Refund.Link.Value.Replace(pagseguroUrl, sandboxUrl);

                        _configuration.Urls.PreApproval.Link.Value = _configuration.Urls.PreApproval.Link.Value.Replace(pagseguroUrl, sandboxUrl);                        
                    }
                }

                return _configuration;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static AccountCredentials Credentials(bool? sandbox = null)
        {
            if (!sandbox.HasValue)
                sandbox = Sandbox;

            if (Configuration == null)
                return PagSeguroConfigSerializer.GetAccountCredentials(LoadXmlConfig(), sandbox.Value);

            if (sandbox.Value)
                return new AccountCredentials(Configuration.Credential.SandboxEmail.Value, Configuration.Credential.SandboxToken.Value);

            return new AccountCredentials(Configuration.Credential.Email.Value, Configuration.Credential.Token.Value);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sandbox"></param>
        /// <returns></returns>
        public static ApplicationCredentials ApplicationCredentials(bool? sandbox = null)
        {
            if (!sandbox.HasValue)
                sandbox = Sandbox;
            if (Configuration == null)
                return PagSeguroConfigSerializer.GetApplicationCredentials(LoadXmlConfig(), sandbox.Value);

            return sandbox.Value ?
                new Domain.ApplicationCredentials(appId: Configuration.Credential.SandboxAppId.ToString(), appKey: Configuration.Credential.SandboxAppKey.ToString()) :
                new Domain.ApplicationCredentials(appId: Configuration.Credential.AppId.ToString(), appKey: Configuration.Credential.AppKey.ToString());
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
                if (Configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.Notification));

                return new Uri(Configuration.Urls.Notification.Link.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri PaymentUri
        {
            get
            {
                if (Configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.Payment));

                return new Uri(Configuration.Urls.Payment.Link.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri PaymentRedirectUri
        {
            get
            {
                if (Configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.PaymentRedirect));

                return new Uri(Configuration.Urls.PaymentRedirect.Link.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri SearchUri
        {
            get
            {
                if (Configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.Search));

                return new Uri(Configuration.Urls.Search.Link.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri SearchAbandonedUri
        {
            get
            {
                if (Configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.SearchAbandoned));

                return new Uri(Configuration.Urls.SearchAbandoned.Link.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri CancelUri
        {
            get
            {
                if (Configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.Cancel));

                return new Uri(Configuration.Urls.Cancel.Link.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri RefundUri
        {
            get
            {
                if (Configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.Refund));

                return new Uri(Configuration.Urls.Refund.Link.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri PreApprovalUri
        {
            get
            {
                if (Configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.PreApproval));

                return new Uri(Configuration.Urls.PreApproval.Link.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri PreApprovalRedirectUri
        {
            get
            {
                if (Configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.PreApprovalRedirect));

                return new Uri(Configuration.Urls.PreApproval.PreApprovalRedirect.Link.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri PreApprovalNotificationUri
        {
            get
            {
                if (Configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.PreApprovalNotification));

                return new Uri(Configuration.Urls.PreApproval.PreApprovalNotification.Link.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri PreApprovalSearchUri
        {
            get
            {
                if (Configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.PreApprovalSearch));

                return new Uri(Configuration.Urls.PreApproval.PreApprovalSearch.Link.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri PreApprovalCancelUri
        {
            get
            {
                if (Configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.PreApprovalCancel));

                return new Uri(Configuration.Urls.PreApproval.PreApprovalCancel.Link.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri PreApprovalPaymentUri
        {
            get
            {
                if (Configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.PreApprovalPayment));

                return new Uri(Configuration.Urls.PreApproval.PreApprovalPayment.Link.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri SessionUri
        {
            get
            {
                if (Configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.Session));

                return new Uri(Configuration.Urls.DirectPayment.Session.Link.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri TransactionsUri
        {
            get
            {
                if (Configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.Transactions));

                return new Uri(Configuration.Urls.DirectPayment.Transactions.Link.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri InstallmentUri
        {
            get
            {
                if (Configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.Installment));

                return new Uri(Configuration.Urls.DirectPayment.Installment.Link.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri AuthorizarionRequestUri
        {
            get
            {
                if (Configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.AuthorizationRequest));

                return new Uri(Configuration.Urls.Authorization.AuthorizationRequest.Link.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri AuthorizarionUri
        {
            get
            {
                if (Configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.Authorization));

                return new Uri(Configuration.Urls.Authorization.AuthorizationURL.Link.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri AuthorizarionSearchUri
        {
            get
            {
                if (Configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.AuthorizationSearch));

                return new Uri(Configuration.Urls.Authorization.AuthorizationSearch.Link.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Uri AuthorizationNotificationUri
        {
            get
            {
                if (Configuration == null)
                    return new Uri(GetUrlValue(PagSeguroConfigSerializer.AuthorizationNotification));

                return new Uri(Configuration.Urls.Authorization.AuthorizationNotification.Link.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static int RequestTimeout
        {
            get
            {
                if (Configuration == null)
                    return Convert.ToInt32(GetDataConfiguration(PagSeguroConfigSerializer.RequestTimeout));

                return Convert.ToInt32(Configuration.Configuration.RequestTimeout.Value);
            }
        }

        /// <summary>
        /// Get Sandbox configuration
        /// </summary>
        public static bool Sandbox
        {
            get
            {
                if (Configuration == null)
                    return Convert.ToBoolean(GetDataConfiguration(PagSeguroConfigSerializer.Sandbox));

                return Convert.ToBoolean(Configuration.Configuration.Sandbox.Value);
            }
        }



        /// <summary>
        /// 
        /// </summary>
        public static string FormUrlEncoded
        {
            get
            {
                if (Configuration == null)
                    return GetDataConfiguration(PagSeguroConfigSerializer.FormUrlEncoded);

                return Configuration.Configuration.FormUrlEncoded.Value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string Encoding
        {
            get
            {
                if (Configuration == null)
                    return GetDataConfiguration(PagSeguroConfigSerializer.Encoding);

                return Configuration.Configuration.Encoding.Value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string LibVersion
        {
            get
            {
                if (Configuration == null)
                    return GetDataConfiguration(PagSeguroConfigSerializer.LibVersion);

                return Configuration.Configuration.LibVersion.Value;
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
