namespace BrowserSimulator
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Type 'exit' and press Enter to exit the browser.");

            Console.WriteLine("Use '<=' to go backward, '=>' to go forward.");

            BrowserSimulator browser = new();

            string? userInput;

            do
            {
                Console.Write("Enter URL or command: ");

                userInput = Console.ReadLine()?.Trim();

                if (!string.IsNullOrEmpty(userInput) && !userInput.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (userInput == "<=") browser.GoBack();

                    else if (userInput == "=>") browser.GoForward();

                    else browser.Navigate(userInput);

                    Console.WriteLine($"Current Page: {browser.CurrentPage}");
                }

            } while (userInput?.ToLower() != "exit");

            Console.WriteLine("Exiting the browser...");
        }
    }

    class BrowserSimulator
    {
        private readonly Stack<string> historyPrimary = new();

        private readonly Stack<string> historyForward = new();

        public string CurrentPage { get; private set; } = "Browser Home";

        public void Navigate(string url)
        {
            historyPrimary.Push(url);

            historyForward.Clear();

            CurrentPage = url;
        }

        public void GoBack()
        {
            if (historyPrimary.Count > 0)
            {

                historyForward.Push(historyPrimary.Pop());

                CurrentPage = historyPrimary.Count > 0 ? historyPrimary.Peek() : "Browser Home";
            }
        }

        public void GoForward()
        {
            if (historyForward.Count > 0)
            {
                historyPrimary.Push(historyForward.Pop());

                CurrentPage = historyPrimary.Peek();
            }
        }
    }
}
