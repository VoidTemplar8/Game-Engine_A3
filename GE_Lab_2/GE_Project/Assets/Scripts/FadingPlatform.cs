using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingPlatform : MonoBehaviour
{
    public float fadeSpeed = 0.33f; // 1f = one second to fade
    public float returnSpeed = 0.5f; // 1f = one second to reappear
    public float delayUnFade = 2f; //1f = one second between when it stops disappearing and starts reappearing again
    bool fading = false;
    bool startTimer = false; //Used for the delay between disappearing and reappearing
    float amountFaded = 1f; //Keeping track how much it has faded (1f = 100% opacity, 0f = 0% opacity, completely clear)

    float freezeTimer = 0f;
    

    Material mat;
    
    void Start()
    {
        mat = this.GetComponent<Renderer>().material;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(startTimer)
        {
            freezeTimer += Time.deltaTime;
            if(freezeTimer >= delayUnFade)
            {
                freezeTimer = 0f;
                startTimer = false;
            }
        }
        //The part that will make the platform fade once the character lands on the platform
        if(fading)
        {
            Color col = mat.color;
            amountFaded -= fadeSpeed * Time.deltaTime;
            //This terribleness is because pointers can't exist
            col.a = amountFaded;
            mat.color = col;
            startTimer = true;
            //So alpha doesn't go negative
            if(amountFaded <= 0)
            {
                fading = false;
                this.GetComponent<MeshCollider>().enabled = false;
            }
        }
        //Reappearing part so the platform isn't gone forever
        else if(amountFaded <= 1f && !startTimer)
        {
            Color col = mat.color;
            amountFaded += fadeSpeed * Time.deltaTime;
            //This terribleness is because pointers can't exist
            col.a = amountFaded;
            mat.color = col;
            //So alpha doesn't go negative
            if(amountFaded <= 0.1)
            {
                fading = false;
                this.GetComponent<MeshCollider>().enabled = true;
            }
        }
    }

    void OnCollisionStay(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            fading = true;
            //startTimer = false;
            freezeTimer = 0f;
        }
    }
     void OnCollisionExit(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            //This is jank but it works
            startTimer = false;
            if(fading)
            {
                startTimer = true;
            }
            fading = false;
            freezeTimer = 0f;
        }
    }
}
