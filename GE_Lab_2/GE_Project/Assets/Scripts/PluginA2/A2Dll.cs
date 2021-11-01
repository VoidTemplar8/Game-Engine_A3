using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class A2Dll : MonoBehaviour
{
    public Color colour1;
    public Color colour2;
    public Color colour3;
    public Color colour4;
    public Color colour5;
    public Color colour6;
    public Color colour7;
    public Color colour8;
    public Color colour9;
    public Color colour10;
    MeshRenderer Renderer;

    [DllImport("PluginA2")]
    private static extern int ChangeColour();

    // Start is called before the first frame update
    void Start()
    {
        if (ChangeColour() == 1)
        {
            Renderer = GetComponent<MeshRenderer>();
            Renderer.material.color = colour1;
        }
        if (ChangeColour() == 2)
        {
            Renderer = GetComponent<MeshRenderer>();
            Renderer.material.color = colour2;
        }
        if (ChangeColour() == 3)
        {
            Renderer = GetComponent<MeshRenderer>();
            Renderer.material.color = colour3;
        }
        if (ChangeColour() == 4)
        {
            Renderer = GetComponent<MeshRenderer>();
            Renderer.material.color = colour4;
        }
        if (ChangeColour() == 5)
        {
            Renderer = GetComponent<MeshRenderer>();
            Renderer.material.color = colour5;
        }
        if (ChangeColour() == 6)
        {
            Renderer = GetComponent<MeshRenderer>();
            Renderer.material.color = colour6;
        }
        if (ChangeColour() == 7)
        {
            Renderer = GetComponent<MeshRenderer>();
            Renderer.material.color = colour7;
        }
        if (ChangeColour() == 8)
        {
            Renderer = GetComponent<MeshRenderer>();
            Renderer.material.color = colour8;
        }
        if (ChangeColour() == 9)
        {
            Renderer = GetComponent<MeshRenderer>();
            Renderer.material.color = colour9;
        }
        if (ChangeColour() == 10)
        {
            Renderer = GetComponent<MeshRenderer>();
            Renderer.material.color = colour10;
        }
    }

}