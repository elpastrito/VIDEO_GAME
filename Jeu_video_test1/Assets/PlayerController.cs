
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f; //servira pour la vitesse de mouvement

    [SerializeField]
    private float XmouseSensitivity = 5f;  //servira pour la vitesse de rotation du regard
    [SerializeField]
    private float YmouseSensitivity = 5f;



    private PlayerMotor motor;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        float xMov = Input.GetAxisRaw("Horizontal"); //gauche_droite
        float zMov = Input.GetAxisRaw("Vertical");  //avant-arrière

        Vector3 moveHorizontal = transform.right * xMov;
        Vector3 moveVertical = transform.forward * zMov;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        motor.Move(velocity);



        /* analyse de la souris */

        //rotation du joueur (gauche droite)
        
        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0, yRot) *XmouseSensitivity;

        motor.Rotate(rotation);  //rotation du corps de gauche à droite


        //rotation de la caméra (haut bas)

        float xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 cameraRotation = new Vector3(xRot,0) * YmouseSensitivity;

        motor.RotateCamera(cameraRotation);  //rotation du corps de gauche à droite

    }
}
