using System.Text;

Console.OutputEncoding = Encoding.UTF8;

// 1. Что находится внутри int
Console.WriteLine("=== 1. int в байтах ===");
foreach (int n in new[] { 1, 256, 65536 })
{
    Console.WriteLine($"{n}: {BitConverter.ToString(BitConverter.GetBytes(n))}");
}

// 2. Порядок байтов
Console.WriteLine();
Console.WriteLine("=== 2. Порядок байтов ===");
int number = 305419896;
Console.WriteLine($"Число: {number}");
Console.WriteLine($"В hex: 0x{number:X8}");
Console.WriteLine($"Little-endian: {BitConverter.IsLittleEndian}");
byte[] numberBytes = BitConverter.GetBytes(number);
Console.WriteLine("Байты числа:");
Console.WriteLine(BitConverter.ToString(numberBytes));

// 3. Число и текст
Console.WriteLine();
Console.WriteLine("=== 3. Текст и UTF-8 ===");
string text = "Hello";
byte[] textBytes = Encoding.UTF8.GetBytes(text);
Console.WriteLine($"Текст: {text}");
Console.WriteLine("Байты текста UTF-8:");
Console.WriteLine(BitConverter.ToString(textBytes));

string text2 = "ABC";
byte[] textBytes2 = Encoding.UTF8.GetBytes(text2);
Console.WriteLine();
Console.WriteLine($"Текст: {text2}");
Console.WriteLine($"Количество символов: {text2.Length}");
Console.WriteLine($"Количество байтов UTF-8: {textBytes2.Length}");
Console.WriteLine($"Байты: {BitConverter.ToString(textBytes2)}");

string text4 = "Привет";
byte[] textBytes4 = Encoding.UTF8.GetBytes(text4);
Console.WriteLine();
Console.WriteLine($"Текст: {text4}");
Console.WriteLine($"Количество символов: {text4.Length}");
Console.WriteLine($"Количество байтов UTF-8: {textBytes4.Length}");
Console.WriteLine($"Байты: {BitConverter.ToString(textBytes4)}");

// 4. Английская и русская буква
Console.WriteLine();
Console.WriteLine("=== 4. Английская и русская буква ===");
string english = "A"; // латинская A
string russian = "А"; // кириллическая А
byte[] englishBytes = Encoding.UTF8.GetBytes(english);
byte[] russianBytes = Encoding.UTF8.GetBytes(russian);
Console.WriteLine($"A (латиница): {BitConverter.ToString(englishBytes)}");
Console.WriteLine($"А (кириллица): {BitConverter.ToString(russianBytes)}");

// 5. Обратное преобразование текста
Console.WriteLine();
Console.WriteLine("=== 5. Обратное преобразование ===");
string text3 = "Привет";
byte[] bytes = Encoding.UTF8.GetBytes(text3);
string restored = Encoding.UTF8.GetString(bytes);
Console.WriteLine($"Исходная строка: {text3}");
Console.WriteLine($"Восстановленная: {restored}");

// 6. Обратное преобразование числа
Console.WriteLine();
int number2 = 123456789;
byte[] bytes2 = BitConverter.GetBytes(number2);
int restored2 = BitConverter.ToInt32(bytes2, 0);
Console.WriteLine($"Исходное число: {number2}");
Console.WriteLine($"Восстановленное: {restored2}");
Console.WriteLine($"Байты: {BitConverter.ToString(bytes2)}");

// Одни байты - разные смыслы
Console.WriteLine();
Console.WriteLine("=== Одни байты - разные смыслы ===");
byte[] data = { 0x41, 0x42, 0x43 };
Console.WriteLine($"Байты: {BitConverter.ToString(data)}");
Console.WriteLine($"Как текст UTF-8: {Encoding.UTF8.GetString(data)}");
