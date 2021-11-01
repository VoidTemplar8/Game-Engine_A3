using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{

    static List<Transform> items;

    public static void PlaceObject(Vector3 position, Color colour, Transform item)
    {
        Transform newCube = Instantiate(item, position, Quaternion.identity);
        newCube.GetComponentInChildren<MeshRenderer>().material.color = colour;
        if (items == null)
        {
            items= new List<Transform>();
        }
        items.Add(newCube);
    }

    public static void RemoveObject(Vector3 position, Color colour)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].position == position && items[i].GetComponentInChildren<MeshRenderer>().material.color == colour)
            {
                GameObject.Destroy(items[i].gameObject);
                items.RemoveAt(i);
                break;
            }
        }
    }
}
