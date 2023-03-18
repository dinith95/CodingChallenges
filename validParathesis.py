# problem link - https://leetcode.com/problems/valid-parentheses/
def IsValidParathesis(bracketStr) -> bool:
    bracketStack = []
    brackets = {'(': ')', '[': ']', '{': '}'}

    for br in bracketStr:
        if (br in brackets.keys()):
            bracketStack.append(brackets[br])

        else:
            if len(bracketStack) == 0:
                return False
            popBr = bracketStack.pop()
            if (br != popBr):
                return False

    return len(bracketStack) == 0


IsValidParathesis('()[]{}')
