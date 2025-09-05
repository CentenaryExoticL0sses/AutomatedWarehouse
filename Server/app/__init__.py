from flask import Flask

def create_app():
    app = Flask(__name__)

    from .routes.state import state_bp
    from .routes.layout import layout_bp

    app.register_blueprint(state_bp)
    app.register_blueprint(layout_bp)

    return app