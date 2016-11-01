using System;
using System.Linq;

namespace MaxCounters
{
    public class SolutionCodibility
    {
        private int m_Max;
        private int[] m_Result = new int[]{};
        private int m_NPlusOne;

        public int[] solution(int N, int[] A)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            m_Result = new int[N];
            m_NPlusOne = N + 1;

            foreach (int X in A)
            {
                DoOperation(X, N);
            }

            return m_Result;
        }

        private void DoOperation(int X,
                                 int N)
        {
            if (IsMaxOperation(X, N))
            {
                MaxOperation();
            }
            else
            if(IsIncreaseOperation(X, N))
            {
                IncreaseOperation(X);
            }
        }

        private void MaxOperation()
        {
            for (int i = 0; i < m_Result.Length; i++)
            {
                m_Result[i] = m_Max;
            }
        }

        private void IncreaseOperation(int X)
        {
            m_Result[X - 1]++;

            if (m_Result[X - 1] > m_Max)
            {
                m_Max = m_Result[X - 1];
            }
        }
        private bool IsIncreaseOperation(int X, int N)
        {
            return X >= 1 && X <= N;
        }

        private bool IsMaxOperation(int X, int N)
        {
            return X == m_NPlusOne;
        }
    }
}