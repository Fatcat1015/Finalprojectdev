using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//not using this 
public class BalloonFloating : Objects
{
    public override void UseObject()
    {
        
        base.UseObject();
        //base calls anything thats in the parent class
        //for example: the debug "Object being used" is called because of base.useobject();

        Debug.Log("Knife being used.");



        //For each object we have, write code below that's the behavior of the object when it's used

        //BalloonDeflected balloonDeflected = FindObjectOfType<BalloonDeflected>();
        //BalloonDeflecte.EnableVisibilityInScene();
    }
}