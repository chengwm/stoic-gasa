using UnityEngine;
using System.Collections;

public class MenuTouches : MonoBehaviour {
	
	public Texture2D button1;
	public Texture2D button2;
	
	// Use this for initialization
	void Start () 
	{
		guiTexture.texture = button1;	
	}

	// Update is called once per frame
	//void Update () 
	//{
		/* Notes: Both methods seem to work.
		 * Theory on how to add pen touch recognition: Use method 2, then check if isPenPressed == true.
		 * If it is true, getPenTouchX() and getPenTouchY(). 
		 * Make a new Vector3: Vector3 position = new Vector3(getPenTouchX(), getPenTouchY(), 0);
		 * Put those values into HitTest(Vector3 position)
		 * Pray that it works.
		 */

		// Method 1 (possible multi-touch functionality, has bugs)
		/*foreach (Touch touch in Input.touches)
		{
			if (guiTexture.HitTest(touch.position) && touch.phase != TouchPhase.Ended)
			{
				guiTexture.texture = button2;
				//transform.Translate(Vector3.right * 1 * Time.smoothDeltaTime);

			}
			else if (guiTexture.HitTest(touch.position) && touch.phase == TouchPhase.Ended)
			{
				guiTexture.texture = button1;
				if(guiTexture.name == "text_START")
					Application.LoadLevel("game");
				else if(guiTexture.name == "text_Settings")
					Application.LoadLevel("settings");
				else if(guiTexture.name == "text_Back")
					Application.LoadLevel("main");
			}
		}*/

		// Method 2
		/*if (guiTexture.HitTest(Input.GetTouch(0).position) && Input.GetTouch(0).phase != TouchPhase.Ended)
		{
			guiTexture.texture = button2; // texture changes to button2 when touched
			//transform.Translate(Vector3.right * 1 * Time.smoothDeltaTime);
			
		}
		else if (guiTexture.HitTest(Input.GetTouch(0).position) && Input.GetTouch(0).phase == TouchPhase.Ended)
		{
			guiTexture.texture = button1;
			if(guiTexture.name == "text_START")
				Application.LoadLevel("game");
			else if(guiTexture.name == "text_Settings")
				Application.LoadLevel("settings");
			else if(guiTexture.name == "text_Back")
				Application.LoadLevel("main");
			else if(guiTexture.name == "text_ClearHighscore")
				PlayerPrefs.DeleteKey ("highScore");
		}
	}*/

	void OnMouseDown(){
		if (guiTexture.name == "text_START")
				Application.LoadLevel ("game");
		else if (guiTexture.name == "text_Settings")
				Application.LoadLevel ("settings");
		else if (guiTexture.name == "text_Back")
				Application.LoadLevel ("main");
		else if (guiTexture.name == "text_ClearHighscore")
				PlayerPrefs.DeleteKey ("highScore");
	}
}