using Cosmos.Data.Cerulean.Cloud;
using System.Xml.Linq;

namespace Frontend.Cerulean.Cloud.Components.Statics
{
    public static class FormHelper
    {
        public static string GetKeyRepeatableKey(bool isRepeatable, string key) {
            if (isRepeatable)
            {
                return $"{key}_1";
            }
            return key;
        }
    }
}
