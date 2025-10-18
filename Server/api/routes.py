from flask import Blueprint, current_app, Response
from api.models import Layout, State, Health
from datetime import datetime

health_bp = Blueprint('health_bp', __name__)

@health_bp.route('/api/v1/health', methods = ['GET'])
def get_health():
    health = Health(status="ok")
    health_data = health.model_dump_json()
    responce = Response(response=health_data, mimetype='application/json')
    return responce

layout_bp = Blueprint('layout_bp', __name__)

@layout_bp.route('/api/v1/layout', methods = ['GET'])
def get_layout():
    simulation = current_app.simulation_engine

    with simulation.lock:
        warehouse = simulation.warehouse
        layout = Layout(grid_size=warehouse.size, shelves=warehouse.shelves)

    layout_data = layout.model_dump_json(indent=2)
    response = Response(response=layout_data, mimetype='application/json')
    return response

state_bp = Blueprint('state_bp', __name__)

@state_bp.route('/api/v1/state', methods = ['GET'])
def get_state():
    simulation = current_app.simulation_engine
    time = datetime.now().isoformat(timespec='milliseconds')

    with simulation.lock:
        warehouse = simulation.warehouse
        state = State(timestamp=time, robots=warehouse.robots)

    state_data = state.model_dump_json(indent=2)
    response = Response(response=state_data, mimetype='application/json')
    return response