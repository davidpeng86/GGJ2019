using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class turnLightsOn : MonoBehaviour {

	SpriteRenderer m_SpriteRenderer;
	Color newColor;
	//float r,g,b;

	// Use this for initialization
	void Start () {
		Screen.SetResolution(828, 1792, true, 60);
		m_SpriteRenderer = GetComponent<SpriteRenderer>();
		newColor = m_SpriteRenderer.color;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
			newColor = new Color(255 - m_SpriteRenderer.color.r,255 - m_SpriteRenderer.color.g,255 - m_SpriteRenderer.color.b);
            Debug.Log("Click");
        }
		m_SpriteRenderer.color = newColor;
	}
}
