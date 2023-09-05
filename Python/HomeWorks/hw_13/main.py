basketball_players = {}  # Создаем пустой словарь для хранения данных

# Функция для добавления информации о баскетболисте
def add_player():
    name = input("Введите ФИО баскетболиста: ")
    height = float(input("Введите рост баскетболиста (в см): "))
    basketball_players[name] = height
    print(f"Информация о баскетболисте {name} добавлена.")

# Функция для удаления информации о баскетболисте
def remove_player():
    name = input("Введите ФИО баскетболиста, которого хотите удалить: ")
    if name in basketball_players:
        del basketball_players[name]
        print(f"Информация о баскетболисте {name} удалена.")
    else:
        print("Баскетболист не найден.")

# Функция для поиска информации о баскетболисте
def search_player():
    name = input("Введите ФИО баскетболиста, которого хотите найти: ")
    if name in basketball_players:
        print(f"Информация о баскетболисте {name}: Рост {basketball_players[name]} см.")
    else:
        print("Баскетболист не найден.")

# Функция для замены информации о баскетболисте
def replace_player():
    name = input("Введите ФИО баскетболиста, информацию о котором хотите заменить: ")
    if name in basketball_players:
        height = float(input(f"Введите новый рост для баскетболиста {name} (в см): "))
        basketball_players[name] = height
        print(f"Информация о баскетболисте {name} обновлена.")
    else:
        print("Баскетболист не найден.")

while True:
    print("\nМеню:")
    print("1. Добавить информацию о баскетболисте")
    print("2. Удалить информацию о баскетболисте")
    print("3. Найти информацию о баскетболисте")
    print("4. Заменить информацию о баскетболисте")
    print("5. Выйти")
    
    choice = input("Выберите действие (1/2/3/4/5): ")
    
    if choice == "1":
        add_player()
    elif choice == "2":
        remove_player()
    elif choice == "3":
        search_player()
    elif choice == "4":
        replace_player()
    elif choice == "5":
        break
    else:
        print("Некорректный выбор. Пожалуйста, выберите действие из меню.")

#_________________________________________________________________________


english_to_french = {}  # Создаем пустой словарь для хранения данных

# Функция для добавления перевода слова
def add_translation():
    english_word = input("Введите слово на английском: ")
    french_word = input("Введите перевод на французский: ")
    english_to_french[english_word] = french_word
    print(f"Перевод слова '{english_word}' добавлен.")

# Функция для удаления перевода слова
def remove_translation():
    english_word = input("Введите слово на английском, перевод которого хотите удалить: ")
    if english_word in english_to_french:
        del english_to_french[english_word]
        print(f"Перевод слова '{english_word}' удален.")
    else:
        print("Слово не найдено.")

# Функция для поиска перевода слова
def search_translation():
    english_word = input("Введите слово на английском, перевод которого хотите найти: ")
    if english_word in english_to_french:
        print(f"Перевод слова '{english_word}' на французский: {english_to_french[english_word]}")
    else:
        print("Слово не найдено.")

# Функция для замены перевода слова
def replace_translation():
    english_word = input("Введите слово на английском, перевод которого хотите заменить: ")
    if english_word in english_to_french:
        french_word = input(f"Введите новый перевод для слова '{english_word}' на французский: ")
        english_to_french[english_word] = french_word
        print(f"Перевод слова '{english_word}' обновлен.")
    else:
        print("Слово не найдено.")

while True:
    print("\nМеню:")
    print("1. Добавить перевод слова")
    print("2. Удалить перевод слова")
    print("3. Найти перевод слова")
    print("4. Заменить перевод слова")
    print("5. Выйти")
    
    choice = input("Выберите действие (1/2/3/4/5): ")
    
    if choice == "1":
        add_translation()
    elif choice == "2":
        remove_translation()
    elif choice == "3":
        search_translation()
    elif choice == "4":
        replace_translation()
    elif choice == "5":
        break
    else:
        print("Некорректный выбор. Пожалуйста, выберите действие из меню.")


#_________________________________________________________________________

company_data = {}  # Создаем пустой словарь для хранения данных

# Функция для добавления информации о сотруднике
def add_employee():
    name = input("Введите ФИО сотрудника: ")
    phone = input("Введите телефон сотрудника: ")
    email = input("Введите рабочий email сотрудника: ")
    position = input("Введите название должности сотрудника: ")
    office_number = input("Введите номер кабинета сотрудника: ")
    skype = input("Введите Skype сотрудника: ")
    company_data[name] = {
        "Телефон": phone,
        "Email": email,
        "Должность": position,
        "Номер кабинета": office_number,
        "Skype": skype
    }
    print(f"Информация о сотруднике {name} добавлена.")

