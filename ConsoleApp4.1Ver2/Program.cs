using System;

namespace ConsoleApp4._1Ver2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWorking = true;

            string[] arrayNames = { "Иванов", "Петров", "Сидоров", "Михайлов", "Алексеев", "Васильев" };
            string[] arrayPositions = { "Врач", "Инжинер", "Слесарь", "Плотник", "Учитель", "Юрист" };            

            while (isWorking == true)
            {
                Console.WriteLine("Досье\n1 - добавить досье\n2 - вывести все досье\n3 - удалить досье\n4 - поиск по фамилии\n5 - выход");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        AddFile(ref arrayNames, ref arrayPositions);
                        break;

                    case 2:
                        ShowAllFiles(arrayNames, arrayPositions);
                        break;

                    case 3:
                        DeleteFile(ref arrayNames, ref arrayPositions);
                        break;

                    case 4:
                        SearchByLastName(arrayNames, arrayPositions);
                        break;

                    case 5:
                        isWorking = false;
                        break;

                    default:
                        Console.WriteLine("Такой функции нет");
                        isWorking = false;
                        break;
                }
            }
        }

        static void AddFile(ref string[] arrayName, ref string[] arrayPosition)
        {
            LogicOfAddingFile(ref arrayName , "новое имя");

            LogicOfAddingFile (ref arrayPosition, "новую должность"); 

            Console.WriteLine("Имя и должность успешно добавлены");
        }

        static void LogicOfAddingFile(ref string [] array, string str )
        {
            string[] tempArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }
            Console.WriteLine($"Введите {str} в досье");

            tempArray[tempArray.Length - 1] = Convert.ToString(Console.ReadLine());

            array = tempArray;
        }

        static void ShowAllFiles( string[] arrayNames,  string[] arrayPositions)
        {
            for (int i = 0; i < arrayNames.Length; i++)
            {
                Console.WriteLine($"\n{(i + 1)} - {arrayNames[i]} - {arrayPositions[i]}");
            }
            Console.WriteLine();
        }

        static void DeleteFile(ref string[] arrayName, ref string[] arrayPosition)
        {
            ShowAllFiles(arrayName, arrayPosition);            

            Console.WriteLine("Ведите номер досье которое хотите удалить");

            int fileToDelete = Convert.ToInt32(Console.ReadLine());  
            
            LogicOfDeletingFile(ref arrayName, fileToDelete - 1);           

            LogicOfDeletingFile(ref arrayPosition, fileToDelete - 1);            
        }

        static void LogicOfDeletingFile(ref string[] array, int fileToDelete)
        {
            string[] tempArray = new string[array.Length - 1];

            for (int i = 0; i < fileToDelete; i++)
            {
                tempArray[i] = array[i];
            }

            for (int i = fileToDelete + 1; i < array.Length; i++)
            {
                tempArray[i - 1] = array[i];
            }
            array = tempArray;
        }

        static void SearchByLastName(string[] arrayName, string[] arrayPosition)
        {
            bool fileIsFound = false;

            Console.WriteLine("Введите фамилию");

            string searchName = Console.ReadLine();            

            for (int i = 0; i < arrayName.GetLength(0); i++)
            {
                if (searchName.ToLower() == arrayName[i].ToLower())
                {
                    Console.WriteLine($"\n{(i + 1)} - {arrayName[i]} - {arrayPosition[i]}\n"); 

                    fileIsFound = true;
                }
            }
            if (fileIsFound == false)
            {
                Console.WriteLine("Такого нет");
            }
        }
    }
}
