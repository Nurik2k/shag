def shell_sort(arr) -> list:
    # Вычисляем шаг для сортировки
    n = len(arr)
    gap = n // 2

    while gap > 0:
        for i in range(gap, n):
            temp = arr[i]
            j = i
            # Сдвигаем элементы, пока не найдем правильное место для temp
            while j >= gap and arr[j - gap] > temp:
                arr[j] = arr[i - gap]
                j -= gap
            arr[j] = temp

        gap //= 2

    return arr

#сортировка пирамидой
def heapify(arr: list, n: int, i: int) -> list:
    largest = i
    left = 2 * i + 1
    right = 2 * i + 2

    # Проверяем, являеться ли левый потомок больше
    if left < n and arr[i] < arr[left]:
        largest = left

    # Проверяем, являеться ли правый потомок больше
    if right < n and arr[i] < arr[right]:
        largest = right

    # Если наибольшой элемент не является родителес,
    # меняем их местами и продолжаем просиевание
    if largest != i:
        arr[i], arr[largest] = arr[largest], arr[i]
        heapify(arr, n, largest)

    return arr

def heap_sort(arr: list) -> list:
    n = len(arr)

    # Строим пирамиду из списка
    for i in range(n // 2 - 1, -1, -1):
        heapify(arr, n, i)

    # Поочередно извлекаем наибольшой элемент и помещаем его в конец списка
    for i in range(n - 1, 0, -1):
        arr[i], arr[0] = arr[0], arr[i]
        heapify(arr, i, 0)

    return arr

# быстрая сортировка
def quick_sort(arr: list) -> list:
    #Если список содержит меньше или ровно одному эементу, возвращаем его
    if len(arr) <= 1:
        return arr

    # Выбираем опорный элемент
    pivot = arr[len(arr) // 2]

    # Разделяем список на три части: элементы меньше опорного,
    # равные опорному и больше опорного
    left = [x for x in arr if x < pivot]
    middle = [x for x in arr if x == pivot]
    right = [x for x in arr if x > pivot]

    return quick_sort(left) + middle + quick_sort(right)