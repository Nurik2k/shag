from collections import deque

class ShopQueue:
    def __init__(self) -> None:
        self.items = deque()
        self.length = 0

    def is_empty(self):
        if self.length <= 0 or self.length == None:
            self.length = 0
        return self.length == 0
    
    def add_customer(self, cargo):
        self.length += 1
        self.items.append(cargo)

    def serve_customer(self):
        self.length -= 1
        if self.length <= 0:
            return None
        self.items.pop()

    def add_top(self, cargo):
        self.length += 1
        self.items.append(cargo)

    def show_queue(self) -> str:
        return f"{self.items}"