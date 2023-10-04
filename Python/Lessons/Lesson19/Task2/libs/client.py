from datetime import *
from random import *
class Client:
    def __init__(self, id, navigate) -> None:
        self.id = id
        self.navigate = navigate
        self.time = datetime.now() + timedelta(seconds=randint(1,20))
