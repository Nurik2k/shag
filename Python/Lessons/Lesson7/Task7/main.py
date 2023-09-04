def lucky_numbers(a):
    if len(a) != 6:
        print("error")
    else:
        if int(a[0]) + int(a[1]) + int(a[2]) != int(a[3]) + int(a[4]) + int(a[5]):
            print("Loser")
        else:
            print("Lucky")

if "__main__" == __name__:
    lucky_numbers("123420")