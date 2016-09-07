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
using System.Text.RegularExpressions;
using System.Globalization;

namespace Nemiro
{

  /// <summary>
  /// Converts a data type to another data type.
  /// </summary>
  /// <remarks>
  /// <para>This class provides a type conversion without incurring exceptions.</para>
  /// <para><see cref="System.DBNull"/> values ​​are treated as <c>null</c>.</para>
  /// <para>For floating-point numbers can be specified point or comma.</para>
  /// <para>To obtain the date, you can specify the format in which it is presented.</para>
  /// </remarks>
  /// <example>
  /// <code lang="C#">
  /// Console.WriteLine("1.  {0}", Convertion.ToInt32("  123,456  "));
  /// Console.WriteLine("2.  {0}", Convertion.ToInt32("28.01"));
  /// Console.WriteLine("3.  {0}", Convertion.ToInt32(DBNull.Value));
  /// Console.WriteLine("4.  {0}", Convertion.ToInt32(DBNull.Value, 555));
  /// Console.WriteLine("5.  {0}", Convertion.ToDouble("  123,456  "));
  /// Console.WriteLine("6.  {0}", Convertion.ToDouble("28.01"));
  /// Console.WriteLine("7.  {0}", Convertion.ToBoolean("true"));
  /// Console.WriteLine("8.  {0}", Convertion.ToBoolean("false"));
  /// Console.WriteLine("9.  {0}", Convertion.ToBoolean("1"));
  /// Console.WriteLine("10. {0}", Convertion.ToBoolean("0"));
  /// Console.WriteLine("11. {0}", Convertion.ToBoolean("   123      "));
  /// Console.WriteLine("12. {0}", Convertion.ToDateTime("31.12.1980", "dd.MM.yyyy"));
  /// Console.WriteLine("13. {0}", Convertion.ToDateTime("12/31/1980", "MM/dd/yyyy"));
  /// Console.WriteLine("14. {0}", Convertion.ToDateTime("23:59:01"));
  /// Console.WriteLine("15. {0}", Convertion.ToDateTime(DBNull.Value));
  /// Console.WriteLine("16. {0}", Convertion.ToDateTime(DBNull.Value, DateTime.Now));
  /// Console.WriteLine("17. {0}", Convertion.ToBase16(16));
  /// Console.WriteLine("18. {0}", Convertion.FromBase16("10"));
  /// Console.WriteLine("19. {0}", Convertion.ToBase16(123123));
  /// Console.WriteLine("20. {0}", Convertion.FromBase16("AF01"));
  /// Console.WriteLine("21. {0}", Convertion.ToBase36(36));
  /// Console.WriteLine("22. {0}", Convertion.FromBase36("10"));
  /// Console.WriteLine("23. {0}", Convertion.ToBase36(123123));
  /// Console.WriteLine("24. {0}", Convertion.FromBase36("ZYR1"));
  /// Console.WriteLine("25. {0}", Convertion.ToBase62(62));
  /// Console.WriteLine("26. {0}", Convertion.FromBase62("10"));
  /// Console.WriteLine("27. {0}", Convertion.ToBase62(123123));
  /// Console.WriteLine("28. {0}", Convertion.FromBase62("Nemiro"));
  /// Console.WriteLine("29. {0}", Convertion.ToBase62(45102691578));
  /// Console.WriteLine("30. {0}", Convertion.ToTimeSpan("12:10:59"));
  /// Console.WriteLine("31. {0}", Convertion.ToTimeSpan(635456955015215351));
  /// </code>
  /// <code lang="VB">
  /// Console.WriteLine("1.  {0}", Convertion.ToInt32("  123,456  "))
  /// Console.WriteLine("2.  {0}", Convertion.ToInt32("28.01"))
  /// Console.WriteLine("3.  {0}", Convertion.ToInt32(DBNull.Value))
  /// Console.WriteLine("4.  {0}", Convertion.ToInt32(DBNull.Value, 555))
  /// Console.WriteLine("5.  {0}", Convertion.ToDouble("  123,456  "))
  /// Console.WriteLine("6.  {0}", Convertion.ToDouble("28.01"))
  /// Console.WriteLine("7.  {0}", Convertion.ToBoolean("true"))
  /// Console.WriteLine("8.  {0}", Convertion.ToBoolean("false"))
  /// Console.WriteLine("9.  {0}", Convertion.ToBoolean("1"))
  /// Console.WriteLine("10. {0}", Convertion.ToBoolean("0"))
  /// Console.WriteLine("11. {0}", Convertion.ToBoolean("   123      "))
  /// Console.WriteLine("12. {0}", Convertion.ToDateTime("31.12.1980", "dd.MM.yyyy"))
  /// Console.WriteLine("13. {0}", Convertion.ToDateTime("12/31/1980", "MM/dd/yyyy"))
  /// Console.WriteLine("14. {0}", Convertion.ToDateTime("23:59:01"))
  /// Console.WriteLine("15. {0}", Convertion.ToDateTime(DBNull.Value))
  /// Console.WriteLine("16. {0}", Convertion.ToDateTime(DBNull.Value, DateTime.Now))
  /// Console.WriteLine("17. {0}", Convertion.ToBase16(16))
  /// Console.WriteLine("18. {0}", Convertion.FromBase16("10"))
  /// Console.WriteLine("19. {0}", Convertion.ToBase16(123123))
  /// Console.WriteLine("20. {0}", Convertion.FromBase16("AF01"))
  /// Console.WriteLine("21. {0}", Convertion.ToBase36(36))
  /// Console.WriteLine("22. {0}", Convertion.FromBase36("10"))
  /// Console.WriteLine("23. {0}", Convertion.ToBase36(123123))
  /// Console.WriteLine("24. {0}", Convertion.FromBase36("ZYR1"))
  /// Console.WriteLine("25. {0}", Convertion.ToBase62(62))
  /// Console.WriteLine("26. {0}", Convertion.FromBase62("10"))
  /// Console.WriteLine("27. {0}", Convertion.ToBase62(123123))
  /// Console.WriteLine("28. {0}", Convertion.FromBase62("Nemiro"))
  /// Console.WriteLine("29. {0}", Convertion.ToBase62(45102691578))
  /// Console.WriteLine("30. {0}", Convertion.ToTimeSpan("12:10:59"))
  /// Console.WriteLine("31. {0}", Convertion.ToTimeSpan(635456955015215351))
  /// </code>
  /// <code lang="plain">
  /// Results:
  /// 1.  123
  /// 2.  28
  /// 3.  0
  /// 4.  555
  /// 5.  123.456
  /// 6.  28.01
  /// 7.  True
  /// 8.  False
  /// 9.  True
  /// 10. False
  /// 11. False
  /// 12. 12/31/1980 00:00:00
  /// 13. 12/31/1980 00:00:00
  /// 14. 01/01/0001 23:59:01
  /// 15. 01/01/0001 00:00:00
  /// 16. 09/06/2014 18:05:12 (current date and time)
  /// 17. 10
  /// 18. 16
  /// 19. 1e0f3
  /// 20. 44801
  /// 21. 10
  /// 22. 36
  /// 23. 2n03
  /// 24. 1677997
  /// 25. 10
  /// 26. 62
  /// 27. w1R
  /// 28. 45102691578
  /// 29. Nemiro
  /// 30. 12:10:59
  /// 31. 735482.14:05:01.5215351
  /// </code>
  /// </example>
  public static partial class Convertion
  {
    
