def borders(a, b):
    sum = 0
    for i in range(a, b+1):
        
        sum += i
    print(sum)


if "__main__" == __name__:
    borders(10, 20)