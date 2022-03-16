using System.Text.Json;

namespace B4Payment.SEPAexpress.Client.Demo.Utils
{
    internal static class ConsoleUtils
    {
        public static void ShowTitle()
        {
            var previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"                                                            ");
            Console.WriteLine(@"                       ______                               ");
            Console.WriteLine(@"                      |  ____|                              ");
            Console.WriteLine(@"  ___  ___ _ __   __ _| |__  __  ___ __  _ __ ___  ___ ___  ");
            Console.WriteLine(@" / __|/ _ \ '_ \ / _` |  __| \ \/ / '_ \| '__/ _ \/ __/ __| ");
            Console.WriteLine(@" \__ \  __/ |_) | (_| | |____ >  <| |_) | | |  __/\__ \__ \ ");
            Console.WriteLine(@" |___/\___| .__/ \__,_|______/_/\_\ .__/|_|  \___||___/___/");
            Console.WriteLine(@"          | |                     | |                       ");
            Console.WriteLine(@"          |_|                     |_|                       ");
            Console.WriteLine(@"                                                            ");
            Console.ForegroundColor=previousColor;
        }

        internal static string GetPaymentId() => GetString("Please enter payment id and press Enter:");

        internal static string GetReferenceId() => GetString("Please enter reference id and press Enter:");

        internal static char ReadCharFromUser()
        {
            var consoleKeyInfo = Console.ReadKey(true);
            return consoleKeyInfo.KeyChar;
        }

        internal static void ShowScenarios()
        {
            Console.WriteLine("Select scenario:");
            Console.WriteLine("1. Create payment in step by step");
            Console.WriteLine("2. Create payment in one step");
            Console.WriteLine("3. Get payment data");
            Console.WriteLine("4. Create recurring payment");
            Console.WriteLine("5. Get reconciliations");
            Console.WriteLine("");
            Console.WriteLine("X. Exit");
        }

        internal static void ShowQuestion(string question)
        {
            Console.WriteLine();
            Console.WriteLine(question);
            Console.WriteLine();
        }

        internal static void DisplayException(Exception apiex)
        {
            Console.WriteLine(apiex.Message);
        }

        internal static void DisplayActionStart(string action)
        {
            var previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine($"--- {action} ---");
            Console.WriteLine();
            Console.ForegroundColor = previousColor;
        }

        internal static void DisplayRequestObject(string uri, object requestObject)
        {
            var json = JsonSerializer.Serialize(requestObject, new JsonSerializerOptions
            {
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = true
            });
            Console.WriteLine($"Request to: {uri}");
            Console.WriteLine(json);
            Console.WriteLine("");
        }

        internal static void DisplayResponseObject(string uri, object responseObject)
        {
            var json = JsonSerializer.Serialize(responseObject, new JsonSerializerOptions
            {
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = true
            });
            Console.WriteLine($"Response from: {uri}");
            Console.WriteLine(json);
            Console.WriteLine("");
        }

        internal static void StartStopScenario(string text)
        {
            var previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("");
            Console.WriteLine($"== {text} ==");
            Console.WriteLine("");
            Console.ForegroundColor = previousColor;
        }

        private static string GetString(string prompt)
        {
            string? userGivenString;
            do
            {
                Console.WriteLine(prompt);
                userGivenString = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(userGivenString));

            return userGivenString;
        }
    }
}