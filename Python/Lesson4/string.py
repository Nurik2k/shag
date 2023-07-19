def string_max_size() -> int:
    import sys

    return sys.maxsize

def quotation_marks() -> None:
    print('string')
    print("string")
    print('''string''')
    print("""string""")

    print('book "war and peace"')
    print("book 'war and peace'")
    print('book \'war and peace\'')
    print("book \"war and peace\"")

    return None

def line_breaks() -> None:
    text = "one\ntwo\nthree"
    print(text)

    return None

def concatenation() -> None:
    s1 = "Hello" + " world"
    s2 = " world"

    print(s1 + s2)

    name = "John"
    age = 30

    print("Name: " + name + ", age: " + str(age))

    return None

def string_compare() -> None:
    s1 = "1a"
    s2 = "aa"
    s3 = "Aa"
    s4 = "ba"

    print("aa" < "Aa")
    print("aa" > "ba")
    print("aa" < "az")
    print(s1 > s2)
    print(s3 == s4)

    s1 = "Intel"
    s2 = "intel"

    print(s1 == s2)

    print(s1.lower() == s2.lower())

    return None

def remove_string() -> None:
    s = "test"

    print(s, s.replace("test", ""))

    s = "test"
    s = ""

    print(s)

    return None

def index_string() -> None:
    s = "abcdef"
    
    print(s[0])
    print(s[1])
    print(s[2])

    print(s[-1])

    return None

def custom_format_string() -> None:
    name = "Alex"

    print("Hello, %s" % name)
    
    print("%d %s, %d %s" % (6, "bananas", 10, "lemons"))

    print("{}".format(100))
    print("{0}, {1}, {2}".format("one", "two", "three"))
    print("{2}, {1}, {0}".format("one", "two", "three"))

    print(f'Hello, {name}!')

    a = 5
    b = 10

    print(f"Five plus ten is {a + b} and not {2 * (a + b)}.")
    
    return None

def string_methods() -> None:
    text = ("Wikipedia is a Python library that makes"
            "is easy to access and parse data from Wikipedia")
    
    print(text.find("Wikipedia"))
    print(text.rfind("Wikipedia"))
    print(text.count("Wikipedia"))

    print(
        text.replace("from Wikipedia", "from https://www.wikipedia.org/")
    )
    print(text.split(" "))

    split_text = text.split(" ")
    print(split_text)
    print("_".join(split_text))

    text = "  test "
    print(text.strip())
    print(text.lstrip())
    print(text.rstrip())

    text = "Python is a product of the Python Software Foundation"

    print(text.lower())
    print(text.upper())

    text = "python is a product of the pyhon software foundation"
    print(text.capitalize())

    return None

def strings_to_types() -> None:
    import json
    from datetime import datetime

    print(int("10"))
    print(int("0x12F", base = 16))

    print("one two three four".split())

    print("one, two, three, four".split(","))

    print("Bytes".encode("utf-8"))

    print(datetime.strptime("Jan 1 2020 1:33PM", "%b %d %Y %I:%M%p"))

    print(float("1.5"))

    print(
        json.loads('{"Russia": "Moscow", "France": "Paris"}')
    )

    print(json.dumps("hello"))

    return None

def main():
    quotation_marks()

    print("\n" + str(string_max_size())) 

    concatenation()

    string_compare()

    remove_string()

    index_string()

    custom_format_string()

    string_methods()

    strings_to_types()

if __name__ == "__main__": 
    main()   