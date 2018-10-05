using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimToArab
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i=1; i<=2000; i++)
            //{
            //    string rim = parseToString(i);
            //    int num2 = parseToInt(rim);
            //    if (i != num2)
            //    {
            //        Console.WriteLine($"{i} == {rim} == {num2}");
            //    }

            //}

            //Console.WriteLine("всё");

            string[] rims = Console.ReadLine().Split('+');
            List<int> nums = new List<int>();
            foreach (string rim in rims)
            {
                if (rim != null && rim != "") nums.Add(parseToInt(rim));
            }

            int sum = nums.Sum();

            Console.WriteLine($"{parseToString(sum)}");

        }

        public static int parseToInt(string rim)
        {
            int num = 0;
            List<int> arab1 = new List<int>();
            List<int> arab2 = new List<int>();
            int arabRes;
            bool flag = true;

            foreach (char r in rim)
                arab1.Add(parseToIntDanil(r));
            //foreach (char r in rim2)
            //    arab2.Add(parseToInt(r));


            //Console.WriteLine(arab2.Sum());

            while (flag)
                flag = test(arab1);

            return arab1.Sum();
        }

        public static int parseToIntDanil(char rim)
        {
            switch (rim)
            {
                case 'I':
                    return 1;
                case 'V':
                    return 5;
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
                default: return -1;
            }
        }

        struct Rim
        {
            public int dec;
            public string rim;

            public Rim(int dec, string rim)
            {
                this.dec = dec;
                this.rim = rim;
            }
        }


        public static string parseToString(int num)
        {
            string result = "";

            List<Rim> mass = new List<Rim>();
            mass.Add(new Rim(1000, "M"));
            mass.Add(new Rim(900, "CM"));
            mass.Add(new Rim(500, "D"));
            mass.Add(new Rim(400, "CD"));
            mass.Add(new Rim(100, "C"));
            mass.Add(new Rim(90, "XC"));
            mass.Add(new Rim(50, "L"));
            mass.Add(new Rim(40, "XL"));
            mass.Add(new Rim(10, "X"));
            mass.Add(new Rim(9, "IX"));
            mass.Add(new Rim(5, "V"));
            mass.Add(new Rim(4, "IV"));
            mass.Add(new Rim(1, "I"));

            foreach (Rim iter in mass)
            {
                int count = num / iter.dec;
                for (int i = 0; i< count; i++)
                {
                    result += iter.rim;
                }
                num -= (iter.dec * count); 
            }

            return result;
        }

        public static bool test(List<int> arab)
        {
            bool flag = false;

            for (int i = 1; i < arab.Count; i++)
            {
                if (arab[i] > arab[i - 1])
                {
                    flag = true;
                    arab[i] -= arab[i - 1];
                    arab.RemoveAt(i - 1);
                    break;
                }
            }

            return flag;
        }


    }

}
