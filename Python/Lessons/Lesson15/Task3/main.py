class Animal:
    def __init__(self, name:str, years_old:int, type:str) -> None:
        self.name = name
        self.years_old = years_old
        self.type = type

    def introduce(self):
        return f"My name is {self.name}, i am {self.type}, {self.years_old} y.o"
    
class Tiger(Animal):
    def __init__(self, name: str, years_old: int) -> None:
        super().__init__(name, years_old, "Tiger")

    #introduce 
    
    def hunt(self):
        return f"{self.name} hunting"

class Crocodile(Animal):
    def __init__(self, name: str, years_old: int) -> None:
        super().__init__(name, years_old, "Crocodile",)
    
    def introduce(self):
        return super().introduce()
    
    def flies(self):
        return f"{self.name} flies"

if __name__ == "__main__":
    tiger = Tiger("TiranTiger228", 35)
    print(tiger.introduce())
    print(tiger.hunt())