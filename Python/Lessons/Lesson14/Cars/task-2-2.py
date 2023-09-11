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

    def rotate(self):
        """
        Вращает колеса.

        :return: None
        """
        print(f"{self.num_wheels} колеса вращаются")


class Engine:
    """
    Класс, представляющий двигатель автомобиля.
    """

    def start(self):
        """
        Запускает двигатель.

        :return: None
        """
        print("Двигатель запущен")

    def stop(self):
        """
        Останавливает двигатель.

        :return: None
        """
        print("Двигатель остановлен")


class Doors:
    """
    Класс, представляющий двери автомобиля.
    """

    def open(self):
        """
        Открывает двери.

        :return: None
        """
        print("Двери открыты")

    def close(self):
        """
        Закрывает двери.

        :return: None
        """
        print("Двери закрыты")


class Car(Wheels, Engine, Doors):
    """
    Класс, представляющий автомобиль.
    Унаследован от классов колес, двигатель и двери.
    """

    def __init__(self, num_wheels: int):
        """
        Инициализация автомобиля.

        :param num_wheels: Количество колес.
        """
        super().__init__(num_wheels)

    def drive(self):
        """
        Автомобиль начинает движение.

        :return: None
        """
        print("Автомобиль поехал")


# Пример использования
if __name__ == "__main__":
    car = Car(num_wheels=4)
    car.start()
    car.open()
    car.drive()
    car.stop()
    car.close()
    car.rotate()
