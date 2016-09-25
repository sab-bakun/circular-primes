using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularPrimes
{
    class Program
    {
        const int n = 1000000;

        static void Main(string[] args)
        {
            Console.WriteLine("The number of ciruclar primes below 1 million is {0}.", NumberOfCircularPrimes(SieveOfEratosthenes(n)));
            Console.ReadKey();
        }

        //Знаходження всіх простих числа до n, застосовуючи алгоритм решета Ератосфена.  
        static bool[] SieveOfEratosthenes(int n)
        {
            bool[] A = new bool[n];
            A[0] = false;
            A[1] = false;

            for (int i = 2; i < n; i++)
            {
                A[i] = true;
            }

            for (int i = 2; i < Math.Sqrt(n) + 1; i++)
            {
                if (A[i])
                {
                    for (int j = i * i; j < n; j += i)
                    {
                        A[j] = false;
                    }
                }
            }
            return A;
        }

        //Підрахунок кількості кругових простих чисел зі знайдених простих чисел.
        static int NumberOfCircularPrimes(bool[] A)
        {
            int count = 0;
            for (int i = 2; i < A.Length; i++)
            {
                if (A[i])
                {
                    int temp = i;
                    int length = i.ToString().Length;
                    bool flag = true;

                    for (int j = 0; j < length - 1; j++)
                    {
                        temp = (int) ((temp % 10) * Math.Pow(10, length - 1) + temp / 10);
                       
                        if (!A[temp])
                        {
                            A[i] = false;
                            flag = false;
                        }

                        if (!flag)
                        {
                            A[temp] = false;
                        }
                    }

                    if (flag)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
