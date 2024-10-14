namespace Links
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CircularLinkedList<int> cll = new CircularLinkedList<int>();
            cll.Add(9);
            cll.Add(2);
            cll.Add(7);
            cll.Add(4);
            cll.Add(5);
            cll.Add(0);
            Console.WriteLine("Is 425 in the list: " + cll.Contains(425));
            Console.WriteLine("Is 9 in the list: " + cll.Contains(9));
            Console.WriteLine("Size of linked list: " + cll.Size());
            Console.WriteLine("Before Sorting:");
            Console.WriteLine(cll.ToString());
            cll.ShellSort();
            Console.WriteLine("After Sorting:");
            Console.WriteLine(cll.ToString());
        }
    }
}
