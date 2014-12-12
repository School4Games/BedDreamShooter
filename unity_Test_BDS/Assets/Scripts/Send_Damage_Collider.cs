using UnityEngine;
using System.Collections;

public class Send_Damage_Collider : MonoBehaviour {

	public int damageValue = 1;
	public string tag = ("Player"); 

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == tag)
			other.gameObject.SendMessage ("ApplyDamage", damageValue, SendMessageOptions.DontRequireReceiver);
	}
}
