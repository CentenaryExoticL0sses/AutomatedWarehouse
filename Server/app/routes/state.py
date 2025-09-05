from flask import Blueprint

state_bp = Blueprint('state_bp', __name__)

@state_bp.route('/api/state')
def get_state():
    return "Current state - NORMAL"