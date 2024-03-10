namespace LeetCodeSolutions.mediumProblems;

// problem: https://leetcode.com/problems/add-two-numbers/
class AddTwoNUmbers
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public ListNode SetUpLinkedLists(int value)
    { 
        var head = new ListNode(value % 10);
        var temp = head;
        value = value / 10;
        while(value >= 1)
        {
            var node = new ListNode(value % 10);
            value = value / 10;
            temp.next = node;
            temp = node;
        }
        return head;
    }

    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode resultHead = new ListNode();
        ListNode resultTemp = resultHead;
        int remainder = 0;
        
        // if both lists are empty stops the executions 
        while(l1 != null || l2 != null || remainder > 0)
        {
            // get the sum of two list nodes and the remainder from the previous sum
            int sum = (l1?.val ?? 0) + (l2?.val ?? 0) + remainder;
            remainder = sum / 10;

            
            // addt the quotient to the result node
            resultTemp.val = sum % 10;
            if(l1?.next != null || l2?.next != null || remainder > 0)
                resultTemp.next = new ListNode();

            // move to the next node
            resultTemp = resultTemp.next;
            l1 = l1?.next;
            l2 = l2?.next;
        }
       
        return resultHead;
    }


    private int getNumber(ListNode l)
    {
        int num = 0;
        int multiplier = 1;
        while (l != null)
        {
            num += l.val * multiplier;
            multiplier *= 10;
            l = l.next;
        }
        return num;
    }
}
