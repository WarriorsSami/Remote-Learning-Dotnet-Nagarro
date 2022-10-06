namespace iQuest.BigTree.Business
{
    public class Node
    {
        public int[] Values { get; set; }

        public Node LeftNode { get; set; }

        public Node RightNode { get; set; }

        public int CountNodes()
        {
            int leftNodesCount = LeftNode?.CountNodes() ?? 0;
            int rightNodesCount = RightNode?.CountNodes() ?? 0;

            return 1 + leftNodesCount + rightNodesCount;
        }
    }
}