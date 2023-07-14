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

def Menu():
    for i in menu:
        for j in i:
            print(j)

    num = int(input())
    if num <= 8:
        match num:
            case 1:
                Addition()
            
            case 2:
                Substraction()
        
            case 3:
                Multiplication()

            case 4:
                Division()

            case 0: 
                print("Выход!")
    else:
        print("Нет такой команды!")

if __name__ == "__main__":
    Menu()