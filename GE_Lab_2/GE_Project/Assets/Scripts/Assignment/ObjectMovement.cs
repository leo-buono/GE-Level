using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : CommandInterface
{
    Vector3 oldPos;
    Vector3 newPos;
    GameObject referenceObject;
    public ObjectMovement(Vector3 _newPos, Vector3 _oldPos, GameObject _ref)
    {
        newPos = _newPos;
        oldPos = _oldPos;
        referenceObject = _ref;
    }
    void CommandInterface.Execute()
    {
        referenceObject.transform.position = newPos;
    }
    void CommandInterface.Undo()
    {
        referenceObject.transform.position = oldPos;
    }
}
