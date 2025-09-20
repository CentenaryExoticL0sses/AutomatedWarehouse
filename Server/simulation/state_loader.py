import json
import pydantic
import pathlib

from .models import Warehouse

def load_warehouse_from_json(filepath: pathlib.Path | str) -> Warehouse:
    """
    Загружает и валидирует конфигурацию склада с помощью Pydantic.
    """
    try:
        with open(filepath, 'r', encoding='utf-8') as f:
            data = json.load(f)
            return Warehouse.model_validate(data)
        
    except FileNotFoundError:
        print(f"Ошибка: Файл конфигурации не найден по пути {filepath}")
        raise

    except pydantic.ValidationError as e:
        print(f"Ошибка валидации JSON-файла: {e}")
        raise