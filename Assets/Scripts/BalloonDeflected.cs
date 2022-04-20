using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//not using this 
public class BalloonDeflected : Objects
{
    public override void UseObject()
    {
        //base calls anything thats in the parent class
        base.UseObject(); //for example: the debug "Object being used" is called because of base.useobject();

        Debug.Log("BalloonDeflected being used.");


    }
}

