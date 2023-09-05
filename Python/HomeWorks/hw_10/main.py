def custom_sort(lst):
    if len(lst) == 0:
        return lst

    average = sum(lst) / len(lst)
    if average > 0:
        # Сортировка первых двух третей по возрастанию
        first_two_thirds = sorted(lst[:2 * len(lst) // 3])
        # Расположение оставшейся части в обратном порядке
        rest = lst[2 * len(lst) // 3:][::-1]
        return first_two_thirds + rest
    else:
        # Сортировка только первой трети по возрастанию
        first_third = sorted(lst[:len(lst) // 3])
        # Расположение оставшихся двух третей в обратном порядке
        rest = lst[len(lst) // 3:][::-1]
        return first_third + rest

# Пример использования
my_list = [3, -2, 5, 1, -4, 2, 6, -1, 7, -3]
sorted_list = custom_sort(my_list)
print(sorted_list)
#_________________________________________________________________________

def calculate_average(grades):
    if len(grades) == 0:
        return 0
    return sum(grades) / len(grades)

grades = []

while True:
    print("\nМеню:")
    print("1. Вывести оценки")
    print("2. Пересдача экзамена")
    print("3. Проверить стипендию")
    print("4. Вывести отсортированный список оценок")
    print("5. Выход")
    
    choice = input("Выберите действие (1/2/3/4/5): ")
    
    if choice == "1":
        print("Оценки студента:", grades)
    elif choice == "2":
        index = int(input("Введите номер оценки для пересдачи: ")) - 1
        if 0 <= index < len(grades):
            new_grade = int(input("Введите новую оценку: "))
            grades[index] = new_grade
            print("Оценка обновлена.")
        else:
            print("Некорректный номер оценки.")
    elif choice == "3":
        average = calculate_average(grades)
        if average >= 10.7:
            print("Студент имеет стипендию.")
        else:
            print("Студент не имеет стипендию.")
    elif choice == "4":
        ascending = input("Вывести оценки по возрастанию (да/нет): ").lower()
        if ascending == "да":
            sorted_grades = sorted(grades)
        else:
            sorted_grades = sorted(grades, reverse=True)
        print("Отсортированные оценки:", sorted_grades)
    elif choice == "5":
        break
    else:
        print("Некорректный выбор. Пожалуйста, выберите действие из меню.")
#_________________________________________________________________________

def bubble_sort_improved(lst):
    n = len(lst)
    swapped = True
    while swapped:
        swapped = False
        for i in range(1, n):
            if lst[i - 1] > lst[i]:
                lst[i - 1], lst[i] = lst[i], lst[i - 1]
                swapped = True
        n -= 1
    return lst

# Пример использования
my_list = [3, -2, 5, 1, -4, 2, 6, -1, 7, -3]
sorted_list = bubble_sort_improved(my_list)
print(sorted_list)
