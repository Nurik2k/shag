class DomesticAnimal:
    def __init__(self, name, breed):
        self.name = name
        self.breed = breed

    def show(self):
        return f"{self.name} ({self.breed})"

    def type(self):
        return "Домашнее животное"

    def sound(self):
        return "Звук не определен"


class Dog(DomesticAnimal):
    def sound(self):
        return "Гав"


class Cat(DomesticAnimal):
    def sound(self):
        return "Мяу"


class Parrot(DomesticAnimal):
    def sound(self):
        return "Попугайчик говорит"


class Hamster(DomesticAnimal):
    def sound(self):
        return "Хрю"


# Пример использования

animals = [
    Dog("Рекс", "Далматин"),
    Cat("Барсик", "Персидская"),
    Parrot("Кеша", "Ара"),
    Hamster("Чарли", "Сирийский")
]

for animal in animals:
    print(f"{animal.show()} - {animal.type()}: {animal.sound()}")
