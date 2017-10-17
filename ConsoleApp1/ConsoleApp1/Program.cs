using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass m = new MyClass();
            //m.PrintStars("5");

            Console.WriteLine("Use the out type to output two value");
            m.OutputBody();
            Console.WriteLine("=======================================");
            Console.WriteLine("Use the Tuple  to output two value");
            m.OutputBody2();
            Console.WriteLine("=======================================");
            Console.WriteLine("Use the more easy Tuple to output two value");
            m.OutputBody3();

            //need Nuget to install System.ValueTuple
            var (sum, count) = Calc(new int[] { 1, 2, 3 });
            Console.WriteLine(sum);
            Console.WriteLine(count);

            Print("6");
            Console.ReadKey();
        }

        static (int x, int y) Calc(int[] values)
        {
            return (values.Sum(), values.Length);
        }

        static void Print(string s)
        {
            if (int.TryParse(s, out int result))
            {
                Console.WriteLine(new string('*', result));
            }

        }
    }

    class MyClass
    {
        // out method example
        public void PrintStars(string s)
        {
            if (int.TryParse(s, out var i))
            {
                Console.WriteLine(new string('*', i));
            }
            else Console.WriteLine("Cloudy - no starts tonikght");
        }

        //return multi value
        //method 1 -out
        public void GetHightAndWeight(out int height, out int weight)
        {
            height = 168;
            weight = 60;
        }
        public void OutputBody()
        {
            GetHightAndWeight(out int height, out int weight);
            Console.WriteLine("Height = {0}", height);
            Console.WriteLine("weight = {0}", weight);
        }
        //method 2 -Truple
        Tuple<int, int> GetHeightAndWeight2()
        {
            var returnVal = new Tuple<int, int>(172, 80);
            return returnVal;
        }

        public void OutputBody2()
        {
            var body = GetHeightAndWeight2();
            Console.WriteLine($"Height = {body.Item1}");
            Console.WriteLine($"Weight = {body.Item2}");
            // Height = 172
            // Weight = 80
        }

        //mtethod 3 -Truple System.ValueTuple
        (int height, int weight) GetHeightAndWeight3()
        {
            var returnVal = (168, 60);
            return returnVal;
        }
        public void OutputBody3()
        {
            var body = GetHeightAndWeight3();
            Console.WriteLine("Height = {0}", body.height);
            Console.WriteLine("Weight = {0}", body.weight);
        }
    }
}
