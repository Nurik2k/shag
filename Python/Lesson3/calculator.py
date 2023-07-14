
def calculate(a, operator, b):
    match operator:
        case '+':
            result = a + b
        case '-':
            result = a - b
        case '*':
            result = a * b
        case '/':
            result = a / b
        case _:
            print("Invalid operator")
            return
    print(result)


expression = input().split()
a = int(expression[0])
operator = expression[1]
b = int(expression[2])
calculate(a, operator, b)

