import deckofcardsapi as dca 

CART_SUTES = ["SPADES", "HEARTS", "DIAMONDS", "CLUBS"]
CART_VALUES = [
    "2",
    "3",
    "4",
    "5",
    "6",
    "7",
    "8",
    "9",
    "10",
    "JACKET",
    "QUEEN",
    "KING",
    "ACE"
]

PLAYER1_RATE = 0
PLAYER2_RATE = 0

def countCardsValue(suit, value) -> int:
    result = 0
    result += CART_VALUES.find(value) + 2
    result *= CART_SUTES.find(suit) + 1
    return result

def main(CART_SUTES, CART_VALUES):
    id = dca.shuffle_deck(CART_SUTES, CART_VALUES)

    while True:
        player1_cards = dca.draw_card(id, count=5)
        if player1_cards['success']:
            for card in player1_cards:
                PLAYER1_RATE += countCardsValue(card['suit'], card['value'])
        elif player1_cards['remaining']<=0:
            break
        player2_cards = dca.draw_card(id, count=5)
        if player2_cards['success']:
            PLAYER2_RATE += countCardsValue(card['suit'], card['value'])
        elif player2_cards['remaining']<=0:
            break

    if PLAYER1_RATE > PLAYER2_RATE: print("player1 win")
    else: print("player2 win")

# if __name__ == "__main___":
main(CART_SUTES, CART_VALUES)
