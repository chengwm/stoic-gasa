using UnityEngine;

public class TimerForIngress: MonoBehaviour {
	public float seconds;
	public float miliseconds;
	public bool runTimer;

	void Start(){
	// Update these depending on which style is used
		seconds = 20;
		miliseconds = 0;
		runTimer = false;
	}
	
	void Update(){
		if(seconds<0) {
			stopTimer();
			guiText.text = "00:00";
		}

		if(runTimer){
			if(miliseconds <= 0){
				if(seconds >= 0){
					seconds--;
				}
				
				miliseconds = 100;
			}
			
			miliseconds -= Time.deltaTime * 100;
			
//			guiText.text = string.Format("{0} : {1}", seconds, (int)miliseconds);
			guiText.text = ToString();

		}

		/* ----------------------
		// Seconds : Milliseconds style
		if(miliseconds <= 0){
			if(seconds >= 0){
				seconds--;
			}
			
			miliseconds = 100;
		}
		
		miliseconds -= Time.deltaTime * 100;
		
		guiText.text = string.Format("{0} : {1}", seconds, (int)miliseconds);
		-------------------------- */
		
		/* ------------------------
		// Minutes : Seconds : Milliseconds Style
		if(miliseconds <= 0){
			if(seconds <= 0){
				minutes--;
				seconds = 59;
			}
			else if(seconds >= 0){
				seconds--;
			}
			
			miliseconds = 100;
		}
		
		miliseconds -= Time.deltaTime * 100;
		
		//Debug.Log(string.Format("{0}:{1}:{2}", minutes, seconds, (int)miliseconds));
		guiText.text = string.Format("{0}:{1}:{2}", minutes, seconds, (int)miliseconds);
		------------------------- */
/*		
		// Seconds only style
		seconds -= Time.deltaTime; // I need timer which from a particular time goes to zero
		
		if (seconds > 0)
		{
			guiText.text = seconds.ToString("F0");
		}
		else{
			Application.LoadLevel ("GameOver");
		}
*/		
		
		/* // Do something when time runs out
		else // timer is <= 0
		{
			guiText.text = "TIME OVER\nPress X to restart"; // when it goes to the end-0,game ends (shows text: time over...)
			
		if (Input.GetKeyDown("x")) // And then i can restart game: pressing restart.
		{
			Application.LoadLevel(Application.loadedLevel); // reload the same level
		}*/
		
	}

	public void stopTimer(){
		runTimer=false;
	}

	public void startTimer(){
		runTimer=true;
	}

	override public string ToString(){
		string s;

		if(seconds > 9){
			s = seconds.ToString();
		} else {
			s = "0"+seconds.ToString();
		}

		int ms = Mathf.FloorToInt(miliseconds);

		if(miliseconds <= 0){
			s = s+":00";
		}else if(ms > 9){
			s = s+":"+ms.ToString();
		}else{
			s = s+":0"+ms.ToString();
		}

		return s;
	}
}