﻿using UnityEngine;
using System.Collections;

public class scrollingScript : MonoBehaviour {

	public float speed = 0;

	// Update is called once per frame
	void Update () 
	{
		renderer.material.mainTextureOffset = new Vector2 (Time.time * speed, 0f);
	}
}
