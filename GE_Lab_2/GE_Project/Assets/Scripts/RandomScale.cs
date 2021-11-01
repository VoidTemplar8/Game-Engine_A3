using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class RandomScale : MonoBehaviour
{
    //Created a Struct within DLL to create all the Vector3s
     [DllImport("MidTerm")]
     public static extern Vector3 RandomVector3(bool setNewSeed); //Returns a Vector 3 with scales no larger than 5

    public List<GameObject> disappearingPlat;
    public List<GameObject> spinningPlat;
    public GameObject player;
    bool needsNewSeed = true;
    void Start()
    {
       Shuffle();
    }

    void Update() 
    {
        //When the player dies, reshuffle the map
        if(player.transform.position.y < -49f)
        {
            Shuffle();
        }   
    }
    void Shuffle()
    {
        if(RandomVector3(false).x == -1)
        {
            return;
        }
         //These are the disappearing platforms they should be scaled down
        foreach(GameObject dPlat in disappearingPlat)
        {
            dPlat.transform.localScale = RandomVector3(needsNewSeed) / 5f;
            needsNewSeed = false;
        }
        //scaled up
        foreach(GameObject sPlat in spinningPlat)
        {
            Vector3 vec = RandomVector3(false) * 5;
            sPlat.transform.localScale = new Vector3(vec.x, 0.1f, vec.y);
        }
    }
}
