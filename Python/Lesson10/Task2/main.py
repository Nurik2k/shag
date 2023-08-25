def count_fruits(current: str, fruit: str) -> int:
    return current.count(fruit)

if __name__ == "__main__":
    FRUITS = ("banana", "apple", "bananamango", "mango", "strawberry-banana")

    fruit = input("Enter name a fruit: ")

    count = len([val for val in FRUITS if count_fruits(val, fruit)])
    print(f'''Фрукт {fruit} встречается {count} раз''')