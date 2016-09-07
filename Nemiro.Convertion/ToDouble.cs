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
using System.Globalization;
using System.Threading;

namespace Nemiro
{

  public static partial class Convertion
  {

    /// <summary>
    /// Converts the value of the specified object to an double-precision floating-point number.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="default">The default value is to be returned in the case of conversion errors.</param>
    public static double? ToDouble(object value, double? @default)
    {
      if (!Convertion.HasValue(value)) { return @default; }
      double result = 0;
      if (!double.TryParse(Convertion.GetNumber(value), NumberStyles.Any, Thread.CurrentThread.CurrentCulture, out result))
      {
        return @default;
      }
      return result;
    }

    /// <summary>
    /// Converts the value of the specified object to an double-precision floating-point number.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="default">The default value is to be returned in the case of conversion errors.</param>
    public static double ToDouble(object value, double @default)
    {
      return Convertion.ToDouble(value, (double?)@default).GetValueOrDefault(@default);
    }

    /// <summary>
    /// Converts the value of the specified object to an double-precision floating-point number.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static double ToDouble(object value)
    {
      return Convertion.ToDouble(value, null).GetValueOrDefault();
    }

  }

}
