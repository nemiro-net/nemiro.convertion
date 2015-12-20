// ----------------------------------------------------------------------------
// Copyright (c) Aleksey Nemiro, 2008-2014. All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading;

namespace Nemiro
{

  public static partial class Convertion
  {

    /// <summary>
    /// Converts the value of the specified object to a <see cref="System.DateTime"/> object.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="default">The default value is to be returned in the case of conversion errors.</param>
    /// <param name="dateSeparator">The string that separates the components of a date, that is, the year, month, and day.</param>
    /// <param name="timeSeparator">The string that separates the components of time, that is, the hour, minutes, and seconds.</param>
    /// <param name="formatDateTime">The format string for a date and time value.</param>
    public static DateTime? ToDateTime(object value, string formatDateTime, string dateSeparator, string timeSeparator, DateTime? @default)
    {
      if (!Convertion.HasValue(value)) { return @default; }
      if (String.IsNullOrEmpty(formatDateTime)) { formatDateTime = Thread.CurrentThread.CurrentCulture.DateTimeFormat.FullDateTimePattern; } // "dd.MM.yyyy HH:mm:ss"
      if (String.IsNullOrEmpty(dateSeparator)) { dateSeparator = Thread.CurrentThread.CurrentCulture.DateTimeFormat.DateSeparator; } // "."
      if (String.IsNullOrEmpty(timeSeparator)) { timeSeparator = Thread.CurrentThread.CurrentCulture.DateTimeFormat.TimeSeparator; } // ":"
      var f = new CultureInfo(Thread.CurrentThread.CurrentCulture.Name, true);
      f.DateTimeFormat.FullDateTimePattern = formatDateTime;
      f.DateTimeFormat.ShortDatePattern = formatDateTime;
      f.DateTimeFormat.DateSeparator = dateSeparator;
      f.DateTimeFormat.TimeSeparator = timeSeparator;
      DateTime result;
      if (!DateTime.TryParse(value.ToString(), f, DateTimeStyles.NoCurrentDateDefault, out result))
      {
        return @default;
      }
      return result;
    }

    /// <summary>
    /// Converts the value of the specified object to a <see cref="System.DateTime"/> object.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="default">The default value is to be returned in the case of conversion errors.</param>
    /// <param name="dateSeparator">The string that separates the components of a date, that is, the year, month, and day.</param>
    /// <param name="formatDateTime">The format string for a date and time value.</param>
    public static DateTime? ToDateTime(object value, string formatDateTime, string dateSeparator, DateTime? @default)
    {
      return Convertion.ToDateTime(value, formatDateTime, dateSeparator, null, @default);
    }

    /// <summary>
    /// Converts the value of the specified object to a <see cref="System.DateTime"/> object.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="default">The default value is to be returned in the case of conversion errors.</param>
    /// <param name="formatDateTime">The format string for a date and time value.</param>
    public static DateTime? ToDateTime(object value, string formatDateTime, DateTime? @default)
    {
      return Convertion.ToDateTime(value, formatDateTime, null, null, @default);
    }

    /// <summary>
    /// Converts the value of the specified object to a <see cref="System.DateTime"/> object.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="default">The default value is to be returned in the case of conversion errors.</param>
    public static DateTime? ToDateTime(object value, DateTime? @default)
    {
      return Convertion.ToDateTime(value, null, null, null, @default);
    }

    /// <summary>
    /// Converts the value of the specified object to a <see cref="System.DateTime"/> object.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="default">The default value is to be returned in the case of conversion errors.</param>
    /// <param name="dateSeparator">The string that separates the components of a date, that is, the year, month, and day.</param>
    /// <param name="timeSeparator">The string that separates the components of time, that is, the hour, minutes, and seconds.</param>
    /// <param name="formatDateTime">The format string for a date and time value.</param>
    public static DateTime ToDateTime(object value, string formatDateTime, string dateSeparator, string timeSeparator, DateTime @default)
    {
      return Convertion.ToDateTime(value, formatDateTime, dateSeparator, timeSeparator, (DateTime?)@default).GetValueOrDefault(@default);
    }

    /// <summary>
    /// Converts the value of the specified object to a <see cref="System.DateTime"/> object.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="dateSeparator">The string that separates the components of a date, that is, the year, month, and day.</param>
    /// <param name="timeSeparator">The string that separates the components of time, that is, the hour, minutes, and seconds.</param>
    /// <param name="formatDateTime">The format string for a date and time value.</param>
    public static DateTime ToDateTime(object value, string formatDateTime, string dateSeparator, string timeSeparator)
    {
      return Convertion.ToDateTime(value, formatDateTime, dateSeparator, timeSeparator, null).GetValueOrDefault();
    }

    /// <summary>
    /// Converts the value of the specified object to a <see cref="System.DateTime"/> object.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="default">The default value is to be returned in the case of conversion errors.</param>
    /// <param name="dateSeparator">The string that separates the components of a date, that is, the year, month, and day.</param>
    /// <param name="formatDateTime">The format string for a date and time value.</param>
    public static DateTime ToDateTime(object value, string formatDateTime, string dateSeparator, DateTime @default)
    {
      return Convertion.ToDateTime(value, formatDateTime, dateSeparator, null, (DateTime?)@default).GetValueOrDefault(@default);
    }

    /// <summary>
    /// Converts the value of the specified object to a <see cref="System.DateTime"/> object.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="dateSeparator">The string that separates the components of a date, that is, the year, month, and day.</param>
    /// <param name="formatDateTime">The format string for a date and time value.</param>
    public static DateTime ToDateTime(object value, string formatDateTime, string dateSeparator)
    {
      return Convertion.ToDateTime(value, formatDateTime, dateSeparator, null, null).GetValueOrDefault();
    }

    /// <summary>
    /// Converts the value of the specified object to a <see cref="System.DateTime"/> object.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="default">The default value is to be returned in the case of conversion errors.</param>
    /// <param name="formatDateTime">The format string for a date and time value.</param>
    public static DateTime ToDateTime(object value, string formatDateTime, DateTime @default)
    {
      return Convertion.ToDateTime(value, formatDateTime, null, null, (DateTime?)@default).GetValueOrDefault(@default);
    }

    /// <summary>
    /// Converts the value of the specified object to a <see cref="System.DateTime"/> object.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="formatDateTime">The format string for a date and time value.</param>
    public static DateTime ToDateTime(object value, string formatDateTime)
    {
      return Convertion.ToDateTime(value, formatDateTime, null, null, null).GetValueOrDefault();
    }

    /// <summary>
    /// Converts the value of the specified object to a <see cref="System.DateTime"/> object.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="default">The default value is to be returned in the case of conversion errors.</param>
    public static DateTime ToDateTime(object value, DateTime @default)
    {
      return Convertion.ToDateTime(value, null, null, null, (DateTime?)@default).GetValueOrDefault(@default);
    }

    /// <summary>
    /// Converts the value of the specified object to a <see cref="System.DateTime"/> object.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static DateTime ToDateTime(object value)
    {
      return Convertion.ToDateTime(value, null, null, null, null).GetValueOrDefault();
    }

  }

}