using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;


using System.Text;
using System.IO;
using log4net;
using System.Web.Mvc;

using System.Linq;
using Bcore.Utility;
using BlockChain.Datalayer.DataObject;

namespace Bcore.Utility

{

  public sealed class DataPattern
  {


    private static readonly ILog log4net = LogManager.GetLogger("DataPattern.cs");
    CCoreDao db = new CCoreDao();
    GenerateData Render = new GenerateData();
    #region Region for Patrern file names
    
    public const string PATTERN_EMAIL_HTML_HEADER = "1";
    
    public const string PATTERN_EMAIL_HTML_SIGNATURE_FOOTER = "2";

    public const string PATTERN_EMAIL_HTML_AFFILIGATE_REFERRAL_PROGRAM = "5";

    public const string PATTERN_EMAIL_HTML_MONTHLY_SALES_REPORT_ADMIN = "10";

    public const string PATTERN_EMAIL_HTML_MONTHLY_SALES_REPORT_CUSTOMER = "11";

    public const string PATTERN_EMAIL_HTML_USER_REGISTER = "12";
    
    public const string PATTERN_EMAIL_HTML_USER_FORGOT_PASSWORD = "13";
   
    public const string PATTERN_EMAIL_HTML_USER_PAYMENT_BUYER = "14";
   
    public const string PATTERN_EMAIL_HTML_USER_PAYMENT_SELLER = "15";
    
    public const string PATTERN_EMAIL_HTML_USER_PAYMENT_RESELLER = "16";
    
    public const string PATTERN_EMAIL_HTML_RESELLER_REGISTER = "17";
    
    public const string PATTERN_EMAIL_HTML_ORDER_INPROCESS = "18";
    
    public const string PATTERN_EMAIL_HTML_COMMISSION_CHANGE = "19";
    
    public const string PATTERN_EMAIL_HTML_PARTNERSHIP_REJECTED = "20";
    
    public const string PATTERN_EMAIL_HTML_PARTNERSHIP_APPROVED = "21";
    
    public const string PATTERN_EMAIL_HTML_ORDER_INPROCESS_NEW_ACCOUNT = "22"; 
    
    public const string PATTERN_EMAIL_HTML_CUSTOMER_PROFILE_UPDATED = "23";  

    public const string PATTERN_EMAIL_HTML_PARTNERSHIP_SUSPENDED = "30";

    public const string PATTERN_EMAIL_HTML_CUSTOMER_ACCOUNT_CLOSED = "31";

    public const string PATTERN_EMAIL_HTML_USER_PAYMENT_BUYER_AUTO_PAYMENT = "32";

    public const string PATTERN_EMAIL_HTML_USER_PAYMENT_BUYER_REFUND_COMPLETED = "33";
    #endregion

    #region Region for Event Name

    // 1
    public const string PATTERN_EVENT_NAME_USER_REGISTER = "Registered successfully and send activation link";

    // 2
    public const string PATTERN_EVENT_NAME_USER_FORGOT_PASSWORD = "Registered successfully";

    // 3
    public const string PATTERN_EVENT_NAME_USER_PAYMENT_BUYER = "Forgot the password";

    // 4
    public const string PATTERN_EVENT_NAME_USER_PAYMENT_SELLER = "Forgot password but account is not existed";

    // 5
    public const string PATTERN_EVENT_NAME_USER_PAYMENT_RESELLER = "Changed password successfylly";

    // 6
    public const string PATTERN_EVENT_NAME_RESELLER_REGISTER = "Send ticket to support team";

    // 7   
    public const string PATTERN_EVENT_NAME_ORDER_INPROCESS = "Remove/delete account then send ticket to them";

    // 8  
    public const string PATTERN_EVENT_NAME_COMMISSION_CHANGE = "Remove/delete account then send discount coupon to them";

    //9  
    public const string PATTERN_EVENT_NAME_PARTNERSHIP_REJECTED = "User paid successfully and send order info";

    //10   
    public const string PATTERN_EVENT_NAME_PARTNERSHIP_APPROVED = "User paid successfully and send thank-you letter";

