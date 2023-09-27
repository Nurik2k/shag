from typing import Any


class Database:
    __instance = None

    def __new__(cls, *args, **kwargs) -> object:
        if cls.__instance is None:
            cls.__instance = super().__new__(cls)
            cls.__instance.__initialized = False
        return cls.__instance

    def __init__(self, user, password, port) -> None:
        self.user = user
        self.password = password
        self.port = port
        self._initialized = True

    def __del__(self) -> None:
                Database._instance = None
    
    def __call__(self, *args: Any, **kwds: Any) -> Any:
          if self.__instance is not None:
                raise TypeError("This class is a singleton")
          
if __name__ == "__main__":
      db = Database("user1", "123450", 80)
      db2 = Database("user2", "5678", 3360)

      print(db, db2, sep="\n")
      print(db.user, db.password, db.port, sep="\n")
      print(db2.user, db2.password, db2.port, sep="\n")
        