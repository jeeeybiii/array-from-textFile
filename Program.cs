namespace ArrayFromTextFile
{
    internal class Program
    {

        struct IceCream
        {
            public string name;
            public string manufacturer;
            public int decade;
        }

        static StreamReader sr;
        static StreamWriter sw;
        static void Main(string[] args)
        {
            IceCream[] iceCream = new IceCream[2];
            int index = 0;
            string filePath = @"../../../iceCream.txt";
            sr = new StreamReader(filePath);
            while (!sr.EndOfStream && index < iceCream.Length)
            {
                iceCream[index].name = sr.ReadLine();
                iceCream[index].manufacturer = sr.ReadLine();
                iceCream[index].decade = int.Parse(sr.ReadLine());
                index++;
            }
            sr.Close();

            for (int i = 0; i < iceCream.Length; i++)
            {
                Console.Write(iceCream[i].name.PadRight(20));
                Console.Write(iceCream[i].manufacturer.PadRight(20));
                Console.WriteLine($"{iceCream[i].decade}".PadRight(20));
            }

            Console.Write("Which ice cream would you like to edit: ");
            string iceCreamSearch = Console.ReadLine();
            for(int i = 0; i < iceCream.Length; i++)
            {
                if(iceCreamSearch.ToLower() == iceCream[i].name.ToLower())
                {
                    Console.WriteLine($"Ice cream found: {iceCream[i].name}");
                    Console.Write("Enter new name for the ice cream: ");
                    iceCream[i].name = Console.ReadLine();
                    Console.WriteLine("Change accepted!");
                    
                }
            }
            Console.WriteLine("\n\n");
            LoadIceCream(iceCream, filePath);
            Console.ReadLine();
            
        }

        static void LoadIceCream(IceCream[] iceCream, string filePath)
        {
            sw = new StreamWriter(filePath);
            for(int i = 0; i < iceCream.Length; i++)
            {
                Console.Write(iceCream[i].name.PadRight(20));
                Console.Write(iceCream[i].manufacturer.PadRight(20));
                Console.WriteLine($"{iceCream[i].decade}".PadRight(20));
                sw.WriteLine(iceCream[i].name);
                sw.WriteLine(iceCream[i].manufacturer);
                sw.WriteLine(iceCream[i].decade);
            }
            sw.Close();
        }

    }
}
