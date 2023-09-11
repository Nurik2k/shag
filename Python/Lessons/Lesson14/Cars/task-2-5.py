class Wheels:
    """
    Класс, представляющий колеса автомобиля.
    """

    def __init__(self, num_wheels: int):
        """
        Инициализация колес.

        :param num_wheels: Количество колес.
        """
        self.num_wheels = num_wheels

    def rotate(self) -> None:
        """
        Вращает колеса.

        :return: None
        """
        print(f"{self.num_wheels} колеса вращаются")


class Engine:
    """
    Класс, представляющий двигатель автомобиля.
    """

    def __init__(self, volume: float):
        """
        Инициализация двигателя.

        :param volume: Объем двигателя в литрах.
        """
        self.volume = volume

    def start(self) -> None:
        """
        Запускает двигатель.

        :return: None
        """
        print(f"Двигатель объемом {self.volume} л запущен")

    def stop(self) -> None:
        """
        Останавливает двигатель.

        :return: None
        """
        print(f"Двигатель объемом {self.volume} л остановлен")


class Doors:
    """
    Класс, представляющий двери автомобиля.
    """

    def __init__(self, num_doors: int):
        """
        Инициализация дверей.

        :param num_doors: Количество дверей.
        """
        self.num_doors = num_doors
        self.is_open = False  # Добавим атрибут для отслеживания состояния дверей

    def open(self) -> None:
        """
        Открывает двери.

        :return: None
        """
        if not self.is_open:
            self.is_open = True
            print(f"{self.num_doors} двери открыты")
        else:
            print("Двери уже открыты")

    def close(self) -> None:
        """
        Закрывает двери.

        :return: None
        """
        if self.is_open:
            self.is_open = False
            print(f"{self.num_doors} двери закрыты")
        else:
            print("Двери уже закрыты")


class Car(Wheels, Engine, Doors):
    """
    Класс, представляющий автомобиль.
    Унаследован от классов колес, двигатель и двери.
    """

    def __init__(self, num_wheels: int, engine_volume: float, num_doors: int):
        """
        Инициализация автомобиля.

        :param num_wheels: Количество колес.
        :param engine_volume: Объем двигателя в литрах.
        :param num_doors: Количество дверей.
        """
        Wheels.__init__(self, num_wheels)
        Engine.__init__(self, engine_volume)
        Doors.__init__(self, num_doors)

    def drive(self) -> None:
        """
        Автомобиль начинает движение.
        Проверяет, что все двери закрыты перед началом движения.

        :return: None
        """
        if self.is_open:  # Проверяем, если двери открыты
            print("Нельзя начать движение с открытыми дверями.")
        else:
            print("Автомобиль поехал")


# Создаем два автомобиля с разными характеристиками
car1 = Car(num_wheels=4, engine_volume=2.5, num_doors=4)
car2 = Car(num_wheels=4, engine_volume=1.8, num_doors=3)

# Пример использования
if __name__ == "__main__":
    # Характеристики для car1
    print("Автомобиль 1:")
    car1.start()
    car1.open()
    car1.rotate()
    car1.drive()
    car1.stop()
    car1.close()

    print("\n")

    # Характеристики для car2
    print("Автомобиль 2:")
    car2.start()
    car2.open()
    car2.rotate()
    car2.drive()
    car2.stop()
    car2.close()
