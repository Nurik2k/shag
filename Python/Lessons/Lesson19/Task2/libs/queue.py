from collections import deque
from datetime import *

class Queue:

    def __init__(self) -> None:
        self.items = deque()
        self.length = 0

    def is_empty(self):
        if self.length <= 0 or self.length == None:
            self.length = 0
        return self.length == 0
    
    def insert_(self, data):
        self.length += 1
        self.items.append(data)


    def serve(self):
        self.length -= 1
        if self.length <= 0:
            return None
        self.items.pop()

    def add_top(self, cargo):
        self.length += 1
        self.items.append(cargo)

    def show_queue(self) -> str:
        return f"{self.items}"
    
    @staticmethod
    def send_to_employee(employee, self):
        for client in self.items:
            if client.navigate == employee.Id:
                employee.queue += 1
                client.id = employee.queue
                print(
                    f"{client.id}\
                        {client.navigate}\
                            {employee.queue}\
                            {employee.name}"
                )

    def client_time(self):
        self.items = [
            client
            for client in self.items
            if client.time + timedelta(seconds=self.time) >= datetime.now()
        ]