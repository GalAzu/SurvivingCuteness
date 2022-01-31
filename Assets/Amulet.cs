using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amulet : MonoBehaviour
{
    private PlayerEvents pc;
    public FMOD.Studio.EventInstance amuletSound;
    [SerializeField]private float fallSpeed;
    private void Start()
    {
        amuletSound = FMODUnity.RuntimeManager.CreateInstance("event:/Player/_Amulet");
        amuletSound.start();
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.down *fallSpeed* Time.deltaTime);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(amuletSound, GetComponent<Transform>(), GetComponent<Rigidbody2D>());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            pc = FindObjectOfType<PlayerEvents>();
            pc.Amulet.Invoke();
            Destroy(this.gameObject);
            amuletSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            FMODUnity.RuntimeManager.PlayOneShot("event:/Player/AmuletTaken");
        }
    }
}
