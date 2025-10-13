using UnityEngine;

namespace AutomatedWarehouse.Infrastructure.View
{
    /// <summary>
    /// A simple free camera to be added to a Unity game object.
    /// </summary>
    /// <remarks>
    /// Keys:
    ///	wasd / arrows	- movement
    ///	q/e 			- up/down (local space)
    ///	r/f 			- up/down (world space)
    ///	pageup/pagedown	- up/down (world space)
    ///	hold shift		- enable fast movement mode
    ///	right mouse  	- enable free look
    ///	mouse			- free look / rotation
    /// </remarks>
    public class CameraController : MonoBehaviour
    {
        /// <summary>
        /// Normal speed of camera movement.
        /// </summary>
        [SerializeField] private float _movementSpeed = 10f;

        /// <summary>
        /// Speed of camera movement when shift is held down,
        /// </summary>
        [SerializeField] private float _fastMovementSpeed = 100f;

        /// <summary>
        /// Sensitivity for free look.
        /// </summary>
        [SerializeField] private float _freeLookSensitivity = 3f;

        /// <summary>
        /// Amount to zoom the camera when using the mouse wheel.
        /// </summary>
        [SerializeField] private float _zoomSensitivity = 10f;

        /// <summary>
        /// Amount to zoom the camera when using the mouse wheel (fast mode).
        /// </summary>
        [SerializeField] private float _fastZoomSensitivity = 50f;

        /// <summary>
        /// Set to true when free looking (on right mouse button).
        /// </summary>
        private bool _isLooking = false;

        private void Update()
        {
            var fastMode = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
            var movementSpeed = fastMode ? _fastMovementSpeed : this._movementSpeed;

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position = transform.position + -transform.right * movementSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.position = transform.position + transform.right * movementSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.position = transform.position + transform.forward * movementSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.position = transform.position + -transform.forward * movementSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.Q))
            {
                transform.position = transform.position + transform.up * movementSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.E))
            {
                transform.position = transform.position + -transform.up * movementSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.R) || Input.GetKey(KeyCode.PageUp))
            {
                transform.position = transform.position + Vector3.up * movementSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.PageDown))
            {
                transform.position = transform.position + -Vector3.up * movementSpeed * Time.deltaTime;
            }

            if (_isLooking)
            {
                float newRotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * _freeLookSensitivity;
                float newRotationY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * _freeLookSensitivity;
                transform.localEulerAngles = new Vector3(newRotationY, newRotationX, 0f);
            }

            float axis = Input.GetAxis("Mouse ScrollWheel");
            if (axis != 0)
            {
                var zoomSensitivity = fastMode ? _fastZoomSensitivity : this._zoomSensitivity;
                transform.position = transform.position + transform.forward * axis * zoomSensitivity;
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                StartLooking();
            }
            else if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                StopLooking();
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