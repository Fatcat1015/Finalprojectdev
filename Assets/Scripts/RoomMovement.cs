using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMovement : MonoBehaviour
{
    [Header("Set Positions")]
    public Vector3 rightRoomPosition;
    public Vector3 leftRoomPosition;
    public Vector3 backRoomPosition;
    public Vector3 startRoomPosition;

    private Vector3 roomToTheRight;
    private Vector3 roomToTheLeft;
    private Vector3 currentRoom;

    public void Awake()
    {
        currentRoom = startRoomPosition;
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
        Camera.main.transform.position = roomToTheRight;
    }

    public void goLeftRoom()
    {
        Camera.main.transform.position = roomToTheLeft;
    }

}