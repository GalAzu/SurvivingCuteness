using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsManager : MonoBehaviour
{

    public int PowerUpID;
    public PlayerControls Player;
    public GameObject _newShield;
    public IPowerUps _IpowerupsID;
    public bool _OnShield;
    private FMOD.Studio.EventInstance _shieldSound;
    public Vector3 _playerVector;

    private void Awake()
    {
        Player = FindObjectOfType<PlayerControls>();
        _shieldSound = FMODUnity.RuntimeManager.CreateInstance("event:/Player/_shield");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _IpowerupsID = collision.GetComponent<IPowerUps>();
        if(collision.tag == "PowerUp")
        {
            PowerUpID = _IpowerupsID.PowerUpID();
            Destroy(collision.gameObject);
            switch (PowerUpID)
            {
                case 0:
                    if(_OnShield == false)
                    {
                        ShieldIsOn();
                    }
                    else
                    {
                        Debug.Log("SHIELD IS ALREADY ACTIVATED");
                    }
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }
    }
    void ShieldIsOn()
    {
        _shieldSound.start();
        _shieldSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(Player.transform.position));
        _OnShield = true;
        _newShield.gameObject.SetActive(true);
        Invoke("ShieldisOff", 7);
    }
    void ShieldisOff()
    {
        _shieldSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        _shieldSound.release();
        _newShield.gameObject.SetActive(false);
        _OnShield = false;
        print("shield is off");
    }
}
