namespace Algoritmit
{
    public class TreeNode
    {
        private int data;
        public int Data
        {
            get { return data; }
        }
        private TreeNode rightNode;
        public TreeNode RightNode
        {
            get { return rightNode; }
            set { rightNode = value; }
        } // Right child
        private TreeNode leftNode;
        public TreeNode LeftNode
        {
            get { return leftNode; }
            set { leftNode = value; }
        } // left 
        private bool IsDeleted; // soft delete variable
        public bool isDeleted
        {
            get { return IsDeleted; }
        }
        public TreeNode(int value)
        {
            data = value;
        } //Node constructor

        public void Insert(int value)
        {
            // if the given value is greater or equal to the data
            // then insert to the right node
            if (value >= data)
            {
                if (rightNode == null)
                    rightNode = new TreeNode(value);
                else
                    rightNode.Insert(value);
            }
            // otherwise we pass it to the left node
            else
            {
                if (leftNode == null)
                    leftNode = new TreeNode(value);
                else
                    leftNode.Insert(value);
            }
        }

        public void Remove()
        {
            IsDeleted = true;
        }

        public void PostorderTraversal()
        {
            if (leftNode != null)
                leftNode.PostorderTraversal();
            
            if(rightNode != null)
                rightNode.PostorderTraversal();

            Console.Write(data + " ");
        }

        public TreeNode Lookup(int value)
        {
            // Starting node
            TreeNode current = this;

            // loop through this node and all of the children of this node 
            while(current != null)
            {
                // if the current nodes data == to the given value, return it
                if (value == current.data && !isDeleted)
                {
                    return current;
                }
                else if(value > current.data) // if the given value is greather than the current data then go to the right child
                {
                    current = current.rightNode;
                }
                else // otherwise go to the left child
                {
                    current = current.leftNode;
                }
            }
            // Node not found
            return null;
        }

        public TreeNode FindRecursive(int value)
        {
            // if given value matches current data, then return the current node
            if (value == data && !isDeleted)
                return this;

            else if (value < data && leftNode != null) // if the given value is less than the current data then go to the left child
                return leftNode.FindRecursive(value);

            else if (rightNode != null) // otherwise go to the right child
                return rightNode.FindRecursive(value);
            else
                return null;
        }

        public void InOrderTraversal()
        {
            // First go to left child and print its children
            if(leftNode != null)
                leftNode.InOrderTraversal();
            Console.Write(data + " ");
            // Then we go to the right node, which will print itself as both its children are null
            if(rightNode != null)
                rightNode.InOrderTraversal();
        }

        public void PreorderTraversal()
        {
            Console.Write(data + " ");

            if (leftNode != null)
                leftNode.PreorderTraversal();

            if (rightNode != null)
                rightNode.PreorderTraversal();
        }

        public int? SmallestValue()
        {
            if (leftNode == null)
                return data;
            else
                return leftNode.SmallestValue();
        }

        public int? LargestValue()
        {
            if(rightNode == null)
                return data;
            else
                return rightNode.LargestValue();
            
        }

        public int NumberOfLeafNodes()
        {
            TreeNode current = this;
            int leftLeaves = 0;
            int rightLeaves = 0;

            if (current.leftNode == null && current.rightNode == null)
                return 1; // Found a leaf node

            if (current.leftNode != null)
                leftLeaves = leftNode.NumberOfLeafNodes();
            if (current.rightNode != null)
                rightLeaves = rightNode.NumberOfLeafNodes();

            return leftLeaves + rightLeaves;
        }

        public int Height()
        {
            if (leftNode == null && rightNode == null)
                return 1;

            int left = 0;
            int right = 0;

            if (leftNode != null)
                left = leftNode.Height();
            if(rightNode != null)
                right = rightNode.Height();

            if (left > right)
                return (left + 1);
            else
                return (right + 1);

        }
    }
}
