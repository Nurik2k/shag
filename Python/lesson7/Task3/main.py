def drow_line(length, direction, symbol):
    
    if direction == "H":
        for i in range(length):
            print(symbol)

    elif direction == "V":
        for i in range(length):
            print(symbol,"\n")
            


if "__main__" == __name__:
    length = int(input("Legth: "))
    direction = input("Direction: ")
    symbol = input("Symbol: ")
    
    drow_line(length, direction, symbol)