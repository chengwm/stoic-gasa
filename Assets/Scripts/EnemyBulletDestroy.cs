using UnityEngine;
using System.Collections;

public class EnemyBulletDestroy : MonoBehaviour {

	private int playerHealth = 0;
	
	// Function is triggered when the object collides with another object
	void OnTriggerEnter(Collider collider)
	{
		if(collider.tag == "Enemy"){
			// Do nothing. The bullet spawns from the middle of the enemy
			// If this detection is not done, the bullet will destroy itself
			// when it exits the enemy.
		}
		
		// If the bullet collides with the character
		// Note: The naming is strict. This means that non-clones and clones are different names
		else if(collider.name == "Character"){
		
			// Get and update the health of the player
			if (PlayerPrefs.HasKey ("playerHealth")) {
				playerHealth = PlayerPrefs.GetInt ("playerHealth");
			}
			playerHealth -= 1;
			PlayerPrefs.SetInt ("playerHealth", (int)playerHealth);
			
			// Todo:
			// Update the code for the player life GUI as well (check playerprefs life value)
			// Need to reset playerprefs life to 3 when the player clicks start
			
			// Destroy the bullet
			Destroy (gameObject);
		}
		else{
			// Destroy the bullet object if it hits anything else
			Destroy (gameObject);
		}
			
	}
}

