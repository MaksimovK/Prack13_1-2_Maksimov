using System.Collections;

ArrayList firstList = new ArrayList() { "Екатерина", "27", "Сергей", "38", "Илья", "21" };
ArrayList secondList = new ArrayList() { "Кирилл", "17", "Иван", "18", "Маша", "36" };
foreach (var el in firstList)
{
    Console.WriteLine(el);
}

Console.WriteLine();
Console.WriteLine("Число должно быть больше 0 и меньше 7");
Console.Write("Введите значение n: ");
int n1 = 0;
try
{
    do
    {
        n1 = Convert.ToUInt16(Console.ReadLine());
    } while (n1 >= secondList.Count);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine("Ошибка");
    Environment.Exit(0);
}


secondList.InsertRange(n1, secondList);
Console.WriteLine("Результат вставки: ");
foreach (var el in firstList)
    Console.Write($"{el} ");

int n = n1 / 2;
Console.Write("\nВведите количество элементов для удаления: ");
int k = 0;
try
{
    do
    {
        k = Convert.ToUInt16(Console.ReadLine());
    } while (k > firstList.Count);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine("Ошибка");
    Environment.Exit(0);
}
firstList.RemoveRange(n, k);
Console.WriteLine("Результат удаления: ");
foreach (var item in firstList)
    Console.Write($"{item} ");
