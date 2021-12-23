using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("MapboxAstronaut").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(player.position.x - 100.4657f, player.position.x + 327.6f, player.position.x - 445.4681f);
        transform.position = new Vector3(player.position.x - 100.4657f, transform.position.y, transform.position.z);
    }
}
