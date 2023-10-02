from TEXTEDITOR.recorder import *

def Menu() -> str:
    print("Меню:")
    print("1. Сохранить текст")
    print("2. Загрузить текст")
    print("3. Отменить последние действия")
    print("0. Выход")
    return input()

if __name__ == "__main__":
    
    editor = Recorder()

    while True:
        ch = Menu()
        print(f"Текущий текст: {editor.text}")


        if ch == "3":
            editor.undo()
        elif ch == "1":
            editor.save(input("Введите имя файла: "))
        elif ch == "2":
            editor.load(input("Введите имя файла: "))
        elif ch == "0":
            break
        else:
            editor.append(ch)