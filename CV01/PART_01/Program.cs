using System;

namespace PDACv1_1
{
    class Program
    {
        static void Main()
        {
            Colorhex();
            NumberToBinary();
            NameSurname();
            ReadFloat();
            ReadChar();
            ReadString();
            ReadLong();
            ReadShort();
            ReadDouble();
            ReadInt();
            ReadByte();
            static void ReadInt()
            {
                Console.WriteLine("Enter a int");
                int num = int.Parse(Console.ReadLine());
                Console.WriteLine("You entered {0}", num);
            }

            static void ReadByte()
            {
                Console.WriteLine("Enter a byte");
                byte num = byte.Parse(Console.ReadLine());
                Console.WriteLine("You entered {0}", num);
            }

            static void ReadShort()
            {
                Console.WriteLine("Enter a short number");
                short num = short.Parse(Console.ReadLine());
                Console.WriteLine("You entered {0}", num);
            }

            static void ReadLong()
            {
                Console.WriteLine("Enter a long number");
                long num = long.Parse(Console.ReadLine());
                Console.WriteLine("You entered {0}", num);
            }

            static void ReadFloat()
            {
                Console.WriteLine("Enter a float number");
                float num = float.Parse(Console.ReadLine());
                Console.WriteLine("You entered {0}", num);
            }

            static void ReadDouble()
            {
                Console.WriteLine("Enter a double number");
                double num = double.Parse(Console.ReadLine());
                Console.WriteLine("You entered {0}", num);
            }

            static void ReadString()
            {
                string myStr;
                Console.WriteLine("Enter a string");
                myStr = Console.ReadLine();
                Console.WriteLine("You entered {0}", myStr);
            }

            static void ReadChar()
            {
                char myChar;
                Console.WriteLine("Enter a char");
                myChar = Convert.ToChar(Console.ReadLine());
                Console.WriteLine("You entered {0}", myChar);
            }

            static void NameSurname()
            {
                string Name;
                string Surname;
                
                Console.WriteLine("Enter your name");
                Name = Console.ReadLine();
                Console.WriteLine("Enter your surname");
                Surname = Console.ReadLine();
                string Full = Name + " " + Surname;
                string first = Name.Substring(0, 1);
                string second = Surname.Substring(0, 1);
                string Init = first + second;
                Console.WriteLine("Your name is {0}", Full);
                Console.WriteLine("Your initials are {0}", Init);
            }

            static void Colorhex()
            {
                Console.WriteLine("Enter a red color up to 255");
                byte r = byte.Parse(Console.ReadLine());
                Console.WriteLine("Enter a green color up to 255");
                byte g = byte.Parse(Console.ReadLine());
                Console.WriteLine("Enter a blue color up to 255");
                byte b = byte.Parse(Console.ReadLine());
                Console.WriteLine("#" + string.Format("{0:X2}{1:X2}{2:X2}", r, g, b));
            }

            static void NumberToBinary()
            {
                Console.WriteLine("Enter a number, get a pie and binary");
                int value = int.Parse(Console.ReadLine());
                string binary = Convert.ToString(value, 2);
                Console.WriteLine("Your number in binary is {0}", binary);
            }
        }
    }
    public class cASCII
    {
        public void tiskCharASCII()
        {
            string input = Console.ReadLine();
            char[] values = input.ToCharArray();
            foreach (char letter in values)
            {
                int value = Convert.ToInt32(letter);
                string hexOutput = String.Format("{0:X}", value);
                Console.WriteLine("Hexadecimal value of {0} is H{1}", letter, hexOutput);
            }
        }

        static void tiskCharASCII_2(string hexOutput)
        {
            Console.WriteLine("Negative hexadecimal value is -{0} and usual is {0}", hexOutput);
        }

    }
}

