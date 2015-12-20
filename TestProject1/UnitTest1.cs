using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nemiro;

namespace TestProject1
{

  /// <summary>
  /// Сводное описание для UnitTest1
  /// </summary>
  [TestClass]
  public class UnitTest1
  {

    public UnitTest1()
    {
      
    }

    private TestContext testContextInstance;

    /// <summary>
    ///Получает или устанавливает контекст теста, в котором предоставляются
    ///сведения о текущем тестовом запуске и обеспечивается его функциональность.
    ///</summary>
    public TestContext TestContext
    {
      get
      {
        return testContextInstance;
      }
      set
      {
        testContextInstance = value;
      }
    }

    [TestMethod]
    public void AnyTest()
    {
      string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
      string r = "BCD";
      long n = Convertion.FromBaseX(r, chars);
      string r2 = Convertion.ToBaseX(n, chars);
      this.TestContext.WriteLine("{0} => {1} => {2}", r, r2, n);
      Assert.AreEqual(r, r2);
    }

    [TestMethod]
    public void Base16()
    {
      for (int n = 0; n <= 256; n++)
      {
        string r = Convertion.ToBase16(n);
        long n2 = Convertion.FromBase16(r);
        this.TestContext.WriteLine("{0} => {1} => {2}", n, r, n2);
        Assert.AreEqual(n, n2);
      }

      this.TestContext.WriteLine("FF => {0}", Convertion.FromBase16("FF"));

      var rnd = new Random(DateTime.Now.Millisecond);
      var range = new int[,] { { Int32.MinValue, 0 }, { 0, Int32.MaxValue }, { Int32.MinValue, Int32.MaxValue } };
      for (int i = 0; i <= range.GetLength(0) - 1; i++)
      {

        this.TestContext.WriteLine("");
        this.TestContext.WriteLine("DEFAULT");

        for (int j = 1; j <= 100; j++)
        {
          long n = rnd.Next(range[i, 0], range[i, 1]);
          string r = Convertion.ToBase16(n);
          long n2 = Convertion.FromBase16(r);
          this.TestContext.WriteLine("{0} => {1} => {2}", n, r, n2);
          Assert.AreEqual(n, n2);
        }

        this.TestContext.WriteLine("");
        this.TestContext.WriteLine("CUSTOM");
        string customCharset = "ABCDEFGHIJKLMNOP";

        for (int j = 1; j <= 100; j++)
        {
          long n = rnd.Next(range[i, 0], range[i, 1]);
          string r = Convertion.ToBase16(n, customCharset);
          long n2 = Convertion.FromBase16(r, customCharset);
          this.TestContext.WriteLine("{0} => {1} => {2}", n, r, n2);
          Assert.AreEqual(n, n2);
        }
      }
    }
    
    [TestMethod]
    public void Base36()
    {
      for (int n = 0; n <= 1296; n++)
      {
        string r = Convertion.ToBase36(n);
        long n2 = Convertion.FromBase36(r);
        this.TestContext.WriteLine("{0} => {1} => {2}", n, r, n2);
        Assert.AreEqual(n, n2);
      }

      var rnd = new Random(DateTime.Now.Millisecond);
      var range = new int[,] { { Int32.MinValue, 0 }, { 0, Int32.MaxValue }, { Int32.MinValue, Int32.MaxValue } };
      for (int i = 0; i <= range.GetLength(0) - 1; i++)
      {

        this.TestContext.WriteLine("");
        this.TestContext.WriteLine("DEFAULT");

        for (int j = 1; j <= 100; j++)
        {
          long n = rnd.Next(range[i, 0], range[i, 1]);
          string r = Convertion.ToBase36(n);
          long n2 = Convertion.FromBase36(r);
          this.TestContext.WriteLine("{0} => {1} => {2}", n, r, n2);
          Assert.AreEqual(n, n2);
        }

        this.TestContext.WriteLine("");
        this.TestContext.WriteLine("CUSTOM");
        string customCharset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*()";

        for (int j = 1; j <= 100; j++)
        {
          long n = rnd.Next(range[i, 0], range[i, 1]);
          string r = Convertion.ToBase36(n, customCharset);
          long n2 = Convertion.FromBase36(r, customCharset);
          this.TestContext.WriteLine("{0} => {1} => {2}", n, r, n2);
          Assert.AreEqual(n, n2);
        }
      }
    }

