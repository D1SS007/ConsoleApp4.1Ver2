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

                        Console.WriteLine("Имя и должность успешно добавлены");

                        break;

                    case 2:

                        ShowAllFiles(ref arrayNames, ref arrayPositions);

                        break;

                    case 3:

                        ShowAllFiles(ref arrayNames, ref arrayPositions);

                        Console.WriteLine("Какое досье удалить?");

                        DeleteFile(ref arrayNames, ref arrayPositions);

                        break;

                    case 4:

                        SearchByLastName(ref arrayNames, ref arrayPositions);

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
            string [] tempName =new string [arrayName.Length+1];

            for (int i = 0; i < arrayName.Length; i++)
            {
                tempName [i] = arrayName [i];
            }
            Console.WriteLine("Введите новое имя в досье");

            tempName[tempName.Length - 1] = Convert.ToString(Console.ReadLine());

            arrayName = tempName;

            string[] tempPosition = new string[arrayPosition.Length + 1];

            for(int i = 0; i < arrayPosition.Length; i++)
            {
                tempPosition [i] = arrayPosition [i];
            }
            Console.WriteLine("Введите новую должность в досье");

            tempPosition[tempPosition.Length - 1] = Convert.ToString(Console.ReadLine());

            arrayPosition = tempPosition;
        }

        static void ShowAllFiles(ref string[] arrayNames, ref string[] arrayPositions)
        {
            for (int i = 0; i < arrayNames.Length; i++)
            {
                Console.WriteLine($"\n{(i + 1)} - {arrayNames[i]} - {arrayPositions[i]}\n");
            }
        }

        static void DeleteFile(ref string[] arrayName, ref string[] arrayPosition)
        {
            Console.WriteLine("Ведите номер досье которое хотите удалить");

            int fileToDelete = Convert.ToInt32(Console.ReadLine());            

            string[] tempName = new string[arrayName.Length - 1];

            for (int i = 0; i < fileToDelete; i++)
            {
                tempName[i] = arrayName[i];
            }

            for (int i = fileToDelete + 1; i < arrayName.Length; i++)
            {
                tempName [i - 1] = arrayName [i];
            }
            arrayName = tempName;

            string[] tempPosition = new string[arrayPosition.Length - 1];

            for (int i = 0; i < fileToDelete; i++)
            {
                tempPosition[i] = arrayPosition[i];
            }

            for(int i = fileToDelete + 1; i < arrayPosition.Length; i++)
            {
                tempPosition[i - 1] = arrayPosition[i];
            }
            arrayPosition = tempPosition;
        }

        static void SearchByLastName(ref string[] arrayName, ref string[] arrayPosition)
        {
            bool fileIsFound = false;

            Console.WriteLine("Введите фамилию");

            string searchName = Convert.ToString(Console.ReadLine());            

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
