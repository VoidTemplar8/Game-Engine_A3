using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScript : MonoBehaviour
{
    public GameObject winText;


    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            winText.GetComponent<TextMesh>().text = "You win!!!";
            Timer.theEnd = true;
        }
    }
}
