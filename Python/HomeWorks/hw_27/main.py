import unittest

# Класс "Транспортное средство"
class Vehicle:
    def __init__(self, vehicle_type):
        self.type = vehicle_type

    def get_type(self):
        return self.type

    def __repr__(self):
        return f"Vehicle({self.type})"

    def __str__(self):
        return f"Vehicle Type: {self.type}"

# Тесты для класса Vehicle
class TestVehicle(unittest.TestCase):
    def test_get_type(self):
        vehicle = Vehicle("Car")
        self.assertEqual(vehicle.get_type(), "Car")

    def test_repr(self):
        vehicle = Vehicle("Bus")
        self.assertEqual(repr(vehicle), "Vehicle(Bus)")

    def test_str(self):
        vehicle = Vehicle("Train")
        self.assertEqual(str(vehicle), "Vehicle Type: Train")

# Класс "Автобус"
class Bus:
    def __init__(self, number):
        self.number = number

    def get_number(self):
        return self.number

    def __repr__(self):
        return f"Bus({self.number})"

    def __str__(self):
        return f"Bus Number: {self.number}"

# Тесты для класса Bus
class TestBus(unittest.TestCase):
    def test_get_number(self):
        bus = Bus("101")
        self.assertEqual(bus.get_number(), "101")

    def test_repr(self):
        bus = Bus("XYZ")
        self.assertEqual(repr(bus), "Bus(XYZ)")

    def test_str(self):
        bus = Bus("999")
        self.assertEqual(str(bus), "Bus Number: 999")

# Класс "Расписание автобусов"
class BusSchedule:
    def __init__(self):
        self.schedule = []

    def add_bus(self, bus_number, departure_time):
        self.schedule.append((bus_number, departure_time))

    def get_schedule(self):
        return self.schedule

    def get_schedule_by_bus_number(self, bus_number):
        return [item for item in self.schedule if item[0] == bus_number]

    def is_bus(self, vehicle_number):
        return any(item[0] == vehicle_number for item in self.schedule)

    def check_schedule(self, bus_number, departure_time):
        return (bus_number, departure_time) in self.schedule

# Тесты для класса BusSchedule
class TestBusSchedule(unittest.TestCase):
    def test_add_bus(self):
        schedule = BusSchedule()
        schedule.add_bus("101", "10:00")
        self.assertEqual(schedule.get_schedule(), [("101", "10:00")])

    def test_get_schedule_by_bus_number(self):
        schedule = BusSchedule()
        schedule.add_bus("101", "10:00")
        schedule.add_bus("102", "11:00")
        self.assertEqual(schedule.get_schedule_by_bus_number("102"), [("102", "11:00")])

    def test_is_bus(self):
        schedule = BusSchedule()
        schedule.add_bus("101", "10:00")
        self.assertTrue(schedule.is_bus("101"))
        self.assertFalse(schedule.is_bus("102"))

    def test_check_schedule(self):
        schedule = BusSchedule()
        schedule.add_bus("101", "10:00")
        self.assertTrue(schedule.check_schedule("101", "10:00"))
        self.assertFalse(schedule.check_schedule("102", "11:00"))

if __name__ == '__main__':
    unittest.main()
