def multiply_list_elements(lst):
    result = 1
    for num in lst:
        result *= num
    return result
#___________________________________

def find_minimum(lst):
    if len(lst) == 0:
        return None
    min_value = lst[0]
    for num in lst:
        if num < min_value:
            min_value = num
    return min_value
#___________________________________

def is_prime(number):
    if number <= 1:
        return False
    for i in range(2, int(number ** 0.5) + 1):
        if number % i == 0:
            return False
    return True

def count_primes(lst):
    count = 0
    for num in lst:
        if is_prime(num):
            count += 1
    return count
#___________________________________

def remove_value(lst, value_to_remove):
    count_removed = 0
    while value_to_remove in lst:
        lst.remove(value_to_remove)
        count_removed += 1
    return count_removed
#___________________________________

def merge_lists(list1, list2):
    return list1 + list2
#___________________________________

def power_list_elements(lst, power):
    result = []
    for num in lst:
        result.append(num ** power)
    return result
