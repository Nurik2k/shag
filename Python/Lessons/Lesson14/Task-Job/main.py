class Employeer:
    def init(self, id: int, name: str, position: str) -> None:
        self.id = id
        self.name = name
        self.position = position
    
    def print(self):
        print(self.id + ": " + self.name + " - " + self.position)

class Manager(Employeer):
    def init(self, id: int, name: str, position: str) -> None:
        super().init(id, name, position)
    
    def print(self):
        return super().print()

class Worker(Employeer):
    def init(self, id: int, name: str, position: str) -> None:
        super().init(id, name, position)
    
    def print(self):
        return super().print()
    
class President(Employeer):
    def init(self, id: int, name: str, position: str) -> None:
        super().init(id, name, position)
    
    def print(self):
        return super().print()
    
if __name__ == "__main__":
    Employeer.init( 1, "Jenna", "pos")