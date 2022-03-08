using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    private Vector3 velocity;
    private Rigidbody rb; //effectue les d�placements physiques

    [SerializeField]
    private Camera cam; //importation influence camera


    //mouvements physiques

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }
    
    private void FixedUpdate()  //effectuer les t�ches
    {
        PerformMovement();
        PerformRotation();
    }

    private void PerformMovement()
    {
        if (velocity != Vector3.zero) //s'il n'y a pas de d�placements
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }


    //mouvements visuels
    private void PerformRotation()  //utilise les donn�es de rotation gauche-droite & haut-bas
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        cam.transform.Rotate(-cameraRotation);
    }

    //rotation corps gauche droite

    private Vector3 rotation;

    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    

    //rotation cam�ra haut bas

    private Vector3 cameraRotation;

    public void RotateCamera(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }
}