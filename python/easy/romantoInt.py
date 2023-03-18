# problem link -

def RomanToInt(romanNumber) -> int:

    lettersDict = {
        'I': 1, 'V': 5, 'X': 10, 'L': 50, 'C': 100, 'D': 500, 'M': 1000
    }
    number = 0

    for i in range(0, len(romanNumber)):
        letter = romanNumber[i].capitalize()
        letterVal = int(lettersDict[letter])

        nextLetterVal = 0
        if (i < len(romanNumber)-1):
            nextLetter = romanNumber[i+1].capitalize()
            nextLetterVal = int(lettersDict[nextLetter])

        if (letterVal < nextLetterVal and nextLetterVal != 0):
            number -= letterVal
        else:
            number += letterVal

    return number


RomanToInt('XL')
