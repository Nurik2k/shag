def FileReader(string):
    file = open(string, "r")
    content = file.readlines()
    file.close()
    return content

def NewFile(string):
    fr = FileReader(string)
    nw = open("D:/shag/Python/Lesson12/Task1/file2.txt", "w")

    for i in fr:
        if len(i) > 7:
            nw.write(i)
       
    nw.close()
    return nw

     

if __name__ == "__main__":
 NewFile("D:/shag/Python/Lesson12/Task1/file.txt")