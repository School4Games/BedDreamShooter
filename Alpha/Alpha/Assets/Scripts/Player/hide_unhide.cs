using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class hide_unhide : MonoBehaviour 
{

	public KeyCode onKey = KeyCode.Y;
	//Aktueller wert der Energy
	public float currentEnergy;  
	//die Maximale Energy
	public float maxEnergy;
	// die regenerations geschwindigkeit der Energy
	public float reachargerate;
	// überprüfung ob Licht an oder aus ist
	public bool useLight;
	// wenn energy = 0, dann muss erst wieder bis zum minLoader geladen werden bis die Taschenlampe wieder angeht
	public float minLoader;
	//überprüfung des MinLoaders
	public float reload;
	//Reload-Rate der FL
	public bool energyEmphty;
	// Slider bekommt den wert currentEnergy zugewiesen
	public Slider energyBar;
	public AudioClip FLSound;
	public bool falshlightCheck;

	//Flashlide Hide Slowly
	public Color ColorOne;
	public Color ColorTwo;
	//public Color ColorThree;
	private float LostTime = 0;


	SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () 
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		energyBar.maxValue = maxEnergy;
	}



	// Update is called once per frame
	void Update () 
	{
		EnergyControll();
	}

	void EnergyControll()
	{
		
		if (Input.GetKeyDown(onKey)) 
			
			audio.PlayOneShot (FLSound, 1.0F);
		
		
		this.collider2D.enabled = Input.GetKey (onKey);
		
		energyBar.value = currentEnergy;
		
		if(useLight)
			{
				
				if (Input.GetKey (onKey))
					{
					
							
								this.renderer.enabled = true;
								falshlightCheck = true;
								currentEnergy -= reachargerate * Time.deltaTime;
								






				ColourChanging();



					}
				else
					{
						this.renderer.enabled = false;
						falshlightCheck = false;
						Reacharge();
						LostTime = 0;
				//LostTime = maxEnergy - currentEnergy;
				//Debug.Log ("LostTime1:" + LostTime);






				//this.gameObject.renderer.material.color = ColorThree;
					
			
			


			
			}
			}
		
		if(currentEnergy >= maxEnergy)
			{
				currentEnergy = maxEnergy; 
			}
		if(currentEnergy <= 0)
			{
				currentEnergy = 0;
				useLight = false;
				this.renderer.enabled = false;
			}
		if (currentEnergy == 0)
			{
				energyEmphty = true;
			}
		if (energyEmphty && minLoader >= currentEnergy)
			{
				falshlightCheck = false;
				Reacharge();
			}
		if(currentEnergy >= minLoader)
			{
				energyEmphty = false;
				useLight = true;
			 
			}

	}






	void ColourChanging()
	{
		//Bestimmung der bereits vergangenen Zeit, seitdem die Taschenlampe an ist
		LostTime += Time.deltaTime/currentEnergy;
		//Debug.Log ("DeltaTime:" + Time.deltaTime);
		//Debug.Log ("Energy:" + currentEnergy);
		//Debug.Log ("LostTime2:" + LostTime);
		//Farb- und Alphawert-Änderung durch LERP
		spriteRenderer.color = Color.Lerp (ColorTwo, ColorOne, (LostTime+1)/currentEnergy);

	}









	void Reacharge ()
	{
		currentEnergy += reachargerate * (Time.deltaTime * reload);
	}
	public float Saft()
	{
		return currentEnergy;
	}
}