    [TestMethod]
    public void Base62()
    {
      for (int n = 0; n <= 3844; n++)
      {
        string r = Convertion.ToBase62(n);
        long n2 = Convertion.FromBase62(r);
        this.TestContext.WriteLine("{0} => {1} => {2}", n, r, n2);
        Assert.AreEqual(n, n2);
      }

      var rnd = new Random(DateTime.Now.Millisecond);
      var range = new int[,] { { Int32.MinValue, 0 }, { 0, Int32.MaxValue }, { Int32.MinValue, Int32.MaxValue } };
      for (int i = 0; i <= range.GetLength(0) - 1; i++)
      {

        this.TestContext.WriteLine("");
        this.TestContext.WriteLine("DEFAULT");

        for (int j = 1; j <= 100; j++)
        {
          long n = rnd.Next(range[i, 0], range[i, 1]);
          string r = Convertion.ToBase62(n);
          long n2 = Convertion.FromBase62(r);
          this.TestContext.WriteLine("{0} => {1} => {2}", n, r, n2);
          Assert.AreEqual(n, n2);
        }

        this.TestContext.WriteLine("");
        this.TestContext.WriteLine("CUSTOM");
        string customCharset = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*()";

        for (int j = 1; j <= 100; j++)
        {
          long n = rnd.Next(range[i, 0], range[i, 1]);
          string r = Convertion.ToBase62(n, customCharset);
          long n2 = Convertion.FromBase62(r, customCharset);
          this.TestContext.WriteLine("{0} => {1} => {2}", n, r, n2);
          Assert.AreEqual(n, n2);
        }
      }
    }
    
    [TestMethod]
    public void BaseX()
    {
      string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
      for (int n = 0; n <= 676; n++)
      {
        string r = Convertion.ToBaseX(n, chars);
        long n2 = Convertion.FromBaseX(r, chars);
        this.TestContext.WriteLine("{0} => {1} => {2}", n, r, n2);
        Assert.AreEqual(n, n2);
      }
    }

    [TestMethod]
    public void BaseXString()
    {
      // https://github.com/alekseynemiro/Nemiro.Convertion/issues/1
      string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
      Assert.AreEqual("00028", Convertion.StringFromBaseX("AAABC", chars));
      Assert.AreEqual("0028", Convertion.StringFromBaseX("AABC", chars));
      Assert.AreEqual("028", Convertion.StringFromBaseX("ABC", chars));
      Assert.AreEqual("28", Convertion.StringFromBaseX("BC", chars));
      Assert.AreEqual("457004", Convertion.StringFromBaseX("BAABC", chars));
    }

