def Odd_numbers(num1, num2):
    for i in range(num1, num2):
        if i % 2 != 0:
            print(i)

    



if "__main__" == __name__:
    num1 = int(input("Enter number 1:"))
    num2 = int(input("Enter number 2:"))

    Odd_numbers(num1, num2)