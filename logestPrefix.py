# problem link - https://leetcode.com/problems/longest-common-prefix/

def GetLongestPrefix(strs) -> str:
    recurse = True
    i = 0
    prefixcount = 0

    while recurse:
        letter = ''
        for s in strs:
            if (prefixcount >= len(s)):
                recurse = False
                break

            if (len(letter) == 0):
                letter = s[prefixcount]
                continue

            if letter != s[prefixcount]:
                recurse = False
                break
        if (recurse):
            prefixcount += 1
    if (prefixcount == 0):
        return ''
    return strs[0][:prefixcount]


strs = ["dog", "racecar", "car"]

result = GetLongestPrefix(strs)
print(result)