# Функция для удаления информации о сотруднике
def remove_employee():
    name = input("Введите ФИО сотрудника, информацию о котором хотите удалить: ")
    if name in company_data:
        del company_data[name]
        print(f"Информация о сотруднике {name} удалена.")
    else:
        print("Сотрудник не найден.")

# Функция для поиска информации о сотруднике
def search_employee():
    name = input("Введите ФИО сотрудника, информацию о котором хотите найти: ")
    if name in company_data:
        print(f"Информация о сотруднике {name}:")
        for key, value in company_data[name].items():
            print(f"{key}: {value}")
    else:
        print("Сотрудник не найден.")

# Функция для замены информации о сотруднике
def replace_employee():
    name = input("Введите ФИО сотрудника, информацию о котором хотите заменить: ")
    if name in company_data:
        phone = input(f"Введите новый телефон для сотрудника {name}: ")
        email = input(f"Введите новый рабочий email для сотрудника {name}: ")
        position = input(f"Введите новую должность для сотрудника {name}: ")
        office_number = input(f"Введите новый номер кабинета для сотрудника {name}: ")
        skype = input(f"Введите новый Skype для сотрудника {name}: ")
        company_data[name] = {
            "Телефон": phone,
            "Email": email,
            "Должность": position,
            "Номер кабинета": office_number,
            "Skype": skype
        }
        print(f"Информация о сотруднике {name} обновлена.")
    else:
        print("Сотрудник не найден.")

while True:
    print("\nМеню:")
    print("1. Добавить информацию о сотруднике")
    print("2. Удалить информацию о сотруднике")
    print("3. Найти информацию о сотруднике")
    print("4. Заменить информацию о сотруднике")
    print("5. Выйти")
    
    choice = input("Выберите действие (1/2/3/4/5): ")
    
    if choice == "1":
        add_employee()
    elif choice == "2":
        remove_employee()
    elif choice == "3":
        search_employee()
    elif choice == "4":
        replace_employee()
    elif choice == "5":
        break
    else:
        print("Некорректный выбор. Пожалуйста, выберите действие из меню.")



#_________________________________________________________________________


book_collection = {}  # Создаем пустой словарь для хранения данных

# Функция для добавления информации о книге
def add_book():
    author = input("Введите имя автора книги: ")
    title = input("Введите название книги: ")
    genre = input("Введите жанр книги: ")
    year = input("Введите год выпуска книги: ")
    pages = input("Введите количество страниц в книге: ")
    publisher = input("Введите издательство книги: ")
    book_collection[title] = {
        "Автор": author,
        "Жанр": genre,
        "Год выпуска": year,
        "Количество страниц": pages,
        "Издательство": publisher
    }
    print(f"Информация о книге '{title}' добавлена.")

# Функция для удаления информации о книге
def remove_book():
    title = input("Введите название книги, информацию о которой хотите удалить: ")
    if title in book_collection:
        del book_collection[title]
        print(f"Информация о книге '{title}' удалена.")
    else:
        print("Книга не найдена.")

# Функция для поиска информации о книге
def search_book():
    title = input("Введите название книги, информацию о которой хотите найти: ")
    if title in book_collection:
        print(f"Информация о книге '{title}':")
        for key, value in book_collection[title].items():
            print(f"{key}: {value}")
    else:
        print("Книга не найдена.")

# Функция для замены информации о книге
def replace_book():
    title = input("Введите название книги, информацию о которой хотите заменить: ")
    if title in book_collection:
        author = input(f"Введите имя автора для книги '{title}': ")
        genre = input(f"Введите жанр для книги '{title}': ")
        year = input(f"Введите год выпуска для книги '{title}': ")
        pages = input(f"Введите количество страниц для книги '{title}': ")
        publisher = input(f"Введите издательство для книги '{title}': ")
        book_collection[title] = {
            "Автор": author,
            "Жанр": genre,
            "Год выпуска": year,
            "Количество страниц": pages,
            "Издательство": publisher
        }
        print(f"Информация о книге '{title}' обновлена.")
    else:
        print("Книга не найдена.")

while True:
    print("\nМеню:")
    print("1. Добавить информацию о книге")
    print("2. Удалить информацию о книге")
    print("3. Найти информацию о книге")
    print("4. Заменить информацию о книге")
    print("5. Выйти")
    
    choice = input("Выберите действие (1/2/3/4/5): ")
    
    if choice == "1":
        add_book()
    elif choice == "2":
        remove_book()
    elif choice == "3":
        search_book()
    elif choice == "4":
        replace_book()
    elif choice == "5":
        break
    else:
        print("Некорректный выбор. Пожалуйста, выберите действие из меню.")


#_________________________________________________________________________




