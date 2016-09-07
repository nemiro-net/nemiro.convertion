// ----------------------------------------------------------------------------
// Copyright © Aleksey Nemiro, 2008-2014. All rights reserved.
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
using System.Threading;

namespace Nemiro
{

  public static partial class Convertion
  {

    /// <summary>
    /// Converts the value of the specified object to a <see cref="System.TimeSpan"/> object.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="default">The default value is to be returned in the case of conversion errors.</param>
    /// <param name="timeSeparator">The string that separates the components of time, that is, the hour, minutes, and seconds.</param>
    public static TimeSpan? ToTimeSpan(object value, string timeSeparator, TimeSpan? @default)
    {
      if (!Convertion.HasValue(value)) { return @default; }
      if (String.IsNullOrEmpty(timeSeparator)) { timeSeparator = Thread.CurrentThread.CurrentCulture.DateTimeFormat.TimeSeparator; }
      if (Thread.CurrentThread.CurrentCulture.DateTimeFormat.TimeSeparator != timeSeparator)
      {
        value = value.ToString().Replace(timeSeparator, Thread.CurrentThread.CurrentCulture.DateTimeFormat.TimeSeparator);
      }
      long? ticks = Convertion.ToInt64(value, null);
      if (ticks.HasValue)
      {
        try
        {
          return TimeSpan.FromTicks(ticks.Value);
        }
        catch { }
      }
      TimeSpan result;
      if (!TimeSpan.TryParse(value.ToString(), out result))
      {
        return @default;
      }
      return result;
    }

    /// <summary>
    /// Converts the value of the specified object to a <see cref="System.TimeSpan"/> object.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="default">The default value is to be returned in the case of conversion errors.</param>
    public static TimeSpan? ToTimeSpan(object value, TimeSpan? @default)
    {
      return Convertion.ToTimeSpan(value, null, @default);
    }

    /// <summary>
    /// Converts the value of the specified object to a <see cref="System.TimeSpan"/> object.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="default">The default value is to be returned in the case of conversion errors.</param>
    /// <param name="timeSeparator">The string that separates the components of time, that is, the hour, minutes, and seconds.</param>
    public static TimeSpan ToTimeSpan(object value, string timeSeparator, TimeSpan @default)
    {
      return Convertion.ToTimeSpan(value, timeSeparator, (TimeSpan?)@default).GetValueOrDefault(TimeSpan.Zero);
    }

    /// <summary>
    /// Converts the value of the specified object to a <see cref="System.TimeSpan"/> object.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="timeSeparator">The string that separates the components of time, that is, the hour, minutes, and seconds.</param>
    public static TimeSpan ToTimeSpan(object value, string timeSeparator)
    {
      return Convertion.ToTimeSpan(value, timeSeparator, (TimeSpan?)null).GetValueOrDefault(TimeSpan.Zero);
    }

    /// <summary>
    /// Converts the value of the specified object to a <see cref="System.TimeSpan"/> object.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="default">The default value is to be returned in the case of conversion errors.</param>
    public static TimeSpan ToTimeSpan(object value, TimeSpan @default)
    {
      return Convertion.ToTimeSpan(value, null, (TimeSpan?)@default).GetValueOrDefault(TimeSpan.Zero);
    }

    /// <summary>
    /// Converts the value of the specified object to a <see cref="System.TimeSpan"/> object.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static TimeSpan ToTimeSpan(object value)
    {
      return Convertion.ToTimeSpan(value, null, null).GetValueOrDefault(TimeSpan.Zero);
    }

  }

}