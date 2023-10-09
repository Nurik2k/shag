# Класс Device, базовый класс для устройств
class Device:
    def __init__(self, brand, model):
        self.brand = brand
        self.model = model

    def turn_on(self):
        print(f"{self.brand} {self.model} is turned on")

    def turn_off(self):
        print(f"{self.brand} {self.model} is turned off")

# Класс CoffeeMachine, производный от Device
class CoffeeMachine(Device):
    def __init__(self, brand, model, coffee_type):
        super().__init__(brand, model)
        self.coffee_type = coffee_type

    def make_coffee(self):
        print(f"{self.brand} {self.model} is making {self.coffee_type} coffee")

# Класс Blender, производный от Device
class Blender(Device):
    def __init__(self, brand, model, speed):
        super().__init__(brand, model)
        self.speed = speed

    def blend(self):
        print(f"{self.brand} {self.model} is blending at speed {self.speed}")

# Класс MeatGrinder, производный от Device
class MeatGrinder(Device):
    def __init__(self, brand, model, motor_power):
        super().__init__(brand, model)
        self.motor_power = motor_power

    def grind_meat(self):
        print(f"{self.brand} {self.model} is grinding meat with {self.motor_power}W motor")

# Пример использования классов
coffee_machine = CoffeeMachine("BrandA", "ModelX", "Espresso")
blender = Blender("BrandB", "ModelY", 3)
meat_grinder = MeatGrinder("BrandC", "ModelZ", 800)

coffee_machine.turn_on()
coffee_machine.make_coffee()
coffee_machine.turn_off()

blender.turn_on()
blender.blend()
blender.turn_off()

meat_grinder.turn_on()
meat_grinder.grind_meat()
meat_grinder.turn_off()


#________________________________________________________________________________________________
# Класс Ship, базовый класс для кораблей
class Ship:
    def __init__(self, name, max_speed):
        self.name = name
        self.max_speed = max_speed

    def sail(self):
        print(f"{self.name} is sailing")

    def stop(self):
        print(f"{self.name} has stopped")

# Класс Frigate, производный от Ship
class Frigate(Ship):
    def __init__(self, name, max_speed, num_cannons):
        super().__init__(name, max_speed)
        self.num_cannons = num_cannons

    def fire_cannons(self):
        print(f"{self.name} fires {self.num_cannons} cannons")

# Класс Destroyer, производный от Ship
class Destroyer(Ship):
    def __init__(self, name, max_speed, missile_system):
        super().__init__(name, max_speed)
        self.missile_system = missile_system

    def launch_missiles(self):
        print(f"{self.name} launches missiles using {self.missile_system}")

# Класс Cruiser, производный от Ship
class Cruiser(Ship):
    def __init__(self, name, max_speed, num_missiles):
        super().__init__(name, max_speed)
        self.num_missiles = num_missiles

    def fire_missiles(self):
        print(f"{self.name} fires {self.num_missiles} missiles")

# Пример использования классов
frigate = Frigate("FrigateA", 30, 16)
destroyer = Destroyer("DestroyerB", 40, "Tomahawk")
cruiser = Cruiser("CruiserC", 35, 32)

frigate.sail()
frigate.fire_cannons()
frigate.stop()

destroyer.sail()
destroyer.launch_missiles()
destroyer.stop()

cruiser.sail()
cruiser.fire_missiles()
cruiser.stop()

#________________________________________________________________________________________________
class Money:
    def __init__(self, dollars, cents):
        self.dollars = dollars
        self.cents = cents

    def display(self):
        print(f"${self.dollars}.{self.cents:02}")

    def add(self, other):
        total_cents = self.cents + other.cents
        total_dollars = self.dollars + other.dollars + total_cents // 100
        remaining_cents = total_cents % 100
        return Money(total_dollars, remaining_cents)

    def subtract(self, other):
        total_cents = self.cents - other.cents
        total_dollars = self.dollars - other.dollars + total_cents // 100
        remaining_cents = total_cents % 100
        return Money(total_dollars, remaining_cents)


# Пример использования класса Money:

class Money:
    def __init__(self, dollars, cents):
        self.dollars = dollars
        self.cents = cents

    def display(self):
        print(f"${self.dollars}.{self.cents:02}")

    def set_amount(self, dollars, cents):
        self.dollars = dollars
        self.cents = cents

# Пример использования класса Money
money = Money(50, 25)
money.display()  # Выводит "$50.25"

money.set_amount(75, 50)
money.display()  # Выводит "$75.50"
