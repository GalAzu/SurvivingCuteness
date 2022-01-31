using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStatic : MonoBehaviour
{
    public Transform player;
    [SerializeField]
    private float Yoffset;
    public PlayerControls _player;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(player.transform.position.x, 1.70f, -1); ;
        Yoffset = 3.5f;


    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, -1);

    }
}