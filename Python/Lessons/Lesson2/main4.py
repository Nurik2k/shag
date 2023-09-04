if __name__ == "__main__":
    first, second, third = (
        int(input("Enter the first number: ")),
        int(input("Enter the second number: ")),
        int(input("Enter the third number: "))
    )

    if first + second > third:
        print("The first number is greater than the second number")
    else:
        print("The second number is greater than the first number") 