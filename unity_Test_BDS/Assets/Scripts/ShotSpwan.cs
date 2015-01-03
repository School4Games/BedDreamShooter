using UnityEngine;
using System.Collections;

public class ShotSpwan : MonoBehaviour {                    //COPY FROM www.pixelnest.io/tutorials/2d-game-unity/shooting-1/

	public Transform shotPrefab;
	public float shootingRate = 0.25f;
	private float shootCooldown;
	
	void Start()
	{
		shootCooldown = 0f;
	}
	
	void Update()
	{
		if (shootCooldown > 0)
		{
			shootCooldown -= Time.deltaTime;
		}
	}

	public void Attack(bool isEnemy)
	{
		if (CanAttack)
		{
			shootCooldown = shootingRate;
			
			// Create a new shot
			var shotTransform = Instantiate(shotPrefab) as Transform;
			
			// Assign position
			shotTransform.position = transform.position;
			
			// The is enemy property
			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
			if (shot != null)
			{
				shot.isEnemyShot = isEnemy;
			}
			
			// Make the weapon shot always towards it
			Movee move = shotTransform.gameObject.GetComponent<Movee>();
			if (move != null)
			{
				move.direction = this.transform.right; // towards in 2D space is the right of the sprite
			}
		}
	}

	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}
}