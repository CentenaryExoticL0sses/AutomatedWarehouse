from typing import List, Optional
from pydantic import BaseModel

class Position(BaseModel):
    x: int
    y: int

class Size(BaseModel):
    width: int
    length: int

class Robot(BaseModel):
    id: str
    position: Position
    status: str
    current_order_id: Optional[str] = None

class Shelf(BaseModel):
    id: str
    position: Position
    size: Size

class Warehouse(BaseModel):
    size: Size
    robots: List[Robot]
    shelves: List[Shelf]