from api.deck import init_game, draw_cards
from collections import Counter
import api.deck as dc

CART_SUTES = ["SPADES", "HEARTS", "DIAMONDS", "CLUBS"]
CART_VALUES = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"]

if __name__ == "__main__":
    desk_id = init_game()
    
