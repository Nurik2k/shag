class Device:
    def __init__(self, brand, model):
        self.brand = brand
        self.model = model

    def turn_on(self):
        print(f"{self.brand} {self.model} is turned on.")

    def turn_off(self):
        print(f"{self.brand} {self.model} is turned off.")


class CoffeeMachine(Device):
    def __init__(self, brand, model, coffee_type):
        super().__init__(brand, model)
        self.coffee_type = coffee_type

    def make_coffee(self):
        print(f"{self.brand} {self.model} is making {self.coffee_type} coffee.")


class Blender(Device):
    def __init__(self, brand, model, power):
        super().__init__(brand, model)
        self.power = power

    def blend(self, ingredients):
        print(f"{self.brand} {self.model} is blending {', '.join(ingredients)}.")


class MeatGrinder(Device):
    def __init__(self, brand, model, motor_power):
        super().__init__(brand, model)
        self.motor_power = motor_power

    def grind_meat(self):
        print(f"{self.brand} {self.model} is grinding meat with {self.motor_power}W motor.")


# Пример использования классов:

coffee_machine = CoffeeMachine("BrandX", "CM100", "Espresso")
coffee_machine.turn_on()
coffee_machine.make_coffee()
coffee_machine.turn_off()

blender = Blender("BrandY", "BlenderPro", 750)
blender.turn_on()
blender.blend(["Banana", "Strawberry"])
blender.turn_off()

meat_grinder = MeatGrinder("BrandZ", "SuperGrind", 1200)
meat_grinder.turn_on()
meat_grinder.grind_meat()
meat_grinder.turn_off()

#________________________________________________________________________________________________
class Ship:
    def __init__(self, name, year):
        self.name = name
        self.year = year

    def sail(self):
        print(f"{self.name} is sailing.")

    def anchor(self):
        print(f"{self.name} dropped anchor.")


class Frigate(Ship):
    def __init__(self, name, year, missile_count):
        super().__init__(name, year)
        self.missile_count = missile_count

    def launch_missiles(self):
        print(f"{self.name} launched {self.missile_count} missiles.")


class Destroyer(Ship):
    def __init__(self, name, year, gun_caliber):
        super().__init__(name, year)
        self.gun_caliber = gun_caliber

    def fire_guns(self):
        print(f"{self.name} fired guns with {self.gun_caliber} caliber.")


class Cruiser(Ship):
    def __init__(self, name, year, missile_system):
        super().__init__(name, year)
        self.missile_system = missile_system

    def deploy_missile_system(self):
        print(f"{self.name} deployed {self.missile_system} missile system.")


# Пример использования классов:

frigate = Frigate("FrigateA", 2005, 16)
frigate.sail()
frigate.launch_missiles()
frigate.anchor()

destroyer = Destroyer("DestroyerB", 2010, 127)
destroyer.sail()
destroyer.fire_guns()
destroyer.anchor()

cruiser = Cruiser("CruiserC", 2018, "Aegis")
cruiser.sail()
cruiser.deploy_missile_system()
cruiser.anchor()
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

money1 = Money(25, 50)
money2 = Money(10, 75)

money1.display()
money2.display()

result_add = money1.add(money2)
result_subtract = money1.subtract(money2)

result_add.display()
result_subtract.display()
