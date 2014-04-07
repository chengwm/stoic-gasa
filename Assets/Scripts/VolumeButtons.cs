using UnityEngine;
using System.Collections;

public class VolumeButtons : MonoBehaviour {

	private float effectsVolume = 5.0F;
	private float musicVolume = 5.0F;
	
	public Texture2D button1;
	public Texture2D button2;
	
	public TextMesh musicVolumeText;
	public TextMesh effectsVolumeText;
	
	public AudioClip menuButton;

	void Start(){
		if (PlayerPrefs.HasKey ("effectsVolume")) {
			effectsVolume = PlayerPrefs.GetInt ("effectsVolume");
		}
		if (PlayerPrefs.HasKey ("musicVolume")) {
			musicVolume = PlayerPrefs.GetInt ("musicVolume");
		}
		AudioListener.volume = effectsVolume / 10;
	}

	void OnMouseUp(){
		if (this.name == "MusicUp"){
			guiTexture.texture = button1;
			audio.PlayOneShot(menuButton);
			if(musicVolume < 10)
			{
				musicVolume+=1;
				PlayerPrefs.SetInt ("musicVolume", (int)musicVolume);
			}
		}
		else if (this.name == "MusicDown"){
			guiTexture.texture = button1;
			audio.PlayOneShot(menuButton);
			if(musicVolume > 0)
			{
				musicVolume-=1;
				PlayerPrefs.SetInt ("musicVolume", (int)musicVolume);
			}
		}
		else if (this.name == "EffectsUp"){
			guiTexture.texture = button1;
			audio.PlayOneShot(menuButton);
			if(effectsVolume < 10)
			{	
				effectsVolume+=1;
				AudioListener.volume += 0.1F;
				PlayerPrefs.SetInt ("effectsVolume", (int)effectsVolume);
			}
			else if(effectsVolume == 10)
			{
				effectsVolume = 10;
				AudioListener.volume = 1.0F;
				PlayerPrefs.SetInt ("effectsVolume", (int)effectsVolume);
			}
		}
		else if (this.name == "EffectsDown"){
			guiTexture.texture = button1;
			audio.PlayOneShot(menuButton);
			if(effectsVolume > 0)
			{
				effectsVolume-=1;
				AudioListener.volume -= 0.1F;
				PlayerPrefs.SetInt ("effectsVolume", (int)effectsVolume);
			}
			else if(effectsVolume == 0)
			{
				effectsVolume = 0;
				AudioListener.volume = 0.0F;
				PlayerPrefs.SetInt ("effectsVolume", (int)effectsVolume);
			}
		}
	}
	
	void OnMouseDown(){
		if (guiTexture.name == "MusicUp")
			guiTexture.texture = button2;
		else if (guiTexture.name == "MusicDown")
			guiTexture.texture = button2;
		else if (guiTexture.name == "EffectsUp")
			guiTexture.texture = button2;
		else if (guiTexture.name == "EffectsDown")
			guiTexture.texture = button2;
	}
	
	void Update()
	{
		if (PlayerPrefs.HasKey ("effectsVolume")) {
			effectsVolume = PlayerPrefs.GetInt ("effectsVolume");
		}
		if (PlayerPrefs.HasKey ("musicVolume")) {
			musicVolume = PlayerPrefs.GetInt ("musicVolume");
		}
	
		musicVolumeText.text = musicVolume.ToString ();
		effectsVolumeText.text = effectsVolume.ToString ();
	}
}
