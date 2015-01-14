using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class hide_unhide : MonoBehaviour 
{

	public KeyCode onKey = KeyCode.Y;
	public float currentEnergy;
	public float maxEnergy;
	public float reachargerate;
	private bool useLight;
	public float minLoader;
	private bool energyEmphty;
	public Slider energyBar;

	// Use this for initialization
	void Start () 
	{
		energyBar.maxValue = maxEnergy;
	}
	
	// Update is called once per frame
	void Update () 
	{

		energyBar.value = currentEnergy;

		if(useLight)
		{
			 if (Input.GetKey (onKey))
			{
				this.renderer.enabled = true;
				currentEnergy -= reachargerate * Time.deltaTime;

			}
			else
			{
				this.renderer.enabled = false;
				Reacharge();
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
			Reacharge();
		}
		if(currentEnergy >= minLoader)
		{
			energyEmphty = false;
			useLight = true;
		}

	}

	void Reacharge ()
	{
		currentEnergy += reachargerate * Time.deltaTime;
	}
	public float Saft()
	{
		return currentEnergy;
	}
}

