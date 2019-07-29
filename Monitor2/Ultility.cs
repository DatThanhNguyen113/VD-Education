using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Monitor2
{
    public static class Ultility
    {
        public static T GenerateFromDataRow<T>(this DataRow dataRow)
 where T : new()
        {
            T item = new T();
            foreach (DataColumn column in dataRow.Table.Columns)
            {
                PropertyInfo property = item.GetType().GetProperty(column.ColumnName);

                if (property != null && dataRow[column] != DBNull.Value)
                {
                    object result = Convert.ChangeType(dataRow[column], property.PropertyType);
                    property.SetValue(item, result, null);
                }
            }

            return item;
        }

        public static IHubProxy GetHubProxy(string hubname)
        {
            var hubip = ConfigurationManager.AppSettings["HubIP"].ToString();
            var hubConnection = new HubConnection(hubip);
            var hub = hubConnection.CreateHubProxy(hubname);
            hubConnection.Start().Wait();
            return hub;
        }

        public static string ConvertDateOfWeek(string day)
        {
            if (day.Length > 0)
            {
                if (day == "Sunday")
                {
                    return "Chủ Nhật";
                }
                else if (day == "Monday")
                {
                    return "Thứ Hai";
                }
                else if (day == "Tuesday")
                {
                    return "Thứ Ba";
                }
                else if (day == "Wednesday")
                {
                    return "Thứ Tư";
                }
                else if (day == "Thursday")
                {
                    return "Thứ Năm";
                }
                else if (day == "Friday")
                {
                    return "Thứ Sáu";
                }
                else if (day == "Saturday")
                {
                    return "Thứ Bảy";
                }
            }
            return "";
        }

        public static List<int> getLessonRage(DateTime mDate, DateTime sDate, int type)
        {
            DateTime aStart;
            aStart = mDate;
            aStart = aStart.AddHours(-(aStart.Hour)).AddMinutes(-(aStart.Minute));
            if (type == 0)
                aStart = aStart.AddHours(7);
            else
                aStart = aStart.AddHours(13);

            var mSpan = aStart.TimeOfDay;
            var startSpan = mDate.TimeOfDay;
            var endSpan = sDate.TimeOfDay;
            var arrTime = new List<int>();
            var iCount = 0;
            for (var i = mSpan.TotalMinutes; i < endSpan.TotalMinutes; i += 50)
            {
                if (i >= startSpan.TotalMinutes)
                {
                    arrTime.Add(iCount);
                    iCount++;
                    var mspan = TimeSpan.FromMinutes(i);
                    if ((mspan.Hours == 8 || mspan.Hours == 14) && mspan.Minutes == 40)
                    {
                        i += 5;
                    }
                    else if ((mspan.Hours == 9 || mspan.Hours == 15) && mspan.Minutes == 35)
                    {
                        i += 10;
                    }
                }
            }
            return arrTime;
        }
    }
}
