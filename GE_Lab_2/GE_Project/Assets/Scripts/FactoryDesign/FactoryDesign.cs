using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryDesign<T> : MonoBehaviour where T : MonoBehaviour
{
    //https://www.patrykgalach.com/2019/03/28/implementing-factory-design-pattern-in-unity/
    [SerializeField]
    public T prefab;
    public T GetNewInstance()
    {
        return Instantiate(prefab);
    }
}

