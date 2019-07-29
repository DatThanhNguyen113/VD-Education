using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Bcore.Utility
{



    public class SystemEnumCore
    {

        public const string FORMAT_DATE_1 = "MM/dd/yyyy HH:mm:ss";
        public const string FORMAT_DATE_2 = "MM/dd/yyyy";
        public const string HH_MM_SS = "HH:mm:ss";
        public const string FORMAT_DATE_3 = "yyyy-MM-dd HH:mm:ss";
        public const string FORMAT_DATE_DEFAULT = "yyyy-MM-dd";
        public const string FORMAT_DATE_DAY_START = "yyyy-MM-dd 00:00:00";
        public const string FORMAT_DATE_DAY_END = "yyyy-MM-dd 23:59:59";
        public const string DATE_DEFAULT = "0001-01-01";
        public const string DATE_DEFAULT_EXPORT_DATA = "1970-01-01 11:59:59";
        public static string UrlServerTransfer = "http://guest-protocol-a59.secondclone.com";
        public static readonly int IsPublic = 1;
        public static readonly int NoPublic = 0;
        public static string TokenKeySystem;
        public static int MAX_DEVICE = 3;
        public static readonly int DayShowRenew = 15;
        public static readonly string DefaultLanguage = "en-US";

       
        public class Sys_ViewID
        {
            public static readonly string user = "2";
            public static readonly string scp_user_activity = "4";
            public static readonly string scp_user_device = "5";
            public static readonly string scp_contact = "6";
            public static readonly string AFG_DOCUMENT = "7";
            public static readonly string AFG_CONTRACT = "8";
            public static readonly string AFG_ACCOUNT = "9";
            public static readonly string AFG_REPORT = "10";
            public static readonly string AFG_RELATIONSHIP = "11";
            public static readonly string AFG_CUSTOMER_STATISTICS = "12";
            public static readonly string CUSTOMER_ACTIVITY = "13";
            public static readonly string EMAIL_SENDING = "14";
            public static readonly string AFG_ACCOUNT_ACTIVITY = "15";
            public static readonly string AFG_CATEGORY = "16";
            public static readonly string AFG_COUNTRY = "17";
            public static readonly string AFG_DOCUMENT1 = "18";
            public static readonly string AFG_PAYMENT_METHOD_INFO = "19";
            public static readonly string ADMIN_ROLE = "20";
            public static readonly string AFG_ADMIN_PERMISSION = "21";
            public static readonly string scp_init_page = "22";
            public static readonly string ADMIN_ROLE_PERMISSION = "23";
            public static readonly string AFG_CURRENCY = "24";
            public static readonly string scp_payment_log = "25";
            public static readonly string MONTHLY_PARTNER_INCOME = "26";
            public static readonly string AFG_COUPON = "27";
            public static readonly string ADMIN_ACCOUNT_ROLE = "28";
            public static readonly string AFG_CUSTOMER_PAYMENT_INFO = "29";
            public static readonly string Data_Definition = "30";
            public static readonly string Monthly_Sales_Report_Get = "31";
            public static readonly string scp_coupon_account = "32";
            public static readonly string scp_count_info_data = "33";
            public static readonly string scp_discount = "34";
            public static readonly string AFG_SCHEDULED_JOB = "35";
            public static readonly string scp_Culture = "36";
            public static readonly string scp_Partner = "37";
            public static readonly string scp_MaintenanceConfig = "38";
            public static readonly string scp_Language = "39";
            //public static readonly string scp_EmailPattern = "49";
            public static readonly string scp_EmailPattern = "8";
            public static readonly string scp_EmailPatternMapping = "41";
            public static readonly string scp_SystemConfig = "46";
            public static readonly string scp_order_report = "43";
            public static readonly string scp_ProtocolSites = "44";
            public static readonly string AFG_Order = "45";
            public static readonly string AFG_ADMIN_ACCOUNT = "46";
            public static readonly string AFG_PROGRAM = "47";
            public static readonly string AFG_PRODUCT_FOLDER = "48";
            public static readonly string MONTHLY_PARTNER_REPORT = "49";
            public static readonly string AFG_PRODUCT = "50";
            public static readonly string ORDER_AUTO_RENEW = "51";
            public static readonly string AFG_BALANCES = "52";
            public static readonly string AFG_ACOUNT_BALANCE = "53";
            public static readonly string AFG_EXCHANGE_RATES = "54";
            public static readonly string AFG_TRANSACTION_HISTORY = "55";
            public static readonly string AFG_BALANCE_HISTORY = "56";
            public static readonly string AFG_BALANCE_CALCULATING_MONTHLY = "57";
            public static readonly string AFG_PRODUCT_COUPON = "58";
            public static readonly string AFG_LICENSE_LIST = "59";
            public static readonly string AFG_LICENSE_PROVIDER = "60";
            public static readonly string AFG_LICENSE_PRODUCT = "61";
            public static readonly string AFG_MY_CUSTOMER = "62";
        }
        public class Status
        {
            public static readonly int Success = 1;
            public static readonly int Failed = 0;
            public static readonly int SessionExpired = -1;
        }

        public class ResultID
        {
            public static readonly int Failed = 0;
            public static readonly int Success = 1;
        }

        public class IdTable
        {
            public static readonly int IdDefault = 0;
        }

        public class ResponseSuccess
        {
            public static readonly int Success = 1;
            public static readonly int Failed = 0;
        }
        public class Pagination
        {
            public static int PageDefault = 0;
            public static int TakeNumber = 30;
        }
        // path save file images
        public static string PathSaveMedia = "/Media/";

        public class MediaType
        {
            public static readonly string Picture = "Picture";
            public static readonly string Video = "Video";
            public static readonly string MeoMos = "MeoMos";
            public static readonly string CallRecording = "CallRecording";
        }

        public static readonly string ApplicationSettings = "ApplicationSettings";
    }
    public class ScpMenuEnumCore
    {
        public class AllowAnonymous
        {
            public static readonly int Allow = 1;
            public static readonly int NotAllow = 0;
        }
    }
    //public class ScpSystemConfigEnumCore
    //{
    //    public static readonly string SYSTEM_THREADING_SLEEP = "SYSTEM_THREADING_SLEEP";
    //    public static readonly string CurrentVersion = "CurrentVersion";
    //    public static readonly string AF_SEND_NOTIFICATION = "AF_SEND_NOTIFICATION";
    //    public static readonly string EMAIL_SUPPORT = "EMAIL_SUPPORT";
    //    public static readonly string EMAIL_SUPPORT_TITLE = "EMAIL_SUPPORT_TITLE";
    //    public static readonly string LOGIN_NOTIFICATION_EMAILS = "LOGIN_NOTIFICATION_EMAILS";
    //    public static readonly string PURCHASE_NOTIFICATION_EMAILS = "PURCHASE_NOTIFICATION_EMAILS";
    //    public static readonly string ORDER_NOTIFICATION_EMAILS = "ORDER_NOTIFICATION_EMAILS";
    //    public static readonly string REFUND_NOTIFICATION_EMAILS = "REFUND_NOTIFICATION_EMAILS";
    //    public static readonly string CHARGEBACK_NOTIFICATION_EMAILS = "CHARGEBACK_NOTIFICATION_EMAILS";
    //    public static readonly string DEVELOPER_TEAM_EMAILS = "DEVELOPER_TEAM_EMAILS";
    //    public static readonly string MAINTENANCE_TEAM_EMAILS = "MAINTENANCE_TEAM_EMAILS";
    //    public static readonly string SYSTEM_ADMIN_NOTIFICATION_EMAILS = "SYSTEM_ADMIN_NOTIFICATION_EMAILS";
    //    public static readonly string SYSTEM_ADMIN_EMAILS = "SYSTEM_ADMIN_EMAILS";
    //    public static readonly string BCC_NOTIFICATION_EMAILS = "BCC_NOTIFICATION_EMAILS";
    //    public static readonly string EMAIL_SERVICE_HOST = "EMAIL_SERVICE_HOST";
    //    public static readonly string EMAIL_SERVICE_PORT = "EMAIL_SERVICE_PORT";
    //    public static readonly string EMAIL_SERVICE_USERNAME = "EMAIL_SERVICE_USERNAME";
    //    public static readonly string EMAIL_SERVICE_PASSWORD = "EMAIL_SERVICE_PASSWORD";
    //    public static readonly string EMAIL_RECEIVE_GIFTCODE = "EMAIL_RECEIVE_GIFTCODE";
    //    public static readonly string GOOGLE_ANALYTICS_ACCOUNT = "GOOGLE_ANALYTICS_ACCOUNT";
    //    public static readonly string GOOGLE_API_KEY = "GOOGLE_API_KEY";
    //    public static readonly string COMPANY_NAME = "COMPANY_NAME";
    //    public static readonly string PRODUCT_NAME = "PRODUCT_NAME";
    //    public static readonly string PRODUCT_NAME_ALIAS = "PRODUCT_NAME_ALIAS";
    //    public static readonly string PRODUCT_PREFIX_NAME = "PRODUCT_PREFIX_NAME";
    //    public static readonly string WEBSITE = "WEBSITE";
    //    public static readonly string WEBSITE_CPANEL = "WEBSITE_CPANEL";
    //    public static readonly string WEBSITE_ADMINTOOL = "WEBSITE_ADMINTOOL";
    //    public static readonly string WEBSITE_ANDROID_DOWNLOAD = "WEBSITE_ANDROID_DOWNLOAD";
    //    public static readonly string WEBSITE_IOS_DOWNLOAD = "WEBSITE_IOS_DOWNLOAD";
    //    public static readonly string WEBSITE_AFFILIATE = "WEBSITE_AFFILIATE";
    //    public static readonly string WEBSITE_SUPPORT = "WEBSITE_SUPPORT";
    //    public static readonly string WEBSITE_FORUM = "WEBSITE_FORUM";
    //    public static readonly string WEBSITE_BLOG = "WEBSITE_BLOG";
    //    public static readonly string WEBSITE_AMBIENT_VOICE_RECORDING_STREAMING = "WEBSITE_AMBIENT_VOICE_RECORDING_STREAMING";
    //    public static readonly string WEBSITE_PROTOCOL = "WEBSITE_PROTOCOL";
    //    public static readonly string LOGO_IMAGE_PATH = "LOGO_IMAGE_PATH";
    //    public static readonly string SHORTCUT_ICON_PATH = "SHORTCUT_ICON_PATH";
    //    public static readonly string LINK_HOW_TO_ADD_DEVICES_IOS = "LINK_HOW_TO_ADD_DEVICES_IOS";
    //    public static readonly string LINK_HOW_TO_ADD_DEVICES_ANDROID = "LINK_HOW_TO_ADD_DEVICES_ANDROID";
    //    public static readonly string LINK_TERMS_OF_USES = "LINK_TERMS_OF_USES";
    //    public static readonly string LINK_FAQ = "LINK_FAQ";
    //    public static readonly string LINK_CONTACT_US = "LINK_CONTACT_US";
    //    public static readonly string LINK_FORUM = "LINK_FORUM";
    //    public static readonly string LINK_BLOG = "LINK_BLOG";
    //    public static readonly string FOLDER_STYLE = "FOLDER_STYLE";
    //    public static readonly string CAPTCHA_ENABLE = "CAPTCHA_ENABLE";
    //    public static readonly string DISPLAY_MONITOR_APP_MESSAGE = "DISPLAY_MONITOR_APP_MESSAGE";
    //    public static readonly string DISPLAY_RENEW_OPTION = "DISPLAY_RENEW_OPTION";
    //    public static readonly string DISPLAY_COPYRIGHT = "DISPLAY_COPYRIGHT";
    //    public static readonly string DISPLAY_SET_LANG = "DISPLAY_SET_LANG";
    //    public static readonly string LANGUAGE_LIST = "LANGUAGE_LIST";
    //    public static readonly string LANGUAGE = "LANGUAGE";
    //    public static readonly string USER_REGISTRATION_PAGE_NICKNAME_NEEDS = "USER_REGISTRATION_PAGE_NICKNAME_NEEDS";
    //    public static readonly string USERNAME_MUST_BE_IN_EMAIL_FORMAT = "USERNAME_MUST_BE_IN_EMAIL_FORMAT";
    //    public static readonly string FEATURE_RESET_LOG_ENABLE = "FEATURE_RESET_LOG_ENABLE";
    //    public static readonly string FEATURE_DELIVERY_LOGS_BY_EMAIL_ENABLE = "FEATURE_DELIVERY_LOGS_BY_EMAIL_ENABLE";
    //    public static readonly string FEATURE_DISCOUNT_COUPONS_ENABLE = "FEATURE_DISCOUNT_COUPONS_ENABLE";
    //    public static readonly string FEATURE_DISCOUNT_COUPONS_PERCENT_WHEN_SEND_EMAIL = "FEATURE_DISCOUNT_COUPONS_PERCENT_WHEN_SEND_EMAIL";
    //    public static readonly string PAYPAL_SUPPORT_LITE_PACKAGE = "PAYPAL_SUPPORT_LITE_PACKAGE";
    //    public static readonly string AMBIENT_VOICE_RECORDING_AUDIO_PATH = "AMBIENT_VOICE_RECORDING_AUDIO_PATH";
    //    public static readonly string FREE_DAY = "FREE_DAY";
    //    public static readonly string DEFAULT_ACCESS_CODE = "DEFAULT_ACCESS_CODE";
    //    public static readonly string DEFAULT_PACKAGE_CODE = "DEFAULT_PACKAGE_CODE";
    //    public static readonly string USE_PROTOCOL_NAVIGATOR = "USE_PROTOCOL_NAVIGATOR";
    //    public static readonly string DISTRIBUTOR_DEFAULT_COMMISSION_PERCENT = "DISTRIBUTOR_DEFAULT_COMMISSION_PERCENT";
    //    public static readonly string ADMINTOOL_SHOW_PASSWORD = "ADMINTOOL_SHOW_PASSWORD";
    //    public static readonly string CDN_URL = "CDN_URL";
    //    public static readonly string CDN_FOLDER = "CDN_FOLDER";
    //    public static readonly string ADMINTOOL_DATETIME_FORMAT = "ADMINTOOL_DATETIME_FORMAT";
    //    public static readonly string ADMINTOOL_DATETIME_FORMAT_LONG = "ADMINTOOL_DATETIME_FORMAT_LONG";
    //    public static readonly string GUI_OPTION_HIDE_WARNING_AT_CP_LOGIN = "GUI_OPTION_HIDE_WARNING_AT_CP_LOGIN";
    //    public static readonly string CERTIFICATION_APS_PRODUCTION_FILE_NAME = "CERTIFICATION_APS_PRODUCTION_FILE_NAME";
    //    public static readonly string DEFAULT_RESET_PASSWORD = "DEFAULT_RESET_PASSWORD";
    //    public static readonly string PROTOCOL_MEDIA_URL = "PROTOCOL_MEDIA_URL";
    //    public static readonly string AMBIENT_RECORDING_TOTAL_FILE_NUMBER_FOR_EACH_ACCOUNT = "AMBIENT_RECORDING_TOTAL_FILE_NUMBER_FOR_EACH_ACCOUNT";
    //    public static readonly string AMBIENT_RECORDING_MAX_FILE_SIZE_FOR_EACH_FILE = "AMBIENT_RECORDING_MAX_FILE_SIZE_FOR_EACH_FILE";
    //    public static readonly string AMBIENT_RECORDING_MAX_SIZE_FOR_EACH_ACCOUNT = "AMBIENT_RECORDING_MAX_SIZE_FOR_EACH_ACCOUNT";
    //    public static readonly string AMBIENT_RECORDING_MAX_DURING_TIME = "AMBIENT_RECORDING_MAX_DURING_TIME";
    //    public static readonly string RELEASE_NOTES = "RELEASE_NOTES";
    //    public static readonly string DISPLAY_EXPIRING_SOON_BEFORE_X_DAYS = "DISPLAY_EXPIRING_SOON_BEFORE_X_DAYS";
    //    public static readonly string LINK_HOW_TO_ROOT_AN_ANDROID = "LINK_HOW_TO_ROOT_AN_ANDROID";
    //    public static readonly string KEY_DISPLAY_CPANEL_WELCOME_MESSAGE = "KEY_DISPLAY_CPANEL_WELCOME_MESSAGE";
    //    public static readonly string APPEAR_CAPTCHA_WHEN_COUNT_WRONG = "APPEAR_CAPTCHA_WHEN_COUNT_WRONG";
    //    public static readonly string VERSION_INFO = "VERSION_INFO";
    //}
}
