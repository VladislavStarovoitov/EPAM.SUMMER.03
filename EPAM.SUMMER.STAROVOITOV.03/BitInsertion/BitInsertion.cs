using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitInsertion
{
    /// <summary>
    /// Provides static method that insert one number to another.
    /// </summary>
    public static class BitInsertion
    {
        private const int BitLength = 30;

        /// <summary>
        /// Inserts one number to the other starting with the starPosition and ending with the endPosition.
        /// </summary>
        /// <param name="destinationNumber">Number in wich sourceNumber will be inserted.</param>
        /// <param name="sourceNumber">Number that will be inserted.</param>
        /// <param name="startPosition">Bit position in destinationNumber at wich insertion begins.</param>
        /// <param name="endPosition">Bit position in destinationNumber at wich insertion ends.</param>
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
