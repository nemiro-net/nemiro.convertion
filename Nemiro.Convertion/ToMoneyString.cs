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

namespace Nemiro
{

  public static partial class Convertion
  {

    /// <summary>
    /// Returns a string containing a number formatted as a currency amount. For example: 1 000.45
    /// </summary>
    /// <param name="value">The amount that you want to convert.</param>
    /// <param name="penny">Indicates should be considered a penny or not.</param>
    public static string ToMoneyString(object value, bool penny)
    {
      if (penny)
      {
        return Convertion.ToDecimal(value).ToString("##,###,##0.00");
      }
      else
      {
        return Convertion.ToDecimal(value).ToString("##,###,##0");
      }
    }

    /// <summary>
    /// Returns a string containing a number formatted as a currency amount without penny. For example: 1 000 000
    /// </summary>
    /// <param name="value">The amount that you want to convert.</param>
    public static string ToMoneyString(object value)
    {
      return Convertion.ToMoneyString(value, false);
    }

  }

}