using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpRaycastDistance;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        if (İsGrounded())
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            _rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
        }
    }

    private bool İsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, jumpRaycastDistance);
    }

    private void Move()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");
        
        Vector3 moveDir = new Vector3(hAxis, 0f, vAxis) * (speed * Time.fixedDeltaTime);
        Vector3 newPosition = _rb.position + _rb.transform.TransformDirection(moveDir);
        _rb.MovePosition(newPosition);



    }
    
    
    
    
    
    
}
