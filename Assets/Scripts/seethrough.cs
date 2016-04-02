using UnityEngine;
using System.Collections;

public class seethrough : MonoBehaviour {
 
    public Color transparentColor;
    private Color m_InitialColor;
    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        m_InitialColor = renderer.material.color;
    }

    public void SetTransparent()
    {
        renderer.material.color = transparentColor;
    }

    public void SetToNormal()
    {
        renderer.material.color = m_InitialColor;
    }
}

