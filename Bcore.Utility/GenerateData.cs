using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace VD.Utility
{
    public class GenerateData
    {

        /// <summary>
        /// Get a object of a row in DataTable
        /// </summary>
        /// <param name="table">type of class DataTable.</param>
        /// <returns>a object T corresponding with row first in DataTable</returns>
        public T ResponseObject<T>(DataTable table) where T : class
        {
            if (table.Rows.Count <= 0)
                return null; //GenerateData<T> then return default(T); 
            T obj = Activator.CreateInstance<T>();
            var properties = obj.GetType().GetProperties();
            foreach (var item in properties)
            {
                try
                {
                    var itemValue = table.Rows[0][item.Name];
                    if (item.PropertyType.IsGenericType && item.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                    {
                        if (itemValue != DBNull.Value)
                            item.SetValue(obj, Convert.ChangeType(itemValue, Nullable.GetUnderlyingType(item.PropertyType)), null);
                        else
                            item.SetValue(obj, Activator.CreateInstance(item.PropertyType));
                    }
                    else
                    {
                        if (item.PropertyType == typeof(DateTime))
                        {
                            //Date = {5/6/2016 12:00:00 AM}
                            var date = (DateTime)itemValue;
                            //huy coode cnay them
                            item.SetValue(obj, date, null);
                        }
                        else

                            item.SetValue(obj, Convert.ChangeType(itemValue, item.PropertyType), null);
                    }

                }
                catch { }
            }
            return obj;
        }
        /// <summary>
        /// Get a list object of multiple row in DataTable
        /// </summary>
        /// <param name="table">type of class DataTable.</param>
        /// <returns>a list object T corresponding with all row in DataTable</returns>
        public IEnumerable<T> ResponseMultiObject<T>(DataTable table) where T : class
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                T obj = Activator.CreateInstance<T>();
                var properties = obj.GetType().GetProperties();
                foreach (var item in properties)
                {
                    try
                    {
                        if (!table.Columns.Contains(item.Name)) continue; //npn add

                        var itemValue = table.Rows[i][item.Name];
                        if (item.PropertyType.IsGenericType && item.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                        {
                            if (itemValue != DBNull.Value)
                                item.SetValue(obj, Convert.ChangeType(itemValue, Nullable.GetUnderlyingType(item.PropertyType)), null);
                            else
                                item.SetValue(obj, Activator.CreateInstance(item.PropertyType));
                        }
                        else
                           if (itemValue != DBNull.Value)
                            item.SetValue(obj, itemValue, null);
                    }
                    catch (Exception E)
                    { }
                }
                yield return obj;
            }
        }


        /// <summary>
        /// Get a list object of multiple row in DataTable
        /// </summary>
        /// <param name="table">type of class DataTable.</param>
        /// <returns>a list object T corresponding with all row in DataTable</returns>
        public IEnumerable<T> ResponseMultiObjectForMappingData<T>(DataTable table) where T : class
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                T obj = Activator.CreateInstance<T>();
                var properties = obj.GetType().GetProperties();
                foreach (var item in properties)
                {
                    try
                    {
                        if (item.Name == "Duration")
                            i = i - 1 + 1;
                        var itemValue = table.Rows[i][item.Name];
                        if (itemValue.GetType() != typeof(System.DBNull))
                        {

                            if (item.PropertyType.IsGenericType && item.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                            {
                                if (itemValue != DBNull.Value)
                                    item.SetValue(obj, Convert.ChangeType(itemValue, Nullable.GetUnderlyingType(item.PropertyType)), null);
                                else
                                    item.SetValue(obj, Activator.CreateInstance(item.PropertyType));
                            }
                            else
                            {
                                if (item.PropertyType == typeof(DateTime))
                                {
                                    //Date = {5/6/2016 12:00:00 AM}
                                    var date = (DateTime)itemValue;
                                    //huy coode cnay them
                                    item.SetValue(obj, date, null);
                                }
                                else

                                    item.SetValue(obj, Convert.ChangeType(itemValue, item.PropertyType), null);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex);
                    }
                }
                yield return obj;
            }
        }

        internal string GenerateXmlFromObject<T>(T p1, T p2, T scp_EmailPattern, string v)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get 1 xml string for execute database
        /// </summary>
        /// <param name="ActionName">INSERT,UPDATE,DELETE,DELETEMULTI,MAPPINGDATA, if get data then null or string.empty</param>
        /// <param name="objectData">objectData contain data of object T</param>
        /// <param name="Sys_View">Sys_View use for IsActiion = true</param>
        /// <param name="ContextName">Name a Store</param>
        /// <param name="UserId">UserId use for manager dev, when stactament is execute in database , we will see who call query of database?</param>
        /// <returns></returns>
        public string GenerateXmlFromObject<T>(string ActionName, T objectData, string Sys_View, string ContextName, string UserId = "13") where T : class
        {
            CultureInfo enCulture = new CultureInfo("en-US");
            string ipAdress = string.Empty;
            var currContext = HttpContext.Current;
            if (currContext != null && currContext.Handler != null && currContext.Request != null)
            {
                ipAdress = currContext.Request.UserHostAddress;
            }
            int LangID = GetCurrentLanguageID();

            string strXml = string.Format("<InputValue IpAdress=\"{0}\" ComputerName=\"{4}\" UserID=\"{1}\" Context=\"{2}\" Sys_ViewID=\"{3}\" LanguageID=\"" + LangID + "\" /><RequestParams UserID=\"{1}\"  Context=\"{2}\"  Sys_ViewID=\"{3}\" ", ipAdress, UserId, ContextName, Sys_View, Environment.MachineName);
            if (ActionName != null || !string.IsNullOrEmpty(ActionName) || !string.IsNullOrWhiteSpace(ActionName))
                strXml = string.Format("<InputValue IpAdress=\"{0}\" UserID=\"{1}\" Action=\"{2}\" Context=\"{3}\" Sys_ViewID=\"{4}\" LanguageID=\"" + LangID + "\"  /><RequestParams UserID=\"{1}\"  Context=\"{3}\" Sys_ViewID=\"{4}\" Action=\"{2}\" ", ipAdress, UserId, ActionName, ContextName, Sys_View);
            foreach (var item in objectData.GetType().GetProperties())
            {
                try
                {
                    object valueProperty = item.GetValue(objectData, null);
                    if (valueProperty != null && item.Name != "Action")
                    {
                        var typeVariable = valueProperty.GetType();
                        if (typeVariable == typeof(DateTime))
                        {
                            strXml += item.Name + "=\"" + ((DateTime)valueProperty).ToString("yyyy-MM-dd HH:mm:ss") + "\" ";
                        }
                        //else
                        //    if (typeVariable == typeof(Decimal))
                        //    strXml += string.Format("{0} = \"{1}\" ", item.Name, ((Decimal)valueProperty).ToString("N8", enCulture));
                        else
                            strXml += string.Format("{0} = \"{1}\" ", item.Name, HttpUtility.HtmlEncode(valueProperty));
                    }

                }
                catch (Exception ex)
                {
                }
            }
            strXml += "/>";
            return strXml;
        }

        public string GenerateXmlFromString(string requestParam, int UserId)
        {
            string ipAdress = string.Empty;
            try
            {
                ipAdress = HttpContext.Current.Request.UserHostAddress;
            }
            catch { }
            string strXml = string.Format("<InputValue IpAdress=\"{0}\" ComputerName=\"{3}\" UserID=\"{1}\"  LanguageID=\"" + GetCurrentLanguageID() + "\" /><RequestParams {2} />", ipAdress, UserId, requestParam, Environment.MachineName);

            return strXml;
        }
        /// <summary>
        /// Get 1 xml string for excute database. (RequestParams don't pass object)
        /// </summary>
        /// <param name="ActionName">INSERT,UPDATE,DELETE,DELETEMULTI,MAPPINGDATA, if get data then null or string.empty</param>
        /// <param name="requestParams">string xml when requested by client</param>
        /// <param name="objectData">objectData contain data of object T</param>
        /// <param name="Sys_View">Sys_View use for IsActiion = true</param>
        /// <param name="ContextName">Name a Store</param>
        /// <param name="UserId">UserId use for manager dev, when stactament is execute in database , we will see who call query of database?</param>
        /// <returns></returns>
        public string GenerateXmlFormString(string ActionName, string requestParams, string Sys_View, string ContextName, int UserId = 13)
        {
            string strXml = string.Format("<InputValue UserID=\"{0}\" Context=\"{1}\" Sys_ViewID=\"{2}\" LanguageID=\"" + GetCurrentLanguageID() + "\" />{3}", UserId, ContextName, Sys_View, requestParams);
            if (ActionName != null || !string.IsNullOrEmpty(ActionName) || !string.IsNullOrWhiteSpace(ActionName))
                strXml = string.Format("<InputValue UserID=\"{0}\" Action=\"{1}\" Context=\"{2}\" Sys_ViewID=\"{3}\"  LanguageID=\"" + GetCurrentLanguageID() + "\" />{4}", UserId, ActionName, ContextName, Sys_View, requestParams);
            return strXml;
        }

        /// <summary>
        /// Generate a string xml <RequestParams></RequestParams>
        /// </summary>
        /// <param name="objAttr">attribute of RequestParams</param>
        /// <param name="arrItem">list object of Anonymous Type with data</param>
        /// <returns>string xml</returns>
        public string GenerateXmlRequestParams(object objAttr, params object[] arrItem)
        {
            try
            {
                string requestParams = "<RequestParams ";
                foreach (var item in objAttr.GetType().GetProperties())
                {
                    object valueProperty = item.GetValue(objAttr, null);
                    requestParams += item.Name + "=\"" + valueProperty + "\" ";
                }
                requestParams += ">";
                foreach (var item in arrItem)
                {
                    requestParams += "<Item ";
                    foreach (var i in item.GetType().GetProperties())
                    {
                        object valueProperty = i.GetValue(item, null);
                        if (valueProperty != null)
                        {
                            if (valueProperty is DateTime)
                                valueProperty = ((DateTime)valueProperty).ToString("yyyy-MM-dd HH:mm:ss");
                            requestParams += i.Name + "=\"" + valueProperty + "\" ";
                        }
                    }
                    requestParams += "></Item>";
                }
                requestParams += "</RequestParams>";
                return requestParams;
            }
            catch
            {
                return "<RequestParams></RequestParams>";
            }
        }

        /// <summary>
        /// Generate a string xml with multi <Request'object'></Request'object'>
        /// </summary>
        /// <param name="arrItem">multi object</param>
        /// <returns>return multi <Request'object'></Request'object'></returns>
        public string GenerateXmlRequestObjectFromMultiObject(params object[] arrItem)
        {
            string requestParams = string.Empty;
            try
            {
                foreach (var item in arrItem)
                {
                    var className = item.ToString().Split('.').LastOrDefault();
                    requestParams += "<Request" + className + " ";
                    foreach (var i in item.GetType().GetProperties())
                    {
                        object valueProperty = i.GetValue(item, null);
                        if (valueProperty != null)
                        {
                            if (valueProperty is DateTime)
                                valueProperty = ((DateTime)valueProperty).ToString("yyyy-MM-dd HH:mm:ss");
                            requestParams += i.Name + "=\"" + valueProperty + "\" ";
                        }
                    }
                    requestParams += "/>";
                }
            }
            catch { }
            return requestParams;
        }
        public string GenerateXmlRequestObjectFromMultiObject(string ActionName, string ContextName, string Sys_View, params object[] arrItem)
        {
            string requestParams = GenerateXmlRequestObjectFromMultiObject(arrItem);
            int UserId = 1;// MySession.GetSessionUserId();
            string strXml = string.Format("<InputValue UserID=\"{0}\" Context=\"{1}\" Sys_ViewID=\"{2}\"  LanguageID=\"" + GetCurrentLanguageID() + "\" />{3}", UserId, ContextName, Sys_View, requestParams);
            if (ActionName != null || !string.IsNullOrEmpty(ActionName) || !string.IsNullOrWhiteSpace(ActionName))
                strXml = string.Format("<InputValue UserID=\"{0}\" Action=\"{1}\" Context=\"{2}\" Sys_ViewID=\"{3}\"  LanguageID=\"" + GetCurrentLanguageID() + "\" />{4}", UserId, ActionName, ContextName, Sys_View, requestParams);
            return strXml;
        }

        public string GenerateXmlRequestObjectFromMultiObject(string ActionName, string ContextName, string Sys_View, string[] ClassName, params object[] arrItem)
        {
            string requestParams = string.Empty;
            try
            {
                for (var i = 0; i < ClassName.LongLength; i++)
                {
                    requestParams += string.Format("<{0} ", ClassName[i]);
                    foreach (var j in arrItem[i].GetType().GetProperties())
                    {
                        object valueProperty = j.GetValue(arrItem[i], null);
                        if (valueProperty != null)
                        {
                            if (valueProperty is DateTime)
                                valueProperty = ((DateTime)valueProperty).ToString("yyyy-MM-dd HH:mm:ss");
                            requestParams += j.Name + "=\"" + valueProperty + "\" ";
                        }
                    }
                    requestParams += "/>";
                }
            }
            catch { }
            int UserId = 1;// MySession.GetSessionUserId();
            string strXml = string.Format("<InputValue UserID=\"{0}\" Context=\"{1}\" Sys_ViewID=\"{2}\"  LanguageID=\"" + GetCurrentLanguageID() + "\" />{3}", UserId, ContextName, Sys_View, requestParams);
            if (ActionName != null || !string.IsNullOrEmpty(ActionName) || !string.IsNullOrWhiteSpace(ActionName))
                strXml = string.Format("<InputValue UserID=\"{0}\" Action=\"{1}\" Context=\"{2}\" Sys_ViewID=\"{3}\"  LanguageID=\"" + GetCurrentLanguageID() + "\" />{4}", UserId, ActionName, ContextName, Sys_View, requestParams);
            return strXml;
        }
        /// <summary>
        /// get one value of anonymous type (object value)
        /// </summary>
        /// <typeparam name="T">type return</typeparam>
        /// <param name="obj">object contain data</param>
        /// <param name="propertyName">property name you want get data</param>
        /// <returns>return type you want get</returns>
        public T GetValueOfObject<T>(object obj, string propertyName)
        {
            return (T)obj.GetType().GetProperty(propertyName).GetValue(obj);
        }

        public int GetCurrentLanguageID()
        {
            return 29;
        }
    }
}
