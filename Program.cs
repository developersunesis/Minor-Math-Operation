using System;
using System.Collections;
using System.Collections.Generic;

namespace Minor_Math_Operation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Checks if 5 is a prime number
            Console.WriteLine(isPrimeNumber(5));
            
            // This function is to find the prime numbers in a list of int numbers
            findPrimeNumbers(new List<int> { 1, 2, 3, 4, 5 });

            // Test: findLCM of a given list of numbers
            Console.WriteLine(findLCM(new List<int> { 16, 18, 20}));

            List<int> l = new List<int> { 16, 18, 20 };

            Console.WriteLine(nextMaxNumber(l)); // 20
            Console.WriteLine(nextMaxNumber(l)); // 18

            // Test: findHCF of a given list of numbers
            Console.WriteLine("HCF : " + findHCF(new List<int> { 9, 81, 27 }));
        }

        // Function to constrain the size of argument of the list numbers 
        public static Boolean isListGreaterThan10(List<int> param)
        {
            return param.Count > 10;
        }

        // Return the state if a number is a prime number or not
        public static Boolean isPrimeNumber(int param)
        {
            bool result = true;
            // loop from number 2 and check if the param is divisible by any number
            // with no remainder less than parm
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

        // Find the prime numbers in a list of numbers
        // return new list of prime numbers
        public static List<int> findPrimeNumbers(List<int> param)
        {
            List<int> primeNumber = new List<int>();
            // Constrain the size of the param to 10 items
            // This can be removed. It was used sequel to the assessment requiement
            
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

        // This function enumerates all the multiples of a give number
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

            // The multiples are been sorted from the least to the most
            multiples.Sort();

            // Returns a list of multiples
            return multiples;
        }

        // This function finds the LCM of a given list of numbers
        public static int findLCM(List<int> param)
        {
            ArrayList multiplesOfAllNumbers = new ArrayList();
            
            // Map multiples of each numbers in the param to a dictionary
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

        // Find the maximum number in a list of numbers
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

        // Find the next maximum number in a given list of numbers
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

        // Find the HCF of a given list of numbers
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
