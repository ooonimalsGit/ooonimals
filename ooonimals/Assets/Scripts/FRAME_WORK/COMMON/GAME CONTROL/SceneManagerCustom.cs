using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneManagerCustom : MonoBehaviour
{
	public string[] levelNames;
    public int gameLevelNum;
    private Fading fading;
    private float fadeTime; 
	
	public void Start ()
	{
		// keep this object alive

		DontDestroyOnLoad (gameObject);

        fading = FindObjectOfType<Fading>();
        fading.BeginFade(Fading.FadeDirection.fadeIn);
        Invoke("DelayToMainMenu", 1.5f);
	}

    private void DelayToMainMenu()
    {
        StartCoroutine("LoadLevel", "Main_Menu");
    }

    public void StartLoadLevel( string sceneName )
    {
        StartCoroutine("LoadLevel", sceneName);
    }
	
    IEnumerator LoadLevel( string sceneName )
	{
        fadeTime = fading.BeginFade(Fading.FadeDirection.fadeOut);
        yield return new WaitForSeconds(fadeTime);
		SceneManager.LoadScene( sceneName );
        Invoke("FadinAfterLoad", fadeTime/2);
	}

    private void FadinAfterLoad(){
        fading.BeginFade(Fading.FadeDirection.fadeIn);
    }
		
	public void ResetGame()
	{
		// reset the level index counter
		gameLevelNum = 0;
	}
	
	public void GoNextLevel()
	{
		// if our index goes over the total number of levels in the array, we reset it
        if( gameLevelNum >= levelNames.Length ){
            gameLevelNum = 0;
        }
			
		
		// load the level (the array index starts at 0, but we start counting game levels at 1 for clarity's sake)
		LoadLevel( gameLevelNum );
		gameLevelNum++;
	}
	
	private void LoadLevel( int indexNum )
	{

        StartCoroutine("LoadLevel", levelNames[indexNum]);
		// load the game level
		//xLoadLevel( levelNames[indexNum] );
	}
}
