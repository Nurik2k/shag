import os
import logging
from telegram import Update, Bot
from telegram.ext import Updater, CommandHandler,  CallbackContext

# Начальное состояние
START, PLAYING = range(2)

# Инициализация логгирования
logging.basicConfig(format='%(asctime)s - %(name)s - %(levelname)s - %(message)s',
                    level=logging.INFO)
logger = logging.getLogger(__name__)

# Глобальная переменная для хранения текущего состояния игры
game_state = {}

def start(update: Update, context: CallbackContext) -> int:
    update.message.reply_text("Добро пожаловать в игру в блэкджек! Чтобы начать, введите /play.")
    return START

def play(update: Update, context: CallbackContext) -> int:
    user_id = update.message.from_user.id
    # Инициализация игры, создание колоды и другие действия по началу игры
    # Здесь вы можете использовать API для работы с колодами карт
    # game_state[user_id] = {...}
    update.message.reply_text("Игра началась! Ваши карты: ...")
    return PLAYING

def main():
    # Получите токен вашего бота из переменной окружения или из файла конфигурации
    bot_token = os.environ.get('YOUR_BOT_TOKEN')

    if not bot_token:
        print("Пожалуйста, укажите токен вашего бота в переменной окружения YOUR_BOT_TOKEN.")
        return

    # Инициализация бота
    bot = Bot(token=bot_token)
    updater = Updater(bot=bot, use_context=True)
    dispatcher = updater.dispatcher

    # Добавление обработчиков команд
    dispatcher.add_handler(CommandHandler('start', start))
    dispatcher.add_handler(CommandHandler('play', play))

    # Запуск бота
    updater.start_polling()
    updater.idle()

if __name__ == '__main__':
    main()
