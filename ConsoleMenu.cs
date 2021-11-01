using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratory2
{
    static class ConsoleMenu
    {
        // 5 книг, с которыми мы будем работать и структуры данных
        static Book book1 = new Book()
        {
            SerialNumber = "ISBN 978-5-93673-265-2",
            Title = "Время жить и время умирать",
            YearOfPub = new DateTime(year: 2005, 1, 1),
            Price = 200,
            Quantity = 5000
        };
        static Book book2 = new Book("ISBN 978-5-93673-266-2", "Собачье сердце", new DateTime(year: 2020, 1, 1), 75, 1000);
        static Book book3 = new Book("ISBN 978-5-93673-267-2", Title: "Шагреневая кожа", new DateTime(year: 2018, 1, 1), 175, 150);
        static Book book4 = new Book(SerialNumber: "ISBN 978-5-93673-268-2", Title: "50 оттенков серого", YearOfPub: new DateTime(year: 2015, 1, 1), Price: 400, Quantity: 5);
        static Book book5 = new Book();
        static Book[] booksArray = new Book[] { book1, book2, book3, book4, book5 };
        static ArrayList booksArrayList = new ArrayList() { book1, book2, book3, book4, book5 };
        static List<Book> booksList = new List<Book>() { book1, book2, book3, book4, book5 };
        static BinaryTree<Book> booksTree = new BinaryTree<Book>(book1, book2, book3, book4, book5);



        static public void Main_Menu()
        {
            Console.WriteLine("НАЖМИТЕ клавишу для выбора. Работа с: ");
            Console.WriteLine("num1 - массив книг;");
            Console.WriteLine("num2 - non-generic коллекция книг;");
            Console.WriteLine("num3 - generic-коллекция книг;");
            Console.WriteLine("num4 - бинарное дерево поиска книг.");
            MainSwitch_Menu(Console.ReadKey().Key);
        }
        static void MainSwitch_Menu(ConsoleKey k)
        {
            switch (k)
            {
                case ConsoleKey.NumPad1: // Array
                    Console.WriteLine("\nВВЕДИТЕ число для выбора. Что нужно?");
                    Console.WriteLine("1 - добавить в массив пустую книгу;");
                    Console.WriteLine("2 - вывести информацию о всех книгах;");
                    Console.WriteLine("3 - удалить книжку по индексу;");
                    Console.WriteLine("4 - изменить (на %) цену книжки по индексу;");
                    Console.WriteLine("5 - удалить первую попавшуюся книгу с количеством 0;");
                    Console.WriteLine("Любое другое значение - в главное меню.");
                    var choice = Console.ReadLine();
                    if (choice == "1" || choice == "2" || choice == "3" || choice == "4" || choice == "5")
                    {
                        Array_Menu(int.Parse(choice));
                    }
                    Console.WriteLine("ОК. Обратно в главное меню.");
                    Main_Menu();
                    break;
                case ConsoleKey.NumPad2: // ArrayList
                    Console.WriteLine("\nВВЕДИТЕ число для выбора. Что нужно?");
                    Console.WriteLine("1 - добавить в non-generic коллекцию пустую книгу;");
                    Console.WriteLine("2 - вывести информацию о всех книжках;");
                    Console.WriteLine("3 - удалить книжку по индексу;");
                    Console.WriteLine("4 - изменить (на %) цену книжки по индексу;");
                    Console.WriteLine("5 - очистить список;");
                    Console.WriteLine("Любое другое значение - в главное меню.");
                    choice = Console.ReadLine();
                    if (choice == "1" || choice == "2" || choice == "3" || choice == "4" || choice == "5")
                    {
                        ArrayList_Menu(int.Parse(choice));
                    }
                    Console.WriteLine("ОК. Обратно в главное меню.");
                    Main_Menu();
                    break;
                case ConsoleKey.NumPad3: // List
                    Console.WriteLine("\nВВЕДИТЕ число для выбора. Что нужно?");
                    Console.WriteLine("1 - добавить в generic-коллекцию пустую книгу;");
                    Console.WriteLine("2 - вывести информацию о всех книжках;");
                    Console.WriteLine("3 - удалить книжку по индексу;");
                    Console.WriteLine("4 - изменить (на %) цену книжки по индексу;");
                    Console.WriteLine("5 - вывод информации всех книг из коллекции, кроме повторяющихся;");
                    Console.WriteLine("6 - сортировка List по цене книжек;");
                    Console.WriteLine("Любое другое значение - в главное меню.");
                    choice = Console.ReadLine();
                    if (choice == "1" || choice == "2" || choice == "3" || choice == "4" || choice == "5" || choice == "6")
                    {
                        List_Menu(int.Parse(choice));
                    }
                    Console.WriteLine("ОК. Обратно в главное меню.");
                    Main_Menu();
                    break;
                case ConsoleKey.NumPad4: // BinaryTree
                    Console.WriteLine("\nВВЕДИТЕ число для выбора. Что нужно?");
                    Console.WriteLine("1 - добавить в бинарное дерево пустую книгу;");
                    Console.WriteLine("2 - вывести информацию о всех книжках (обход дерева - Postorder);");
                    Console.WriteLine("3 - вывести информацию о книжке по индексу коллекции обхода дерева - Postorder;");
                    Console.WriteLine("4 - добавить в бинарное дерево новую книгу с указанной ценой;");
                    Console.WriteLine("Любое другое значение - в главное меню.");
                    choice = Console.ReadLine();
                    if (choice == "1" || choice == "2" || choice == "3" || choice == "4")
                    {
                        Tree_Menu(int.Parse(choice));
                    }
                    Console.WriteLine("ОК. Обратно в главное меню.");
                    Main_Menu();
                    break;
                default:
                    Console.WriteLine("\nНажмите клавишу на нам-паде!");
                    Main_Menu();
                    break;
            }
        }

        static void Array_Menu(int choice)
        {

            if (choice == 1) // Добавить в массив пустую книгу
            {
                Array.Resize(ref booksArray, booksArray.Length + 1);
                booksArray[booksArray.Length - 1] = new Book();
                Console.WriteLine("Успешно добавлена пустая книга в массив");
            }
            if (choice == 2) // вывести информацию о всех книжках
                for (int i = 0; i < booksArray.Length; i++)
                    Console.WriteLine(booksArray[i].GetInformation()+"\n");
            if (choice == 3) // удалить книжку по индексу
            {
                Console.WriteLine("Введите индекс");
                try
                {
                    booksArray[int.Parse(Console.ReadLine())] = null;
                    booksArray = booksArray.Where(x => x != null).ToArray();
                    Console.WriteLine("Успешно удалена книга по индексу");
                }
                catch
                {
                    Console.WriteLine("Вы что-то не то нажали, ошибка");
                }
            }
            if (choice == 4) // изменить (на %) цену книжки по индексу
            {
                Console.WriteLine("Сначала введите индекс, а потом процент на который хотите изменить цену.");
                Console.WriteLine("Процент может быть отрицательным, при этом помните, что цена не может быть меньше 0");
                try
                {
                    booksArray[int.Parse(Console.ReadLine())].PriceChangePercent(int.Parse(Console.ReadLine()));
                    Console.WriteLine("Успешно изменена цена книги по индексу");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            if (choice == 5) // удалить первую попавшуюся книгу с количеством 0
            {
                Predicate<Book> predicate = delegate (Book obj)
                {
                    return obj.Quantity == 0;
                };
                booksArray[Array.FindIndex(booksArray, predicate)] = null;
                booksArray = booksArray.Where(x => x != null).ToArray();
                Console.WriteLine("Успешна удалена книга с количеством 0");
            }
            MainSwitch_Menu(ConsoleKey.NumPad1);
        }
        static void ArrayList_Menu(int choice)
        {

            if (choice ==1) // добавить в non-generic коллекцию пустую книгу
            {
                booksArrayList.Add(new Book());
                Console.WriteLine("Успешно добавлена пустая книга!");
            }
            if (choice == 2) // вывести информацию о всех книжках
            {
                foreach (var item in booksArrayList)
                {
                    Book book = (Book)item;
                    Console.WriteLine(book.GetInformation() + "\n");
                }
            }
            if (choice == 3) // удалить книжку по индексу
            {
                Console.WriteLine("Введите индекс для удаления");
                try
                {
                    booksArrayList.RemoveAt(int.Parse(Console.ReadLine()));
                    Console.WriteLine("Успешно удалена книга по индексу");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            if (choice ==4) // изменить (на %) цену книжки по индексу
            {
                Console.WriteLine("Сначал введите индекс, а потом процент на который хотите изменить цену.");
                Console.WriteLine("Процент может быть отрицательным, при этом помните, что цена не может быть меньше 0");
                try
                {
                    int index = int.Parse(Console.ReadLine());
                    Book book = (Book)booksArrayList[index];
                    book.PriceChangePercent(int.Parse(Console.ReadLine()));
                    booksArrayList[index] = book;

                    Console.WriteLine("Успешно изменена цена книги по индексу");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            if (choice== 5) // очистить список
            {
                booksArrayList.Clear();
                Console.WriteLine("\tКоллекция очищена (удалены все элементы)");
            }
            MainSwitch_Menu(ConsoleKey.NumPad2);
            
        }
        static void List_Menu(int choice)
        {
            if (choice == 1) // добавить в generic-коллекцию пустую книгу
            {
                booksList.Add(new Book());
                Console.WriteLine("Успешно добавлена пустая книга в List.");
            }
            if (choice == 2) // вывести информацию о всех книжках
            {
                foreach (var item in booksList)
                {
                    Console.WriteLine(item.GetInformation()+"\n");
                }
            }
            if (choice == 3) // удалить книжку по индексу
            {
                Console.WriteLine("Введите индекс книги, которую хотите удалить");
                try
                {
                    booksList.RemoveAt(int.Parse(Console.ReadLine()));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка!");
                    Console.WriteLine(e.Message);
                }
            }
            if (choice == 4) // изменить (на %) цену книжки по индексу
            {
                try
                {
                    Console.WriteLine("Сначал введите индекс, а потом процент на который хотите изменить цену.");
                    Console.WriteLine("Процент может быть отрицательным, при этом помните, что цена не может быть меньше 0");
                    booksList[int.Parse(Console.ReadLine())].PriceChangePercent(int.Parse(Console.ReadLine()));

                    Console.WriteLine("Успешно изменена цена");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            if (choice == 5) // вывод информации всех книг из коллекции, кроме повторяющихся
            {
                foreach (var item in booksList.Distinct())
                {
                    Console.WriteLine(item.GetInformation());
                }
            }
            if (choice == 6) // сортировка List по цене книжек
            {
                booksList.Sort();
                Console.WriteLine("Успешно отсортировано!");
            }
            MainSwitch_Menu(ConsoleKey.NumPad3);
        }
        static void Tree_Menu(int choice)
        {
            if (choice == 1) // добавить в бинарное дерево пустую книгу
            {
                booksTree.Add(new Book());
            }
            if (choice == 2) // вывести информацию о всех книжках
            {
                Console.WriteLine("Сортировка по цене. Цена корня: "+ booksTree.Root.Data.Price);
                foreach (Book item in booksTree) // реализация IEnumerable и IEnumerator
                {
                    Console.WriteLine(item.GetInformation()+"\n");
                }
            }
            if (choice == 3) // вывести информацию о книге по индексу
            {
                try
                {
                    Console.WriteLine("Введите индекс");
                    Console.WriteLine("\n"+booksTree[int.Parse(Console.ReadLine())].GetInformation());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            if (choice == 4) // Добавление к бинарное дерево книги с ценой
            {
                Console.WriteLine("Введите цену новой книги");
                try
                {
                    booksTree.Add(new Book(int.Parse(Console.ReadLine())));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            MainSwitch_Menu(ConsoleKey.NumPad4);
        }
    }
}
