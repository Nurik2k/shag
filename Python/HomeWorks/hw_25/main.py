import pandas as pd
import os
import argparse

class ToDoList:
    def __init__(self, filename):
        self.filename = filename
        self.tasks = pd.DataFrame(columns=["Task", "Status"])

    def load_tasks(self):
        if os.path.exists(self.filename):
            try:
                self.tasks = pd.read_excel(self.filename)
            except Exception as e:
                print(f"Error occurred while loading tasks: {e}")

    def save_tasks(self):
        try:
            self.tasks.to_excel(self.filename, index=False)
        except Exception as e:
            print(f"Error occurred while saving tasks: {e}")

    def add_task(self, task):
        self.tasks = self.tasks.append({"Task": task, "Status": "Not Done"}, ignore_index=True)
        self.save_tasks()

    def mark_as_done(self, task_index):
        if task_index < len(self.tasks):
            self.tasks.at[task_index, "Status"] = "Done"
            self.save_tasks()
        else:
            print("Invalid task index")

    def display_tasks(self):
        print(self.tasks)

def main():
    parser = argparse.ArgumentParser(description='ToDoList with Excel Saving')
    parser.add_argument('file', help='Excel file to load or create')
    args = parser.parse_args()

    todo_list = ToDoList(args.file)
    todo_list.load_tasks()

    while True:
        print("\nMenu:")
        print("1. Add Task")
        print("2. Mark Task as Done")
        print("3. Display Tasks")
        print("4. Exit")

        choice = input("Enter your choice: ")

        if choice == "1":
            task = input("Enter the task: ")
            todo_list.add_task(task)
        elif choice == "2":
            task_index = int(input("Enter the task index to mark as done: "))
            todo_list.mark_as_done(task_index)
        elif choice == "3":
            todo_list.display_tasks()
        elif choice == "4":
            break
        else:
            print("Invalid choice. Please enter a valid option.")

if __name__ == "__main__":
    main()
