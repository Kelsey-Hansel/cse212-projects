public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    // Unique values only.
    public void Insert(int value)
    {
        // Call Contains to check for value
        // if comparsion for Contains return value

        if (Contains(value) == true)
        {
            return;
        }
        else
        {
            if (value < Data)
            {
                // Insert to the left
                if (Left is null)
                    Left = new Node(value);
                else
                    Left.Insert(value);
            }
            else
            {
                // Insert to the right
                if (Right is null)
                    Right = new Node(value);
                else
                    Right.Insert(value);
            }
        }
    }

    // Using recursion, check for values already in tree.
    // Look at Insert() for guidance.
    public bool Contains(int value)
    {
        // Base case: "value" equal to current "Data" value, return true
        // Smaller Problem: check the root, check left, and then check right

        if (this.Data == value)
        {
            return true;
        }

        if (value < this.Data && Left is not null)
        {
            return Left.Contains(value);
        }

        if (value > this.Data && Right is not null)
        {
            return Right.Contains(value);
        }

        return false;
    }

    // Total height of tree (root node is + 1, bigger subtree is the height added to)
    // Use recursion
    public int GetHeight()
    {
        // Base Case: checking for just root, checking is node is null
        // Smaller Problem: call both subtrees and return taller value

        if (Left is null && Right is null)
        {
            return 1;
        }

        int heigthLeft = 0;
        int heightRight = 0;

        if (Left is not null)
        {
            heigthLeft = Left.GetHeight();
        }

        if (Right is not null)
        {
            heightRight = Right.GetHeight();
        }

        return Math.Max(heigthLeft, heightRight) + 1;
    }
}