def display_quote():
    quote = "Don't let the noise of others' opinions\n" \
            "drown out your own inner voice."
    author = "Steve Jobs"
    print(quote)
    print(author)

display_quote()
#______________________________________________________________________________________

def display_odd_numbers(start, end):
    for num in range(start, end + 1):
        if num % 2 != 0:
            print(num, end=" ")

start_num = int(input("Введите начальное число: "))
end_num = int(input("Введите конечное число: "))
display_odd_numbers(start_num, end_num)
#______________________________________________________________________________________

def display_line(length, direction, symbol):
    if direction == "horizontal":
        print(symbol * length)
    elif direction == "vertical":
        for _ in range(length):
            print(symbol)

length = int(input("Введите длину линии: "))
direction = input("Введите направление ('horizontal' или 'vertical'): ")
symbol = input("Введите символ: ")
display_line(length, direction, symbol)
#______________________________________________________________________________________

def max_of_four(a, b, c, d):
    return max(a, b, c, d)

num1 = int(input("Введите первое число: "))
num2 = int(input("Введите второе число: "))
num3 = int(input("Введите третье число: "))
num4 = int(input("Введите четвертое число: "))
result = max_of_four(num1, num2, num3, num4)
print("Максимальное число:", result)
#______________________________________________________________________________________

def sum_in_range(start, end):
    return sum(range(start, end + 1))

start_range = int(input("Введите начальное число диапазона: "))
end_range = int(input("Введите конечное число диапазона: "))
result_sum = sum_in_range(start_range, end_range)
print("Сумма чисел в диапазоне:", result_sum)
#______________________________________________________________________________________

def is_prime(number):
    if number <= 1:
        return False
    for i in range(2, int(number ** 0.5) + 1):
        if number % i == 0:
            return False
    return True

num_to_check = int(input("Введите число для проверки: "))
if is_prime(num_to_check):
    print("Число является простым.")
else:
    print("Число не является простым.")
#______________________________________________________________________________________

def is_happy_six_digit_number(number):
    digits = [int(digit) for digit in str(number)]
    if len(digits) != 6:
        return False
    first_half_sum = sum(digits[:3])
    second_half_sum = sum(digits[3:])
    return first_half_sum == second_half_sum

num_to_check = int(input("Введите шестизначное число для проверки: "))
if is_happy_six_digit_number(num_to_check):
    print("Число является счастливым шестизначным числом.")
else:
    print("Число не является счастливым шестизначным числом.")
