class Employer:
    def __init__(self, name, age, salary):
        self.name = name
        self.age = age
        self.salary = salary

    def __str__(self):
        return f"{self.name}, возраст: {self.age}, зарплата: {self.salary}"

    def __int__(self):
        return self.age


class President(Employer):
    def __init__(self, name, age, salary, country):
        super().__init__(name, age, salary)
        self.country = country

    def Print(self):
        print(f"Президент: {self.name}, возраст: {self.age}, зарплата: {self.salary}, страна: {self.country}")


class Manager(Employer):
    def __init__(self, name, age, salary, department):
        super().__init__(name, age, salary)
        self.department = department

    def Print(self):
        print(f"Менеджер: {self.name}, возраст: {self.age}, зарплата: {self.salary}, отдел: {self.department}")


class Worker(Employer):
    def __init__(self, name, age, salary, position):
        super().__init__(name, age, salary)
        self.position = position

    def Print(self):
        print(f"Рабочий: {self.name}, возраст: {self.age}, зарплата: {self.salary}, должность: {self.position}")


# Пример использования

president = President("Иван Иванович", 50, 1000000, "Россия")
manager = Manager("Петр Петрович", 35, 50000, "Отдел продаж")
worker = Worker("Анна Андреевна", 28, 30000, "Инженер")

print(president)
print(manager)
print(worker)

president.Print()
manager.Print()
worker.Print()
