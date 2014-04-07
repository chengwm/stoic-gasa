using UnityEngine;
using System.Collections;

public class KeepMusicOverScenes : MonoBehaviour {

	private static KeepMusicOverScenes instance = null;
	public static KeepMusicOverScenes Instance{
		get { return instance; }
	}
	public AudioClip menuMusic;
	
	void Start(){
		audio.clip = menuMusic;
		if(Application.loadedLevelName != "mainHall"){
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

