﻿
namespace LemonWayTest.Service
{
    public class FibonacciService: BaseService
    {
        /// <summary>
        ///  takes input an integer N, and return the Nth value in the Fibonacci sequence 
        /// </summary>
        /// <param name="n">integer must be between 1<=n<=100</param>
        /// <returns>nth value in the Fibonacci sequence</returns>
        public decimal GetNthFibonacci(int n)
        {
            if (n < 1 || n > 100)
                return -1;

            decimal a = 0;
            decimal b = 1;
            // In N steps compute Fibonacci sequence iteratively.
            for (int i = 0; i < n; i++)
            {
                decimal temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }
    }
}
