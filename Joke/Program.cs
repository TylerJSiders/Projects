using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Joke
{
    class Program
    {
        static async Task Main(string[] args)
        {

            bool run = true;
            Console.WriteLine("Would you like to hear a joke? Enter Y for yes and N for no.");
            string answer = Console.ReadLine();
            answer.ToLower();
            Console.Clear();
            do
            {
                if (VerifyInput(answer))
                {
                    if (answer == "y")
                    {
                        await PlayJoke();
                        Console.WriteLine("Would you Like to hear another joke? Enter Y for yes and N for no.");
                        answer = Console.ReadLine();
                        Console.Clear();
                        while (!VerifyInput(answer))
                        {
                            Console.WriteLine("Please enter Y or N");
                            answer = Console.ReadLine();
                            Console.Clear();

                        }
                        if (answer == "n")
                        {
                            Console.Clear();
                            break;
                        }
                           

                    }
                    else
                        break;
                }
                else
                {
                    while(!VerifyInput(answer))
                    {
                        Console.WriteLine("Please enter Y or N");
                        answer = Console.ReadLine();
                        
                    }
                    
                }
            } while (run);
            Console.WriteLine("Thank you!");
            
        }

        public static bool VerifyInput(string input)
        {
            if (input == "n" || input == "y")
            {
                return true;
            }
            return false;
        }

        public static async Task PlayJoke()
        {
            JokeWeb jokeWeb = new JokeWeb();
            Joke joke = await jokeWeb.GetRandomJoke();
            Console.WriteLine(joke.setup);
            Console.WriteLine("Press any key for punchline.");
            Console.ReadLine();
            Console.WriteLine(joke.punchLine);
        }

    }
}
