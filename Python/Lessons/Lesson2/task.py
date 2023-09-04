# number = int(input("Enter number: "))

# if number % 2 == 0:
#     print("This number Even: ", number)
# else:
#     print("This number Odd: ", number)
#_____________________________________________

# number = int(input("Enter number: "))

# if number % 7 == 0:
#     print("Number is multiple 7")
# else:
#     print("Number is not multiple 7")
#_____________________________________________

# number1 = int(input("Enter number1: "))
# number2 = int(input("Enter number2: "))

# max = max(number1, number2)
# print("Max: ", max)
#_____________________________________________

# number1 = int(input("Enter number1: "))
# number2 = int(input("Enter number2: "))

# min = max(number1, number2)
# print("Min: ", max)
#____________________________________________

# def calculate(a, operator, b):
#     match operator:
#         case '+':
#             result = a + b
#         case '-':
#             result = a - b
#         case '*':
#             result = a * b
#         case '/':
#             if b == 0:
#                 print("error")
#                 return
#             result = a / b
#         case '%':
#             if b == 0:
#                 print("error")
#                 return
#             result = (a + b)/2
#         case _:
#             print("Invalid operator")
#             return
#     print(result)


# expression = input().split()
# a = int(expression[0])
# operator = expression[1]
# b = int(expression[2])

# calculate(a, operator, b)
#_____________________________________________

# def week(number):
#     match number:
#         case 1:
#             print("Будний")
#         case 2:
#             print("Будний")
#         case 3:
#             print("Будний")
#         case 4:
#             print("Будний")
#         case 5:
#             print("Будний")
#         case 6:
#             print("Выходной")
#         case 7:
#             print("Выходной")

# number = int(input())
# week(number)
#____________________________________________

def display_board(board, start_position=None, end_position= None):
    print("     a b c d e f g h")
    print("_____________________")

    for i in range(8):
        print(i = 1, end='|')
        for j in range(8):
            if(j+i)%2 == 0:
                print("#"+ board[i][j], end=' ')
            else:
                print(board[i][j], end=' ')
        
        print("|" + str(i+1))
    print("_____________________")
    print("     a b c d e f g h")

