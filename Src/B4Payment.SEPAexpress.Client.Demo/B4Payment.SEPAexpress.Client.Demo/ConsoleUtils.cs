namespace B4Payment.SEPAexpress.Client.Demo
{
    internal static class ConsoleUtils
    {
        public static void ShowTitle()
        {
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
        }

        internal static char ReadScenarioFromUser()
        {
            var consoleKeyInfo = Console.ReadKey();
            return consoleKeyInfo.KeyChar;
        }

        internal static void ShowScenarios()
        {
            Console.WriteLine("Select scenario:");
            Console.WriteLine("1. Create payment in step by step");
            Console.WriteLine("2. Create payment in one step");
            Console.WriteLine("");
            Console.WriteLine("X. Exit");
        }
    }
}