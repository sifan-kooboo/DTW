using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Maticsoft.DBUtility
{
    public class urlElement : ConfigurationElement
    {
        [ConfigurationProperty("config_value")]
        public string Config_value
        {
            get { return this["config_value"] as string; }
            set { this["config_value"] = value; }
        }
    }

    public class qymcElement : ConfigurationElement
    {
        [ConfigurationProperty("config_value")]
        public string Config_value
        {
            get { return this["config_value"] as string; }
            set { this["config_value"] = value; }
        }
    }

    public class applicationVersionElement : ConfigurationElement
    {
        [ConfigurationProperty("config_value")]
        public string Config_value
        {
            get { return this["config_value"] as string; }
            set { this["config_value"] = value; }
        }
    }

    public class BaseInfo_configSection : ConfigurationSection
    {
        [ConfigurationProperty("url")]
        public urlElement Url
        {
            get { return this["url"] as urlElement; }
            set { this["url"] = value; }
        }
        [ConfigurationProperty("qymc")]
        public qymcElement Qymc
        {
            get { return this["qymc"] as qymcElement; }
            set { this["qymc"] = value; }
        }
        [ConfigurationProperty("applicationVersion")]
        public applicationVersionElement ApplicationVersion
        {
            get { return this["applicationVersion"] as applicationVersionElement; }
            set { this["applicationVersion"] = value; }
        }
    }
}
