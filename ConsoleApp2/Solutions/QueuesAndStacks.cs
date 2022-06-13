namespace Algoritmit
{
    public class QueuesAndStacks
    {
        public bool IsValid(string s)
        {

            Stack<int> sLast = new Stack<int>();
            foreach (int c in s)
            {
                if (c == 40 || c == 91 || c == 123)
                {
                    sLast.Push(c);
                }
                else if (sLast.Count > 0 && ((c == 41 && sLast.Peek() == 40) || (c == 93 && sLast.Peek() == 91) || (c == 123 && sLast.Peek() == 125)))
                {
                    sLast.Pop();
                }
                else
                {
                    return false;
                }
            }
            return sLast.Count == 0;
        }
    }
}
