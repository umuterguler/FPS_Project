using System;
using UnityEngine;

public class EnemyHealthBarUI : MonoBehaviour
{
    private Camera _playerCamera;

    private void Start()
    {
        _playerCamera = Camera.main;
    }

    private void Update()
    {
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        transform.LookAt(transform.position + _playerCamera.transform.rotation * Vector3.forward,
            _playerCamera.transform.rotation * Vector3.up );
    }
}
