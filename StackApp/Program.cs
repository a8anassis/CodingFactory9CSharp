namespace StackApp;

internal class Program
{
    static void Main(string[] args)
    {
        var myStack = new CFStack(50);
        try
        {
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(4);
            myStack.Push(5);
            int popped = myStack.Pop();
            Console.WriteLine(popped);
            for (int i = 0; i < myStack.Count; i++)
            {
                Console.Write(myStack.GetItemAt(i) + " ");
            }
        }
        catch (StackIsFullException e)
        {
            Console.Error.WriteLine(e.Message);
            throw;
        }
        catch (Exception e)
        {
            Console.Error.WriteLine("Error occurred: " + e);
            throw;
        }
    }
}