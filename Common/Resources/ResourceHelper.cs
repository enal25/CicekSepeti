using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;

namespace Common.Resources
{
    public static class ResourceHelper
    {
        public static string ReadFromResource(string key)
        {
            ResourceManager resourceManager = new ResourceManager(typeof(StringResources));
            return resourceManager.GetString(key);
        }
    }
}
