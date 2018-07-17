namespace LeetCode
{
    public class LeetCodeChinaData
    {
        
    }
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }

        public static ListNode CreateNodeList(int[] valList)
        {
            ListNode head = new ListNode(valList[0]);
            ListNode currentNode = head;
            for (int i = 1; i < valList.Length; i++)
            {
                var newNode = new ListNode(valList[i]);
                currentNode.next = newNode;
                currentNode = newNode;
            }

            return head;
        }
    }
}