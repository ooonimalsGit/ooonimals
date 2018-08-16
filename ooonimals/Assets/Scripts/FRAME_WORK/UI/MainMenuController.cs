using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[AddComponentMenu("UI/Generic Main Menu")]

public class MainMenuController : MonoBehaviour
{
	public int whichMenu= 0;	
	public GUISkin menuSkin;		
	public string gameDisplayName= "OooNimals";
	public string gamePrefsName= "DefaultGame";	
	public float default_width= 720;
	public float default_height= 600;		
	public string[] gameLevels;

	private SceneManagerCustom sceneManager;
    private Fading fading;
    private float fadeTime;
	
	public bool useSceneManagerToStartgame;
	public bool isLoading;

    void Start()
	{		
        sceneManager = FindObjectOfType<SceneManagerCustom>();
		// now tell scene manager about the levels we have in this game
        if(sceneManager)sceneManager.levelNames = gameLevels;

        CustomUserManager customUserManager = FindObjectOfType<CustomUserManager>();
	}
	
	void OnGUI()
	{
		float scaleX = Screen.width / default_width; 
		float scaleY = Screen.height / default_height; 
		GUI.matrix = Matrix4x4.TRS (new Vector3(0, 0, 0), Quaternion.identity, new Vector3 (scaleX, scaleY, 1));
				
		// set the GUI skin to use our custom menu skin
		GUI.skin= menuSkin;		
		switch(whichMenu)
		{
		case 0:	
			GUI.BeginGroup (new Rect (default_width / 2 - 150, default_height / 2 - 250, 500, 500));

			// All rectangles are now adjusted to the group. (0,0) is the topleft corner of the group.
					
		//GUI.Label(new Rect( 0, 75, 300, 50 ), gameDisplayName, "textarea");
			
			if(!isLoading && GUI.Button(new Rect( 0, 150, 300, 40 ),"USER PROFILE", "button"))
			{				
				if(!useSceneManagerToStartgame)
				{
                    PlayBtnClick(transform.position);
                    LoadLevel( "User_Profile" );
				//} else {
					//isLoading=true;
					//Debug.Log ("Telling scene Manager to load next level..");
					//sceneManager.GoNextLevel();	
				}
			}
			
            if (!isLoading && GUI.Button(new Rect(0, 200, 300, 40), "CHARM CATALOG", "button") )
            {               
                if (!useSceneManagerToStartgame)
                {
                    PlayBtnClick(transform.position);
                    LoadLevel("Charm_Catalog");
                }
            }
            
            if (!isLoading && GUI.Button(new Rect(0, 250, 300, 40), "NOTIFICATION SETTINGS", "button"))
            {
               
                if (!useSceneManagerToStartgame)
                {
                    PlayBtnClick(transform.position);
                    LoadLevel("Notification_Settings");
                }                
            }
            
            if (!isLoading && GUI.Button(new Rect(0, 300, 300, 40), "YOUTUBE", "button") )
            {               
                if (!useSceneManagerToStartgame)
                {
                    PlayBtnClick(transform.position);
                    LoadLevel("YouTube");
                }
            }
            
            if (!isLoading && GUI.Button(new Rect(0, 350, 300, 40), "WISH LIST", "button") )
            {               
                if (!useSceneManagerToStartgame)
                {
                    PlayBtnClick(transform.position);
                    LoadLevel("Wish_List");
                }
            }			
			GUI.EndGroup ();
			
		break;
		
		case 1:
			GUI.BeginGroup (new Rect (default_width / 2 - 150, default_height / 2 - 250, 500, 500));
			GUI.Label(new Rect( 0, 50, 300, 50 ), "USER PROFILE", "textarea");			
			if(GUI.Button(new Rect(0, 250, 300, 40 ),"MAIN MENU"))
			{
               PlayBtnClick(transform.position);
               LoadLevel("Main_Menu");
			}				
			GUI.EndGroup ();			
		break;
		
		case 2:
			GUI.BeginGroup (new Rect (default_width / 2 - 150, default_height / 2 - 250, 500, 500));
			GUI.Label(new Rect( 0, 50, 300, 50 ), "CHARM CATALOG", "textarea");			
            if (GUI.Button(new Rect(0, 250, 300, 40), "MAIN MENU"))
            {
                PlayBtnClick(transform.position);
                LoadLevel("Main_Menu");
            }			
			GUI.EndGroup ();			
		break;
		
		case 3:
			GUI.BeginGroup (new Rect (default_width / 2 - 150, default_height / 2 - 250, 500, 500));
			GUI.Label(new Rect( 0, 50, 300, 40 ), "NOTIFICATION SETTINGS", "textarea");            
            if (GUI.Button(new Rect(400, 440, 100, 40), "MAIN MENU"))
            {
                PlayBtnClick(transform.position);
                LoadLevel("Main_Menu");
            }			
			GUI.EndGroup ();
		break;
        
        case 4:
            GUI.BeginGroup (new Rect (default_width / 2 - 150, default_height / 2 - 250, 500, 500));
            GUI.Label(new Rect( 0, 50, 300, 50 ), "YOUTUBE", "textarea");            
            if (GUI.Button(new Rect(0, 250, 300, 40), "MAIN MENU"))
            {
                PlayBtnClick(transform.position);
                LoadLevel("Main_Menu");
            }            
            GUI.EndGroup ();
        break;
		
		case 5:
			GUI.BeginGroup (new Rect (default_width / 2 - 150, default_height / 2 - 250, 500, 500));
			GUI.Label(new Rect( 0, 50, 300, 50 ), "WISH LIST", "textarea");            
            if (GUI.Button(new Rect(0, 250, 300, 40), "MAIN MENU"))
            {
               PlayBtnClick(transform.position);
               LoadLevel("Wish_List");
            }			
			GUI.EndGroup ();
		break;
		
		} 
	}

    private void PlayBtnClick(Vector3 pos){
        BaseSoundController.Instance.PlaySoundByIndex(0, pos);
    }
	
	private void LoadLevel( string whichLevel )
	{
        sceneManager.StartLoadLevel(whichLevel);
	}
	
	void GoMainMenu()
	{
		whichMenu=0;	
	}   
	
	void ConfirmExitGame()
	{
		whichMenu=2;
	}
	
	void ExitGame()
	{
		// tell level loader to shut down the game for us
		Application.Quit();
	}
}
