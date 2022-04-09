using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMovement : MonoBehaviour
{
    public Room currentRoom;
   //[Header("Set Positions")]
   // public Vector3 rightRoomPosition;
   // public Vector3 leftRoomPosition;
    //public Vector3 backRoomPosition;
   // public Vector3 startRoomPosition;

   // private Vector3 roomToTheRight;
   // private Vector3 roomToTheLeft;
    //private Vector3 currentRoom;

    public void Awake()
    {
        Camera.main.transform.position = currentRoom.background.position + new Vector3 (0, 0, -1);
    }

    private void Update()
    {
        /*if (currentRoom == startRoomPosition)
        {
            roomToTheRight = rightRoomPosition;
            roomToTheLeft = leftRoomPosition;
        }*/

    }

    public void goRightRoom()
    {
        Room rightRoom = currentRoom.roomToTheRight;
        currentRoom = rightRoom;

        Camera.main.transform.position = currentRoom.background.position + new Vector3(0, 0, -1);
  
    }

    public void goLeftRoom()
    {
        Room leftRoom = currentRoom.roomToTheLeft;
        currentRoom = leftRoom;

        Camera.main.transform.position = currentRoom.background.position + new Vector3(0, 0, -1);
    
    }

}