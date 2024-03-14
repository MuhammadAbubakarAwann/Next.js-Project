
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSmoothing;
    public GameObject Player;
    private float camPos;
    private Vector3 playerPosition;
    public float offsetX;
    public float offsetY;


    private void Start()
    {

        playerPosition = new Vector3(Player.transform.position.x, Player.transform.position.y, transform.position.z);
    }

    private void Update()
    {
  

        playerPosition = new Vector3(Player.transform.position.x+offsetX, Player.transform.position.y+offsetY, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, playerPosition, cameraSmoothing * Time.deltaTime);
    }
}
