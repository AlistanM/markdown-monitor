using Common.Models;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace Common;

public static class ConfigHelper
{
    private static string ConfigPath = @"..\..\..\..\..\..\config.xml";
    private static Configuration _configuration;

    public static Configuration Configuration
    {
        get
        {
            if (_configuration == null)
            {
                Init();
            }
            return _configuration;
        }
    }

    private static void Init()
    {
        using (var stream = new FileStream(ConfigPath, FileMode.Open))
        {
            var xml = new XmlSerializer(typeof(Configuration));
            _configuration = xml.Deserialize(stream) as Configuration;
        }
    }
}
