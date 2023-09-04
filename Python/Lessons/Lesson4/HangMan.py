import random
import requests
import re


def downloads_russian_words() -> list:
    """
    Загружает файл, содержащий русские слова, с удаленного URL-адреса и
    возвращает содержимое в виде строки.

    Принимает:
        None

    Возвращает:
        str: содержимое файла в виде списка.
    """
    response = requests.get(
        "https://raw.githubusercontent.com/LussRus/Rus_words/master/UTF8/txt/raw/summary.txt"
    )
    text = response.content.decode("utf-8")

    return text


def choice_random_word(word_list: list) -> str:
    """
    Выбирает случайное слово из списка.

    Принимает:
        word_list (list): Список слов.

    Возвращает:
        str: Слово.
    """
    random_index = random.randint(0, len(word_list) - 1)

    new_list_words = word_list.split('\n')

    return new_list_words[56]


def is_russian_char(guess: str) -> bool:
    """
    Проверяет, является ли буква из русского алфавита.

    Принимает:
        guess (str): Буква или знак '-'.

    Возвращает:
        bool: True, если буква русского алфавита, False в противном случае
    """
    if (
        (re.match("[а-я]", guess) is None)
        and (ord(guess[0]) != 1105)
        and (ord(guess[0]) != 45)
    ):
        return False
    return True


def main():
    list_words = downloads_russian_words()


    word_to_guess = choice_random_word(list_words)

    list_word_to_guess = list(word_to_guess)

    user_word = str()

    guess_number = 12

    hidden_word = ""

    list_of_tried_letters = ""
    list_of_correct_tried_letters = ""

    for i in word_to_guess:
        hidden_word += "_"

    list_hidden_word = list(hidden_word)

    while(guess_number != 0):
        print(list_hidden_word)
        print(f"Tried letters: {list_of_tried_letters}")
        print(f"Attempts:{guess_number} ")
        print("Letter: ")

        current_letter = input()
        if(is_russian_char(current_letter)):
            if current_letter in list_of_correct_tried_letters:
                print("You tried this letter it was correct")
            elif current_letter in list_of_tried_letters:
                print("You tried this letter it was incorrect")
            elif current_letter in list_word_to_guess:
                # hidden_word = hidden_word.replace("_", current_letter)
                for i, j  in enumerate(list_word_to_guess):
                    if(j == current_letter):
                        list_hidden_word[i] = current_letter
                        list_of_correct_tried_letters += j
            else:
                guess_number = guess_number - 1
                list_of_tried_letters += current_letter
        else:
            print("Enter russian letter")

        if(list_hidden_word == list_word_to_guess):
            print("Well done")
            break




        

        

if __name__ == "__main__":
    main()