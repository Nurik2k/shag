import math

# Массив строк меню
menu = [
    ["Select an operation:"],
    ["1. Addition"],
    ["2. Substraction"],
    ["3. Multiplication"],
    ["4. Division"],
    ["5. Power"],
    ["6. Square root"], 
    ["7. Logarithm"],
    ["8. Factorial"],
    ["0. Exit"]
]


def Addition():
    num1 = int(input("Enter num1: "))
    num2 = int(input("Enter num2: "))
    print("Result: ", num1 + num2, "\n")
    Menu()

def Substraction():
    num1 = int(input("Enter num1: "))
    num2 = int(input("Enter num2: "))
    print("Result: ", num1 - num2, "\n")
    Menu()

def Multiplication():
    num1 = int(input("Enter num1: "))
    num2 = int(input("Enter num2: "))
    print("Result: ", num1 * num2, "\n")
    Menu()

def Division():
    num1 = int(input("Enter num1: "))
    num2 = int(input("Enter num2: "))
    try:
        result = num1 / num2
    except ZeroDivisionError:
        print("Ошибка деления на ноль!")
    except Exception as e:
        print("Произошла ошибка: ", str(e))
    else:
        print("Результат: ", result, "\n")
    finally:
        Menu()

def Power():
    num1 = int(input("Enter num1: "))
    num2 = int(input("Enter num2: "))
    print("Result: ", math.pow(num1, num2), "\n")
    Menu()

def SquareRoot():
    num1 = int(input("Enter num1: "))
    num2 = int(input("Enter num2: "))
    print("Result: ", math.sqrt(num1, num2), "\n")
    Menu()

def Logarithm():
    num1 = int(input("Enter num1: "))
    num2 = int(input("Enter num2: "))
    print("Result: ", math.log(num1, num2), "\n")
    Menu()

def Factorial():
    num1 = int(input("Enter num1: "))
    num2 = int(input("Enter num2: "))
    print("Result: ", math.factorial(num1, num2), "\n")
    Menu()

def Menu():
    for i in menu:
        for j in i:
            print(j)

    num = int(input("Enter number 1-8: "))
    if num <= 8:
        if  num == 1:
            Addition()
            
        elif num == 2:
            Substraction()
        
        elif num == 3:
            Multiplication()

        elif num == 4:
            Division()

        elif num == 5:
            Power()

        elif num == 6:
            SquareRoot()

        elif num == 7:
            Logarithm()

        elif num == 8:
            Factorial()

        elif num == 0: 
            print("Выход!")
    else:
        print("Нет такой команды!")
        Menu()

if __name__ == "__main__":
    Menu()