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

namespace Nemiro
{

  public static partial class Convertion
  {

    /// <summary>
    /// Converts the value of the specified object to an equivalent Boolean value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="default">The default value is to be returned in the case of conversion errors.</param>
    public static bool? ToBoolean(object value, bool? @default)
    {
      if (!Convertion.HasValue(value)) { return @default; }
      bool result;
      if (!bool.TryParse(value.ToString(), out result))
      {
        if (value.ToString() == "1")
        {
          return true;
        }
        else if (value.ToString() == "0")
        {
          return false;
        }
        if (Array.IndexOf(new Type[] { typeof(byte), typeof(Int16), typeof(Int32), typeof(Int64) }, value.GetType()) != -1)
        {
          return Convertion.ToInt32(value) != 0;
        }
        return @default;
      }
      return result;
    }

    /// <summary>
    /// Converts the value of the specified object to an equivalent Boolean value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="default">The default value is to be returned in the case of conversion errors.</param>
    public static bool ToBoolean(object value, bool @default)
    {
      return Convertion.ToBoolean(value, (bool?)@default).GetValueOrDefault(@default);
    }

    /// <summary>
    /// Converts the value of the specified object to an equivalent Boolean value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static bool ToBoolean(object value)
    {
      return Convertion.ToBoolean(value, null).GetValueOrDefault(false);
    }

  }

}