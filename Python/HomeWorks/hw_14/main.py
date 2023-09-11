# Открываем исходные файлы
with open("file1.txt", "r") as file1, open("file2.txt", "r") as file2:
    lines1 = file1.readlines()
    lines2 = file2.readlines()

# Проверяем совпадение строк
for line1, line2 in zip(lines1, lines2):
    if line1 != line2:
        print("Строка из первого файла:", line1.strip())
        print("Строка из второго файла:", line2.strip())
        print("Строки не совпадают.\n")

#____________________________________________________________________________

# Открываем исходный файл
with open("input.txt", "r") as file:
    text = file.read()

# Инициализируем счетчики
char_count = len(text)
line_count = text.count('\n')
vowel_count = sum(1 for char in text if char.lower() in 'aeiouаеёиоуыэюя')
consonant_count = sum(1 for char in text if char.isalpha() and char.lower() not in 'aeiouаеёиоуыэюя')
digit_count = sum(1 for char in text if char.isdigit())

# Создаем новый файл со статистикой
with open("statistics.txt", "w") as output_file:
    output_file.write(f"Количество символов: {char_count}\n")
    output_file.write(f"Количество строк: {line_count}\n")
    output_file.write(f"Количество гласных букв: {vowel_count}\n")
    output_file.write(f"Количество согласных букв: {consonant_count}\n")
    output_file.write(f"Количество цифр: {digit_count}\n")
#____________________________________________________________________________

# Открываем исходный файл и читаем его содержимое
with open("input.txt", "r") as file:
    lines = file.readlines()

# Удаляем последнюю строку
lines.pop()

# Создаем новый файл и записываем в него обновленное содержимое
with open("output.txt", "w") as output_file:
    output_file.writelines(lines)

#____________________________________________________________________________

# Открываем файл и читаем его содержимое
with open("input.txt", "r") as file:
    lines = file.readlines()

# Находим длину самой длинной строки
max_length = max(len(line) for line in lines)

print("Длина самой длинной строки:", max_length)

#____________________________________________________________________________

# Задаем слово для поиска
word_to_count = input("Введите слово для поиска: ")

# Открываем файл и читаем его содержимое
with open("input.txt", "r") as file:
    text = file.read()

# Подсчитываем количество вхождений слова
word_count = text.lower().count(word_to_count.lower())

print(f"Слово '{word_to_count}' встречается {word_count} раз.")


#____________________________________________________________________________

# Задаем слово для поиска и замены
word_to_find = input("Введите слово для поиска: ")
word_to_replace = input("Введите слово для замены: ")

# Открываем файл и читаем его содержимое
with open("input.txt", "r") as file:
    text = file.read()

# Заменяем слово в тексте
new_text = text.replace(word_to_find, word_to_replace)

# Создаем новый файл и записываем в него обновленное содержимое
with open("output.txt", "w") as output_file:
    output_file.write(new_text)


#____________________________________________________________________________