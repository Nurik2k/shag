import random
from sorts import *

def generate_random():
    arr = []
    

    for i in range(0, 10):
        arr.append(random.randint(0, 10))
        
    quick = quick_sort(arr)
    heap = heap_sort(arr)
    shell = shell_sort(arr)

    return arr[0:10], quick, heap, shell

if "__main__" == __name__:

    print(generate_random())


        