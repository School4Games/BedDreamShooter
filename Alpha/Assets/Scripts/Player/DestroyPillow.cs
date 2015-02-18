using UnityEngine;
using System.Collections;

public class DestroyPillow : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{


	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Slimer")
			{
			// gameObject an welchem das script dranhängt (pillow)
				Destroy (this.gameObject); 
			}
	}

}
