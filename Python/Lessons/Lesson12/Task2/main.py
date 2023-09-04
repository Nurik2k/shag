def FileReader(string):
    file = open(string, "r")
    content = file.readlines()
    file.close()
    return content

def NewFile(string):
    fr = FileReader(string)
    nw = open("D:/shag/Python/Lesson12/Task2/file2.txt", "w")

    for i in fr:
        if i.__contains__(","):
            nw.write("*******")
       
    nw.close()
    return nw

     

if __name__ == "__main__":
 NewFile("D:/shag/Python/Lesson12/Task2/file.txt")