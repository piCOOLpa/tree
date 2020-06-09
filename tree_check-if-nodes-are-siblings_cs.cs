using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tree_find_if_nodes_are_siblings_cs
{
    public class treenode
    {
        public int value;
        public treenode left, right;

        // constructor  
        public treenode(int value)
        {
            this.value = value;
            left = null;
            right = null;
        }

        class Program
        {
            private treenode root;

            static treenode make_tree(List<int> level_order, int current_position, int totaltreenodecount)
            {
                treenode root = null;
                if (current_position < totaltreenodecount)
                {
                    root = new treenode(level_order[current_position]);
                    root.left = make_tree(level_order, (2 * current_position) + 1, level_order.Count);
                    root.right = make_tree(level_order, (2 * current_position) + 2, level_order.Count);

                }
                return root;
            }

            static void inorder(treenode root)
            {
                if (root == null)
                {
                    return;
                }

                inorder(root.left);
                Console.Write(root.value + " ");
                inorder(root.right);
            }

            public static void levelOrder(treenode root)
            {
                Queue<treenode> first = new Queue<treenode>();
                Queue<treenode> second = new Queue<treenode>();
                // container to hold the tree elements.

                if (root == null)
                {
                    return;
                }

                // Pushing first level node  
                // into first queue  
                first.Enqueue(root);

                // Executing loop till both the  
                // queues become empty  
                while (first.Count != 0 || second.Count != 0)
                {

                    while (first.Count > 0)
                    {
                        // pop the elements from the first queue
                        // add the child elemets  to the second queue  
                        // repeat this process until the first queue is empty.

                        if (first.Peek().left != null)
                        {
                            // add the left child of the first queue element to the second queue.
                            second.Enqueue(first.Peek().left);
                        }

                        if (first.Peek().right != null)
                        {
                            // add the child child of the first queue element to the second queue.
                            second.Enqueue(first.Peek().right);
                        }

                        Console.Write(first.Peek().value + " ");
                        first.Dequeue();
                    }
                    Console.WriteLine();

                    while (second.Count > 0)
                    {
                        // pop the elements from the second queue
                        // add the child elemets  to the first queue  
                        // repeat this process until the second queue is empty.

                        if (second.Peek().left != null)
                        {
                            // add the left child of the second queue element to the first queue.
                            first.Enqueue(second.Peek().left);
                        }

                        if (second.Peek().right != null)
                        {
                            // add the right child of the second queue element to the first queue.
                            first.Enqueue(second.Peek().right);
                        }

                        Console.Write(second.Peek().value + " ");
                        second.Dequeue();
                    }
                    Console.WriteLine();

                }
            }

            public static bool isCousin(treenode root, treenode Node1, treenode Node2)
            {
                /*
                                A
                             x      y
                */

                if (root == null)
                    //  no tree to check for 
                    return false;

                if ((root.left == Node1 && root.right == Node2) || (root.left == Node2 && root.right == Node1))
                {
                    return true;
                }
                // if current root does not contain the left and right child as siblings , then recurse further.

                bool left_subtree = isCousin(root.left, Node1, Node2);
                if (left_subtree)
                    return true;
                bool right_subtree = isCousin(root.right, Node1, Node2);
                return (left_subtree || right_subtree);
                
            }

            static void Main(string[] args)
            {

                int[] lev_arr = new int[] { 6, 3, 5, 7, 8, 3, 1 };
                // given collection of the node data.

                int node_count = lev_arr.Length;

                // define a generic list and add all the elements into the generic list one by one 
                List<int> level_order = new List<int>();

                // adding all the elements to the generics 
                for (int index = 0; index < node_count; index++)
                {
                    level_order.Add(lev_arr[index]);
                }

                // iterate through the collection to check the elements 
                Console.Write("Elements Present in List:\n");
                int p = 0;

                /*
                foreach (int k in level_order)
                {
                    Console.Write("At Position {0}: ", p.ToString());
                    Console.WriteLine(k);
                    p++;
                }
                */

                treenode root;
                // referance to create the entire tree 

                int treenode_count = level_order.Count;
                root = make_tree(level_order, 0, treenode_count);

                //Console.WriteLine("the elements of the tree in the level-order traversal : ");
                //levelOrder(root);

                //Console.WriteLine("the elements of the tree in the in-order traversal : ");
                //inorder(root);

                treenode Node1  = root.right.left;
                treenode Node2  = root.right.right;
                // define two node referances to check for siblings. 


                if (isCousin(root, Node1, Node2))
                {
                    Console.WriteLine("the nodes are siblings");
                }
                else
                {
                    Console.WriteLine("the nodes are not siblings");
                }
                Console.WriteLine(" ");
                Console.ReadLine();
            }


        }
    }
}
