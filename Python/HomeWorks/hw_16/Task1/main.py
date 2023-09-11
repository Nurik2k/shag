class Shape:
    def area(self):
        pass

    def perimeter(self):
        pass

    def __str__(self):
        return "Фигура не определена"

    def __int__(self):
        return 0


class Square(Shape):
    def __init__(self, side_length):
        self.side_length = side_length

    def area(self):
        return self.side_length ** 2

    def perimeter(self):
        return 4 * self.side_length

    def __str__(self):
        return f"Квадрат со стороной {self.side_length}"

    def __int__(self):
        return self.area()


class Circle(Shape):
    def __init__(self, radius):
        self.radius = radius

    def area(self):
        return 3.14 * self.radius ** 2

    def perimeter(self):
        return 2 * 3.14 * self.radius

    def __str__(self):
        return f"Круг с радиусом {self.radius}"

    def __int__(self):
        return self.area()


class CircleInSquare:
    def __init__(self, square_side_length, circle_radius):
        self.square = Square(square_side_length)
        self.circle = Circle(circle_radius)

    def total_area(self):
        return self.square.area() + self.circle.area()

    def total_perimeter(self):
        return self.square.perimeter() + self.circle.perimeter()

    def __str__(self):
        return f"Фигура, состоящая из {str(self.square)} и {str(self.circle)}"


# Пример использования

circle_in_square = CircleInSquare(5, 2)
print(circle_in_square)
print("Площадь:", circle_in_square.total_area())
print("Периметр:", circle_in_square.total_perimeter())
