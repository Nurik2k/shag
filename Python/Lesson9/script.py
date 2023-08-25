import time
import timeit
import random
from sorts import shell_sort, heap_sort, quick_sort


def function_to_compare_timeit(function: callable, arr: list) -> float:
    try:
        # Засекаем время перед выполнением функции
        starttime = timeit.default_timer()
        function(arr)
        return timeit.default_timer() - starttime
    except Exception:
        return 0




# Функция, которую нужно сравнить
def function_to_compare(function: callable, arr: list) -> float:
    # Засекаем время перед выполнением функции
    start_time = time.time()

    # Выполняем функцию
    arr_copy = function(arr)

    # Засекаем время после выполнения функции
    end_time = time.time()
    # Возвращаем время выполнения скрипта
    return end_time - start_time, arr_copy






if __name__ == "__main__":
    arr = [random.randrange(100) for val in range(100)]
    print(arr)

    arr_copy = arr.copy()
    print(id(arr), id(arr_copy))
    time_arr, arr_copy = function_to_compare(quick_sort, arr_copy)

    print(
        "Время выполнения:",
        time_arr,
        "секунд",
    )
    print("quick_sort", arr_copy)

    arr_copy = arr.copy()
    print(id(arr), id(arr_copy))
    time_arr, arr_copy = function_to_compare(heap_sort, arr_copy)
    print(
        "Время выполнения:",
        time_arr,
        "секунд",
    )
    print("pyramid_sort", arr_copy)

    arr_copy = arr.copy()
    print(id(arr), id(arr_copy))
    time_arr, arr_copy = function_to_compare(quick_sort, arr_copy)
    print(
        "Время выполнения:",
        time_arr,
        "секунд",
    )
    print("shell_sort", arr_copy)

    arr_copy = arr.copy()
    print(id(arr), id(arr_copy))
    print(
        "Время выполнения:",
        function_to_compare_timeit(shell_sort, arr_copy),
        "секунд",
    )
    arr_copy = arr.copy()
    print(
        "Время выполнения:",
        function_to_compare_timeit(heap_sort, arr_copy),
        "секунд",
    )
    arr_copy = arr.copy()
    print(
        "Время выполнения:",
        function_to_compare_timeit(quick_sort, arr_copy),
        "секунд",
    )

