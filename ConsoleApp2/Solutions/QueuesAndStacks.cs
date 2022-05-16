namespace Algoritmit
{
    public class QueuesAndStacks
    {
        public bool IsValid(string s)
        {
           
            Stack<char> stack = new Stack<char>();
           foreach (char s2 in s)
            {
                stack.Push(s2);
            }
            
            stack.Select(s => s).ToList().ForEach(Console.WriteLine);
            return true;
        }
    }
}
