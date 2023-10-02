from .text_editor import *

class Recorder(TextEditor):
    def __init__(self, *args) -> None:
        super().__init__(*args)

    def undo(self):
        return super().undo()
    
    def append(self, item):
        return super().append(item)
    
    def save(self, filename):
        f = open(f"{filename}.txt", "w")
        for item in self.text:
            f.write(item)

    def load(self, filename):
        f = open(f"{filename}.txt","r")
        r = f.read()
        print(r)
