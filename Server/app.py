import pathlib

from flask import Flask
from flask_cors import CORS
from simulation import state_loader

def create_app():
    app = Flask(__name__)
    CORS(app)

    current_file_path = pathlib.Path(__file__)
    script_dir = current_file_path.parent
    config_path = script_dir / "configs" / "default_warehouse.json"
    
    initial_warehouse_state = state_loader.load_warehouse_from_json(config_path)
    app.warehouse_state = initial_warehouse_state

    from api.routes import state_bp
    from api.routes import layout_bp
    from api.routes import health_bp

    app.register_blueprint(state_bp)
    app.register_blueprint(layout_bp)
    app.register_blueprint(health_bp)

    return app