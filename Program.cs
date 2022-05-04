namespace Consordle
{
    public class DatabaseEN
    {
        public string[] words5 = {
            "brain",
            "farts",
            "damns",
            "doggo",
            "train",
            "trams",
            "tooth",
            "heart",
            "paper",
            "bread",
            "music",
            "virus",
            "steak",
            "youth",
            "honey",
            "union",
            "apple",
            "month",
            "scene",
            "uncle",
            "shirt",
            "cheek",
            "truth",
            "piano",
            "actor",
            "topic",
            "video",
            "queen",
            "phone",
            "child",
            "buyer",
            "death",
            "owner",
            "story",
            "error",
            "media",
            "ratio",
            "salad",
            "bonus",
            "drama",
            "woman",
            "depth",
            "skill",
            "guest",
            "world",
            "photo",
            "night",
            "chest",
            "thing",
            "power",
            "blood",
            "movie",
            "entry",
            "hotel",
            "basis",
            "pizza",
            "frame",
            "drain",
            "drone",
            "darks",
            "judge",
            "human",
            "robes",
            "budge",
            "pushy",
            "lushy",
            "freak",
            "frick",
            "frogs",
            "month",
            "march",
            "april",
            "three",
            "seven",
            "eight",
            "teens",
            "minis",
            "teeny"
        };
    }
    public class DatabaseCZ
    {
        public string[] words5 = {
            "dobře",
            "jedna",
            "třeba",
            "kokos",
            "špína",
            "kryty",
            "jeden",
            "jádro",
            "křeče",
            "jedli",
            "kůrka",
            "křupe",
            "úterý",
            "pátek",
            "párek",
            "dieta",
            "dírou",
            "ručně",
            "různě",
            "mějte",
            "máslo",
            "salám",
            "halal",
            "bacha",
            "chyba",
            "hreji",
            "hraju",
            "dřevo",
            "dříví",
            "druhá",
            "druhý",
            "kurňa",
            "frňák",
            "vodka",
            "kolmý",
            "šunka",
            "válka",
            "rusko",
            "tečka",
            "čárka",
            "mohou",
            "prdka",
            "kapsa",
            "nosní",
            "sprej",
            "kříže",
            "mříže",
            "vězeň",
            "mrtev",
            "mrtvý",
            "papír",
            "malíř",
            "kočka",
            "písty",
            "pytel",
            "pokec",
            "hráti",
            "hráči",
            "zámek",
            "láska",
            "nárok",
            "rákos",
            "číslo",
            "deset",
            "slovo",
            "lůžko",
            "myška",
            "drama",
            "pokus",
            "kopec",
            "druhy",
            "humor",
            "kolmo",
            "pokoj",
            "místo",
            "kruhy",
            "padák",
            "drtič",
            "krtek",
            "krtka",
            "zničí",
            "šupin",
            "rybíz",
            "rokle",
            "pixel",
            "kříže",
            "elekt",
            "grafy",
            "buben",
            "duben",
            "kolem",
            "dráha",
            "práhy",
            "kukla",
            "hůlka",
            "včela",
            "včely",
            "hadry",
            "chábr",
            "jistá",
            "poupě",
            "popel",
            "prach",
            "tlama",
            "lampa",
            "kroup"
        };
    }
    public class Game
    {
        static void Main(string[] args)
        {
            Game g = new Game();
            if (args.Length >= 1) {
                if (args[0] == "-en") g.en();
                else if (args[0] == "-cz") g.cz();
            } else g.en();
        }
        public void cz()
        {
            DatabaseCZ d = new DatabaseCZ();
            Random r = new Random();

            Console.Title = "Consordle";
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Vítejte v Consordle! Je zde " + d.words5.Length + " slov na uhádnutí.");
            Console.WriteLine("Určitě víte jak se hraje Wordle. Pokud ano, stiskněte jakoukoli klávesu. Pokud ne, vyhledejte si to.");
            Console.ReadKey();
            Console.Clear();

            string[] w = d.words5;
            string[] guesses = { "", "", "", "", "", "" };
            string word = w[r.Next(w.Length)];
            char[] wordarray = word.ToUpper().ToCharArray();
            Console.ForegroundColor = ConsoleColor.White;
//          Console.WriteLine(word);

            for (int i = 0; i < 6; i += 1)
            {
                string guess = Console.ReadLine();
                char[] guessarray = guess.ToUpper().ToCharArray();
                int[] guessstate = { 0, 0, 0, 0, 0 };
                if (guessarray.Length != 5)
                {
                    Console.WriteLine("Neplatná délka");
                    i -= 1;
                }
                else
                {
                    guesses[i] = guess;
                    for (int j = 0; j < guess.Length; j += 1)
                    {
                        if (guessarray[j] == wordarray[j])
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            guessstate[j] = 2;
                            Console.Write(guessarray[j]);

                        }
                        else if (guessarray[j] != wordarray[j] && wordarray.Contains(guessarray[j]))
                        {
                            // when two identical letters are yellow in a word (for example 
                            // loops), it makes the DOUBLE o yellow even though the word
                            // might be hello, a word with a SINGLE o
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            guessstate[j] = 1;
                            Console.Write(guessarray[j]);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            guessstate[j] = 0;
                            Console.Write(guessarray[j]);
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    int g = 0;
                    for (int l = 0; l < 5; l += 1) if (guessstate[l] == 2) g += 1;
                    if (g == 5)
                    {
                        int guessesAmount = 0;
                        string guessFall = " pokusů!";
                        for (int l = 0; l < 6; l += 1) if (guesses[l] != "") guessesAmount += 1;
                        if (guessesAmount == 1) guessFall = " pokus!";
                        else if (guessesAmount >= 2 && guessesAmount <= 4) guessFall = " pokusy!";
                        Console.Write("\nGratuluji, uhádli jste to za " + guessesAmount + guessFall + "\n");
                        Console.WriteLine("Sdílejte váš postup na Twitteru:\n\n#Consordle " + guessesAmount + "/6");
                        for (int m = 0; m < guessesAmount; m += 1) Console.WriteLine(guesses[m].ToUpper());
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                    else if (g != 5 && guesses[5] != "")
                    {
                        Console.Write("\nSmůla, slovo bylo " + word);
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
                Console.WriteLine();
            } 
        }
        public void en() {
            DatabaseEN d = new DatabaseEN();
            Random r = new Random(); 

            Console.Title = "Consordle";
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Welcome to Consordle! There are " + d.words5.Length + " words to guess.");
            Console.WriteLine("Assuming you know how to play Wordle, press any key to continue.");
            Console.ReadKey();
            Console.Clear();

            string[] w = d.words5;
            string[] guesses = {"", "", "", "", "", ""};
            string word = w[r.Next(w.Length)];
            char[] wordarray = word.ToUpper().ToCharArray();
            Console.ForegroundColor = ConsoleColor.White;
//          Console.WriteLine(word);

            for (int i = 0; i < 6; i += 1)
            {
                string guess = Console.ReadLine();
                char[] guessarray = guess.ToUpper().ToCharArray();
                int[] guessstate = { 0, 0, 0, 0, 0 };
                if (guessarray.Length != 5)
                {
                    Console.WriteLine("Invalid length");
                    i -= 1;
                }
                else
                {
                    guesses[i] = guess;
                    for (int j = 0; j < guess.Length; j += 1)
                    {
                        if (guessarray[j] == wordarray[j])
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            guessstate[j] = 2;
                            Console.Write(guessarray[j]);
                            
                        }
                        else if (guessarray[j] != wordarray[j] && wordarray.Contains(guessarray[j]))
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            guessstate[j] = 1;
                            Console.Write(guessarray[j]);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            guessstate[j] = 0;
                            Console.Write(guessarray[j]);
                        }
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                    int g = 0;
                    for (int k = 0; k < 5; k += 1) if (guessstate[k] == 2) g += 1;
                    if (g == 5)
                    {
                        string guessFall = " guesses!";
                        int guessesAmount = 0;
                        for (int l = 0; l < 6; l += 1) if (guesses[l] != "") guessesAmount += 1;
                        if (guessesAmount == 1) guessFall = " guess!";
                        Console.Write("\nCongratulations! You guessed it in " + guessesAmount + guessFall + " ");
                        Console.WriteLine("Share your result on Twitter:\n\n#Consordle " + guessesAmount + "/6");
                        for (int m = 0; m < guessesAmount; m += 1) Console.WriteLine(guesses[m].ToUpper());
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                    else if (g != 5 && guesses[5] != "")
                    {
                        Console.Write("\nYou lose! The word was: " + word);
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
                Console.WriteLine();
            }
        }
    } 
}