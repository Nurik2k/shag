from libs.record import *

class Database:
    records = Record

    def __init__(self) -> None:
        self.records = []

    def __str__(self) -> str:
        return f"|{self.record.Name}|{self.record.Age}|{self.record.Sex}|"
    
