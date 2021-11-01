using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : CommandInterface
{
    Vector3 oldPos;
    Vector3 newPos;
    GameObject referenceObject;

    FactoryDesign<MonoBehaviour> factoryRef;
    public ObjectMovement(Vector3 _newPos, Vector3 _oldPos, GameObject _ref, FactoryDesign<MonoBehaviour> factory)
    {
        newPos = _newPos;
        oldPos = _oldPos;
        referenceObject = _ref;
    }
    void CommandInterface.Execute()
    {
        if(referenceObject != null)
        {
            referenceObject.transform.position = newPos;
        }
    }
    void CommandInterface.Undo()
    {
        if(referenceObject != null)
        {
            referenceObject.transform.position = oldPos;
        }
    }
}
