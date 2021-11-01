using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  InstatiatePlat : CommandInterface
{
    private GameObject obj;
    private GameObject objectRef;
    private Vector3 pos;

    FactoryDesign<MonoBehaviour> factoryRef;
    public InstatiatePlat(FactoryDesign<MonoBehaviour> factory, Vector3 posOfObj)
    {
        factoryRef = factory;
        pos = posOfObj;
    }
    void  CommandInterface.Execute()
    {
        //objectRef = GameObject.Instantiate(obj, pos, Quaternion.identity);
        objectRef = factoryRef.GetNewInstance().gameObject;
        objectRef.transform.position = pos;
    }
    void CommandInterface.Undo()
    {
        if(objectRef != null)
        {
            GameObject.Destroy(objectRef);
        }
    }
}
