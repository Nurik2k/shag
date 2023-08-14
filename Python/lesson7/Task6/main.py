def simple_number(a):
    if a == 1:
        return False
    for i in range(2, a - 1, 1):
        if a % i == 0:
            return False
    return True

if "__main__" == __name__:
    print(simple_number(19))