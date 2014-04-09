using UnityEngine;
using System.Collections;

public class KeepMusicOverScenes : MonoBehaviour {

	private static KeepMusicOverScenes instance = null;
	public static KeepMusicOverScenes Instance{
		get { return instance; }
	}
	public AudioClip gameMusic;
	
	void Start(){
		audio.clip = gameMusic;
		if(Application.loadedLevelName == "mainHall"){
			audio.Play ();
		}
		
		if(instance != null && instance != this){
			Destroy (this.gameObject);
			return;
		}
		else{
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
}

