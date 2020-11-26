using System;
using System.Threading;
using OptionsGame;
using Game;

namespace MainProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            SettingsGameJSON SF = new SettingsGameJSON();     
            ConsoleKeyInfo choose;
            for (;;)
            {
                Console.Clear();
                Console.WriteLine("---GRA W LICZENIE---\n\n" +
                    "MENU GŁÓWNE:\n" +
                    "---------------------\n" +
                    "1. Dodawanie\n" +
                    "2. Odejmowanie\n" +
                    "3. Mnożenie\n" +
                    "4. Dzielenie\n" +
                    "---------------------\n" +
                    "5. Opcje\n" +
                    "---------------------\n" +
                    "9. Wyjście\n");
         
                    choose = Console.ReadKey();
                    switch (choose.Key.ToString())
                    {
                        case "D1":
                        case "D2":
                        case "D3":
                        case "D4":
                        MathGame.Play(SF.Range, SF.Quantity, choose);
                            break;
                        case "D5":
                        OptionsMenu.SetGame(SF);
                            break;
                        case "D9":
                            Environment.Exit(0);
                            break;
                    }
            }
        }
    }
}
//208
//291