namespace FrogRiverOne
{
    public class MySolution
    {
        public int Solution(int x, int[] a)
        {
            bool[] flags = new bool[x + 1];
            flags[0] = true;

            // let leaves fall
            int counter = 0;
            int answer = -1;

            for (int time = 0; time < a.Length; time++)
            {
                int leaveFallingAtTime = a[time];

                // if it is bewteen 0 to x-1 and no leave has fallen onto position before, count it
                if (leaveFallingAtTime <= x &&
                    !flags[leaveFallingAtTime])
                {
                    flags[leaveFallingAtTime] = true;
                    counter++;

                    if (counter == x)
                    {
                        answer = time;

                        break;
                    }
                }
            }

            return answer;
        }
    }
}
