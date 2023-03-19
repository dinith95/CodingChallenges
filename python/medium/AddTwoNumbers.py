# promblem url -> https://leetcode.com/problems/add-two-numbers/


class ListNode:

    def __init__(self, val=0, next=None):

        self.val = val

        self.next = next


class solution:

    def GetNumericValue(self, l1, l2):

        head: ListNode = None
        rootNode: ListNode = None
        carriage = 0

        while l1 or l2 or carriage > 0:
            value = carriage
            carriage = 0
            if l1:
                value += l1.val
                l1 = l1.next

            if l2:
                value += l2.val
                l2 = l2.next

            if value >= 10:
                carriage = value // 10
                value = value % 10

            newNode = ListNode(value)

            if (head):
                head.next = newNode
                head = head.next

            else:
                head = newNode
                rootNode = newNode

        return rootNode

    def GetLinkedList(self, arrItems):

        head = None

        for item in arrItems:
            if (head is None):
                head = ListNode(item)
                continue

            newNode = ListNode(item)
            newNode.next = head
            head = newNode

        return head


l1 = solution().GetLinkedList(reversed([2, 4, 3]))

l2 = solution().GetLinkedList(reversed([5, 6, 4]))

res = solution().GetNumericValue(l1, l2)
