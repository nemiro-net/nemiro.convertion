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

namespace Nemiro
{

  public static partial class Convertion
  {

    /// <summary>
    /// Converts the value of the specified object to a 64-bit unsigned integer.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="default">The default value is to be returned in the case of conversion errors.</param>
    public static UInt64? ToUInt64(object value, UInt64? @default)
    {
      if (!Convertion.HasValue(value)) { return @default; }
      decimal? result = Convertion.ToDecimal(value, null);
      if (!result.HasValue || result.Value < UInt64.MinValue || result.Value > UInt64.MaxValue)
      {
        return @default;
      }
      return Convert.ToUInt64(result);
    }

    /// <summary>
    /// Converts the value of the specified object to a 64-bit unsigned integer.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="default">The default value is to be returned in the case of conversion errors.</param>
    public static UInt64 ToUInt64(object value, UInt64 @default)
    {
      return Convertion.ToUInt64(value, (UInt64?)@default).GetValueOrDefault(@default);
    }

    /// <summary>
    /// Converts the value of the specified object to a 64-bit unsigned integer.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static UInt64 ToUInt64(object value)
    {
      return Convertion.ToUInt64(value, null).GetValueOrDefault();
    }

  }

}