    [TestMethod]
    public void DateTimeTest()
    {
      this.TestContext.WriteLine("31.12.1980 (format dd.MM.yyyy) => {0}", Convertion.ToDateTime("31.12.1980", "dd.MM.yyyy"));
      this.TestContext.WriteLine("12/31/1980 (format MM/dd/yyyy) => {0}", Convertion.ToDateTime("12/31/1980", "MM/dd/yyyy"));
      this.TestContext.WriteLine("31.12.1980 05:17 (format dd.MM.yyyy HH:mm) => {0}", Convertion.ToDateTime("31.12.1980 05:17", "dd.MM.yyyy HH:mm"));
      this.TestContext.WriteLine("12/31/1980 05:17 (format MM/dd/yyyy HH:mm) => {0}", Convertion.ToDateTime("12/31/1980 05:17", "MM/dd/yyyy HH:mm"));
      this.TestContext.WriteLine("31.12.1980 (format and dateSeparator is dot) => {0}", Convertion.ToDateTime("31.12.1980", "dd.MM.yyyy", "."));
      this.TestContext.WriteLine("31/12/1980 (dateSeparator is /) => {0}", Convertion.ToDateTime("31/12/1980", null, "/"));
      this.TestContext.WriteLine("31/12/1980 (value only) => {0}", Convertion.ToDateTime("31/12/1980"));
      this.TestContext.WriteLine("12/31/1980 (dateSeparator is /) => {0}", Convertion.ToDateTime("12/31/1980", null, "/"));
      this.TestContext.WriteLine("12/31/1980 (value only) => {0}", Convertion.ToDateTime("12/31/1980"));
      this.TestContext.WriteLine("23:59:01 (value only) => {0}", Convertion.ToDateTime("23:59:01"));
      this.TestContext.WriteLine("null (value only) => {0}", Convertion.ToDateTime(null));
      this.TestContext.WriteLine("DBNull (value only) => {0}", Convertion.ToDateTime(DBNull.Value));
    }

    [TestMethod]
    public void TimeSpanTest()
    {
      this.TestContext.WriteLine("12:00:01 => {0}", Convertion.ToTimeSpan("12:00:01"));
      this.TestContext.WriteLine("23.01.03 (timeSeparator is dot) => {0}", Convertion.ToTimeSpan("23.01.03", "."));
      this.TestContext.WriteLine("635456955015215351 => {0}", Convertion.ToTimeSpan(635456955015215351));
      this.TestContext.WriteLine("null (value only) => {0}", Convertion.ToTimeSpan(null));
      this.TestContext.WriteLine("DBNull (value only) => {0}", Convertion.ToTimeSpan(DBNull.Value));
    }

    [TestMethod]
    public void DecimalTest()
    {
      Assert.AreEqual(0.512m, Convertion.ToDecimal("0.512"));
      Assert.AreEqual(0.512m, Convertion.ToDecimal("0,512"));

      Assert.AreEqual(123456.78m, Convertion.ToDecimal("123,456.78"));
      Assert.AreEqual(123456.78m, Convertion.ToDecimal("123 456.78"));
      Assert.AreEqual(123456.78m, Convertion.ToDecimal("123.456,78"));
    }

    [TestMethod]
    public void DoubleTest()
    {
      Assert.AreEqual(0.512, Convertion.ToDouble("0.512"));
      Assert.AreEqual(0.512, Convertion.ToDouble("0,512"));

      Assert.AreEqual(1895, Convertion.ToDouble("1,895.00"));
      Assert.AreEqual(1895, Convertion.ToDouble("1.895,00"));

      Assert.AreEqual(1895, Convertion.ToDouble("1 895.00"));
      Assert.AreEqual(1895, Convertion.ToDouble("1 895,00"));
    }

    [TestMethod]
    public void MoneyTest()
    {
      this.TestContext.WriteLine("1024.512 => {0}", Convertion.ToMoneyString("1024.512"));
      this.TestContext.WriteLine("1024.512 => {0}", Convertion.ToMoneyString("1024,512"));
      this.TestContext.WriteLine("1024.512 => {0}", Convertion.ToMoneyString("1024.512", true));
      this.TestContext.WriteLine("1024.512 => {0}", Convertion.ToMoneyString("1024,512", true));

      this.TestContext.WriteLine("null => {0}", Convertion.ToMoneyString(null));
    }

