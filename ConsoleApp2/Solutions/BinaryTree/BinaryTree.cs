using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmit
{
    public class BinaryTree
    {
        private TreeNode root;

        // recursively calls insert down the tree untill it finds an open spot
        public void Insert(int data)
        {
            if (root != null)
                root.Insert(data);
            else
                root = new TreeNode(data);
        }
        public void Remove(int data)
        {
            TreeNode current = root;
            TreeNode parent = root;
            bool isLeftChild = false;

            // empty tree
            if (current == null)
                return;

            // Loop through the nodes untill we find a matching value
            while(current != null && current.Data != data)
            {
                // set current node to be new parent reference, then we look at its children
                parent = current;

                // if the data we are looking for is less than the current node, then we look at its left child
                if (data < current.Data)
                {
                    current = current.LeftNode;
                    isLeftChild = true; // Set the variable to determine which child we are looking at 
                }
                // otherwise we will look at its right child
                else
                {
                    current = current.RightNode;
                    isLeftChild = false; // Set the variable to determine which child we are looking at 
                }
            }

            // if the node is not found, then there is nothing to delete so we just return
            if (current == null)
                return;

            // If the current node doesnt have children, then it means that
            // its a leaf node, i.e no child nodes
            if(current.RightNode == null && current.LeftNode == null)
            {
                if (current == root)
                    root = null;
                else
                {
                    // If not the root node, then we check which parent should be deleted
                    if (isLeftChild)
                    {
                        // remove reference to the left side node
                        parent.LeftNode = null;
                    }
                    else
                    {
                        // remove reference to the right child node
                        parent.RightNode = null;
                    }
                }
            }
            else if(current.RightNode == null)
            {
                //If the current node is the root then we just set root to Left child node
                if (current == root)
                    root = current.LeftNode;
                else
                {
                    //see which child of the parent should be deleted
                    if (isLeftChild) //is this the right child or left child
                        //current is left child so we set the left node of the parent to the current nodes left child
                        parent.LeftNode = current.LeftNode;
                    else
                        //current is right child so we set the right node of the parent to the current nodes left child
                        parent.RightNode = current.LeftNode;
                }
            }
            else if(current.LeftNode == null)
            {
                //If the current node is the root then we just set root to Right child node
                if (current == root)
                    root = current.RightNode;
                else
                {
                    //see which child of the parent should be deleted
                    if (isLeftChild)
                        //current is left child so we set the left node of the parent to the current nodes right child
                        parent.LeftNode = current.RightNode;
                    else
                        //current is right child so we set the right node of the parent to the current nodes right child
                        parent.RightNode = current.RightNode;
                }
            }
            else
            {
                //When both child nodes exist we can go to the right node and then find the leaf node of the left child as this will be the least number
                //that is greater than the current node. It may have a right child, so the right child would become..left child of the parent of this leaf aka successer node

                TreeNode successor = GetSuccessor(current);
                //if the current node is the root node then the new root is the successor node
                if (current == root)
                    root = successor;
                else if (isLeftChild)
                    //if this is the left child set the parents left child node as the successor node
                    parent.LeftNode = successor;
                
                else
                    //if this is the right child set the parents right child node as the successor node
                    parent.RightNode = successor;
            }
        }
        private TreeNode GetSuccessor(TreeNode node)
        {
            TreeNode parentOfSuccessor = node;
            TreeNode successor = node;
            TreeNode current = node.RightNode;

            while (current != null)
            {
                parentOfSuccessor = successor;
                successor = current;
                current = current.LeftNode;
            }

            if(successor != node.RightNode)
            {
                parentOfSuccessor.LeftNode = successor.RightNode;
                successor.RightNode = node.RightNode;
            }
            successor.LeftNode = node.LeftNode;

            return successor;
        }
        public void SoftDelete(int data)
        {
            TreeNode toDelete = Lookup(data);
            if(toDelete != null)
            {
                toDelete.Remove();
            }
        }

        // Tree traversal in order
        // Traverses the tree recursively in the following order
        // Root -> Left -> Root -> Right
        public void InOrderTraversal()
        {
            if (root != null)
                root.InOrderTraversal();
        }

        // Traverses the tree recursively in the following order
        // Root->Left->Right
        public void PreorderTravesal()
        {
            if (root != null)
                root.PreorderTraversal();
        }

        // Traverses the tree recursively in the following order
        // Left -> Right -> Root
        public void PostorderTraversal()
        {
            if (root != null)
                root.PostorderTraversal();
        }
        public TreeNode Lookup(int data)
        {
            if (root != null)
                return root.Lookup(data);

            else
                return null;
        }
        public TreeNode FindRecursive(int data)
        {
            if (root != null)
                return root.FindRecursive(data);
            else
                return null;
        }
        public Nullable<int> Smallest()
        {
            if (root != null)
                return root.SmallestValue();
            else
                return null;
        }
        public Nullable<int> Largest()
        {
            if (root != null)
                return root.LargestValue();
            else
                return null;
        }
        public int NumberOfLeafNodes()
        {
            if (root == null)
                return 0;

            return root.NumberOfLeafNodes();
        }
        public int Height()
        {
            if (root == null)
                return 0;
            return root.Height();
        }
    }
}
