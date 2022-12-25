using Interfaces;
using UnityEngine;

namespace Player
{
    public class PlayerCameraController : MonoBehaviour
    {
        [SerializeField] private float lookSensitivity;
        [SerializeField] private float smoothing;
    
        private GameObject _player;
        private Vector2 _smoothedVelocity;
        private Vector2 _currentLookingPos;
        
        private void Start()
        {
            _player = transform.parent.gameObject;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    
        private void Update()
        {
            RotateCamera(); 
        }
    
        private void RotateCamera()
        {
            var inputValues = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
    
            inputValues = Vector2.Scale(inputValues,new Vector2( lookSensitivity * smoothing, lookSensitivity * smoothing));
            _smoothedVelocity.x = Mathf.Lerp(_smoothedVelocity.x, inputValues.x, 1f/smoothing);
            _smoothedVelocity.y = Mathf.Lerp(_smoothedVelocity.y, inputValues.y, 1f/smoothing);
    
            _currentLookingPos += _smoothedVelocity;
            
            transform.localRotation = Quaternion.AngleAxis(-_currentLookingPos.y, Vector3.right);
            _player.transform.localRotation = Quaternion.AngleAxis(_currentLookingPos.x, Vector3.up);
            
            _currentLookingPos.y = Mathf.Clamp(_currentLookingPos.y, -80f, 80f);
        }
    }
}

