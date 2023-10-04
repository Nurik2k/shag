from libs.queue import *
from libs.client import *
from libs.employee import *

if __name__ == "__main__":
    Employee("Arman", 1,1)
    Employee("Ne Arman", 2, 2)

    clients = [
    Client(1,1),
    Client(2,2),
    Client(3,1),
    Client(4,2),
    Client(5,1),
    Client(6,2),
    Client(7,1)
    ]

    q = Queue()
    for client in clients:
        q.insert_(client)
        
    while True:
        q.serve()
        print(q.show_queue())
        if q.is_empty():
            break
