using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[AddComponentMenu("Base/GameController")]

public class BaseGameController : MonoBehaviour

{
    private bool paused;

    public virtual void PlayerLostLife ()
	{
		// deal with player life lost (update U.I. etc.)
	}
	
	public virtual void SpawnPlayer ()
	{
		// the player needs to be spawned
	}
	
	public virtual void Respawn ()
	{
		// the player is respawning
	}
	
	public virtual void StartGame()
	{
		// do start game functions
	}

		
    public bool Paused
    {
        get 
        { 
            // get paused
            return paused; 
        }
        set
        {
            // set paused 
            paused = value;

			if (paused)
			{
                // pause time
                Time.timeScale= 0f;
			} else {
                // unpause Unity
				Time.timeScale = 1f;
            }
        }
    }
	
}
