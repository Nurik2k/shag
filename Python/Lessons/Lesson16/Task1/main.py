class Additional:


    def __call__(self, a,b):
        return a + b

if __name__ == "__main__":
    additional = Additional()

    print(additional(5,3))