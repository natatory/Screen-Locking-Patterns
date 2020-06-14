using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Screen_Locking_Patterns
{
    class Solution
    {
        int countPattern = 0;
        char[,] dotMatrix = new char[3, 3] {
            { 'A', 'B', 'C' },
            { 'D', 'E', 'F' },
            { 'G', 'H', 'I' }
        };
        HashSet<char> dotChain = new HashSet<char>();
        int[] dotInd = new int[2];
        public int CountPatternsFrom(char firstDot, int length)
        {
            if (length == 0) return 0;
            dotChain.Add(firstDot);
            length--;
            if (length == 0)
            {
                length++;
                dotChain.Remove(dotChain.Last());
                return ++countPattern;
            }
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (dotChain.Contains(dotMatrix[i, j])) continue;
                    if (
                        (Math.Abs(i - GetDotInd(firstDot)[0]) < 2
                        && Math.Abs(j - GetDotInd(firstDot)[1]) < 2
                        || Math.Abs(i - GetDotInd(firstDot)[0]) == 1
                        && Math.Abs(j - GetDotInd(firstDot)[1]) == 2
                        || Math.Abs(i - GetDotInd(firstDot)[0]) == 2
                        && Math.Abs(j - GetDotInd(firstDot)[1]) == 1)
                        ||
                        (i != 1 || j != 1)
                        &&
                        (Math.Abs(i - GetDotInd(firstDot)[0]) == 2
                        && Math.Abs(j - GetDotInd(firstDot)[1]) == 0
                        && dotChain.Contains(dotMatrix[i == 0 ? i + 1 : i - 1, j])
                        ||
                        Math.Abs(i - GetDotInd(firstDot)[0]) == 0
                        && Math.Abs(j - GetDotInd(firstDot)[1]) == 2
                        && dotChain.Contains(dotMatrix[i, j == 0 ? j + 1 : j - 1])
                        ||
                        Math.Abs(i - GetDotInd(firstDot)[0]) == 2
                        && Math.Abs(j - GetDotInd(firstDot)[1]) == 2
                        && dotChain.Contains(dotMatrix[1, 1]))
                       )
                    {
                        CountPatternsFrom(dotMatrix[i, j], length);
                    }
                }
            dotChain.Remove(dotChain.Last());
            return countPattern;
        }

        int[] GetDotInd(char c)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (dotMatrix[i, j] == c)
                    {
                        dotInd[0] = i;
                        dotInd[1] = j;
                        return dotInd;
                    }
                }
            return null;
        }
    }
}