    [TestMethod]
    public void BooleanTest()
    {
      this.TestContext.WriteLine("true => {0}", Convertion.ToBoolean("true"));
      Assert.AreEqual(true, Convertion.ToBoolean("true"));
      
      this.TestContext.WriteLine("false => {0}", Convertion.ToBoolean("false"));
      Assert.AreEqual(false, Convertion.ToBoolean("false"));

      this.TestContext.WriteLine("false (default: true) => {0}", Convertion.ToBoolean("false", true));
      Assert.AreEqual(false, Convertion.ToBoolean("false", true));

      this.TestContext.WriteLine("test (default: null) => {0}", Convertion.ToBoolean("test", null));
      Assert.AreEqual(null, Convertion.ToBoolean("test", null));

      this.TestContext.WriteLine("test (default: true) => {0}", Convertion.ToBoolean("test", true));
      Assert.AreEqual(true, Convertion.ToBoolean("test", true));

      this.TestContext.WriteLine("0 => {0}", Convertion.ToBoolean(0));
      Assert.AreEqual(false, Convertion.ToBoolean(0));

      this.TestContext.WriteLine("'0' => {0}", Convertion.ToBoolean("0"));
      Assert.AreEqual(false, Convertion.ToBoolean("0"));

      this.TestContext.WriteLine("1 => {0}", Convertion.ToBoolean(1));
      Assert.AreEqual(true, Convertion.ToBoolean(1));

      this.TestContext.WriteLine("'1' => {0}", Convertion.ToBoolean("1"));
      Assert.AreEqual(true, Convertion.ToBoolean("1"));

      this.TestContext.WriteLine("123 => {0}", Convertion.ToBoolean(123));
      Assert.AreEqual(true, Convertion.ToBoolean(123));

      this.TestContext.WriteLine("'123' => {0}", Convertion.ToBoolean("123"));
      Assert.AreEqual(false, Convertion.ToBoolean("123"));

      this.TestContext.WriteLine("null => {0}", Convertion.ToBoolean(null));
      Assert.AreEqual(false, Convertion.ToBoolean(null));

      this.TestContext.WriteLine("DBNull => {0}", Convertion.ToBoolean(DBNull.Value));
      Assert.AreEqual(false, Convertion.ToBoolean(DBNull.Value));

      this.TestContext.WriteLine("null (default: true) => {0}", Convertion.ToBoolean(null, true));
      Assert.AreEqual(true, Convertion.ToBoolean(null, true));

      this.TestContext.WriteLine("DBNull (default: true) => {0}", Convertion.ToBoolean(DBNull.Value, true));
      Assert.AreEqual(true, Convertion.ToBoolean(DBNull.Value, true));

      this.TestContext.WriteLine("(bool?)null => {0}", Convertion.ToBoolean((bool?)null));
      Assert.AreEqual(false, Convertion.ToBoolean((bool?)null));

      this.TestContext.WriteLine("(bool?)null (default: true) => {0}", Convertion.ToBoolean((bool?)null, true));
      Assert.AreEqual(true, Convertion.ToBoolean((bool?)null, true));
    }

