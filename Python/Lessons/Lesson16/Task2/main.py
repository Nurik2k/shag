class LimitedNumber:
    def __init__(self, min_value, max_value) -> None:
        self.min_value = min_value
        self.max_value = max_value
        self._value = None
    
    def __get__(self, instance, owner):
        return self._value
    
    def __set__(self, intance, value):
        if not(self.min_value <= value <= self.max_value):
            raise ValueError(
                f"Значение должно быть диапазоне от {self.min_value} до {self.max_value}"
            )
        self._value = value

class Myclass:
    limited_value = LimitedNumber(0,100)

    def __init__(self, limited_value) -> None:
        self.limited_value = limited_value

if __name__ == "__main__":

    obj = Myclass(50)
    print(obj.limited_value)

    obj.limited_value = 120 