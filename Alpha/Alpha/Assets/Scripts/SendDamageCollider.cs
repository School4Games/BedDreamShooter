using UnityEngine;
using System.Collections;

public class SendDamageCollider : MonoBehaviour {

	public int damageValue = 1;
	public string tag = ("Player"); 
	
	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == tag)
			other.gameObject.SendMessage ("ApplyDamage", damageValue, SendMessageOptions.DontRequireReceiver);
	}
}
