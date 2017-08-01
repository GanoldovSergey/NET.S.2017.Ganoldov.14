using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{

    public class Logic
    {
        /// <summary>
        /// Count fibonacci number
        /// </summary>
        /// <param name="x">Wich Fibonacci number</param>
        /// <returns>Fibonacci number</returns>
        public IEnumerable<BigInteger> Fibonacci(BigInteger x)
        {
            if (x < 1) throw new ArgumentException();

            BigInteger prev = 0;
            BigInteger next = 1;

            for (int i = 0; i < x; i++)
            {
                BigInteger sum = prev + next;
                prev = next;
                next = sum;

                yield return sum;
            }
        }
    }
}
