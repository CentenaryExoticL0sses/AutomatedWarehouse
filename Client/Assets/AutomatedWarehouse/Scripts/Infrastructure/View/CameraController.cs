using UnityEngine;

namespace AutomatedWarehouse.Infrastructure.View
{
    public class CameraController : MonoBehaviour
    {
        /// <summary>
        /// Normal speed of camera movement.
        /// </summary>
        [SerializeField] private float _movementSpeed = 50f;

        /// <summary>
        /// Speed of camera movement when shift is held down,
        /// </summary>
        [SerializeField] private float _fastMovementSpeed = 100f;

        /// <summary>
        /// Sensitivity for free look.
        /// </summary>
        [SerializeField] private float _freeLookSpeed = 200f;

        /// <summary>
        /// Amount to zoom the camera when using the mouse wheel.
        /// </summary>
        [SerializeField] private float _zoomSpeed = 100f;

        /// <summary>
        /// Amount to zoom the camera when using the mouse wheel (fast mode).
        /// </summary>
        [SerializeField] private float _fastZoomSpeed = 150f;

        private Vector3 _movementDirection;
        private Vector2 _rotationDirection;
        private float _zoomDirection;

        private bool _fastMode = false;
        private bool _isLooking = false;

        private void Update()
        {
            _fastMode = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
            
            _movementDirection = Vector3.zero;
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                _movementDirection += Vector3.left;
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                _movementDirection += Vector3.right;
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                _movementDirection += Vector3.forward;
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                _movementDirection += Vector3.back;
            }

            if (Input.GetKey(KeyCode.Q))
            {
                _movementDirection += Vector3.up;
            }

            if (Input.GetKey(KeyCode.E))
            {
                _movementDirection += Vector3.down;
            }

            if(_movementDirection.sqrMagnitude > 0.0001f)
            {
                float movementSpeed = _fastMode ? _fastMovementSpeed : _movementSpeed;
                Vector3 offset = Time.deltaTime * movementSpeed * _movementDirection.normalized;
                transform.Translate(offset);
            }

            _zoomDirection = Input.GetAxis("Mouse ScrollWheel");
            if (_zoomDirection != 0)
            {
                float zoomSpeed = _fastMode ? _fastZoomSpeed : _zoomSpeed;
                Vector3 zoomDirection = _zoomDirection * Vector3.forward;
                Vector3 zoomOffset = Time.deltaTime * zoomSpeed * zoomDirection.normalized;
                transform.Translate(zoomOffset);
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                StartLooking();
            }
            else if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                StopLooking();
            }

            _rotationDirection = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            if (_isLooking)
            {
                Vector3 eulerAngles = Time.deltaTime * _freeLookSpeed * new Vector3(-_rotationDirection.y, _rotationDirection.x, 0f);
                Vector3 eulerRotation = transform.localEulerAngles + eulerAngles;
                Quaternion rotation = Quaternion.Euler(eulerRotation);
                transform.rotation = rotation;
            }
        }

        private void OnDisable()
        {
            if(_isLooking)
            {
                StopLooking();
            }
        }

        /// <summary>
        /// Enable free looking.
        /// </summary>
        private void StartLooking()
        {
            _isLooking = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        /// <summary>
        /// Disable free looking.
        /// </summary>
        private void StopLooking()
        {
            _isLooking = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}