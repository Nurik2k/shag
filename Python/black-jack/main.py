import os
import logging
from telegram import Update, Bot
from telegram.ext import Updater, CommandHandler,  CallbackContext

START, PLAYING = range(2)

logging.basicConfig(format='%(asctime)s - %(name)s - %(levelname)s - %(message)s',
                    level=logging.INFO)
logger = logging.getLogger(__name__)

game_state = {}

def start(update: Update, context: CallbackContext) -> int:
    update.message.reply_text("Добро пожаловать в игру в блэкджек! Чтобы начать, введите /play.")
    return START

def play(update: Update, context: CallbackContext) -> int:
    user_id = update.message.from_user.id

    update.message.reply_text("Игра началась! Ваши карты: ...")
    return PLAYING

def main():

    bot_token = os.environ.get('6007701990:AAFsfbSX1PrUXXZMOff5DLQLCQ_n3pgA8ZA')

    if not bot_token:
        print("Пожалуйста, укажите токен вашего бота в переменной окружения YOUR_BOT_TOKEN.")
        return

    bot = Bot(token=bot_token)
    updater = Updater(bot=bot, use_context=True)
    dispatcher = updater.dispatcher

    dispatcher.add_handler(CommandHandler('start', start))
    dispatcher.add_handler(CommandHandler('play', play))

    updater.start_polling()
    updater.idle()

if __name__ == '__main__':
    main()
