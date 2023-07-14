for i in range(5):
    print("Число:", i)

fruits = ["Apple", "Banana", "Pineapple"]
for fruit in fruits:
    print("Fruits: ", fruit)

colors = ("red", "green", "blue")
for color in colors:
    print("Color:", color)

numbers = {1, 2, 3, 4, 5}
for number in numbers:
    print("Number:", number)

person = {"name": "Alex", "age": 25, "city":"Moscow"}
for key, value in person.items():
    print(key + ":", value)

letters = ["a", "c", "d", "e"]
for index, letter in enumerate(letters):
    print("Letter - ", letter, "have index: ", index)

person = {"name": "Alex", "age": 25, "city":"Moscow"}
for index, value in enumerate(person):
    print(
        "Пункт словаря - ", value, "имеет значение: ", index
    )

person = {"name": "Alex", "age": 25, "city":"Moscow"}
for value in enumerate(person):
    print(
        "Пункт словаря - ", value, "key", f"'{value[1]}'", "значение", person[value[1]]
    )


print([x for x in enumerate(person)])

print([x[0] for x in enumerate(person)])
print([x[1] for x in enumerate(person)])
print([person[x[1]]] for x in enumerate(person))
