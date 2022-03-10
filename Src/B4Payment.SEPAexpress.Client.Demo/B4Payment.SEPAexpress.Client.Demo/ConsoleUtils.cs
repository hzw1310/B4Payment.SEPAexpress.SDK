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

        public static void ReadAuthenticationData()
        {
            Console.WriteLine("Authentication:");
            Console.Write("Tenant: ");
            var tenant = Console.ReadLine();
            Console.Write("User name: ");
            var userName = Console.ReadLine();
            Console.Write("Password: ");
            var password = ReadPassword();
        }

        private static string ReadPassword()
        {
            var pass = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    Console.Write("\b \b");
                    pass = pass[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);

            return pass;
        }
    }
}