    //11
    public const string PATTERN_EVENT_NAME_ORDER_INPROCESS_NEW_ACCOUNT = "User paid successfully and send thank-you letter - format 2";

    //12   
    public const string PATTERN_EVENT_NAME_MONTHLY_SALES_REPORT_ADMIN = "Send monthly sales report to admin";

    //13
    public const string PATTERN_EVENT_NAME_MONTHLY_SALES_REPORT_CUSTOMER = "Send monthly sales report to customer";

    //14
    public const string PATTERN_EVENT_NAME_CUSTOMER_PROFILE_UPDATED = "Customers's profile updated";

    //15
    public const string PATTERN_EVENT_NAME_AFFILIGATE_REFERRAL_PROGRAM = "Affiligate Referral Program";

    //16
    public const string PATTERN_EVENT_NAME_PARTNERSHIP_SUSPENDED = "Partnership suspended";

    //17
    public const string PATTERN_EVENT_NAME_CUSTOMER_ACCOUNT_CLOSED = "Customer close account";

    //18
    public const string PATTERN_EVENT_NAME_USER_PAYMENT_BUYER_AUTO_PAYMENT = "Automatic payment";


    public const string PATTERN_EVENT_NAME_USER_PAYMENT_BUYER_REFUND_COMPLETED = "Forgot the password";
    #endregion

    private string _HtmlContent = string.Empty;

    public string _Subject = string.Empty;

    private string _lang = string.Empty;
    public string _emailPattern { get; set; }

    private DataPattern()
    {
    }

    public DataPattern(string lang, string emailPattern)
    {
      _lang = lang;
      _emailPattern = emailPattern;
      if (!string.IsNullOrEmpty(_lang) && _lang.Contains("-"))
        _lang = _lang.Split('-')[0].ToUpper();
    }

    public string doReplacePatterns(Hashtable htPatterns)
    {
      if ((htPatterns != null))
      {
        IDictionaryEnumerator myEnumerator = htPatterns.GetEnumerator();
        while (myEnumerator.MoveNext())
        {
          try
          {
            string strKey = myEnumerator.Key.ToString();
            string strValue = myEnumerator.Value.ToString();
            _HtmlContent = _HtmlContent.Replace(strKey, strValue);
          }
          catch (Exception)
          {
          }
        }

      }
      return _HtmlContent;
    }

    public static string doReplacePatternsWithHtmlCode(Hashtable htPatterns, string htmlContent)
    {
      if ((htPatterns != null))
      {
        IDictionaryEnumerator myEnumerator = htPatterns.GetEnumerator();
        while (myEnumerator.MoveNext())
        {
          string strKey = myEnumerator.Key.ToString();
          string strValue = myEnumerator.Value.ToString();
          htmlContent = htmlContent.Replace(strKey, strValue);
        }

      }
      return htmlContent;
    }


    public void loadDataPattern()
    {

      try
      {
        string xmlEmailMapping = Render.GenerateXmlFromObject<object>(null, new
        {
          ID = _emailPattern,
          LanguageCode = _lang.ToUpper()
        }, SystemEnumCore.Sys_ViewID.scp_EmailPattern, "SCP_EmailPattern_GetDetail");
        var emailPattern = Render.ResponseMultiObject<CEmailPatternMapping>(db.GetContextData(xmlEmailMapping).Tables[0]).ToList();
        string emailPatternContent = string.Empty;
        _HtmlContent = System.Web.HttpUtility.HtmlDecode(emailPattern[1].Content);
        _Subject = System.Web.HttpUtility.HtmlDecode(emailPattern[1].Subject);
      }
      catch (Exception ex)
      {
        log4net.Error("EmailPatterns->GetEditorEmailPattern->" + ex.Message);
      }
    }

