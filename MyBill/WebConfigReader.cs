using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.Common;


public static class WebConfigReader
{
    private readonly static string dbConnectionString;
    private readonly static string dbProviderName;
   
    static WebConfigReader()
	{
        dbConnectionString = System.Configuration.ConfigurationSettings.AppSettings["mydbname"];

        //mydbprovider
        dbProviderName = System.Configuration.ConfigurationSettings.AppSettings["mydbprovider"];
      
	}
    public static string DbConnectionString
    {
        get
        {
            return dbConnectionString;
        }
    }
    public static string DbProviderName
    {
        get
        {
            return dbProviderName;
        }
    }
   

   
}
