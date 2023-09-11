class Wheels:
    def __init__(self, num_wheels):
        self.num_wheels = num_wheels

    def rotate(self):
        print(f"{self.num_wheels} колеса вращаются")


class Engine:
    def __init__(self, engine_volume):
        self.engine_volume = engine_volume
        self.running = False

    def start(self):
        self.running = True
        print(f"Двигатель объемом {self.engine_volume} запущен")

    def stop(self):
        self.running = False
        print("Двигатель остановлен")


class Doors:
    def __init__(self, num_doors):
        self.num_doors = num_doors
        self.is_open = False

    def open(self):
        self.is_open = True
        print(f"{self.num_doors} двери открыты")

    def close(self):
        self.is_open = False
        print(f"{self.num_doors} двери закрыты")


class Car(Wheels, Engine, Doors):
    def __init__(self, num_wheels, engine_volume, num_doors):
        Wheels.__init__(self, num_wheels)
        Engine.__init__(self, engine_volume)
        Doors.__init__(self, num_doors)

    def drive(self):
        if not self.is_open:
            print("Автомобиль двигается")
        else:
            print("Невозможно двигаться, двери открыты")

    def is_running(self):
        return self.running

    def __str__(self):
        return f"Автомобиль с {self.num_wheels} колесами, объемом двигателя {self.engine_volume} и {self.num_doors} дверьми"


# Пример использования

my_car = Car(num_wheels=4, engine_volume=2.0, num_doors=4)
print(my_car)
my_car.start()
my_car.open()
my_car.drive()
my_car.close()
my_car.drive()
my_car.stop()
