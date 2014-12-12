using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {


	public float gravity = 10;										// float = FließKommaZahlen
	public float speed = 1;
	public float jumpPower = 1;

	bool inputJump = false;											// bool = ist etwas true or else
	private float velocity = 0;
	Vector3 moveDirection = Vector3.zero;
	
	CharacterController characterController;

	// Use this for initialization
	void Start () 
	{
		characterController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () 
	
	{
		InputCheck ();
		Move ();

	}

	void InputCheck()
	
	{
		velocity = Input.GetAxis ("Horizontal") * speed;

		if (Input.GetKeyDown (KeyCode.Space)) 								// GetKeyDown = beim drücken, GetKeyUP = beim loslassen, GetKey = beim gedrückt halten die ganze zeit(jump)
			{
			inputJump = true;
			}
		else
			{
			inputJump = false;
			}
	}

	void Move()
	
	{
		if (characterController.isGrounded)
		
		{
			if (inputJump)
				moveDirection.y = jumpPower;
		}

		moveDirection.x = velocity;
		moveDirection.y -= gravity;
		characterController.Move (moveDirection * Time.deltaTime);
	}
		
}
