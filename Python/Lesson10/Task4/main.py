import random

def digit_statistics(tup):
    statistics ={}
    for item in tup:
        num_digits = len(str(item))
        if num_digits in statistics:
            statistics[num_digits] += 1
        else:
            statistics[num_digits] = 1
    return statistics
    

if __name__ == "__main__":
    NUMBERS = (random.randint(1, 1000) for _ in range(10))

    counted_statistics = digit_statistics(NUMBERS)

    for count, quantuty in enumerate(counted_statistics):
        print(quantuty, counted_statistics[quantuty])
    