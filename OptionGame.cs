using System;
using System.Threading;

namespace OptionsGame
{
   public static class Options
    {
        public static void SetGame(ref int range, ref int quantity)
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
                            range = int.Parse(Console.ReadLine());
                        while (range < 50 || range > 10000);
                        break;
                    case "D2":
                        Console.WriteLine("\nPodaj nową ilość działań do wykonania - max. 20 (domyślnie: 10): \n");
                        do
                            quantity = int.Parse(Console.ReadLine());
                        while (quantity > 20 || quantity < 1);
                        break;
                    case "D3":
                        Console.WriteLine("USTAWIENIA ZOSTAŁY PRZYWRÓCONE!");
                        range = 100;
                        quantity = 10;
                        break;
                    case "D4":
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