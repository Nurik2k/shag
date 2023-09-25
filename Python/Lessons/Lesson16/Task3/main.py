class PositiveNumber:
    def __init__(self, number) -> None:
        self.number = number

    def __get__(self, intance, owner):
        return self.number
    
    def __set__(self, intance, number):
        if not (number >= 0):
            raise ValueError(
                f"Число не позитивное {number}"
            )
        self.number = number

    def __delete__(self, intance):
        raise ValueError(
            f"Числа нет"
        )

class MyClass:
    positiveNumber = PositiveNumber(0)

    def __init__(self, positiveNumber) -> None:
        self.positiveNumber = positiveNumber

if __name__ == "__main__":
    obj = MyClass(5)
    print(obj.positiveNumber)

    del obj.positiveNumber
    
