import re

def is_palindrome(s):
    s = s.lower().replace(" ", "").replace(",", "").replace(".", "")
    return s == s[::-1]

user_input = input("Введите строку: ")
if is_palindrome(user_input):
    print("Введенная строка является палиндромом.")
else:
    print("Введенная строка не является палиндромом.")

#______________________________________________________________________________________
def replace_reserved_words(text, reserved_words):
    words = text.split()
    for i in range(len(words)):
        if words[i] in reserved_words:
            words[i] = words[i].upper()
    return " ".join(words)

user_text = input("Введите текст: ")
reserved_words = input("Введите зарезервированные слова через пробел: ").split()
modified_text = replace_reserved_words(user_text, reserved_words)
print("Измененный текст:")
print(modified_text)

#______________________________________________________________________________________
def count_sentences(text):
    # Подсчет предложений по наличию '.', '!' или '?'
    sentences = [s.strip() for s in re.split(r'[.!?]', text) if s.strip()]
    return len(sentences)

user_text = input("Введите текст: ")
sentence_count = count_sentences(user_text)
print("Количество предложений:", sentence_count)
