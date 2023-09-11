import json

# Инициализация списка сотрудников
employees = []

# Функция для добавления данных о сотруднике
def add_employee():
    name = input("Введите ФИО сотрудника: ")
    age = int(input("Введите возраст сотрудника: "))
    position = input("Введите должность сотрудника: ")
    employee = {"ФИО": name, "Возраст": age, "Должность": position}
    employees.append(employee)
    print(f"Сотрудник {name} добавлен.")

# Функция для редактирования данных о сотруднике
def edit_employee():
    name = input("Введите ФИО сотрудника, данные которого хотите отредактировать: ")
    for employee in employees:
        if employee["ФИО"] == name:
            age = int(input("Введите новый возраст сотрудника: "))
            position = input("Введите новую должность сотрудника: ")
            employee["Возраст"] = age
            employee["Должность"] = position
            print(f"Данные о сотруднике {name} обновлены.")
            return
    print("Сотрудник не найден.")

# Функция для удаления сотрудника
def remove_employee():
    name = input("Введите ФИО сотрудника, которого хотите удалить: ")
    for employee in employees:
        if employee["ФИО"] == name:
            employees.remove(employee)
            print(f"Сотрудник {name} удален.")
            return
    print("Сотрудник не найден.")

# Функция для поиска сотрудника по фамилии
def find_employee_by_lastname():
    lastname = input("Введите фамилию сотрудника: ")
    found_employees = [employee for employee in employees if employee["ФИО"].split()[-1].startswith(lastname)]
    if found_employees:
        print("Найденные сотрудники:")
        for employee in found_employees:
            print(f"ФИО: {employee['ФИО']}, Возраст: {employee['Возраст']}, Должность: {employee['Должность']}")
    else:
        print("Сотрудники с указанной фамилией не найдены.")

# Функция для поиска сотрудников по возрасту
def find_employees_by_age():
    age = int(input("Введите возраст сотрудников: "))
    found_employees = [employee for employee in employees if employee["Возраст"] == age]
    if found_employees:
        print("Найденные сотрудники:")
        for employee in found_employees:
            print(f"ФИО: {employee['ФИО']}, Возраст: {employee['Возраст']}, Должность: {employee['Должность']}")
    else:
        print(f"Сотрудники с возрастом {age} не найдены.")

# Функция для сохранения списка сотрудников в файл
def save_to_file(filename):
    with open(filename, "w") as file:
        json.dump(employees, file)
    print("Список сотрудников сохранен в файл.")

# Загрузка списка сотрудников из файла
def load_from_file(filename):
    try:
        with open(filename, "r") as file:
            loaded_employees = json.load(file)
            employees.extend(loaded_employees)
        print("Список сотрудников загружен из файла.")
    except FileNotFoundError:
        print("Файл не найден. Создан новый список сотрудников.")

# Основной цикл программы
if __name__ == "__main__":
    filename = "employees.json"  # Имя файла для сохранения и загрузки данных

    load_from_file(filename)

    while True:
        print("\nМеню:")
        print("1. Добавить сотрудника")
        print("2. Редактировать данные сотрудника")
        print("3. Удалить сотрудника")
        print("4. Найти сотрудника по фамилии")
        print("5. Найти сотрудников по возрасту")
        print("6. Вывести информацию обо всех сотрудниках")
        print("7. Сохранить список сотрудников в файл")
        print("8. Выйти")

        choice = input("Выберите действие (1/2/3/4/5/6/7/8): ")

        if choice == "1":
            add_employee()
        elif choice == "2":
            edit_employee()
        elif choice == "3":
            remove_employee()
        elif choice == "4":
            find_employee_by_lastname()
        elif choice == "5":
            find_employees_by_age()
        elif choice == "6":
            print("Список сотрудников:")
            for employee in employees:
                print(f"ФИО: {employee['ФИО']}, Возраст: {employee['Возраст']}, Должность: {employee['Должность']}")
        elif choice == "7":
            save_to_file(filename)
        elif choice == "8":
            break
        else:
            print("Некорректный выбор. Пожалуйста, выберите действие из меню.")
