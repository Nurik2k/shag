class Record:
    def __init__(self, data):
        self.data = data

    def __str__(self) -> str:
        return '|'.join(self.data)
    
    @classmethod
    def from_string(cls, string:str) -> 'Record':
        data = string.split('|')
        return cls(data)
