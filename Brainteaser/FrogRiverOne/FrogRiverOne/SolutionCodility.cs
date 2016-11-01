using System.Linq;

namespace FrogRiverOne
{
    public class SolutionCodility
    {
        public int Solution(int X,
                            int[] A)
        {
            int max = -1;

            for(int i=0; i<X;i++)
            {
                int minute = A[i];

                if(minute > max)
                {
                    max = minute;
                }
            }

            return max + 1;

//            if (A.Length == 1)
//            {
//                return A[0];
//            }
//
//            bool[] tiles = new bool[X];
//            int steps = X;
//
//            for (int i = 0; i < A.Length; i++)
//            {
//                int index = A[i] - 1;
//                if (!tiles[index])
//                {
//                    steps--;
//                    tiles[index] = true;
//                }
//
//                if (steps == 0)
//                    return i;
//            }
//
//            return -1;

//            int[] path = new int[X];
//
//            int pathElements = 0;
//            int t = 0;
//            while (pathElements < X &&
//                   t < A.Length)
//            {
//                int newLeaf = A[t] - 1;
//                if (newLeaf < X)
//                {
//                    path[newLeaf]++;
//
//                    if (path[newLeaf] == 1)
//                    {
//                        pathElements++;
//                    }
//                }
//                t++;
//            }
//
//            if (pathElements < X)
//            {
//                return -1;
//            }
//
//            return t - 1;
        }
    }
}