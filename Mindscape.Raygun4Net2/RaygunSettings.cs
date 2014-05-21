﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Mindscape.Raygun4Net
{
  public class RaygunSettings : ConfigurationSection
  {
    private static RaygunSettings settings = ConfigurationManager.GetSection("RaygunSettings") as RaygunSettings;

    private const string DefaultApiEndPoint = "https://api.raygun.io/entries";

    public static RaygunSettings Settings
    {
      get
      {
        // If no configuration setting is provided then return the default values
        return settings ?? (settings = new RaygunSettings { ApiKey = "", ApiEndpoint = new Uri(DefaultApiEndPoint) });
      }
    }

    [ConfigurationProperty("apikey", IsRequired = true)]
    [StringValidator]
    public string ApiKey
    {
      get { return (string)this["apikey"]; }
      set { this["apikey"] = value; }
    }

    [ConfigurationProperty("endpoint", IsRequired = false, DefaultValue = DefaultApiEndPoint)]
    public Uri ApiEndpoint
    {
      get { return (Uri)this["endpoint"]; }
      set { this["endpoint"] = value; }
    }

    [ConfigurationProperty("excludeHttpStatusCodes", IsRequired = false, DefaultValue = "")]
    [RegexStringValidator(@"^(\d+(,\s?\d+)*)?$")]
    public string ExcludeHttpStatusCodesList
    {
      get { return (string)this["excludeHttpStatusCodes"]; }
      set { this["excludeHttpStatusCodes"] = value; }
    }

    [ConfigurationProperty("excludeErrorsFromLocal", IsRequired = false, DefaultValue = false)]
    public bool ExcludeErrorsFromLocal
    {
      get { return (bool)this["excludeErrorsFromLocal"]; }
      set { this["excludeErrorsFromLocal"] = value; }
    }

    [ConfigurationProperty("ignoreFormDataNames", IsRequired = false, DefaultValue = "")]
    public string IgnoreFormDataNames
    {
      get { return (string)this["ignoreFormDataNames"]; }
      set { this["ignoreFormDataNames"] = value; }
    }
  }
}
