using Bcore.Utility;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http.Controllers;

namespace VDSoLienLac.Models.Base
{
    public class CustomeJsonSettingAttribute : Attribute, IControllerConfiguration
    {
        public  PropertyRenameAndIgnoreSerializerContractResolver jsonResolver;

        public void Initialize(HttpControllerSettings controllerSettings, HttpControllerDescriptor controllerDescriptor)
        {
            jsonResolver = new PropertyRenameAndIgnoreSerializerContractResolver();
            var formatter = controllerSettings.Formatters.JsonFormatter;

            controllerSettings.Formatters.Remove(formatter);

            formatter = new JsonMediaTypeFormatter
            {
                SerializerSettings =
            {
                ContractResolver = jsonResolver,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            }
            };

            controllerSettings.Formatters.Insert(0, formatter);
        }

        public void IgnoreProperty<T>(params object[] name)
        {
            foreach(var item in name)
            {
                jsonResolver.IgnoreProperty(typeof(T), item.ToString());
            } 
        }
    }
}