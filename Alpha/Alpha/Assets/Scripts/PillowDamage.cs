using UnityEngine;
using System.Collections;

public class PillowDamage : MonoBehaviour {


	public int damageValue = 1;
	public string tag = ("Player");

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == tag)
			other.gameObject.SendMessage ("ApplyDamage", damageValue, SendMessageOptions.DontRequireReceiver);
		
	}
}
