using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{

//Destroy Object when leaving Boundary
void OnTriggerExit2D(Collider2D other)
	{
	if (other.gameObject.tag == "Boundary")
		{
		Destroy(gameObject);
		}
	}
}