from flask import Blueprint

layout_bp = Blueprint('layout_bp', __name__)

@layout_bp.route('/api/layout')
def get_layout():
    return "Current layout - UNDEFINED"