using System;
using System.Collections;
using System.Collections.Generic;

namespace Minor_Math_Operation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(isPrimeNumber(5));
            findPrimeNumbers(new List<int> { 1, 2, 3, 4, 5 });

            Console.WriteLine(findLCM(new List<int> { 16, 18, 20}));

            List<int> l = new List<int> { 16, 18, 20 };

            Console.WriteLine(nextMaxNumber(l)); // 20
            Console.WriteLine(nextMaxNumber(l)); // 18

            Console.WriteLine("HCF : " + findHCF(new List<int> { 9, 81, 27 }));
        }

        public static Boolean isListGreaterThan10(List<int> param)
        {
            return param.Count > 10;
        }

        public static Boolean isPrimeNumber(int param)
        {
            bool result = true;
            for (int i = 2; i < param; i++)
            {
                if ((param % i) == 0)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public static List<int> findPrimeNumbers(List<int> param)
        {
            List<int> primeNumber = new List<int>();
            if (isListGreaterThan10(param))
            {
                Console.WriteLine("Total number of items in the list cannot be greater than 10.");
                return primeNumber;
            }

            foreach (int number in param)
            {
                if (isPrimeNumber(number))
                {
                    primeNumber.Add(number);
                    Console.WriteLine(number + " is a prime number");
                }
            }

            return primeNumber;
        }

        public static List<int> enumerateMultiplesOf(int number)
        {
            List<int> multiples = new List<int>();

            for (int i = 2; i <= number; i++)
            {
                if ((number % i) == 0)
                {
                    multiples.Add(i);
                    number = number / i;
                    i = 1;
                } 
            }

            multiples.Sort();

            return multiples;
        }

        public static int findLCM(List<int> param)
        {
            ArrayList multiplesOfAllNumbers = new ArrayList();
            IDictionary<int, int> dict = new Dictionary<int, int>();

            double result = 1;

            if (isListGreaterThan10(param))
            {
                Console.WriteLine("Total number of items in the list cannot be greater than 10.");
                return -1;
            }

            foreach (int number in param)
            {
                multiplesOfAllNumbers.Add(enumerateMultiplesOf(number));
            }

            foreach(List<int> multiples in multiplesOfAllNumbers)
            {
                foreach(int primenumber in multiples)
                {
                    int count = multiples.FindAll((x) => x == primenumber).Count;

                    if (dict.ContainsKey(primenumber))
                    {
                        if(count > dict[primenumber])
                        {
                            dict[primenumber] = count;
                        }
                    } else
                    {
                        dict[primenumber] = count;
                    }
                }
            }

            foreach(KeyValuePair<int, int> item in dict)
            {
                result *= Math.Pow(item.Key, item.Value);
            }

            return (int) result;
        }

        public static int maxNumber(List<int> param)
        {
            int result = 0;
            if (isListGreaterThan10(param))
            {
                Console.WriteLine("Total number of items in the list cannot be greater than 10.");
                return -1;
            }
            foreach (int number in param)
            {
                result = (number > result) ? number : result;
            }

            return result;
        }

        public static int nextMaxNumber(List<int> param)
        {
            int result = 0;

            if (isListGreaterThan10(param))
            {
                Console.WriteLine("Total number of items in the list cannot be greater than 10.");
                return -1;
            }

            param.Sort();
            result = param[param.Count - 1];
            param.RemoveAt(param.Count - 1);
            return result;
        }

        public static int findHCF(List<int> param)
        {
            int result = 0;
            List<int> factors = new List<int>();

            if (isListGreaterThan10(param))
            {
                Console.WriteLine("Total number of items in the list cannot be greater than 10.");
                return -1;
            }

            foreach (int number in param)
            {
                for(int i = 2; i <= number; i++)
                {
                    if ((number % i) == 0) factors.Add(i);
                }
            }

            factors.Sort();

            int count = 0;
            foreach(int factor in factors)
            {
                int tempCount = factors.FindAll((x) => (x == factor)).Count;
                count = (tempCount > count) ? tempCount : count;
                result = (tempCount == count) ? factor : result;
            }

            return result;
        }
    }
}
