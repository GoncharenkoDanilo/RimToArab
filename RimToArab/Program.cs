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
            string inStr = Console.ReadLine();
            char[] rim1 = inStr.Split('+')[0].ToCharArray();
            char[] rim2 = inStr.Split('+')[1].ToCharArray();
            List<int> arab1 = new List<int>();
            List<int> arab2 = new List<int>();
            int arabRes;
            bool flag = true;

            foreach (char r in rim1)
                arab1.Add(parseToInt(r));
            foreach (char r in rim2)
                arab2.Add(parseToInt(r));

            while (flag)
                flag = test(arab1);
            while (flag)
                flag = test(arab2);

            Console.WriteLine(arab1.Sum());
            Console.WriteLine(arab2.Sum());

            arabRes = arab1.Sum() + arab2.Sum();
            Console.WriteLine(arabRes);

            Console.ReadLine();
        }

        public static int parseToInt(char rim)
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
