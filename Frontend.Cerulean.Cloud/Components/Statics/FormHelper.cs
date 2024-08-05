using Cosmos.Data.Cerulean.Cloud;
using System.Xml.Linq;

namespace Frontend.Cerulean.Cloud.Components.Statics
{
    public static class FormHelper
    {
        public static string GetKeyRepeatableKey(string key, int copyNumber) {
            if (copyNumber > 0)
            {
                return $"{key}_{copyNumber}";
            }
            return key;
        }
    }
}
