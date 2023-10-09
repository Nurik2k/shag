class TreeNode:
    def __init__(self, value=0, left=None, right=None):
        self.value = value
        self.left = left
        self.right = right

def max_path_sum(root):
    if not root:
        return 0, []

    # Если текущий узел является листом
    if not root.left and not root.right:
        return root.value, [root.value]

    # Рекурсивно находим путь для левого и правого поддерева
    left_sum, left_path = max_path_sum(root.left)
    right_sum, right_path = max_path_sum(root.right)

    # Выбираем путь с наибольшей суммой
    if left_sum > right_sum:
        return left_sum + root.value, [root.value] + left_path
    else:
        return right_sum + root.value, [root.value] + right_path

# Тест
root = TreeNode(10, TreeNode(5, TreeNode(3), TreeNode(7)), TreeNode(15, TreeNode(12), TreeNode(20)))
total_sum, path = max_path_sum(root)

print(f"Максимальная сумма: {total_sum}")
print(f"Путь к сокровищам: {' -> '.join(map(str, path))}")