using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;

namespace LibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LibraryService libraryService = new LibraryService();

            Helper.WriteConsole(ConsoleColor.Blue, "Select one option : ");
            Helper.WriteConsole(ConsoleColor.Yellow, "1 - Create library, 2 - Get library by id, 3 - Update library, 4 - Delete library");

            while (true)
            {
                SelectOption: string selectOption = Console.ReadLine();

                int selectTrueOption;

                bool isSelectOption = int.TryParse(selectOption, out selectTrueOption);

                if (isSelectOption)
                {
                    switch (selectTrueOption)
                    {
                        case 1:

                            Helper.WriteConsole(ConsoleColor.Blue, "Add library name : ");
                            
                            string libraryname = Console.ReadLine();

                            Helper.WriteConsole(ConsoleColor.Blue, "Add library seat count : ");
                            
                            SeatCount: string librarySeatCount = Console.ReadLine();
                            int seatCount;
                            bool isSeatCount = int.TryParse(librarySeatCount, out seatCount);
                            
                            if (isSeatCount)
                            {
                                Library library = new Library
                                {
                                    Name = libraryname,
                                    SeatCount = seatCount
                                };

                                var result = libraryService.Create(library);
                                Helper.WriteConsole(ConsoleColor.Green, $"Library Id : {result.Id}, Name : {result.Name}, Seat count : {result.SeatCount}");
                            }
                            else
                            {
                                Helper.WriteConsole(ConsoleColor.Red, "Add coreect seat count : ");
                                goto SeatCount;
                            }

                            break;
                        case 2:
                            Console.WriteLine(selectTrueOption);
                            break;
                        case 3:
                            Console.WriteLine(selectTrueOption);
                            break;
                        case 4:
                            Console.WriteLine(selectTrueOption);
                            break;
                        default:
                            Helper.WriteConsole(ConsoleColor.Red, "Select correct option number");
                            break;
                    }
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Select correct option");
                    goto SelectOption;
                }
            }
        }
    }
}
