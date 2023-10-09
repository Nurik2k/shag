import math

class Circle:
    def __init__(self, radius):
        self.radius = radius

    def __eq__(self, other):
        return self.radius == other.radius

    def __gt__(self, other):
        return self.radius > other.radius

    def __lt__(self, other):
        return self.radius < other.radius

    def __le__(self, other):
        return self.radius <= other.radius

    def __ge__(self, other):
        return self.radius >= other.radius

    def __add__(self, other):
        return Circle(self.radius + other.radius)

    def __sub__(self, other):
        return Circle(self.radius - other.radius)

    def __iadd__(self, other):
        self.radius += other.radius
        return self

    def __isub__(self, other):
        self.radius -= other.radius
        return self

    def __str__(self):
        return f"Circle with radius {self.radius}"

# Пример использования
circle1 = Circle(5)
circle2 = Circle(3)

print(circle1 == circle2)  # Проверка на равенство радиусов (False)
print(circle1 > circle2)   # Сравнение длин (True)
print(circle1 + circle2)   # Пропорциональное изменение размеров (Circle with radius 8)
#_________________________________________________________________________________________________

class Complex:
    def __init__(self, real, imag):
        self.real = real
        self.imag = imag

    def __add__(self, other):
        return Complex(self.real + other.real, self.imag + other.imag)

    def __sub__(self, other):
        return Complex(self.real - other.real, self.imag - other.imag)

    def __mul__(self, other):
        return Complex(self.real * other.real - self.imag * other.imag,
                       self.real * other.imag + self.imag * other.real)

    def __truediv__(self, other):
        denominator = other.real**2 + other.imag**2
        real_part = (self.real * other.real + self.imag * other.imag) / denominator
        imag_part = (self.imag * other.real - self.real * other.imag) / denominator
        return Complex(real_part, imag_part)

    def __str__(self):
        return f"{self.real} + {self.imag}i"

# Пример использования
complex1 = Complex(1, 2)
complex2 = Complex(3, 4)

sum_result = complex1 + complex2
difference_result = complex1 - complex2
product_result = complex1 * complex2
division_result = complex1 / complex2

print(sum_result)       # Вывод: 4 + 6i
print(difference_result)  # Вывод: -2 - 2i
print(product_result)    # Вывод: -5 + 10i
print(division_result)   # Вывод: 0.44 + 0.08i


#_________________________________________________________________________________________________


class Airplane:
    def __init__(self, model, max_passengers):
        self.model = model
        self.max_passengers = max_passengers
        self.passengers = 0

    def __eq__(self, other):
        return self.model == other.model

    def __add__(self, value):
        self.passengers += value
        return self

    def __sub__(self, value):
        self.passengers -= value
        if self.passengers < 0:
            self.passengers = 0
        return self

    def __iadd__(self, value):
        self.passengers += value
        return self

    def __isub__(self, value):
        self.passengers -= value
        if self.passengers < 0:
            self.passengers = 0
        return self

    def __lt__(self, other):
        return self.max_passengers < other.max_passengers

    def __le__(self, other):
        return self.max_passengers <= other.max_passengers

    def __gt__(self, other):
        return self.max_passengers > other.max_passengers

    def __ge__(self, other):
        return self.max_passengers >= other.max_passengers

    def __str__(self):
        return f"{self.model} ({self.passengers}/{self.max_passengers} passengers)"

# Пример использования
plane1 = Airplane("Boeing 747", 400)
plane2 = Airplane("Airbus A380", 600)

print(plane1 == plane2)  # Проверка на равенство типов самолетов (False)
plane1 += 200
plane2 -= 100
print(plane1 < plane2)   # Сравнение по максимальному количеству пассажиров (True)


#_________________________________________________________________________________________________

class Flat:
    def __init__(self, area, price):
        self.area = area
        self.price = price

    def __eq__(self, other):
        return self.area == other.area

    def __ne__(self, other):
        return self.area != other.area

    def __lt__(self, other):
        return self.price < other.price

    def __le__(self, other):
        return self.price <= other.price

    def __gt__(self, other):
        return self.price > other.price

    def __ge__(self, other):
        return self.price >= other.price

    def __str__(self):
        return f"Flat with area {self.area} sq.m priced at ${self.price}"

# Пример использования
flat1 = Flat(80, 100000)
flat2 = Flat(75, 95000)
flat3 = Flat(80, 105000)

print(flat1 == flat2)  # Проверка на равенство площадей (False)
print(flat1 != flat3)  # Проверка на неравенство площадей (True)
print(flat2 < flat1)   # Сравнение по цене (True)



#_________________________________________________________________________________________________
