letters = "аяуюоеёэиы"
exceptions = list(letters + letters.upper())


def is_letter_val(letter) -> bool:
    if letter in exceptions:
        return True
    else:
        return False
    
def salt_lang(lines) -> str:
    result = ""
    list_lines = list(lines.split(" "))
    
    for word in list_lines:
        for value in word:
            if(is_letter_val(value)):
                result += value + "c" + value
            else:
                result += value
            result += ""
        return result
    
def easy_salt_lang(sentence: str) -> str:
    for vowel in exceptions:
        sentence = sentence.replace(vowel, vowel + "c" + vowel.lower)
    return sentence



def main() -> None:
    while True:
        print("Write a word: ")
        word = str(input())
        print(salt_lang(word))
    
if __name__=="__main__":
    main()