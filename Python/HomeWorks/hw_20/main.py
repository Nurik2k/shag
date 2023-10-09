import re

# Дескриптор для проверки имени
class NameDescriptor:
    def __get__(self, instance, owner):
        return instance._name

    def __set__(self, instance, value):
        if not value.isalpha():
            raise ValueError("Name must consist of letters only")
        instance._name = value

# Дескриптор для проверки возраста
class AgeDescriptor:
    def __get__(self, instance, owner):
        return instance._age

    def __set__(self, instance, value):
        if not isinstance(value, int) or value <= 0:
            raise ValueError("Age must be a positive integer")
        instance._age = value

# Дескриптор для проверки email
class EmailDescriptor:
    email_pattern = r'^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$'

    def __get__(self, instance, owner):
        return instance._email

    def __set__(self, instance, value):
        if not re.match(self.email_pattern, value):
            raise ValueError("Invalid email address")
        instance._email = value

# Класс User с использованием дескрипторов
class User:
    name = NameDescriptor()
    age = AgeDescriptor()
    email = EmailDescriptor()

    def __init__(self, name, age, email):
        self.name = name
        self.age = age
        self.email = email

# Класс Database для управления пользователями
class Database:
    def __init__(self):
        self.users = []
        self.next_id = 1

    def add_user(self, user):
        user.id = self.next_id
        self.users.append(user)
        self.next_id += 1

    def update_user(self, user_id, **kwargs):
        for user in self.users:
            if user.id == user_id:
                for key, value in kwargs.items():
                    setattr(user, key, value)
                return

    def delete_user(self, user_id):
        self.users = [user for user in self.users if user.id != user_id]

    def search_users_by_name(self, name):
        return [user for user in self.users if user.name == name]

    def search_users_by_age(self, age):
        return [user for user in self.users if user.age == age]

    def search_users_by_email(self, email):
        return [user for user in self.users if user.email == email]

# Пример использования
db = Database()
db.add_user(User(name="John Doe", age=30, email="john.doe@example.com"))
db.add_user(User(name="Jane Doe", age=25, email="jane.doe@example.com"))

db.update_user(1, age=31)

result_name = db.search_users_by_name("Jane Doe")
print(result_name)  # Выведет: [<User(name='Jane Doe', age=25, email='jane.doe@example.com')>]

result_age = db.search_users_by_age(30)
print(result_age)  # Выведет: [<User(name='John Doe', age=31, email='john.doe@example.com')>]

result_email = db.search_users_by_email("john.doe@example.com")
print(result_email)  # Выведет: [<User(name='John Doe', age=31, email='john.doe@example.com')>]

db.delete_user(2)
