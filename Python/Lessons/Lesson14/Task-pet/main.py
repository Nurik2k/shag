class Animal:
    def __init__(self, show: str, type: str) -> None:
        self.Show = show
        self.Type = type

    def sound(self):
        pass
    def show(self):
        pass
    def type(self):
        pass


class Cat(Animal):
    def sound(self):
        print("Meow")
    def show(self):
        print(self.show)
    def type(self):
        print(self.type)

class Humster(Animal):
    def sound(self):
        print("pi-pi-pi")
    def show(self):
        print(self.show)
    def type(self):
        print(self.type)

class Dog(Animal):
    def sound(self):
        print("Gaf")
    def show(self):
        print(self.show)
    def type(self):
        print(self.type)

if __name__ == "__main__":
    cat = Animal.__init__(show="Snowy", type="Felis")
    cat.sound()