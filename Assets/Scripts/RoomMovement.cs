using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMovement : MonoBehaviour
{
    public Room currentRoom;
    public int horizontal_shift = 1;

    public void Awake()
    {
        Camera.main.transform.position = currentRoom.background.position + new Vector3 (horizontal_shift, 0, -1);
    }

    private void Update()
    {


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

}