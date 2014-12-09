using UnityEngine;
using System.Collections;

public class DestroyEnemySlimer : MonoBehaviour {
	
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D col) {
		
													//Debug.Log("collosion name = " + col.gameObject.tag);
		if (col.gameObject.tag == "Slimer")
		{
													//Debug.Log("Collision with: " + col.gameObject.tag);

			Destroy(col.gameObject); // gameObject mit dem die Collision stattfindet (Slimer)
			Destroy(this.gameObject); // gameObject an welchem das script dranhängt (pillow)
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
}