using UnityEngine;
using System.Collections;

public class Edges : MonoBehaviour
{
    public static float leftEdge, rightEdge, botEdge, topEdge,pix_size;
    
    void Awake ()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x;
        rightEdge = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
        topEdge = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y;
        botEdge = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y;
        pix_size = (topEdge - botEdge) / Screen.height;
    }
	
	// Update is called once per frame
	void Update ()
    {
        topEdge = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y;
        botEdge = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y;
    }
}
