using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
	//Bed
	public float speed;
	private float rotation; 
	//
	public Boundary boundary;

	//Feedback for been hit
	private Material mat;
	//private Color[] colors = {Color.yellow, Color.red};
	public Color[] colors;
	private float flashSpeed = 0.1f;
	private float lengthOfTimeToFlash = 0.5f;


	//Shot
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;
	//LifePoints
	public float Health = 5;
	// UI Face
	public Image redFace;
	public Image orangeFace;
	public Image darkYellowFace;
	public Image yellowFace;
	public Image greenFace;

	
	void Start()
	{
		this.mat = GetComponent<SpriteRenderer>().material;
	}
	
	void Update ()
	{
		// wenn rechtemaustaste gedrückt wird, wird ein Schuss am Player gespawnt 
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		} 

	}

	
	void FixedUpdate ()
	{
		UIHealth();
		//StartCoroutine("UIHealth");
				//zuweisung der keys w,a,s,d || Arrowkeys & velocity

				float moveHorizontal = Input.GetAxis ("Horizontal");
				float moveVertical = Input.GetAxis ("Vertical");
		
				Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
				rigidbody2D.velocity = movement * speed;
		
				rigidbody2D.position = new Vector3 
				//boundary auf x und y axe
				(Mathf.Clamp (rigidbody2D.position.x, boundary.xMin, boundary.xMax),Mathf.Clamp (rigidbody2D.position.y, boundary.yMin, boundary.yMax));
	}

	void ApplyDamage (float damage)
	{
		StartCoroutine(Flash(this.lengthOfTimeToFlash, this.flashSpeed));
		if (Health > 0) 										// is Health bigger than 0, do the following steps
			{
				// von health wird damage abgezogen
				Health -= damage;								// it's possible /Health = Health - damage / but it is longer
				

				if (Health < 0)									// is Health lower than 0
					Health = 0;									// than put Health to 0 
				
				//what happens if Health = 0?
				if (Health == 0) 
					{
						// GameOver
						RestartScene ();
					}
			}
	}

	void RestartScene()
	{
		Application.LoadLevel (Application.loadedLevel);
	}


	IEnumerator Flash(float time, float intervalTime)
	{
		float elapsedTime 	= 0f;
		int index			= 0;
		gameObject.GetComponent<BoxCollider2D>().enabled = false;
		while (elapsedTime < time)
		{
			mat.color = colors[index % 2];
			elapsedTime += Time.deltaTime;
			index++;
			yield return new WaitForSeconds(intervalTime);
		}
		//Debug.Log("Fertig");
		mat.color = colors[0];
		gameObject.GetComponent<BoxCollider2D>().enabled = true;
	}



	void UIHealth()
	{
		if (Health == 5)
			//zeige nur greenFace an
			//entweder ich setze den Alpha auf 0 oder ich mmach das bild enable.
			{
				yellowFace.color = new Color(yellowFace.color.r,yellowFace.color.g,yellowFace.color.b,1);
				darkYellowFace.color = new Color(darkYellowFace.color.r,darkYellowFace.color.g,darkYellowFace.color.b,1);
				orangeFace.color = new Color(orangeFace.color.r,orangeFace.color.g,orangeFace.color.b,1);
				redFace.color = new Color(redFace.color.r,redFace.color.g,redFace.color.b,1);
				greenFace.color = new Color(greenFace.color.r,greenFace.color.g,greenFace.color.b,1);
			}

		if (Health == 4)
			//zeige nur yellowFace an
			{
				

				yellowFace.color = new Color(yellowFace.color.r,yellowFace.color.g,yellowFace.color.b,1);
				darkYellowFace.color = new Color(darkYellowFace.color.r,darkYellowFace.color.g,darkYellowFace.color.b,1);
				orangeFace.color = new Color(orangeFace.color.r,orangeFace.color.g,orangeFace.color.b,1);
				redFace.color = new Color(redFace.color.r,redFace.color.g,redFace.color.b,1);
				greenFace.color = new Color(greenFace.color.r,greenFace.color.g,greenFace.color.b,0);
		
		
			}

		if (Health == 3)
			//zeige nur darkYellowFace an
			{
				yellowFace.color = new Color(yellowFace.color.r,yellowFace.color.g,yellowFace.color.b,0);
				darkYellowFace.color = new Color(darkYellowFace.color.r,darkYellowFace.color.g,darkYellowFace.color.b,1);
				orangeFace.color = new Color(orangeFace.color.r,orangeFace.color.g,orangeFace.color.b,1);
				redFace.color = new Color(redFace.color.r,redFace.color.g,redFace.color.b,1);
				greenFace.color = new Color(greenFace.color.r,greenFace.color.g,greenFace.color.b,0);
			}
		if (Health == 2)
			//zeige nur orangeFace an
			{
				yellowFace.color = new Color(yellowFace.color.r,yellowFace.color.g,yellowFace.color.b,0);
				darkYellowFace.color = new Color(darkYellowFace.color.r,darkYellowFace.color.g,darkYellowFace.color.b,0);
				orangeFace.color = new Color(orangeFace.color.r,orangeFace.color.g,orangeFace.color.b,1);
				redFace.color = new Color(redFace.color.r,redFace.color.g,redFace.color.b,1);
				greenFace.color = new Color(greenFace.color.r,greenFace.color.g,greenFace.color.b,0);
			}
		if (Health == 1)
			//zeige nur redFace an
			{
				yellowFace.color = new Color(yellowFace.color.r,yellowFace.color.g,yellowFace.color.b,0);
				darkYellowFace.color = new Color(darkYellowFace.color.r,darkYellowFace.color.g,darkYellowFace.color.b,0);
				orangeFace.color = new Color(orangeFace.color.r,orangeFace.color.g,orangeFace.color.b,0);
				redFace.color = new Color(redFace.color.r,redFace.color.g,redFace.color.b,1);
				greenFace.color = new Color(greenFace.color.r,greenFace.color.g,greenFace.color.b,0);
			}
	}
	public float HealthFace ()
	{
		return Health;

	}

}


























