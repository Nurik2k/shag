from libs.shop_queue import *

if __name__ == "__main__":
    shop = ShopQueue()
    
    shop.add_customer("Иван")
    shop.add_customer("Алимжан")
    shop.add_customer("Мария")

    while True:
        shop.serve_customer()
        print(shop.show_queue())
        if shop.is_empty():
            break

    