def FileReader(string):
    file = open(string, "r")
    content = file.readlines()
    file.close()
    return content

def NewFile(string):
    fr = FileReader(string)
    nw = open("D:/shag/Python/Lessons/Lesson13/Task1/file2.txt", "w")

    for i in fr:
        nw.write(i)
        if i.__contains__("bitch"):
            nw.write(i.replace(i," ****"))
       
    nw.close()
    return nw

if __name__ == "__main__":
 NewFile("D:/shag/Python/Lessons/Lesson13/Task1/file.txt")