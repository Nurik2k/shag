if __name__ == "__main__":
    competent = True
    responsible = True
    print(competent and responsible)

    competent = True
    responsible = False
    print(competent and responsible)

    competent = True
    responsible = False
    print(competent or responsible)

    competent = False
    responsible = False
    print(competent or responsible)

    previosly_fired = True
    print(not previosly_fired)

    previosly_fired = False
    print(not previosly_fired)

    time = int(input("Enter the current time in hourseL "))% 24
    ticket = False
    money = True
    luggage = False
    print(money or ticket and not luggage and time > 6)
    print((money or ticket) and not luggage and time > 6) 