using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class cameraControl : MonoBehaviour
{
    public Transform player;
    [SerializeField] private float boxCameraY;
    [SerializeField] private float cameraSpeedFollow;


    void Update()
    {
        if ((player.position.y > transform.position.y + boxCameraY) || (player.position.y < transform.position.y - boxCameraY))
        {
            var newVector3 = new Vector3(transform.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newVector3, cameraSpeedFollow * Time.deltaTime);
        }
    }

}
