from typing import Any

class ListManipulator:
    def __init__(self, my_list: list):
        self._my_list = my_list

    def get_length(self) -> int:
        return len(self._my_list)

    def add_element(self, element: Any) -> None:
        self._my_list.append(element)

    def remove_element(self, element: Any) -> None:
        try:
            self._my_list.remove(element)
        except ValueError:
            raise ValueError(f"{element} not found in the list")

    def get_element_at_index(self, index: int) -> Any:
        try:
            return self._my_list[index]
        except IndexError:
            raise IndexError("Index out of range")

    @staticmethod
    def merge_lists(list1: list, list2: list) -> list:
        return list1 + list2

# Пример использования класса ListManipulator:

my_list = [1, 2, 3, 4, 5]
list_manager = ListManipulator(my_list)

print("Initial List:", my_list)
print("Length of List:", list_manager.get_length())

list_manager.add_element(6)
print("List after adding 6:", my_list)

list_manager.remove_element(3)
print("List after removing 3:", my_list)

element_at_index = list_manager.get_element_at_index(2)
print("Element at index 2:", element_at_index)

list1 = [1, 2, 3]
list2 = [4, 5, 6]
merged_list = ListManipulator.merge_lists(list1, list2)
print("Merged List:", merged_list)
#________________________________________________________________________________________________

class FileManager:
    def __init__(self, file_name: str):
        self._file_name = file_name

    def read_file(self) -> str:
        try:
            with open(self._file_name, 'r') as file:
                return file.read()
        except FileNotFoundError:
            return "File not found"

    def write_to_file(self, content: str) -> None:
        with open(self._file_name, 'w') as file:
            file.write(content)

# Пример использования класса FileManager:

file_manager = FileManager("sample.txt")
file_content = file_manager.read_file()
print("File Content:")
print(file_content)

new_content = "This is the new content."
file_manager.write_to_file(new_content)
updated_content = file_manager.read_file()
print("Updated File Content:")
print(updated_content)

#________________________________________________________________________________________________

from datetime import datetime, timedelta

class DateTimeManager:
    def __init__(self):
        self.current_datetime = datetime.now()

    def add_days(self, days: int) -> None:
        self.current_datetime += timedelta(days=days)

    def subtract_days(self, days: int) -> None:
        self.current_datetime -= timedelta(days=days)

    def format_date(self, format_string: str) -> str:
        return self.current_datetime.strftime(format_string)

# Пример использования класса DateTimeManager:

date_manager = DateTimeManager()

print("Current Date and Time:", date_manager.current_datetime)
date_manager.add_days(7)
print("Date after adding 7 days:", date_manager.current_datetime)
date_manager.subtract_days(3)
print("Date after subtracting 3 days:", date_manager.current_datetime)

formatted_date = date_manager.format_date("%Y-%m-%d %H:%M:%S")
print("Formatted Date:", formatted_date)
