class Car:
    """
    Класс, представляющий автомобиль.
    """

    def __init__(self, num_wheels: int):
        """
        Инициализация автомобиля.

        :param num_wheels: Количество колес.
        """
        self.num_wheels = num_wheels

    def drive(self):
        """
        Автомобиль начинает движение.

        :return: None
        """
        print("Автомобиль поехал")

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

    def rotate(self):
        """
        Вращает колеса.

        :return: None
        """
        print(f"{self.num_wheels} колеса вращаются")

# Пример использования
if __name__ == "__main__":
    car = Car(num_wheels=4)
    car.start()
    car.open()
    car.drive()
    car.stop()
    car.close()
    car.rotate()
