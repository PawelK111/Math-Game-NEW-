using System;
using System.Threading;

namespace OptionsGame
{
   public static class OptionsMenu
    {
        public static void SetGame(SettingsGameJSON SetGame)
        {
            ConsoleKeyInfo choose;
            for(;;)
            {
                Console.Clear();
                Console.WriteLine("---GRA W LICZENIE---\n\n" 
                    + "OPCJE: \n" +
                    "----------------------\n" +
                    "1. Zmień zakres liczb\n" +
                    "2. Zmień ilość wykonywanych działań\n" +
                    "3. Przywróć ustawienia domyślne\n" +
                    "4. Powrót do menu głównego\n");
                choose = Console.ReadKey();
                switch (choose.Key.ToString())
                {
                    case "D1":
                        Console.WriteLine("\nPodaj nowy zakres liczb od 50 do 10000 (domyślnie: 100): \n");
                        do
                            SetGame.Range = int.Parse(Console.ReadLine());
                        while (SetGame.Range < 50 || SetGame.Range > 10000);
                        break;
                    case "D2":
                        Console.WriteLine("\nPodaj nową ilość działań do wykonania - max. 20 (domyślnie: 10): \n");
                        do
                            SetGame.Quantity = int.Parse(Console.ReadLine());
                        while (SetGame.Quantity > 20 || SetGame.Quantity < 1);
                        break;
                    case "D3":
                        Console.WriteLine("USTAWIENIA ZOSTAŁY PRZYWRÓCONE!");
                        SetGame.Range = 100;
                        SetGame.Quantity = 10;
                        break;
                    case "D4":
                        SetGame.SaveSettings(SetGame);
                        return;
                    default:
                        Console.WriteLine("NIE MA TAKIEJ OPCJI!");
                        break;
                }
                Console.WriteLine("\n\n\nZMIANY ZOSTAŁY WPROWADZONE!");
                Thread.Sleep(2000);
            }
        }
    }
}