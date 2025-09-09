from flask import Blueprint

layout_bp = Blueprint('layout_bp', __name__)

@layout_bp.route('/api/v1/layout')
def get_layout():
    return  '''{
                "grid_size": {
                    "width": 50,
                    "height": 30
                },
                "robots": [
                    {
                    "id": "robot-01",
                    "position": {"x": 1, "y": 1}
                    }
                ]
                }'''