using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScale : CommandInterface
{
    Vector3 oldScale;
    Vector3 newScale;
    GameObject referenceObject;
    public ObjectScale(Vector3 _newScale, Vector3 _oldScale, GameObject _ref)
    {
        newScale = _newScale;
        oldScale = _oldScale;
        referenceObject = _ref;
    }
    void CommandInterface.Execute()
    {
        referenceObject.transform.localScale = newScale;
    }
    void CommandInterface.Undo()
    {
        referenceObject.transform.localScale = oldScale;
    }
}
