﻿using KenticoCloud.Delivery;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace DaningGoat
{
    /// <summary>
    /// Provides the settings from web.config file, can be used with <see cref="ConfigurationBuilder"/>.
    /// </summary>
    public class ConfigurationManagerProvider : ConfigurationProvider, IConfigurationSource
    {
        /// <summary>
        /// Loads the data used by provider
        /// </summary>
        public override void Load()
        {
            foreach (var settingKey in ConfigurationManager.AppSettings.AllKeys)
            {
                Data.Add(settingKey, ConfigurationManager.AppSettings[settingKey]);
            }
        }

        /// <summary>
        /// Builds IConfigurationProvider for this class.
        /// </summary>
        /// <param name="builder">The configuration builder.</param>
        /// <returns>The current instance of this class.</returns>
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return this;
        }

        /// <summary>
        /// Generates and returns the <see cref="DeliveryOptions"/> instance.
        /// </summary>
        /// <returns>The <see cref="DeliveryOptions"/> instance.</returns>
        public DeliveryOptions GetDeliveryOptions()
        {
            var configuration = new ConfigurationBuilder().Add(this).Build();
            var result = new DeliveryOptions();
            configuration.Bind(result);
            return result;
        }
    }
}