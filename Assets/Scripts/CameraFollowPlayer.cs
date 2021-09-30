using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] float zRemoteLoc = 16.0f;
    [SerializeField] float yPos = 7.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Camera position is adjusted in accordance the player
        float zPos = player.transform.position.z - zRemoteLoc;
        Vector3 cameraPositon = new Vector3(player.transform.position.x, yPos, zPos);
        transform.position = cameraPositon;
    }
}
