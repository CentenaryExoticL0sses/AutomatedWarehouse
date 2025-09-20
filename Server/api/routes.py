from flask import Blueprint, current_app, Response
from api.models import Layout, State

health_bp = Blueprint('health_bp', __name__)

@health_bp.route('/api/v1/health')
def get_health():
    return  "status: ok"

layout_bp = Blueprint('layout_bp', __name__)

@layout_bp.route('/api/v1/layout')
def get_layout():
    warehouse = current_app.warehouse_state
    layout = Layout(grid_size=warehouse.size, shelves=warehouse.shelves)
    layout_data = layout.model_dump_json(indent=2)
    mimetype = 'application/json'
    response = Response(response=layout_data, mimetype=mimetype)
    return response

state_bp = Blueprint('state_bp', __name__)

@state_bp.route('/api/v1/state')
def get_state():
    warehouse = current_app.warehouse_state
    state = State(robots=warehouse.robots)
    state_data = state.model_dump_json(indent=2)
    mimetype = 'application/json'
    response = Response(response=state_data, mimetype=mimetype)
    return response