    public static IEnumerable<SelectListItem> GetLstPartternEmailType()
    {
      IList<SelectListItem> items = new List<SelectListItem>
            {
                //1
                new SelectListItem{Text = PATTERN_EVENT_NAME_USER_REGISTER, Value = PATTERN_EMAIL_HTML_USER_REGISTER},
                //2
                new SelectListItem{Text =PATTERN_EVENT_NAME_USER_FORGOT_PASSWORD, Value = PATTERN_EMAIL_HTML_USER_FORGOT_PASSWORD},
                //3
                new SelectListItem{Text = PATTERN_EVENT_NAME_USER_PAYMENT_BUYER, Value =PATTERN_EMAIL_HTML_USER_PAYMENT_BUYER},
                //4
                new SelectListItem{Text = PATTERN_EVENT_NAME_USER_PAYMENT_SELLER, Value = PATTERN_EMAIL_HTML_USER_PAYMENT_SELLER},
                //5
                new SelectListItem{Text = PATTERN_EVENT_NAME_USER_PAYMENT_RESELLER, Value = PATTERN_EMAIL_HTML_USER_PAYMENT_RESELLER},
                //6
                new SelectListItem{Text =PATTERN_EVENT_NAME_RESELLER_REGISTER, Value = PATTERN_EMAIL_HTML_RESELLER_REGISTER},
                //7
                new SelectListItem{Text = PATTERN_EVENT_NAME_ORDER_INPROCESS, Value =PATTERN_EMAIL_HTML_ORDER_INPROCESS},
                //8
                new SelectListItem{Text = PATTERN_EVENT_NAME_COMMISSION_CHANGE, Value = PATTERN_EMAIL_HTML_COMMISSION_CHANGE},
                //9
                new SelectListItem{Text = PATTERN_EVENT_NAME_PARTNERSHIP_REJECTED, Value = PATTERN_EMAIL_HTML_PARTNERSHIP_REJECTED},
                //10
                new SelectListItem{Text =PATTERN_EVENT_NAME_PARTNERSHIP_APPROVED, Value = PATTERN_EMAIL_HTML_PARTNERSHIP_APPROVED},
                //11
                new SelectListItem{Text = PATTERN_EVENT_NAME_ORDER_INPROCESS_NEW_ACCOUNT, Value =PATTERN_EMAIL_HTML_ORDER_INPROCESS_NEW_ACCOUNT},
                //12
                new SelectListItem{Text = PATTERN_EVENT_NAME_MONTHLY_SALES_REPORT_ADMIN, Value = PATTERN_EMAIL_HTML_MONTHLY_SALES_REPORT_ADMIN},
                //13
                new SelectListItem{Text = PATTERN_EVENT_NAME_MONTHLY_SALES_REPORT_CUSTOMER, Value = PATTERN_EMAIL_HTML_MONTHLY_SALES_REPORT_CUSTOMER},
                //14
                new SelectListItem{Text = PATTERN_EVENT_NAME_CUSTOMER_PROFILE_UPDATED, Value = PATTERN_EMAIL_HTML_CUSTOMER_PROFILE_UPDATED},
                //15
                new SelectListItem{Text = PATTERN_EVENT_NAME_AFFILIGATE_REFERRAL_PROGRAM, Value = PATTERN_EMAIL_HTML_AFFILIGATE_REFERRAL_PROGRAM},
                //16
                new SelectListItem{Text =PATTERN_EVENT_NAME_PARTNERSHIP_SUSPENDED, Value = PATTERN_EMAIL_HTML_PARTNERSHIP_SUSPENDED},
                //17
                new SelectListItem{Text =PATTERN_EVENT_NAME_CUSTOMER_ACCOUNT_CLOSED, Value = PATTERN_EMAIL_HTML_CUSTOMER_ACCOUNT_CLOSED},
                //18
                new SelectListItem{Text = PATTERN_EVENT_NAME_USER_PAYMENT_BUYER_AUTO_PAYMENT, Value =PATTERN_EMAIL_HTML_USER_PAYMENT_BUYER_AUTO_PAYMENT},
                //18
                new SelectListItem{Text = PATTERN_EVENT_NAME_USER_PAYMENT_BUYER_REFUND_COMPLETED, Value =PATTERN_EMAIL_HTML_USER_PAYMENT_BUYER_REFUND_COMPLETED}

            };
      return items;
    }

  }
}