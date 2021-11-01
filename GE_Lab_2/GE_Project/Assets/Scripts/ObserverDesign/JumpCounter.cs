using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpCounter : MonoBehaviour
{
    private void OnDisable() 
    {
        PlayerMovement.jumpEvent -= OnJump;
    }
    private void OnEnable() 
    {
        PlayerMovement.jumpEvent += OnJump;
    }
    int jumpAmount = 0;
    void OnJump()
    {
        ++jumpAmount;
        //update tge text
        this.GetComponent<Text>().text = "Jump Count : " + jumpAmount;
    }

}
