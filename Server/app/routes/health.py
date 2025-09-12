from flask import Blueprint

health_bp = Blueprint('health_bp', __name__)

@health_bp.route('/api/v1/health')
def get_health():
    return  "status: ok"