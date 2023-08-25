def replacement_manufacturer(tup: tuple, manufacturer: str, replacement: str) -> tuple:
    return tuple(replacement if item == manufacturer else item for item in tup)

if __name__ == "__main__":
    CAR_BRANDS = ("BMW", "Audi", "Mercedes", "BMW", "Toyota", "BMW")

    brand = input("Enter name a manufacturer: ")
    replacement = input("Enter a replace word: ")

    print(replacement_manufacturer(CAR_BRANDS, brand, replacement))