    /// <summary>
    /// Converts a specified value to another number system.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="charset">Character set that will be used to format conversion.</param>
    /// <seealso cref="ToBase16(long, string)"/>
    /// <seealso cref="ToBase36(long, string)"/>
    /// <seealso cref="ToBase62(long, string)"/>
    /// <seealso cref="FromBaseX(string, string)"/>
    /// <seealso cref="StringFromBaseX(string, string)"/>
    public static string ToBaseX(long value, string charset)
    {
      if (String.IsNullOrEmpty(charset)) { throw new ArgumentNullException("charset"); }
      if (value == 0) 
      {
        return charset.Substring(0, 1);
      }
      string result = "";
      int basis = charset.Length;
      bool negative = value < 0;
      value = Math.Abs(value);
      while (value != 0)
      {
        int r = Convert.ToInt32(value % basis);
        value /= basis;
        result = charset.Substring(r, 1) + result;
      }
      if (negative)
      {
        result = result.Insert(0, "-");
      }
      return result;
    }

    /// <summary>
    /// Converts the specified value from the specified system to decimal.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="charset">Character set that will be used to format conversion.</param>
    /// <seealso cref="FromBase16(string, string)"/>
    /// <seealso cref="FromBase36(string, string)"/>
    /// <seealso cref="FromBase62(string, string)"/>
    /// <seealso cref="StringFromBaseX(string, string)"/>
    /// <seealso cref="ToBaseX(long, string)"/>
    public static long FromBaseX(string value, string charset)
    {
      if (String.IsNullOrEmpty(charset)) { throw new ArgumentNullException("charset"); }
      long result = 0;
      int basis = charset.Length;
      bool negative = value.StartsWith("-");
      if (negative) { value = value.Substring(1); }
      for (int i = value.Length - 1; i >= 0; i -= 1)
      {
        result += Convert.ToInt64(charset.IndexOf(value[i]) * (Math.Pow(basis, (value.Length - i - 1))));
      }
      if (negative) { result = -result; }
      return result;
    }

