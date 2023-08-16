def asc_buble_sort(array):
    for i in range(len(array)):
        for j in range(len(array)):
            if array[i] < array[j]:
                temp = array[i]
                array[i] = array[j]
                array[j] = temp
    return array

def desc_buble_sort(array):
    for i in range(len(array)):
        for j in range(len(array)):
            if array[i] > array[j]:
                temp = array[i]
                array[i] = array[j]
                array[j] = temp
    return array

def simple_print(array):
    return array


if "__main__" == __name__:
    import random

    array = []

    for i in range(0,9):
        array.append(random.randint(0, 9))

    a = asc_buble_sort(array[0 : len(array) // 3])
    b = desc_buble_sort(array[len(array) // 3 : (len(array) // 3) * 2])
    c = simple_print(array[(len(array) // 3) * 2 : len(array)])

    result = "-" + str(a) + " - " + str(b) + " - " + str(c)
    print(result)
