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

    //saving these files to a text file to store data on command rather than automatically (from lab 7 demo)
    public override string ToString()
    {
        return "this will check what events occur in the editor on your command";
    }
}
