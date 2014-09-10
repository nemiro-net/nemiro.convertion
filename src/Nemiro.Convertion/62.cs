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

    private const string Charset62 = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

    /// <summary>
    /// Converts the value of the specified number to duosexagesimal format.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="charset">Character set that will be used to format conversion. At least 62 characters. Default: <c>0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ</c>.</param>
    /// <seealso cref="Convertion.ToBase16(long, string)"/>
    /// <seealso cref="Convertion.ToBase36(long, string)"/>
    /// <seealso cref="Convertion.ToBaseX(long, string)"/>
    /// <seealso cref="Convertion.FromBase62(string, string)"/>
    public static string ToBase62(long value, string charset)
    {
      if (String.IsNullOrEmpty(charset)) { charset = Convertion.Charset62; }
      if (charset.Length < 62) { throw new ArgumentOutOfRangeException("charset"); }
      return Convertion.ToBaseX(value, charset);
    }

    /// <summary>
    /// Converts the value of the specified number to duosexagesimal format.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <seealso cref="Convertion.ToBase16(long)"/>
    /// <seealso cref="Convertion.ToBase36(long)"/>
    /// <seealso cref="Convertion.ToBaseX(long, string)"/>
    /// <seealso cref="Convertion.FromBase62(string)"/>
    public static string ToBase62(long value)
    {
      return Convertion.ToBase62(value, null);
    }

    /// <summary>
    /// Converts the value in duosexagesimal format to a 64-bit signed integer.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="charset">Character set that will be used to format conversion. At least 62 characters. Default: <c>0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ</c>.</param>
    /// <seealso cref="Convertion.FromBase16(string, string)"/>
    /// <seealso cref="Convertion.FromBase36(string, string)"/>
    /// <seealso cref="Convertion.FromBaseX(string, string)"/>
    /// <seealso cref="Convertion.ToBase62(long, string)"/>
    public static long FromBase62(string value, string charset)
    {
      if (String.IsNullOrEmpty(charset)) { charset = Convertion.Charset62; }
      if (charset.Length < 62) { throw new ArgumentOutOfRangeException("charset"); }
      return Convertion.FromBaseX(value, charset);
    }

    /// <summary>
    /// Converts the value in duosexagesimal format to a 64-bit signed integer.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <seealso cref="Convertion.FromBase16(string)"/>
    /// <seealso cref="Convertion.FromBase36(string)"/>
    /// <seealso cref="Convertion.FromBaseX(string, string)"/>
    /// <seealso cref="Convertion.ToBase62(long)"/>
    public static long FromBase62(string value)
    {
      return Convertion.FromBase62(value, null);
    }

  }

}
