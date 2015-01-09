using UnityEngine;
using System.Collections;

public class Learp : MonoBehaviour
{
	public float smooth;
	
	private Vector3 newPosition;
	private float newIntensity;
	private Color newColour;
	
	
	void Awake ()
	{
		newPosition = transform.position;
		newIntensity = light.intensity;
		newColour = light.color;
	}
	
	
	void Update ()
	{
		PositionChanging();
		IntensityChanging();
		ColourChanging();
	}
	
	
	void PositionChanging ()
	{
		Vector3 positionA = new Vector3(-5, 3, 0);
		Vector3 positionB = new Vector3(5, 3, 0);
		
		if(Input.GetKeyDown(KeyCode.Q))
			newPosition = positionA;
		if(Input.GetKeyDown(KeyCode.E))
			newPosition = positionB;
		
		transform.position = Vector3.Lerp(transform.position, newPosition, smooth * Time.deltaTime);
	}
	
	
	void IntensityChanging ()
	{
		float intensityA = 0.5f;
		float intensityB = 5f;
		
		if(Input.GetKeyDown(KeyCode.A))
			newIntensity = intensityA;
		if(Input.GetKeyDown(KeyCode.D))
			newIntensity = intensityB;
		
		light.intensity = Mathf.Lerp(light.intensity, newIntensity, smooth * Time.deltaTime);
	}
	
	
	void ColourChanging ()
	{
		Color colourA = Color.red;
		Color colourB = Color.green;
		
		if(Input.GetKeyDown(KeyCode.Y))
			newColour = colourA;
		if(Input.GetKeyDown(KeyCode.C))
			newColour = colourB;
		
		light.color = Color.Lerp(light.color, newColour, smooth * Time.deltaTime);
	}
}