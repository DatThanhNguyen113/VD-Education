using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Bcore.Utility
{
    /// <summary>
    /// manipulation with XML
    /// </summary>
    public static class XMLUtility
    {
        /// <summary>
        /// Set a value for xml and return new xml
        /// </summary>
        /// <param name="strContent">for a string xml</param>
        /// <param name="element">element are set value for attribute</param>
        /// <param name="attr">attribute are set value</param>
        /// <param name="value">data are set for attribute</param>
        /// <returns>return new string xml</returns>
        public static string SetAttribute(string strContent, string element, string attr, string value)
        {
            try
            {
                strContent = strContent.Contains("<root>") || strContent.Contains("</root>") ? strContent : "<root>" + strContent + "</root>";
                var document = XDocument.Parse(strContent);
                var xElement = document.Descendants(element);
                xElement.FirstOrDefault(x => x.Name == element).SetAttributeValue(attr, value);//.Attribute(attr).SetValue(value);
                return document.ToString().Replace("<root>", "").Replace("</root>", "");
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Set a value for xml and return new xml
        /// </summary>
        /// <param name="strContent">for a string xml</param>
        /// <param name="element">element are set value for attribute</param>
        /// <param name="keyValue">a dictionary contain key is name attribute and value is set value for attribute</param>
        /// <returns>return a new xml string</returns>
        public static string SetMultiAttributeForElement(string strContent, string element, Dictionary<string, string> keyValue)
        {
            try
            {
                strContent = strContent.Contains("<root>") || strContent.Contains("</root>") ? strContent : "<root>" + strContent + "</root>";
                var document = XDocument.Parse(strContent);
                var xElement = document.Descendants(element);
                XElement elementSetValue = xElement.FirstOrDefault(x => x.Name == element);
                foreach (var i in keyValue)
                {
                    try
                    {
                        elementSetValue.Attribute(i.Key).SetValue(i.Value);
                    }
                    catch { }
                }
                return document.ToString().Replace("<root>", "").Replace("</root>", "").Trim();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// get a value in string xml
        /// </summary>
        /// <param name="strContent">for a string xml</param>
        /// <param name="element">element are get value of attribute</param>
        /// <param name="attr">attribute are get value</param>
        /// <returns>return data get in string xml</returns>
        public static string GetAttribute(string strContent, string element, string attr)
        {
            try
            {
                strContent = strContent.Contains("<root>") || strContent.Contains("</root>") ? strContent : "<root>" + strContent + "</root>";
                var document = XDocument.Parse(strContent);
                var xElement = document.Descendants(element);
                return xElement.FirstOrDefault(x => x.Name == element).Attribute(attr).Value;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// remove a attribute of a element
        /// </summary>
        /// <param name="strContent">string xml</param>
        /// <param name="element">element have contain the attribute need remove</param>
        /// <param name="arrAttr">attribute need remove</param>
        /// <returns>return a new string xml</returns>
        public static string RemoveAttribute(string strContent, string element, string attr)
        {
            try
            {
                strContent = strContent.Contains("<root>") || strContent.Contains("</root>") ? strContent : "<root>" + strContent + "</root>";
                var document = XDocument.Parse(strContent);
                var xElement = document.Descendants(element);
                xElement.FirstOrDefault(x => x.Name == element).Attribute(attr).Remove();
                return document.ToString().Replace("<root>", "").Replace("</root>", "").Trim();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// remove multi attribute of a element
        /// </summary>
        /// <param name="strContent">string xml</param>
        /// <param name="element">element have contain the attribute need remove</param>
        /// <param name="arrAttr">list attribute remove</param>
        /// <returns>return a new string xml</returns>
        public static string RemoveMultiAttribute(string strContent, string element, params string[] arrAttr)
        {
            try
            {
                strContent = strContent.Contains("<root>") || strContent.Contains("</root>") ? strContent : "<root>" + strContent + "</root>";
                var document = XDocument.Parse(strContent);
                var xElement = document.Descendants(element);
                var remove = xElement.FirstOrDefault(x => x.Name == element);
                foreach (var item in arrAttr)
                {
                    remove.Attribute(item).Remove();
                }
                return document.ToString().Replace("<root>", "").Replace("</root>", "").Trim();
            }
            catch
            {
                return null;
            }
        }
    }
}
