counter = 0 

while counter < 5:
    print("Counter: ", counter)
    counter += 1

while True:
    user_input = input("Enter 'q', quit: ")
    if user_input.lower == "q":
        break

counter = 0 
while counter < 10:
    counter += 1
    if counter % 2 == 0:
        continue
    print("Odd number: ", counter)


outer_counter = 0 
while outer_counter < 3:
    inner_counter = 0
    while inner_counter < 3:
        print("Outer counter: ", outer_counter, "Inner counter: ", inner_counter)
        inner_counter += 1
    outer_counter += 1

