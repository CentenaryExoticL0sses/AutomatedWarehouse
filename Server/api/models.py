from typing import List, Optional
from pydantic import BaseModel
from simulation.models import Size, Shelf, Robot

class Layout(BaseModel):
    grid_size: Size
    shelves: List[Shelf]

class State(BaseModel):
    timestamp: str
    robots: List[Robot]

class Health(BaseModel):
    status : str