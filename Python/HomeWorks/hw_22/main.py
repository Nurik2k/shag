# Создаем пустой список для хранения чисел
number_list = []

while True:
    print("Меню:")
    print("1. Добавить число в список")
    print("2. Удалить все вхождения числа из списка")
    print("3. Показать содержимое списка (с начала или с конца)")
    print("4. Проверить есть ли значение в списке")
    print("5. Заменить значение в списке")
    print("6. Выйти")

    choice = input("Выберите действие (1/2/3/4/5/6): ")

    if choice == "1":
        num = int(input("Введите число для добавления: "))
        if num not in number_list:
            number_list.append(num)
        else:
            print(f"Число {num} уже существует в списке.")

    elif choice == "2":
        num = int(input("Введите число для удаления: "))
        number_list = [x for x in number_list if x != num]

    elif choice == "3":
        direction = input("Показать с начала или с конца? (начало/конец): ")
        if direction == "начало":
            print(number_list)
        elif direction == "конец":
            print(number_list[::-1])

    elif choice == "4":
        num = int(input("Введите число для проверки: "))
        if num in number_list:
            print(f"Число {num} есть в списке.")
        else:
            print(f"Числа {num} нет в списке.")

    elif choice == "5":
        num = int(input("Введите число для замены: "))
        new_num = int(input("Введите новое число: "))
        replace_all = input("Заменить все вхождения? (да/нет): ")
        if replace_all == "да":
            number_list = [new_num if x == num else x for x in number_list]
        else:
            for i in range(len(number_list)):
                if number_list[i] == num:
                    number_list[i] = new_num

    elif choice == "6":
        break
#_________________________________________________________________________________________________
class DynamicStack:
    def __init__(self):
        self.stack = []

    def push(self, value):
        self.stack.append(value)

    def pop(self):
        if not self.is_empty():
            return self.stack.pop()
        else:
            print("Стек пуст. Невозможно извлечь элемент.")
            return None

    def count(self):
        return len(self.stack)

    def is_empty(self):
        return len(self.stack) == 0

    def clear(self):
        self.stack = []

    def peek(self):
        if not self.is_empty():
            return self.stack[-1]
        else:
            print("Стек пуст. Невозможно получить элемент.")
            return None

# Пример использования
stack = DynamicStack()

while True:
    print("Меню:")
    print("1. Добавить строку в стек")
    print("2. Вытолкнуть строку из стека")
    print("3. Количество строк в стеке")
    print("4. Проверить пустой ли стек")
    print("5. Очистить стек")
    print("6. Получить значение без выталкивания")
    print("7. Выйти")

    choice = input("Выберите действие (1/2/3/4/5/6/7): ")

    if choice == "1":
        value = input("Введите строку для добавления в стек: ")
        stack.push(value)

    elif choice == "2":
        popped_value = stack.pop()
        if popped_value is not None:
            print(f"Извлечено: {popped_value}")

    elif choice == "3":
        print(f"Количество строк в стеке: {stack.count()}")

    elif choice == "4":
        if stack.is_empty():
            print("Стек пуст.")
        else:
            print("Стек не пуст.")

    elif choice == "5":
        stack.clear()
        print("Стек очищен.")

    elif choice == "6":
        peeked_value = stack.peek()
        if peeked_value is not None:
            print(f"Верхняя строка в стеке: {peeked_value}")

    elif choice == "7":
        break

       



#_________________________________________________________________________________________________
