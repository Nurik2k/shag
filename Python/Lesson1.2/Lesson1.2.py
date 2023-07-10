
#num1 = float(input("Введите первое число: "))
#num2 = float(input("Введите второе число: "))
#num3 = float(input("Введите третье число: "))

#choice = input("Выберите операцию (+ для суммы, * для произведения): ")

#if choice == '+':
#    result = num1 + num2 + num3
#    print("Сумма трех чисел:", result)
#elif choice == '*':
#    result = num1 * num2 * num3
#    print("Произведение трех чисел:", result)
#else:
#    print("Некорректный выбор операции.")
#____________________________________________________________________

#num1 = float(input("Введите первое число: "))
#num2 = float(input("Введите второе число: "))
#num3 = float(input("Введите третье число: "))

#choice = input("Выберите операцию (max, min, avg): ")

#if choice == 'max':
#    result = max(num1, num2, num3)
#    print("Максимум из трех чисел:", result)
#elif choice == 'min':
#    result = min(num1, num2, num3)
#    print("Минимум из трех чисел:", result)
#elif choice == 'avg':
#    result = (num1 + num2 + num3) / 3
#    print("Среднее арифметическое трех чисел:", result)
#else:
#    print("Некорректный выбор операции.")
#_____________________________________________________________________

meters = float(input("Введите количество метров: "))

choice = input("Выберите единицу измерения (mi для миль, in для дюймов, yd для ярдов): ")

if choice == 'mi':
    miles = meters * 0.000621371
    print("Метры в милях:", miles)
elif choice == 'in':
    inches = meters * 39.3701
    print("Метры в дюймах:", inches)
elif choice == 'yd':
    yards = meters * 1.09361
    print("Метры в ярдах:", yards)
else:
    print("Некорректный выбор единицы измерения.")

