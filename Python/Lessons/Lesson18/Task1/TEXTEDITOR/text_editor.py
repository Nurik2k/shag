
class TextEditor:

    def __init__(self):
        self.text = []
        self.undo_history = []

    def __str__(self):
        return ''.join(self.text)

    def append(self, item):
        self.text.append(item)
        self.undo_history.append(self.text.copy())  # Store a copy of the current text for undo


    def undo(self):
        if self.undo_history:
            self.text = self.undo_history.pop()  # Restore the previous text state
        else:
            print("Nothing to undo.")
