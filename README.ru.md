### Nemiro.Convertion

**Nemiro.Convertion** это небольшая библиотека классов для проектов **.NET Framework**, которая позволяет конвертировать один тип данных в другой без выбрасывания исключений.

Исходный код библиотеки **Nemiro.Convertion** предоставляется на условиях лицензии **Apache 2.0**.

Для установки **Nemiro.Convertion**, выполните следующую команду в консоли диспетчера пакетов (**Package Manager Console**):

`PM> Install-Package Nemiro.Convertion`

[Подробнее об установке](https://www.nuget.org/packages/Nemiro.OAuth.LoginForms/)

[Использование диспетчера пакетов NuGet](http://docs.nuget.org/consume/package-manager-console)

### Особенности

* Безопасная обработка пустых значений, в том числе значений DBNull и NULL; 
* Обработка любых типов десятичных разделителей (точка/запятая);
* Преобразование чисел между различными системами счисления: шестнадцатеричные, 36-ричные, 62-ричные, с возможность использовать собственные системы счисления;
* Корректное преобразование дат в любом формате;
* Использование значений по умолчанию, если преобразование невозможно.

### Системные требования

* Microsoft Windows XP/7/10 с .NET Framework 3.5, 4.0, 4.5 или новее;
* Microsoft Visual Studio 2010 (рекомендуется не ниже Professional Edition с Service Pack 1) или новее;
* Sandcastle Help File Builder (для проекта документации, если потребуется работа с исходным кодом решения).

### Примеры использования
**C#**
```C#
// разделитель - точка
object value = "123.456";
double num = Convertion.ToDouble(value);
Console.WriteLine("Число: {0}", num);

// разделитель - запятая
value = "123,456";
num = Convertion.ToDouble(value);
Console.WriteLine("Число: {0}", num);

// получение даты из строки в формате ДД.ММ.ГГГГ
DateTime date = Convertion.ToDateTime("31.12.2012", "dd.MM.yyyy");
Console.WriteLine("Дата: {0}", date);

// преобразование десятичного числа в 62-ричное
string duosexagesimal = Convertion.ToBase62(45102691578);
Console.WriteLine("45102691578 = {0}", duosexagesimal);

// преобразование десятичного числа в число собственной системы счисления
string customHex = Convertion.ToBase16(123, "ABCDEFGHIJKLMNOP");
Console.WriteLine("123 = {0}", customHex);
// и обратно
Console.WriteLine
(
  "{0} = {1}", 
  customHex, 
  Convertion.FromBase16(customHex, "ABCDEFGHIJKLMNOP")
);
```
**Visual Basic .NET**
```VB
' разделитель - точка
Dim value As Object = "123.456"
Dim num As Double = Convertion.ToDouble(value)
Console.WriteLine("Число: {0}", num)

' разделитель - запятая
value = "123,456"
num = Convertion.ToDouble(value)
Console.WriteLine("Число: {0}", num)

' получение даты из строки в формате ДД.ММ.ГГГГ
Dim date As Date = Convertion.ToDateTime("31.12.2012", "dd.MM.yyyy")
Console.WriteLine("Дата: {0}", date)

' преобразование десятичного числа в 62-ричное
Dim duosexagesimal As String = Convertion.ToBase62(45102691578)
Console.WriteLine("45102691578 = {0}", duosexagesimal)

' преобразование десятичного числа в число собственной системы счисления
Dim customHex As String = Convertion.ToBase16(123, "ABCDEFGHIJKLMNOP")
Console.WriteLine("123 = {0}", customHex)
' и обратно
Console.WriteLine _
(
  "{0} = {1}", 
  customHex, 
  Convertion.FromBase16(customHex, "ABCDEFGHIJKLMNOP")
)
```

### См. также

* http://convertion.nemiro.net
* http://nemiro.net 
