using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacerCommand : CommandInterface
{
    Vector3 position;
    Color colour;
    Transform item;

    public ObjectPlacerCommand(Vector3 position, Color colour, Transform item)
    {
        this.position = position;
        this.colour = colour;
        this.item = item;
    }

    public void Execute()
    {
        ObjectPlacer.PlaceObject(position, colour, item);
    }

    public void Undo()
    {
        ObjectPlacer.RemoveObject(position, colour);
    }

}