    [TestMethod]
    public void IntegerTest()
    {
      this.TestContext.WriteLine("123.456 => {0}", Convertion.ToInt32(123.456));
      Assert.AreEqual(123, Convertion.ToInt32(123.456));

      this.TestContext.WriteLine("'123.456' => {0}", Convertion.ToInt32("123.456"));
      Assert.AreEqual(123, Convertion.ToInt32("123.456"));

      this.TestContext.WriteLine("'123,456' => {0}", Convertion.ToInt32("123,456"));
      Assert.AreEqual(123, Convertion.ToInt32("123,456"));

      this.TestContext.WriteLine("'1 223,456' => {0}", Convertion.ToInt32("1 223,456"));
      Assert.AreEqual(1223, Convertion.ToInt32("1 223,456"));

      this.TestContext.WriteLine("123.789 => {0}", Convertion.ToInt32(123.789));
      Assert.AreEqual(124, Convertion.ToInt32(123.789));

      this.TestContext.WriteLine("'123.789' => {0}", Convertion.ToInt32("123.789"));
      Assert.AreEqual(124, Convertion.ToInt32("123.789"));

      this.TestContext.WriteLine("'123,789' => {0}", Convertion.ToInt32("123,789"));
      Assert.AreEqual(124, Convertion.ToInt32("123,789"));

      this.TestContext.WriteLine("test (default: 123) => {0}", Convertion.ToInt32("test", 123));
      Assert.AreEqual(123, Convertion.ToInt32("test", 123));

      this.TestContext.WriteLine("test (default: null) => {0}", Convertion.ToInt32("test", null));
      Assert.AreEqual(null, Convertion.ToInt32("test", null));

      this.TestContext.WriteLine("test => {0}", Convertion.ToInt32("test"));
      Assert.AreEqual(0, Convertion.ToInt32("test"));

      this.TestContext.WriteLine("null => {0}", Convertion.ToInt32(null));
      Assert.AreEqual(0, Convertion.ToInt32(null));

      this.TestContext.WriteLine("DBNull => {0}", Convertion.ToInt32(DBNull.Value));
      Assert.AreEqual(0, Convertion.ToInt32(DBNull.Value));

      this.TestContext.WriteLine("Decimal.MinValue => {0}", Convertion.ToInt32(Decimal.MinValue));
      Assert.AreEqual(0, Convertion.ToInt32(Decimal.MinValue));

      this.TestContext.WriteLine("Decimal.MaxValue => {0}", Convertion.ToInt32(Decimal.MaxValue));
      Assert.AreEqual(0, Convertion.ToInt32(Decimal.MaxValue));

      this.TestContext.WriteLine("UInt64.MinValue => {0}", Convertion.ToInt32(UInt64.MinValue));
      Assert.AreEqual(0, Convertion.ToInt32(UInt64.MinValue));

      this.TestContext.WriteLine("UInt64.MaxValue => {0}", Convertion.ToInt32(UInt64.MaxValue));
      Assert.AreEqual(0, Convertion.ToInt32(UInt64.MaxValue));

      this.TestContext.WriteLine("Int32.MinValue => {0}", Convertion.ToInt32(Int32.MinValue));
      Assert.AreEqual(Int32.MinValue, Convertion.ToInt32(Int32.MinValue));

      this.TestContext.WriteLine("Int32.MaxValue => {0}", Convertion.ToInt32(Int32.MaxValue));
      Assert.AreEqual(Int32.MaxValue, Convertion.ToInt32(Int32.MaxValue));
    }

    [TestMethod]
    public void LongTest()
    {
      this.TestContext.WriteLine("123.456 => {0}", Convertion.ToInt64(123.456));
      Assert.AreEqual(123, Convertion.ToInt64(123.456));

      this.TestContext.WriteLine("'123.456' => {0}", Convertion.ToInt64("123.456"));
      Assert.AreEqual(123, Convertion.ToInt64("123.456"));

      this.TestContext.WriteLine("'123,456' => {0}", Convertion.ToInt64("123,456"));
      Assert.AreEqual(123, Convertion.ToInt64("123,456"));

      this.TestContext.WriteLine("'1 223,456' => {0}", Convertion.ToInt64("1 223,456"));
      Assert.AreEqual(1223, Convertion.ToInt64("1 223,456"));

      this.TestContext.WriteLine("123.789 => {0}", Convertion.ToInt64(123.789));
      Assert.AreEqual(124, Convertion.ToInt64(123.789));

      this.TestContext.WriteLine("'123.789' => {0}", Convertion.ToInt64("123.789"));
      Assert.AreEqual(124, Convertion.ToInt64("123.789"));

      this.TestContext.WriteLine("'123,789' => {0}", Convertion.ToInt64("123,789"));
      Assert.AreEqual(124, Convertion.ToInt64("123,789"));

      this.TestContext.WriteLine("test (default: 123) => {0}", Convertion.ToInt64("test", 123));
      Assert.AreEqual(123, Convertion.ToInt64("test", 123));

      this.TestContext.WriteLine("test (default: null) => {0}", Convertion.ToInt64("test", null));
      Assert.AreEqual(null, Convertion.ToInt64("test", null));

      this.TestContext.WriteLine("test => {0}", Convertion.ToInt64("test"));
      Assert.AreEqual(0, Convertion.ToInt64("test"));

      this.TestContext.WriteLine("null => {0}", Convertion.ToInt64(null));
      Assert.AreEqual(0, Convertion.ToInt64(null));

      this.TestContext.WriteLine("DBNull => {0}", Convertion.ToInt64(DBNull.Value));
      Assert.AreEqual(0, Convertion.ToInt64(DBNull.Value));

      this.TestContext.WriteLine("Decimal.MinValue => {0}", Convertion.ToInt64(Decimal.MinValue));
      Assert.AreEqual(0, Convertion.ToInt64(Decimal.MinValue));

      this.TestContext.WriteLine("Decimal.MaxValue => {0}", Convertion.ToInt64(Decimal.MaxValue));
      Assert.AreEqual(0, Convertion.ToInt64(Decimal.MaxValue));

      this.TestContext.WriteLine("UInt64.MinValue => {0}", Convertion.ToInt64(UInt64.MinValue));
      Assert.AreEqual(0, Convertion.ToInt64(UInt64.MinValue));

      this.TestContext.WriteLine("UInt64.MaxValue => {0}", Convertion.ToInt64(UInt64.MaxValue));
      Assert.AreEqual(0, Convertion.ToInt64(UInt64.MaxValue));

      this.TestContext.WriteLine("Int64.MinValue => {0}", Convertion.ToInt64(Int64.MinValue));
      Assert.AreEqual(-9223372036854775808, Convertion.ToInt64(Int64.MinValue));

      this.TestContext.WriteLine("Int64.MaxValue => {0}", Convertion.ToInt64(Int64.MaxValue));
      Assert.AreEqual(9223372036854775807, Convertion.ToInt64(Int64.MaxValue));
    }

