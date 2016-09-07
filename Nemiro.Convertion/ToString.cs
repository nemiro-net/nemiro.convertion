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
    /// Converts the value of the specified object to a string.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="default">The default value if the object contains no data.</param>
    public static string ToString(object value, string @default)
    {
      if (!Convertion.HasValue(value)) { return @default; }
      return value.ToString();
    }

    /// <summary>
    /// Converts the value of the specified object to a string.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static string ToString(object value)
    {
      return Convertion.ToString(value, String.Empty);
    }

  }

}