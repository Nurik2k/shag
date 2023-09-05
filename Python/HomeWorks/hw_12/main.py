tuple1 = (1, 2, 3, 4, 5)
tuple2 = (3, 4, 5, 6, 7)
tuple3 = (5, 6, 7, 8, 9)

common_elements = set(tuple1) & set(tuple2) & set(tuple3)
common_elements = list(common_elements)
print("Элементы, которые есть во всех кортежах:", common_elements)
#_________________________________________________________________________

tuple1 = (1, 2, 3, 4, 5)
tuple2 = (3, 4, 5, 6, 7)
tuple3 = (5, 6, 7, 8, 9)

unique_elements_tuple1 = set(tuple1) - set(tuple2) - set(tuple3)
unique_elements_tuple2 = set(tuple2) - set(tuple1) - set(tuple3)
unique_elements_tuple3 = set(tuple3) - set(tuple1) - set(tuple2)

unique_elements_tuple1 = list(unique_elements_tuple1)
unique_elements_tuple2 = list(unique_elements_tuple2)
unique_elements_tuple3 = list(unique_elements_tuple3)

print("Уникальные элементы в первом кортеже:", unique_elements_tuple1)
print("Уникальные элементы во втором кортеже:", unique_elements_tuple2)
print("Уникальные элементы в третьем кортеже:", unique_elements_tuple3)
#_________________________________________________________________________

tuple1 = (1, 2, 3, 4, 5)
tuple2 = (3, 4, 5, 6, 7)
tuple3 = (5, 6, 7, 8, 9)

common_elements = []

for i in range(min(len(tuple1), len(tuple2), len(tuple3))):
    if tuple1[i] == tuple2[i] == tuple3[i]:
        common_elements.append(tuple1[i])

print("Элементы, которые есть в каждом кортеже и находятся на той же позиции:", common_elements)
