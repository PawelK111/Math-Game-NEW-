using System;
using System.Collections.Generic;
using System.Threading;

namespace Game
{
    enum ScoreElements
    {
        Correct,
        Missed,
        Percent
    }
    public static class MathGame
    {
        private static int operation(int [] values, char sign)
        {
                switch (sign)
                {
                    case '+':
                        return values[0] + values[1];
                    case '-':
                        return values[0] - values[1];
                    case '*':
                        return values[0] * values[1];
                    case '/':
                        return values[0] / values[1];
                }
            return 0;
        }

        private static void endGame(Dictionary<ScoreElements, int> score)
        {
            Console.Clear();
            Console.WriteLine($"Koniec gry! Twoje wyniki: \n" +
                $"Prawidłowych: {score[ScoreElements.Correct]} \n" +
                $"Błędynch: {score[ScoreElements.Missed]}\n" +
                $"Procent poprawnych: {score[ScoreElements.Percent]}\n\n\n" +
                $"Naciśnij dowolny klawisz, aby kontynuować...");
            Console.ReadKey();
        }
        public static void Play(int range, int quantity, ConsoleKeyInfo op)
        {
            char sign = ' ';
            int result;
            int answer;
            int[] values = new int[2];
            Random rnd = new Random();
            Dictionary<ScoreElements, int> Score = new Dictionary<ScoreElements, int>()
            {
                [ScoreElements.Correct] = 0,
                [ScoreElements.Missed] = 0,
                [ScoreElements.Percent] = 0,
            };
            switch (op.Key.ToString())
            {
                case "D1":
                    sign = '+';
                    break;
                case "D2":
                    sign = '-';
                    break;
                case "D3":
                    sign = '*';
                    break;
                case "D4":
                    sign = '/';
                    break;
            }
            for (int total = 1; total <= quantity; total++)
            {
                Console.Clear();
                values[0] = rnd.Next(1, range + 1);
                values[1] = rnd.Next(1, range + 1);

                if (sign == '-' || sign == '/')
                    if (values[0] < values[1])
                    {
                        var bufor = values[0];
                        values[0] = values[1];
                        values[1] = bufor;
                    }
                Console.WriteLine($"Prawidłowych: {Score[ScoreElements.Correct]} | Błędnych: {Score[ScoreElements.Missed]} | Procent poprawnych: {Score[ScoreElements.Percent]} | Działanie: {total}\n\n" +
                    $"{values[0]} {sign} {values[1]}\n\n" +
                    $"Wpisz liczbę i naciśnij ENTER...");

                answer = int.Parse(Console.ReadLine());

                result = operation(values, sign);
                if (answer == result)
                {
                    Console.WriteLine("\n\nBRAWO! ZDOBYWASZ PUNKT!");
                    Score[ScoreElements.Correct]++;
                }
                else
                {
                    Console.WriteLine($"\n\nŹLE! POPRAWNA ODPOWIEDŹ TO: {result}");
                    Score[ScoreElements.Missed]++;
                }
                Thread.Sleep(1500);
                Score[ScoreElements.Percent] = 100 * Score[ScoreElements.Correct] / total;
            }
            endGame(Score);
        }
    }
}