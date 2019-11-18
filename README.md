# Minor-Math-Operation
This class basically performs Lowest Common Multiples (L.C.M), Highest Common Factor (H.C.F), maximum and next maximum of a list of numbers.

The class also has functions to find the multiples of and factors of a given number

# Test
``
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
``
