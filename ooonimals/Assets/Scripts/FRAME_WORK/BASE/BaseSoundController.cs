using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Base/Sound Controller")]

public class BaseSoundController : MonoBehaviour
{
    public static BaseSoundController Instance;
    public AudioClip[] GameSounds;
    public float volume = 1;

    private int totalSounds;
	private ArrayList soundObjectList;
	private SoundObject tempSoundObj;

	public void Awake() 
	{
		Instance= this;
	}
	
	void Start ()
	{		
		soundObjectList=new ArrayList();       

		// make sound objects for all of the sounds in GameSounds array
		foreach(AudioClip theSound in GameSounds)
		{
			tempSoundObj= new SoundObject(theSound, theSound.name, volume);
			soundObjectList.Add(tempSoundObj);
            totalSounds++;

		}
	}
	
	public void PlaySoundByIndex(int anIndexNumber, Vector3 aPosition)
	{
		// make sure we're not trying to play a sound indexed higher than exists in the array
		if(anIndexNumber>soundObjectList.Count)
		{
			Debug.LogWarning("BaseSoundController>Trying to do PlaySoundByIndex with invalid index number. Playing last sound in array, instead.");
			anIndexNumber= soundObjectList.Count-1;
		}
		
		tempSoundObj= (SoundObject)soundObjectList[anIndexNumber];
		tempSoundObj.PlaySound(aPosition);	
	}
}
