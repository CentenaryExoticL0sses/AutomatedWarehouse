import random

class SimulationEngine:
    
    def __init__(self, warehouse):
        self.warehouse = warehouse

    def tick(self):
        for robot in self.warehouse.robots:
            robot.position.x += random.randint(-1, 1)
            robot.position.y += random.randint(-1, 1)

         