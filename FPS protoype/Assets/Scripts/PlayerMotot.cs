using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotot : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 yRotation = Vector3.zero;
    private Vector2 cameraRotation = Vector3.zero;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    //get a rotational vector
    public void Rotate(Vector3 _yRotation)
    {
        yRotation = _yRotation;
    }
    //get a rotational vector
    public void RotateCamera(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }

    //run every physics iteration
    void FixedUpdate()
    {
        PerformMovement();
        PerformYRotation();
    }

    // perform movement based on velocity variable
    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
        }
    }

    //perform rotation
    void PerformYRotation()
    {
        rb.MoveRotation(transform.rotation * Quaternion.Euler (yRotation));

        if (cam != null)
        {
            cam.transform.Rotate(-cameraRotation);
        }
    }

}
