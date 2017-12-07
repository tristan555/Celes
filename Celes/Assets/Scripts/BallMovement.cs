using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {

    public float speed=20.0f;//brzina lopte
	private float orbit;//brzina rotacije
	private Rigidbody rb;//nasa lopta
	public VirtualJoystick VJ;//virtualni joystick za upravljanje
	public AudioSource Hit;//zvuk udarca
	private Transform camTransform;//nasa kamera
	public  bool canJump;//da li moze skociti?
    private CharacterController controller;

    void Start () 
	{
       
        rb = GetComponent<Rigidbody> ();
        controller = rb.GetComponent<CharacterController>();
		camTransform = Camera.main.transform;//uzmi tu kameru nasu(ovo ja ne znam u private uradit)
	}
    void OnCollisionEnter(Collision other)
    {
        Hit.Play();
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Podovi"))canJump = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        canJump = false;
    }

    void FixedUpdate () {//zasto fixed? nadji na netu neki je glup razlog al dosta efektivan
		if (Commands.isGoing) {//aha ne moze ako je isGoing false brate hehe
			Vector3 movement=Vector3.zero;//ovo ovde sad namjestas da se mozes kretat tastaturom i strelicama
			movement.x = Input.GetAxis ("Horizontal") * speed;
			movement.y = Input.GetAxis ("Vertical") * speed;
			if(movement.magnitude>1){
				movement.Normalize ();
			}
			if(VJ.InputDirection != Vector3.zero){//eh ovde ide VJ komande(samo prebacujes ono sa tastature vamo
				movement=VJ.InputDirection;//kako je prelijepa funkcija

			}
			Vector3 rotatedDir=camTransform.TransformDirection(movement);//ovo stima rotaciju kamere
			rotatedDir=new Vector3(rotatedDir.x,0,rotatedDir.z);
			rotatedDir=rotatedDir.normalized*movement.magnitude;
			rb.AddForce(rotatedDir*speed);//eh ovde se tek kamera moze vrtit


            if (Input.GetKey(KeyCode.Space) && canJump)
            {
                rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
                canJump = false;
            }

        }
	}
	
}
