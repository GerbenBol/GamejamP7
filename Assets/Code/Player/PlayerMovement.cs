using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Camera _mainCam;
    private Rigidbody _rigidBody;
    private float _originalSpeed;

    [SerializeField] private float _MovementSpeed;  // 20000
    [SerializeField] private int _Sensitivity;      // 5

    void Start()
    {
        _mainCam = Camera.main;
        _rigidBody = GetComponent<Rigidbody>();
        _originalSpeed = _MovementSpeed;

        //locks the cursor to the middle of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
            LookAround();

        //Makes the player move with [W,A,S,D]
        _rigidBody.AddForce(transform.right * (Input.GetAxis("Horizontal") * _MovementSpeed * Time.deltaTime));
        _rigidBody.AddForce(transform.forward * (Input.GetAxis("Vertical") * _MovementSpeed * Time.deltaTime));
    }

    public IEnumerator SpeedBoost()
    {
        _MovementSpeed = 25000;
        yield return new WaitForSeconds(5);
        _MovementSpeed = _originalSpeed;
    }

    private void LookAround()
    {
        //Rotates the Camera around the player model on the Y Axis
        _mainCam.transform.localRotation = Quaternion.Euler(30, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * _Sensitivity, 0);
    }
}
