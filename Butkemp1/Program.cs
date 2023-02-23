// Дано число N. Нужно показать числа от -N  до N.

int GetValueByUser(string text)
{
    int value = 0;
    bool flag = false; // проверка на дурака
    do
    {
    Console.Write(text);
    string s = Console.ReadLine()!;
    flag = int.TryParse(s, out value) && value > 0; // не вводить буквы, цифры д.б. больше 0
    } while (!flag);
    return value;
}

string PrintNumbers1(int n)
{
    string output = "0";
    for (int i = 1; i <= n; i++) //делает в два раза меньше операций, только от 1 до n
    {
        //output = output + i + " ";
        output = $"{-i} " + output + $" {i}"; // так string работает? Получатеся заполняет в обе стороны от нуля!!!
    }
    return output;
}

int n = GetValueByUser("Введите N ");
string res = PrintNumbers1(n);
Console.WriteLine(res);
File.WriteAllText("data.txt", res); // создает файл data.txt и записывает в него результат


//Есть массив чисел. Хотим в нем считать сумму каждой последовательной тройки или четверки и т.д.