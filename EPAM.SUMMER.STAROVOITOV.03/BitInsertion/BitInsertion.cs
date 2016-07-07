using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitInsertion
{
    public static class BitInsertion
    {
        private const int BitLength = 30;
        public static void Insertion(ref int destinationNumber, int sourceNumber, int startPosition, int endPosition)
        {
            if (endPosition < startPosition)
            {
                throw new ArgumentException();
            }
            if (endPosition > BitLength || endPosition < 0 || startPosition < 0)
            {
                throw new ArgumentException();
            }
            sourceNumber <<= startPosition;
            sourceNumber &= int.MaxValue >> (BitLength - endPosition);
            int mask = -1;
            for (int i = startPosition; i <= endPosition; i++)
            {
                mask ^= 1 << i;
            }
            destinationNumber &= mask;
            destinationNumber |= sourceNumber;
        }
    }
}
