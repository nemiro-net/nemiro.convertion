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

    private const string Charset16 = "0123456789abcdef";

    /// <summary>
    /// Converts the value of the specified number to hexadecimal format.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="charset">Character set that will be used to format conversion. At least 16 characters. Default: <c>0123456789abcdef</c>.</param>
    /// <seealso cref="ToBase36(long, string)"/>
    /// <seealso cref="ToBase62(long, string)"/>
    /// <seealso cref="ToBaseX"/>
    /// <seealso cref="FromBase16(string, string)"/>
    public static string ToBase16(long value, string charset)
    {
      if (String.IsNullOrEmpty(charset)) { charset = Convertion.Charset16; }
      if (charset.Length < 16) { throw new ArgumentOutOfRangeException("charset"); }
      return Convertion.ToBaseX(value, charset);
    }

    /// <summary>
    /// Converts the value of the specified number to hexadecimal format.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <seealso cref="ToBase36(long)"/>
    /// <seealso cref="ToBase62(long)"/>
    /// <seealso cref="ToBaseX"/>
    /// <seealso cref="FromBase16(string)"/>
    public static string ToBase16(long value)
    {
      return Convertion.ToBase16(value, null);
    }

    /// <summary>
    /// Converts the value in hexadecimal format to a 64-bit signed integer.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="charset">Character set that will be used to format conversion. At least 16 characters. Default: <c>0123456789abcdef</c>.</param>
    /// <seealso cref="FromBase36(string, string)"/>
    /// <seealso cref="FromBase62(string, string)"/>
    /// <seealso cref="FromBaseX"/>
    /// <seealso cref="ToBase16(long, string)"/>
    public static long FromBase16(string value, string charset)
    {
      if (String.IsNullOrEmpty(charset)) { charset = Convertion.Charset16; }
      if (charset.Length < 16) { throw new ArgumentOutOfRangeException("charset"); }
      return Convertion.FromBaseX(value, charset);
    }

    /// <summary>
    /// Converts the value in hexadecimal format to a 64-bit signed integer.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <seealso cref="FromBase36(string)"/>
    /// <seealso cref="FromBase62(string)"/>
    /// <seealso cref="FromBaseX"/>
    /// <seealso cref="ToBase16(long)"/>
    public static long FromBase16(string value)
    {
      return Convertion.FromBase16(value.ToLower(), null);
    }

  }

}