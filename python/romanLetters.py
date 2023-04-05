
def intToRoman( num: int) -> str:
    resultStr: str = ''
    remainder: int = 0

    romanLetterValsDict = {}
  
    resultStr += recurseAddChar(num // 1000,'M')
    remainder = num % 1000
    resultStr += recurseAddChar(remainder // 500, 'D')
    remainder = remainder % 500
    resultStr += recurseAddChar(remainder // 100, 'C')
    remainder = remainder % 100
    resultStr += recurseAddChar(remainder // 50, 'L')
    remainder = remainder % 50
    resultStr += recurseAddChar(remainder // 10, 'X')
    remainder = remainder % 10
    resultStr += recurseAddChar(remainder // 5 , 'V')
    print(resultStr)
    


def recurseAddChar(count: int, char: str) -> str:
    resultStr = ''
    for i in range(0,count):
        resultStr += char
    return resultStr

intToRoman(1677)