using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tree_build_a_tree_inordertraversal
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

            static treenode make_tree(List<char> level_order, int current_position, int totaltreenodecount)
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
            static void Main(string[] args)
            {

                char[] lev_arr = new char[] { 'D', 'B', 'E', 'A', 'F', 'C' };
                // inorder traversal 

                int char_count = lev_arr.Length;

                // define a generic list and add all the elements into the generic list one by one 
                List<char> level_order = new List<char>();

                // adding all the elements to the generics 
                for (int index = 0; index < char_count; index++)
                {
                    level_order.Add(lev_arr[index]);
                }


                // iterate through the collection to check the elements 
                Console.Write("Elements Present in List:\n");
                int p = 0;
                foreach (int k in level_order)
                {
                    Console.Write("At Position {0}: ", p.ToString());
                    Console.WriteLine(k);
                    p++;
                }

                treenode root;
                // referance to create the entire tree 
                int treenode_count = level_order.Count;
                root = make_tree(level_order, 0, treenode_count);
                 Console.WriteLine("the elements of the tree in the in-order traversal : ");
                inorder(root);


                Console.WriteLine(" ");
                Console.ReadLine();
            }


        }
    }
}
