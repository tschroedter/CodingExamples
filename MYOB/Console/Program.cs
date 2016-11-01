using System.Diagnostics.CodeAnalysis;

namespace Console
{
    [ExcludeFromCodeCoverage]
    //ncrunch: no coverage start
    public class Program
    {
        /// <summary>
        /// For bonus points: 
        /// 1. Use as little memory as possible and make it run as fast as possible. 
        /// 2. In your comments, discuss the runtime order complexity of your solution e.g., O(n) or O(n^2), etc. 
        /// 3. Explain any assumptions or trade-offs you have made. 
        ///
        /// About 1: Linked List solution:
        ///          The linked list has a starts with a fixed length and is reduced over time
        ///          Pro: 
        ///          - Easy to implement
        ///          - Will work only nice with small numbers of players, 
        ///          Cons: 
        ///          - Slow with big numbers
        ///          - Because it's removing items from a list and this takes time,
        ///            might trigger garbage collector which slows it down even more
        /// 
        ///          BitArray Solution:
        ///          Pro: 
        ///          - Fast with big numbers
        ///          - Space efficient, constant memory usage
        ///          Cons:
        ///          - All persons checked everytime, even if not standing
        /// 
        /// About 2: Linked List solution:
        ///          The implementation uses a ring (linked list) as the main solution.
        ///          The ring gets smaller with each removed player. - The complexity is O(n^2).
        /// 
        ///          BitArray Solution:
        ///          Complexity is O(n) even with always checking all persons
        /// 
        /// About 3: I choose 2 solution because the Linked List solution shows TDD a bit better than the BitArray solution!
        ///          In production I would use BitArray.
        ///          I didn't use Castle Windsor (I know it's a small problem but stil helps to keep focused on inversion of control).
        ///          I didn't use my Selkie.Windsor project to register Castle Windsor components (https://github.com/tschroedter/Selkie.Windsor).
        ///          I didn't use FODY (ToString, Visualize).
        ///          I didn't use aspect oriented programming or contracts to check parameters.
        /// </summary>
        public static void Main(string[] args)
        {
            var helper = new SolutionHelper();

            var linkedList = new SolutionLinkedList(helper);
            linkedList.Run(10,
                           4);

            var bitArray = new SolutionBitArray(helper);
            bitArray.Run(10,
                         4);

            System.Console.ReadLine();
        }
    }
}