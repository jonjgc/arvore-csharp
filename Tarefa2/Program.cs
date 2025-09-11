using System;
using System.Linq;

// Define a estrutura de um nó da árvore
public class TreeNode
{
    public int Value;
    public TreeNode? Left;
    public TreeNode? Right;

    public TreeNode(int value = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.Value = value;
        this.Left = left;
        this.Right = right;
    }
}

public class TreeBuilder
{
    public TreeNode? BuildTree(int[] nums)
    {
        if (nums == null || nums.Length == 0)
        {
            return null;
        }

        int maxValue = nums[0];
        int maxIndex = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > maxValue)
            {
                maxValue = nums[i];
                maxIndex = i;
            }
        }
        TreeNode root = new TreeNode(maxValue);

        int[] leftSubArray = nums.Take(maxIndex).ToArray();
        int[] rightSubArray = nums.Skip(maxIndex + 1).ToArray();

        root.Left = BuildBranchAsChain(leftSubArray);
        root.Right = BuildBranchAsChain(rightSubArray);

        return root;
    }

    private TreeNode? BuildBranchAsChain(int[] nums)
    {
        if (nums == null || nums.Length == 0)
        {
            return null;
        }

        Array.Sort(nums);
        Array.Reverse(nums);

        TreeNode headNode = new TreeNode(nums[0]);
        TreeNode currentNode = headNode;

        for (int i = 1; i < nums.Length; i++)
        {
            currentNode.Right = new TreeNode(nums[i]);
            currentNode = currentNode.Right;
        }

        return headNode;
    }

    public void PrintTree(TreeNode? node, string indent = "", bool last = true)
    {
        if (node != null)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("└── ");
                indent += "    ";
            }
            else
            {
                Console.Write("├── ");
                indent += "│   ";
            }
            Console.WriteLine(node.Value);
            var children = new[] { node.Left, node.Right }.Where(c => c != null).ToList();
            for (int i = 0; i < children.Count; i++)
            {
                PrintTree(children[i], indent, i == children.Count - 1);
            }
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        TreeBuilder builder = new TreeBuilder();

        Console.WriteLine("Cenario 1");
        int[] inputArray1 = { 3, 2, 1, 6, 0, 5 };
       
        TreeNode? root1 = builder.BuildTree(inputArray1);
        builder.PrintTree(root1);

        Console.WriteLine("\n---------------------------\n");

        Console.WriteLine("Cenario 2");
        int[] inputArray2 = { 7, 5, 13, 9, 1, 6, 4 };
        
        TreeNode? root2 = builder.BuildTree(inputArray2);
        builder.PrintTree(root2);
    }
}