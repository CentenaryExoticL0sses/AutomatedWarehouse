class Size:
    def __init__(self, width : float, length : float):
        self.id = id
        self.width = width
        self.length = length

class Position:
    def __init__(self, x : int, y : int):
        self.id = id
        self.x = x
        self.y = y

class Robot:
    def __init__(self, id : str, position : Position, status : str, current_order_id : str):
        self.id = id
        self.position = position
        self.status = status
        self.current_order_id = current_order_id

class Shelf:
    def __init__(self, id : str, position : Position, size : Size):
        self.id = id
        self.position = position
        self.size = size

class Task:
    def  __init__(self, type : str, params : object):
        self.type = type
        self.params = params

class Order:
    def __init__(self, id : str):
        self.id = id
        self.tasks: list[Task] = []
        self.status : str