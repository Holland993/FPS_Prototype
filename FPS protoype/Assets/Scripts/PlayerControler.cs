using UnityEngine;

[RequireComponent(typeof(PlayerMotot))]
public class PlayerControler : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;
    private PlayerMotot motor;
    private float lookSensitivity = 3f;

    void Start()
    {
        motor = GetComponent<PlayerMotot>();
    }

    void Update()
    {
        // calculate movement velocity as a 3D vector
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov; 
        Vector3 _movVertical = transform.forward * _zMov;

        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        //apply movement
        motor.Move(_velocity);

        //calculate rotation as a 3D vector
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _yRotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

        //Apply rotation 
        motor.Rotate(_yRotation);
        
        //calculate rotation as a 3D vector
        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * lookSensitivity;

        //Apply rotation 
        motor.RotateCamera(_cameraRotation);
    }
}
