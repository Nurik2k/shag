# Создаем списки идентификационных кодов и телефонных номеров
codes = [101, 102, 103, 104, 105]
phone_numbers = ['555-101', '555-102', '555-103', '555-104', '555-105']

while True:
    print("\nМеню:")
    print("1. Отсортировать по идентификационным кодам")
    print("2. Отсортировать по номерам телефона")
    print("3. Вывести список пользователей")
    print("4. Выход")
    
    choice = input("Выберите действие (1/2/3/4): ")
    
    if choice == "1":
        sorted_data = sorted(zip(codes, phone_numbers), key=lambda x: x[0])
        print("Отсортированный список по идентификационным кодам:")
        for code, phone in sorted_data:
            print(f"Код: {code}, Телефон: {phone}")
    elif choice == "2":
        sorted_data = sorted(zip(codes, phone_numbers), key=lambda x: x[1])
        print("Отсортированный список по номерам телефона:")
        for code, phone in sorted_data:
            print(f"Код: {code}, Телефон: {phone}")
    elif choice == "3":
        print("Список пользователей:")
        for code, phone in zip(codes, phone_numbers):
            print(f"Код: {code}, Телефон: {phone}")
    elif choice == "4":
        break
    else:
        print("Некорректный выбор. Пожалуйста, выберите действие из меню.")
#_________________________________________________________________________

# Создаем списки названий книг и годов выпуска
book_titles = ['Книга 1', 'Книга 2', 'Книга 3', 'Книга 4', 'Книга 5']
release_years = [2000, 1995, 2010, 2005, 2021]

while True:
    print("\nМеню:")
    print("1. Отсортировать по названию книг")
    print("2. Отсортировать по годам выпуска")
    print("3. Вывести список книг")
    print("4. Выход")
    
    choice = input("Выберите действие (1/2/3/4): ")
    
    if choice == "1":
        sorted_data = sorted(zip(book_titles, release_years), key=lambda x: x[0])
        print("Отсортированный список по названию книг:")
        for title, year in sorted_data:
            print(f"Книга: {title}, Год выпуска: {year}")
    elif choice == "2":
        sorted_data = sorted(zip(book_titles, release_years), key=lambda x: x[1])
        print("Отсортированный список по годам выпуска:")
        for title, year in sorted_data:
            print(f"Книга: {title}, Год выпуска: {year}")
    elif choice == "3":
        print("Список книг:")
        for title, year in zip(book_titles, release_years):
            print(f"Книга: {title}, Год выпуска: {year}")
    elif choice == "4":
        break
    else:
        print("Некорректный выбор. Пожалуйста, выберите действие из меню.")
