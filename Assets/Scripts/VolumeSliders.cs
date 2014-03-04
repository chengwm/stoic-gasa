using UnityEngine;
using System.Collections;

public class VolumeSliders : MonoBehaviour {

	public float effectsVolume = 0.0F;
	public float musicVolume = 0.0F;
	private float musicXPos = Screen.width;
	private float musicYPos = Screen.height;
	private float effectsXPos;
	private float effectsYPos;

	void Start(){
		effectsXPos = musicXPos;
		effectsYPos = musicYPos;
		musicXPos = musicXPos * (float)0.25;
		musicYPos = musicYPos * (float)0.43;
		effectsXPos = effectsXPos * (float)0.25;
		effectsYPos = effectsYPos * (float)0.62;
	}

	void OnGUI() {
		musicVolume = GUI.HorizontalSlider(new Rect(musicXPos, musicYPos, 300, 30), musicVolume, 0.0F, 10.0F);
		effectsVolume = GUI.HorizontalSlider(new Rect(effectsXPos, effectsYPos, 300, 30), effectsVolume, 0.0F, 10.0F);
	}
}
