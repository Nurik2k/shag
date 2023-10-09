import pickle

class Shape:
    def __init__(self, x, y):
        self.x = x
        self.y = y

    def Show(self):
        pass

    def Save(self, filename):
        with open(filename, 'wb') as file:
            pickle.dump(self, file)

    @classmethod
    def Load(cls, filename):
        with open(filename, 'rb') as file:
            return pickle.load(file)

class Rectangle(Shape):
    def __init__(self, x, y, width, height):
        super().__init__(x, y)
        self.width = width
        self.height = height

    def Show(self):
        print(f"Rectangle: x={self.x}, y={self.y}, width={self.width}, height={self.height}")

class Circle(Shape):
    def __init__(self, x, y, radius):
        super().__init__(x, y)
        self.radius = radius

    def Show(self):
        print(f"Circle: x={self.x}, y={self.y}, radius={self.radius}")

class Ellipse(Shape):
    def __init__(self, x, y, width, height):
        super().__init__(x, y)
        self.width = width
        self.height = height

    def Show(self):
        print(f"Ellipse: x={self.x}, y={self.y}, width={self.width}, height={self.height}")

# Создаем список фигур
shapes = [Rectangle(0, 0, 5, 10), Circle(3, 3, 7), Ellipse(2, 2, 6, 4)]

# Сохраняем фигуры в файл
with open('shapes.dat', 'wb') as file:
    pickle.dump(shapes, file)

# Загружаем фигуры из файла
with open('shapes.dat', 'rb') as file:
    loaded_shapes = pickle.load(file)

# Отображаем информацию о каждой из фигур
for shape in loaded_shapes:
    shape.Show()
