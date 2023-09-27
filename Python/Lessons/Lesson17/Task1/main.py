class Number:
    def __init__(self, num) -> None:
        self.num = num

    def __add__(self, other):
        if isinstance(self.num, str):
            return f"No"
        elif isinstance(self.num, chr):
            return f"No"
        return self.num + other.num

    def __sub__(self, other):
        if isinstance(self.num, str):
            return f"No"
        elif isinstance(self.num, chr):
            return f"No"
        return self.num - other.num
    
    def __mul__(self, other):
        if isinstance(self.num, str):
            return f"No"
        elif isinstance(self.num, chr):
            return f"No"
        return self.num * other.num
    
    def __truediv__(self, other):
        if isinstance(self.num, str):
            return f"No"
        elif isinstance(self.num, chr):
            return f"No"
        return self.num / other.num
    
if __name__ == "__main__":
    num1 = Number(5)
    num2 = Number(3)

    print(Number.__add__(num1, num2))
    print(Number.__sub__(num1, num2))
    print(Number.__mul__(num1, num2))
    print(Number.__truediv__(num1, num2))
