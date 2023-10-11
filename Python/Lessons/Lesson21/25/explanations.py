import os 
from pathlib import Path 
import pandas as pd 
 
class ToDoList: 
    def __init__(self, filename): 
        directory_folder = os.path.dirname(os.path.abspath(__file__)) 
        filename = directory_folder + "/" + filename 
 
     # Проверка наличия файла для хранения ID и его загрузка 
        self.id_filename = "task_id.txt" 
        if os.path.exists(self.id_filename): 
            with open(self.id_filename, "r") as id_file: 
                self.task_id = int(id_file.read()) 
        else: 
            self.task_id = 1 
 
 
        # self.task_id = 1 
 
        if not os.path.exists(filename): 
            Path(filename).touch() 
            self.filename = filename 
            self.tasks = pd.DataFrame(columns=["Дата", "Задача"]) 
            self.save_tasks() 
 
        self.filename = filename 
        self.tasks = pd.DataFrame(columns=["Дата", "Задача"]) 
        self.load_tasks() 
 
    def load_tasks(self): 
        if os.path.exists(self.filename): 
            self.tasks = pd.read_excel(self.filename, header=0) 
 
    def save_tasks(self): 
        self.tasks.to_excel(self.filename, index=False) 
 
 
    def add_task(self, task): 
        date = input("Введите дату для задачи (в формате 'YYYY-MM-DD'): ") 
        new_task = pd.DataFrame({"ID": [self.task_id], "Дата": [pd.to_datetime(date)], "Задача": [task]}) 
        self.tasks = pd.concat([self.tasks, new_task], ignore_index=True) 
        self.save_tasks() 
        print(f"Задача '{task}' на {date} добавлена с ID: {self.task_id}") 
 
        # Увеличение значения ID и его сохранение 
        self.task_id += 1 
        with open(self.id_filename, "w") as id_file: 
            id_file.write(str(self.task_id))
            
    def view_tasks(self): 
        print("Список всех задач:") 
        print(self.tasks["Задача"].tolist()) 
 
    def remove_task(self, task): 
        if task in self.tasks["Задача"].values: 
            self.tasks = self.tasks[self.tasks["Задача"] != task].reset_index(drop=True) 
            self.save_tasks() 
            return True 
        else: 
            return False 
 
    def clear_list(self): 
        self.tasks = pd.DataFrame(columns=["Дата", "Задача"]) 
        self.save_tasks() 
        print("Список задач очищен.") 
 
    def view_day(self, day): 
        day_tasks = self.tasks.loc[self.tasks["Дата"].dt.strftime("%Y-%m-%d") == day] 
        if not day_tasks.empty: 
            print(f"Список задач на {day}:") 
            print(day_tasks["Задача"].tolist()) 
        else: 
            print(f"На {day} задачи отсутствуют.") 
 
    def search_tasks(self, keyword): 
        result = self.tasks[self.tasks["Задача"].str.contains(keyword, case=False, na=False)] 
        if not result.empty: 
            print("Найденные задачи:") 
            print(result["Задача"].tolist()) 
        else: 
            print("Задачи с указанным ключевым словом не найдены.") 
 
    def show_menu(self): 
        print("Меню Списка задач:") 
        print("1. Добавить задачу") 
        print("2. Просмотреть все задачи") 
        print("3. Удалить задачу") 
        print("4. Очистить список задач") 
        print("5. Просмотр задач на день") 
        print("6. Поиск задач") 
        print("0. Выход") 
 
    def run(self): 
        while True: 
            self.show_menu() 
            choice = input("Выберите действие: ") 
 
            if choice == "1": 
                task = input("Введите задачу: ") 
                self.add_task(task) 
                print(f"Задача '{task}' добавлена.") 
            elif choice == "2": 
                self.view_tasks() 
            elif choice == "3": 
                task = input("Введите задачу для удаления: ") 
                if self.remove_task(task): 
                    print(f"Задача '{task}' удалена.") 
                else: 
                    print(f"Задача '{task}' не найдена.") 
            elif choice == "4": 
                self.clear_list() 
            elif choice == "5": 
                day = input("Введите дату (в формате 'YYYY-MM-DD'): ") 
                self.view_day(day) 
            elif choice == "6": 
                keyword = input("Введите ключевое слово для поиска: ") 
                self.search_tasks(keyword) 
            elif choice == "0": 
                print("До свидания!") 
                break 
            else: 
                print("Неверный выбор. Попробуйте еще раз.") 
 
if name == "__main__": 
    my_todo = ToDoList("tasks.xlsx") 
    my_todo.run()