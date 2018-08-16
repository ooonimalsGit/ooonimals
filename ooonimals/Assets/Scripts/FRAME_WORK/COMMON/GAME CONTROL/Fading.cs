using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : MonoBehaviour {

    public Texture2D fadeOutTexture;    // the texture that will overlay the screen. This can be a black image or a loading graphic.
    public float fadeSpeed = 0.8f;      // the fading speed.

    private int drawDepth = -1000;      // the texture's order in the draw hierarchy: low number renders on top
    private float alpha = 1.0f;         // the texure's alpha value between 0 and 1
    private int fadeDir = -1;

    [HideInInspector]
    public enum FadeDirection {fadeOut=0, fadeIn}
    public FadeDirection fadeDirection;

    private void Start()
    {       
       BeginFade(Fading.FadeDirection.fadeIn);
    }

    private void OnGUI()
	{
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        // force (clamp) the number between 0 and 1 because GUI.color uses alpha values 0 and 1.
        alpha = Mathf.Clamp01(alpha);

        // Set color of our GUI (in this case our texture). Color values remain the same & the Alpha is set to the alpha var.
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
	}

    public float BeginFade(FadeDirection direction){
        fadeDir = direction == FadeDirection.fadeIn ? -1 : 1;
        return (fadeSpeed);
    }
}
