﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api;
using System.Collections.Generic;

namespace PayPal.Testing
{
    [TestClass]
    public class OAuthTokenCredentialTest
    {
        [TestMethod, TestCategory("Unit")]
        public void OAuthTokenCredentialCtorConfigTest()
        {
            var config = new Dictionary<string, string>();
            config[BaseConstants.ClientId] = "xxx";
            config[BaseConstants.ClientSecret] = "yyy";
            var oauthTokenCredential = new OAuthTokenCredential(config);
            Assert.AreEqual("xxx", oauthTokenCredential.ClientId);
            Assert.AreEqual("yyy", oauthTokenCredential.ClientSecret);
        }

        [TestMethod, TestCategory("Unit")]
        public void OAuthTokenCredentialCtorClientInfoTest()
        {
            var oauthTokenCredential = new OAuthTokenCredential("aaa", "bbb");
            Assert.AreEqual("aaa", oauthTokenCredential.ClientId);
            Assert.AreEqual("bbb", oauthTokenCredential.ClientSecret);
        }

        [TestMethod, TestCategory("Unit")]
        public void OAuthTokenCredentialCtorClientInfoConfigTest()
        {
            var config = new Dictionary<string, string>();
            config[BaseConstants.ClientId] = "xxx";
            config[BaseConstants.ClientSecret] = "yyy";
            var oauthTokenCredential = new OAuthTokenCredential("aaa", "bbb", config);
            Assert.AreEqual("aaa", oauthTokenCredential.ClientId);
            Assert.AreEqual("bbb", oauthTokenCredential.ClientSecret);
        }

        [TestMethod, TestCategory("Unit")]
        public void OAuthTokenCredentialCtorEmptyConfigTest()
        {
            var config = new Dictionary<string, string>();
            var oauthTokenCredential = new OAuthTokenCredential(config);
            Assert.IsTrue(string.IsNullOrEmpty(oauthTokenCredential.ClientId));
            Assert.IsTrue(string.IsNullOrEmpty(oauthTokenCredential.ClientSecret));
        }

        [TestMethod, TestCategory("Unit")]
        public void OAuthTokenCredentialCtorNullValuesTest()
        {
            // If null values are passed in, OAuthTokenCredential uses the values specified in the config.
            var oauthTokenCredential = new OAuthTokenCredential(null, null, null);
            Assert.IsTrue(!string.IsNullOrEmpty(oauthTokenCredential.ClientId));
            Assert.IsTrue(!string.IsNullOrEmpty(oauthTokenCredential.ClientSecret));
        }
    }
}
