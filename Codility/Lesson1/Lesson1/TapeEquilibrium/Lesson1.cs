using System;
using System.Collections.Generic;
using System.Linq;

namespace TapeEquilibrium
{
    public class Lesson1
    {
        public int Solution(int[] a)
        {
            if ( a == null ||
                 a.Length == 0 )
            {
                return 0;
            }

            if ( a.Length == 1 )
            {
                return Math.Abs(a [ 0 ]);
            }

            int sum = FindMinimumSum(a);

            return sum;
        }

        private int FindMinimumSum(int[] a)
        {
//            int minimum = int.MaxValue;
//            int totalSum = a.Sum();
//            var leftSum = 0;
//            //var rightSum = totalSum;
//
//            for ( var i = 0 ; i < a.Length-1 ; i++ )
//            {
//                leftSum += a [ i ];
//                int rightSum = totalSum - leftSum;
//
//                int difference = Math.Abs(leftSum - rightSum);
//
//                if ( difference < minimum )
//                {
//                    minimum = difference;
//                }
//            }
//            return minimum;

            var list = new List <int>();
            
            int leftSum = 0;
            int totoalSum = a.Sum();
            
            for ( int i = 0 ; i < a.Length-1 ; i++ )
            {
                leftSum += a [ i ];
                int rightSum = Math.Abs(totoalSum - leftSum);
            
                int difference = Math.Abs(leftSum - rightSum);
            
                list.Add(difference);
            }
            
            return list.Min();
        }
    }
}