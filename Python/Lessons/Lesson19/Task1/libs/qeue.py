from collections import deque

class Queue:
    def __init__(self) -> None:
        self.items = deque()
        self.length = 0

    def is_empty(self):
        if self.length <= 0 or self.length == None:
            self.length = 0
        return self.length == 0
    
    def insert(self, cargo):
        self.length += 1
        self.items.append(cargo)

    def remove(self):
        self.length += 1
        if self.length <= 0:
            return None
        self.items.pop()

    def insert_top(self, cargo):
        self.length += 1
        self.items.append(cargo)