    [TestMethod]
    public void LongUInt64()
    {
      this.TestContext.WriteLine("123.456 => {0}", Convertion.ToUInt64(123.456));
      Assert.AreEqual(123U, Convertion.ToUInt64(123.456));

      this.TestContext.WriteLine("'123.456' => {0}", Convertion.ToUInt64("123.456"));
      Assert.AreEqual(123U, Convertion.ToUInt64("123.456"));

      this.TestContext.WriteLine("'  123,456  ' => {0}", Convertion.ToUInt64("  123,456  "));
      Assert.AreEqual(123U, Convertion.ToUInt64("  123,456  "));

      this.TestContext.WriteLine("123.789 => {0}", Convertion.ToUInt64(123.789));
      Assert.AreEqual(124U, Convertion.ToUInt64(123.789));

      this.TestContext.WriteLine("'123.789' => {0}", Convertion.ToUInt64("123.789"));
      Assert.AreEqual(124U, Convertion.ToUInt64("123.789"));

      this.TestContext.WriteLine("'123,789' => {0}", Convertion.ToUInt64("123,789"));
      Assert.AreEqual(124U, Convertion.ToUInt64("123,789"));

      this.TestContext.WriteLine("'1,123.789' => {0}", Convertion.ToUInt64("1,123.789"));
      Assert.AreEqual(1124U, Convertion.ToUInt64("1,123.789"));

      this.TestContext.WriteLine("test (default: 123) => {0}", Convertion.ToUInt64("test", 123));
      Assert.AreEqual(123U, Convertion.ToUInt64("test", 123));

      this.TestContext.WriteLine("test (default: null) => {0}", Convertion.ToUInt64("test", null));
      Assert.AreEqual(null, Convertion.ToUInt64("test", null));

      this.TestContext.WriteLine("test => {0}", Convertion.ToUInt64("test"));
      Assert.AreEqual(0U, Convertion.ToUInt64("test"));

      this.TestContext.WriteLine("null => {0}", Convertion.ToUInt64(null));
      Assert.AreEqual(0U, Convertion.ToUInt64(null));

      this.TestContext.WriteLine("DBNull => {0}", Convertion.ToUInt64(DBNull.Value));
      Assert.AreEqual(0U, Convertion.ToUInt64(DBNull.Value));

      this.TestContext.WriteLine("Decimal.MinValue => {0}", Convertion.ToUInt64(Decimal.MinValue));
      Assert.AreEqual(0U, Convertion.ToUInt64(Decimal.MinValue));

      this.TestContext.WriteLine("Decimal.MaxValue => {0}", Convertion.ToUInt64(Decimal.MaxValue));
      Assert.AreEqual(0U, Convertion.ToUInt64(Decimal.MaxValue));

      this.TestContext.WriteLine("UInt64.MinValue => {0}", Convertion.ToUInt64(UInt64.MinValue));
      Assert.AreEqual(UInt64.MinValue, Convertion.ToUInt64(UInt64.MinValue));

      this.TestContext.WriteLine("UInt64.MaxValue => {0}", Convertion.ToUInt64(UInt64.MaxValue));
      Assert.AreEqual(UInt64.MaxValue, Convertion.ToUInt64(UInt64.MaxValue));

      this.TestContext.WriteLine("Int64.MinValue => {0}", Convertion.ToUInt64(Int64.MinValue));
      Assert.AreEqual(0U, Convertion.ToUInt64(Int64.MinValue));

      this.TestContext.WriteLine("Int64.MaxValue => {0}", Convertion.ToUInt64(Int64.MaxValue));
      Assert.AreEqual(Convert.ToUInt64(Int64.MaxValue), Convertion.ToUInt64(Int64.MaxValue));
    }

