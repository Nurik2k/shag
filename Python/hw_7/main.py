import random


def calculate_expression(expression):
    try:
        result = eval(expression)
        return result
    except:
        return "Ошибка при вычислении выражения."

user_expression = input("Введите арифметическое выражение: ")
result = calculate_expression(user_expression)
print("Результат:", result)

#___________________________________________________________

# Создание списка случайных чисел
num_list = [random.randint(-10, 10) for _ in range(20)]

# Инициализация счетчиков
positive_count = 0
negative_count = 0
zero_count = 0

# Поиск минимального и максимального элементов
min_num = min(num_list)
max_num = max(num_list)

# Подсчет количества положительных, отрицательных и нулевых элементов
for num in num_list:
    if num > 0:
        positive_count += 1
    elif num < 0:
        negative_count += 1
    else:
        zero_count += 1

# Вывод результатов
print("Список чисел:", num_list)
print("Минимальный элемент:", min_num)
print("Максимальный элемент:", max_num)
print("Количество положительных элементов:", positive_count)
print("Количество отрицательных элементов:", negative_count)
print("Количество нулей:", zero_count)
