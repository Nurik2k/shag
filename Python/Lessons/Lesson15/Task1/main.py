class Human:
    def __init__(self, name:str, job:str) -> None:
        self.name = name
        self.job = job

    def __str__(self) -> str:
        return f"{self.job} {self.name}"

class Builder(Human):
    def __init__(self, name: str, action: str) -> None:
        super().__init__(name, "Builder")
        self.action = action

    def __str__(self) -> str:
        return super().__str__()
    
    def building(self) -> str:
        return f"{self.job} {self.action}"
    
class Sailor(Human):
    def __init__(self, name: str, action: str) -> None:
        super().__init__(name, "Sailor")
        self.action = action

    def __str__(self) -> str:
        return super().__str__()
    
    def floats(self) -> str:
        return f"{self.job} {self.action}"
    
class Pilot(Human):
    def __init__(self, name: str, action: str) -> None:
        super().__init__(name, "Pilot")
        self.action = action

    def __str__(self) -> str:
        return super().__str__()
    
    def flies(self)-> str:
        return f"{self.job} {self.action}"
    
if __name__ == "__main__":
    pilot = Pilot("Nurzhan", "flies")
    print(pilot)
    print(pilot.flies())