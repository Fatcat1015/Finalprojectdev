using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMovement : MonoBehaviour
{
    public Room currentRoom;
    public int horizontal_shift = 1;

    public bool isZoomedin = false;
    public Vector3 beforezoom;

    private GameObject leftA;
    private GameObject rightA;
    private GameObject backA;

    public void Awake()
    {
        Camera.main.transform.position = currentRoom.background.position + new Vector3 (horizontal_shift, 0, -1);
        leftA = GameObject.Find("Left Arrow");
        rightA = GameObject.Find("RightArrow");
        backA = GameObject.Find("BackArrow");
        backA.SetActive(false);

    }

    public void goRightRoom()
    {
        Room rightRoom = currentRoom.roomToTheRight;
        currentRoom = rightRoom;

        Camera.main.transform.position = currentRoom.background.position + new Vector3(horizontal_shift, 0, -1);
  
    }

    public void goLeftRoom()
    {
        Room leftRoom = currentRoom.roomToTheLeft;
        currentRoom = leftRoom;

        Camera.main.transform.position = currentRoom.background.position + new Vector3(horizontal_shift, 0, -1);
    
    }

    public void zoomin(Transform pos)
    {
        beforezoom = currentRoom.background.position + new Vector3(horizontal_shift, 0, -1);
        Camera.main.transform.position = new Vector3(pos.position.x+horizontal_shift, pos.position.y, -10);
        backA.SetActive(true);
        leftA.SetActive(false);
        rightA.SetActive(false);

        isZoomedin = true;
    }

    public void zoomout()
    {
        if (beforezoom != null)
        {
            Camera.main.transform.position = beforezoom;
            backA.SetActive(false);
            leftA.SetActive(true);
            rightA.SetActive(true);

            isZoomedin = false;

        }
    }

}