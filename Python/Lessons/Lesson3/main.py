def main():
    try:
        result = 10 / 0
    except ZeroDivisionError:
        print("Ошибка деления на ноль!")
    except Exception as e:
        print("Произошла ошибка: ", str(e))
    else:
        print("Результат: ", result)
    finally:
        print("Конец программы")

if __name__ == "__main__":
    main()