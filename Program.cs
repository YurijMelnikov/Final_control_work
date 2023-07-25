/*Задача: Написать программу, которая из имеющегося массива строк формирует новый массив из строк, длина которых меньше, либо равна 3 символам. 
Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения алгоритма. 
При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.*/

int VariableCreationInt(string text)
{
    PrintColor(text, ConsoleColor.Green);
    return Convert.ToInt32(Console.ReadLine());
}

//метод создания и заполнения массива строк случайными строчными буквами кириллицы, с заданным количеством элементов и максимальной длиной строки
string[] FillingArray(int arrayLength, int stringLength) //
{
    string[] stringArray = new string[arrayLength];
    Random rnd = new Random();
    for (int i = 0; i < stringArray.Length; i++)
    {
        string randomString = string.Empty;
        for (int j = 1; j <= rnd.Next(1, stringLength + 1); j++) //цикл формирования строки массива, длина рассчитывается случайно от 1 до заданной максимальной длины
        {
            randomString += Convert.ToChar(rnd.Next(1072, 1104)); //создание случайного десятичного кода из таблицы Unicode в диапазоне [1072; 1103] - строчные буквы кириллицы
        }
        stringArray[i] = randomString;
    }
    return stringArray;
}

//метод формирования массива из строк из входящего строкового массива, где строки меньше или равны трём символам
string[] ArrayStringSort(string[] arrayString)
{
    int sortArrayLength = 0; //Переменная для подсчёта длины массива
    for (int i = 0; i < arrayString.Length; i++)
    {
        if (arrayString[i].Length <= 3) sortArrayLength++;
    }
    string[] arrayStringSort = new string[sortArrayLength]; //создаём массив с вычисленной выше длиной
    int counter = 0; //индексатор массива
    for (int i = 0; i < arrayString.Length; i++)
    {
        if (arrayString[i].Length <= 3)
        {
            arrayStringSort[counter] = arrayString[i];
            counter++;
        }
    }
    return arrayStringSort;
}

void PrintArray(string[] array, string information)
{
    PrintColor(information + "\n", ConsoleColor.Green);
    for (int i = 0; i < array.Length; i++)
    {
        System.Console.WriteLine(array[i]);
    }
}

void PrintColor(string information, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.Write(information);
    Console.ResetColor();
}

int arrayLength = VariableCreationInt("Введите количество элементов в заполненном случайными строками массиве: ");
int stringLength = VariableCreationInt("Введите максимальную длину строки в массиве строк: ");
string[] randomStringArray = FillingArray(arrayLength, stringLength);
PrintArray(randomStringArray, "Вывод сгенерированного массива строк");
string[] arrayStringSort = ArrayStringSort(randomStringArray);
if (arrayStringSort.Length != 0)
{
    PrintArray(arrayStringSort, "Вывод отсортированного массива с длиной строк равной или меньше трёх");
}
else
{
    PrintColor("Сгенерированный массив случайных строк не содержит элементов меньше или равной трём символам\n", ConsoleColor.Red);
}