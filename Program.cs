using System.Reflection;

namespace Reflection
{
    internal class Program
    {
        public int Property { get; set; }

        public Program(int initialValue)
        {
            Property = initialValue;
        }

        public void Method()
        {
            Console.WriteLine("Method called");
        }

        static void Main(string[] args)
        {
           static int FindClosestEvenNumber(int N)
        {
            int lower = N;
            int upper = N;
            if (N<0)
            {
                while (!EvenDigits(lower) && !EvenDigits(upper))
                {
                    lower++;
                    upper--;
                }
            }
            else
            {
                while (!EvenDigits(lower) && !EvenDigits(upper))
                {
                    lower--;
                    upper++;
                }
            }
            return Math.Abs(N-lower)<=Math.Abs(N - upper)? lower : upper;
        }

        static bool EvenDigits(int num)
        {
            while (num != 0)
            {
                int digit = Math.Abs(num % 10);
                if (digit % 2 != 0)
                {
                    return false;
                }
                num /= 10;
            }
            return true;
        }
            object[] constructorParameters = { 42 };
            Type programType = typeof(Program);
            Console.WriteLine("***************Invoke Method******************");
            object programObject = Activator.CreateInstance(programType, constructorParameters);
            MethodInfo methodInfo = programType.GetMethod("Method");
            if (methodInfo != null)
            {
                methodInfo.Invoke(programObject, null);
            }
            else
            {
                Console.WriteLine("Method not found.");
            }
            Console.WriteLine("*************parameterized object********************");
            if (programObject is Program)
            {
                Console.WriteLine("Parameterized object of Program class created using reflection.");
                Console.WriteLine("SomeProperty: " + ((Program)programObject).Property);
            }
            else
            {
                Console.WriteLine("Failed to create a parameterized object of Program class.");
            }
            Console.WriteLine("************Empty Object********************");

            if (programObject is Program)
            {
                Console.WriteLine("Empty object of Program class created using reflection.");
            }
            else
            {
                Console.WriteLine("Failed to create an empty object of Program class.");
            }
            Console.WriteLine("****************Class Members*******************");
            Console.WriteLine("Class Members:");
            MemberInfo[] classMembers = programType.GetMembers(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var member in classMembers)
            {
                Console.WriteLine(member);
            }
            Console.Write("Enter an integer N: ");
            int N = int.Parse(Console.ReadLine());

            int closestEvenNumber = FindClosestEvenNumber(N);

            Console.WriteLine("The closest number with even digits is: " + closestEvenNumber);
        }

    }
}