    [TestMethod]
    public void ByteTest()
    {
      this.TestContext.WriteLine("123.456 => {0}", Convertion.ToByte(123.456));
      Assert.AreEqual(123, Convertion.ToByte(123.456));

      this.TestContext.WriteLine("'123.456' => {0}", Convertion.ToByte("123.456"));
      Assert.AreEqual(123, Convertion.ToByte("123.456"));

      this.TestContext.WriteLine("'123,456' => {0}", Convertion.ToByte("123,456"));
      Assert.AreEqual(123, Convertion.ToByte("123,456"));

      this.TestContext.WriteLine("123.789 => {0}", Convertion.ToByte(123.789));
      Assert.AreEqual(124, Convertion.ToByte(123.789));

      this.TestContext.WriteLine("'123.789' => {0}", Convertion.ToByte("123.789"));
      Assert.AreEqual(124, Convertion.ToByte("123.789"));
      
      this.TestContext.WriteLine("'123,789' => {0}", Convertion.ToByte("123,789"));
      Assert.AreEqual(124, Convertion.ToByte("123,789"));

      this.TestContext.WriteLine("'255' => {0}", Convertion.ToByte("255"));
      Assert.AreEqual(255, Convertion.ToByte("255"));

      this.TestContext.WriteLine("'256' => {0}", Convertion.ToByte("256"));
      Assert.AreEqual(0, Convertion.ToByte("256"));

      this.TestContext.WriteLine("-123 => {0}", Convertion.ToByte(-123));
      Assert.AreEqual(0, Convertion.ToByte(-123));

      this.TestContext.WriteLine("test (default: 123) => {0}", Convertion.ToByte("test", 123));
      Assert.AreEqual(123, Convertion.ToByte("test", 123));

      this.TestContext.WriteLine("test (default: null) => {0}", Convertion.ToByte("test", null));
      Assert.AreEqual(null, Convertion.ToByte("test", null));

      this.TestContext.WriteLine("test => {0}", Convertion.ToByte("test"));
      Assert.AreEqual(0, Convertion.ToByte("test"));

      this.TestContext.WriteLine("null => {0}", Convertion.ToByte(null));
      Assert.AreEqual(0, Convertion.ToByte(null));

      this.TestContext.WriteLine("DBNull => {0}", Convertion.ToByte(DBNull.Value));
      Assert.AreEqual(0, Convertion.ToByte(DBNull.Value));

      this.TestContext.WriteLine("Decimal.MinValue => {0}", Convertion.ToByte(Decimal.MinValue));
      Assert.AreEqual(0, Convertion.ToByte(Decimal.MinValue));

      this.TestContext.WriteLine("Decimal.MaxValue => {0}", Convertion.ToByte(Decimal.MaxValue));
      Assert.AreEqual(0, Convertion.ToByte(Decimal.MaxValue));

      this.TestContext.WriteLine("UInt64.MinValue => {0}", Convertion.ToByte(UInt64.MinValue));
      Assert.AreEqual(0, Convertion.ToByte(UInt64.MinValue));

      this.TestContext.WriteLine("UInt64.MaxValue => {0}", Convertion.ToByte(UInt64.MaxValue));
      Assert.AreEqual(0, Convertion.ToByte(UInt64.MaxValue));

      this.TestContext.WriteLine("byte.MinValue => {0}", Convertion.ToByte(byte.MinValue.ToString()));
      Assert.AreEqual(0, Convertion.ToByte(byte.MinValue.ToString()));

      this.TestContext.WriteLine("byte.MaxValue => {0}", Convertion.ToByte(byte.MaxValue.ToString()));
      Assert.AreEqual(255, Convertion.ToByte(byte.MaxValue.ToString()));
    }

