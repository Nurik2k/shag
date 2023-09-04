import requests


def shuffle_deck() -> str:
    """
    Перемешивает колоду карт.

    Returns:
        str: ID перемешанной колоды.
    """
    response = requests.get(
        "https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1"
    )
    data = response.json()
    return data["deck_id"]


def draw_card(deck_id: str, count=1) -> dict:
    """
    Вытаскивает карту(ы) из колоды.

    Args:
        deck_id (str): ID колоды.
        count (int, optional): Количество карт для вытягивания. По умолчанию 1.

    Returns:
        list: Список карт.
    """
    url = f"https://deckofcardsapi.com/api/deck/{deck_id}/draw/?count={count}"
    response = requests.get(url)
    data = response.json()

    return data


# Пример использования


if __name__ == "__main__":
    # Перемешиваем колоду
    deck_id = shuffle_deck()

    # Вытаскиваем и печатаем 5 карт
    cards = draw_card(deck_id, count=5)
    for card in cards:
        print(f"{card['value']} of {card['suit']}")