    /// <summary>
    /// Converts the specified value from the specified system to decimal and returns string.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="charset">Character set that will be used to format conversion.</param>
    /// <seealso cref="FromBase16(string, string)"/>
    /// <seealso cref="FromBase36(string, string)"/>
    /// <seealso cref="FromBase62(string, string)"/>
    /// <seealso cref="FromBaseX(string, string)"/>
    /// <seealso cref="ToBaseX(long, string)"/>
    public static string StringFromBaseX(string value, string charset)
    {
      if (String.IsNullOrEmpty(charset)) { throw new ArgumentNullException("charset"); }

      long result = 0;
      string zeros = "";
      int basis = charset.Length;
      bool negative = value.StartsWith("-");

      if (negative) { value = value.Substring(1); }

      for (int i = value.Length - 1; i >= 0; i -= 1)
      {
        var n = Convert.ToInt64(charset.IndexOf(value[i]) * (Math.Pow(basis, (value.Length - i - 1))));
        result += n;
        if (n == 0)
        {
          zeros += "0";
        }
        else
        {
          zeros = "";
        }
      }

      return String.Format("{0}{1}{2}", (negative ? "-" : ""), zeros, result);
    }

    /// <summary>
    /// Checks in the specified value has data or is empty.
    /// </summary>
    /// <param name="value">The value for checking.</param>
    private static bool HasValue(object value)
    {
      if (value == DBNull.Value || value == null) { return false; }
      if (value.GetType() == typeof(string) && String.IsNullOrEmpty(value.ToString())) { return false; }
      return true;
    }

    /// <summary>
    /// Returns a string containing a number.
    /// </summary>
    /// <param name="value">The value for processing.</param>
    private static string GetNumber(object value)
    {
      if (!Convertion.HasValue(value)) { return "0"; }

      int comma = value.ToString().LastIndexOf(",");
      int dot = value.ToString().LastIndexOf(".");

      if (comma != -1 && dot != -1)
      {
        int separatorIndex = Math.Max(comma, dot);
        value = value.ToString().Replace((separatorIndex == comma ? "." : ","), "");
      }
      
      return Regex.Replace(Regex.Replace(value.ToString(), @",|\.", NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator), @"\s+", "");
    }

  }

}