    [TestMethod]
    public void Example()
    {
      Console.WriteLine("1.  {0}", Convertion.ToInt32("  123,456  "));
      Console.WriteLine("2.  {0}", Convertion.ToInt32("28.01"));
      Console.WriteLine("3.  {0}", Convertion.ToInt32(DBNull.Value));
      Console.WriteLine("4.  {0}", Convertion.ToInt32(DBNull.Value, 555));
      Console.WriteLine("5.  {0}", Convertion.ToDouble("  123,456  "));
      Console.WriteLine("6.  {0}", Convertion.ToDouble("28.01"));
      Console.WriteLine("7.  {0}", Convertion.ToBoolean("true"));
      Console.WriteLine("8.  {0}", Convertion.ToBoolean("false"));
      Console.WriteLine("9.  {0}", Convertion.ToBoolean("1"));
      Console.WriteLine("10. {0}", Convertion.ToBoolean("0"));
      Console.WriteLine("11. {0}", Convertion.ToBoolean("   123      "));
      Console.WriteLine("12. {0}", Convertion.ToDateTime("31.12.1980", "dd.MM.yyyy"));
      Console.WriteLine("13. {0}", Convertion.ToDateTime("12/31/1980", "MM/dd/yyyy"));
      Console.WriteLine("14. {0}", Convertion.ToDateTime("23:59:01"));
      Console.WriteLine("15. {0}", Convertion.ToDateTime(DBNull.Value));
      Console.WriteLine("16. {0}", Convertion.ToDateTime(DBNull.Value, DateTime.Now));
      Console.WriteLine("17. {0}", Convertion.ToBase16(16));
      Console.WriteLine("18. {0}", Convertion.FromBase16("10"));
      Console.WriteLine("19. {0}", Convertion.ToBase16(123123));
      Console.WriteLine("20. {0}", Convertion.FromBase16("AF01"));
      Console.WriteLine("21. {0}", Convertion.ToBase36(36));
      Console.WriteLine("22. {0}", Convertion.FromBase36("10"));
      Console.WriteLine("23. {0}", Convertion.ToBase36(123123));
      Console.WriteLine("24. {0}", Convertion.FromBase36("ZYR1"));
      Console.WriteLine("25. {0}", Convertion.ToBase62(62));
      Console.WriteLine("26. {0}", Convertion.FromBase62("10"));
      Console.WriteLine("27. {0}", Convertion.ToBase62(123123));
      Console.WriteLine("28. {0}", Convertion.FromBase62("Nemiro"));
      Console.WriteLine("29. {0}", Convertion.ToBase62(45102691578));
      Console.WriteLine("30. {0}", Convertion.ToTimeSpan("12:10:59"));
      Console.WriteLine("31. {0}", Convertion.ToTimeSpan(635456955015215351));
    }

  }

}
