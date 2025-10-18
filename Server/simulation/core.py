import random
import time
import threading

class SimulationEngine:
    
    def __init__(self, warehouse, tick_interval):
        self.warehouse = warehouse
        self.tick_interval = tick_interval
        self.lock = threading.Lock()

    def tick(self):
        with self.lock:
            for robot in self.warehouse.robots:
                robot.position.x = max(0, min(robot.position.x + random.randint(-1, 1), self.warehouse.size.width - 1))
                robot.position.y = max(0, min(robot.position.y + random.randint(-1, 1), self.warehouse.size.length - 1))

    def run(self):
        while(True):
            self.tick()
            time.sleep(self.tick_interval)

         