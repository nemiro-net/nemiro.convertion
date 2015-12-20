### Nemiro.Convertion

**Nemiro.Convertion** is small helper class for converting a data types to another data types in **.NET Framework**.

**Nemiro.Convertion** is licensed under the **Apache License Version 2.0**.

To install **Nemiro.Convertion**, run the following command in the **Package Manager Console**:

`PM> Install-Package Nemiro.Convertion`

### Features

* Safe conversion the DBNull, NULL and empty values; 
* Processing floating-point numbers, regardless of the type of decimal separator (dot or comma); 
* Number system conversion: hexadecimal, hexatrigesimal, duosexagesimal, etc.; 
* Easy to specify the date format for converting; 
* Using the default values for zero incoming values. 

### System Requirements

* Microsoft Windows XP, 7 or later with .NET Framework 3.5, 4.0 or 4.5;
* Microsoft Visual Studio 2010 (recommended Professional Edition with Service Pack 1) or later;
* Sandcastle Help File Builder (for documentation project).

### Examples
**C#**
```C#
object value = "123.456"; // dot
double num = Convertion.ToDouble(value);
Console.WriteLine("Number: {0}", num);

value = "123,456"; // comma
num = Convertion.ToDouble(value);
Console.WriteLine("Number: {0}", num);

DateTime date = Convertion.ToDateTime("31.12.2012", "dd.MM.yyyy");
Console.WriteLine("Date: {0}", date);

string duosexagesimal = Convertion.ToBase62(45102691578);
Console.WriteLine("45102691578 is {0}", duosexagesimal);

string customHex = Convertion.ToBase16(123, "ABCDEFGHIJKLMNOP");
Console.WriteLine("123 is {0}", customHex);
Console.WriteLine
(
  "{0} is {1}", 
  customHex, 
  Convertion.FromBase16(customHex, "ABCDEFGHIJKLMNOP")
);
```
**Visual Basic .NET**
```VB
Dim value As Object = "123.456" ' dot
Dim num As Double = Convertion.ToDouble(value)
Console.WriteLine("Number: {0}", num)

value = "123,456" ' comma
num = Convertion.ToDouble(value)
Console.WriteLine("Number: {0}", num)

Dim date As Date = Convertion.ToDateTime("31.12.2012", "dd.MM.yyyy")
Console.WriteLine("Date: {0}", date)

Dim duosexagesimal As String = Convertion.ToBase62(45102691578)
Console.WriteLine("45102691578 is {0}", duosexagesimal)

Dim customHex As String = Convertion.ToBase16(123, "ABCDEFGHIJKLMNOP")
Console.WriteLine("123 is {0}", customHex)
Console.WriteLine _
(
  "{0} is {1}", 
  customHex, 
  Convertion.FromBase16(customHex, "ABCDEFGHIJKLMNOP")
)
```

### See Also

* http://convertion.nemiro.net
* http://nemiro.net 
