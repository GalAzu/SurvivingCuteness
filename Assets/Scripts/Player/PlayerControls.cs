using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
   
{
    [SerializeField][Range(0, 100)]
    public int health;
    private PowerUpsManager pm;
    public bool _poisoned ;
    public bool onInteraction;
    public bool _canDoubleJump = false;
    public bool _isGrounded = true;
    public float speed = 5;
    public float JumpForce = 2;
    public Animator animator;
    public Animator Explosion;
    public Rigidbody2D rb;
    public SpriteRenderer Char;
    public int _health = 100;
    private IDamagable damageable;
    private IActionable actionable;
    private IPowerUps PowerUpID;
    public UImanager UImanager;
    [SerializeField]
    public AudioDataPreset audioplayer;
    public FMOD.Studio.EventInstance bgm;
    private FMOD.Studio.EventInstance ambiance;
    public int coins = 0;
    void Start()
    {
        audioplayer = FindObjectOfType<AudioDataPreset>();
        bgm = FMODUnity.RuntimeManager.CreateInstance("event:/Scene1/Main Theme");
        ambiance = FMODUnity.RuntimeManager.CreateInstance("event:/Scene1/_wind");
        _health = 100;
        Char = GetComponent<SpriteRenderer>();
        UImanager = GameObject.FindObjectOfType<UImanager>();
        pm = GameObject.FindObjectOfType<PowerUpsManager>();
        UImanager.DeathText.SetActive(false);
        UImanager.TimeOutText.SetActive(false);
        UImanager.LoseCanvas.SetActive(false);

        bgm.start();
        ambiance.start();


    }

    void FixedUpdate()
    {
        Movement();
        Interaction();
        Death();
        health = _health;
        bgmBehaviour();
        if (_health <= 0)
        {
            _health = 0;
        }
        if(UImanager.Timer <= 0)
        {
            UImanager.Timer = 0;
        }
    }

    void Movement ()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float movement = horizontalInput * speed * Time.deltaTime;
        transform.Translate(movement, 0, 0);
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        animator.SetBool("isGrounded", _isGrounded);

        if (horizontalInput < 0)
        {
            Char.flipX = true;
        }
        if(horizontalInput>0)
        {
            Char.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            _isGrounded = false;
            _canDoubleJump = true;
            FMODUnity.RuntimeManager.PlayOneShot("event:/Player/_jump");        }

        else if (Input.GetKeyDown(KeyCode.Space) && _canDoubleJump == true)
        {
            _canDoubleJump = false;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * JumpForce /1.1f  , ForceMode2D.Impulse);
            FMODUnity.RuntimeManager.PlayOneShot("event:/Player/_jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        damageable = collision.collider.GetComponent<IDamagable>();

        if (collision.collider.tag == "Ground" || collision.collider.tag == "Platform")
        {

            _isGrounded = true;
            _canDoubleJump = false;
        }
        if (damageable != null && pm._OnShield == false)
        {
            damageable.OnDamage();
            _health = _health - damageable.Damage();
            UImanager._healthText.text = ":" + _health.ToString();
            if(_health <= 0)
            {
                _health = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        actionable = collision.GetComponent<IActionable>();
 
        OnInteraction();

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        OutInteraction();
    }
    private void InteractionEnable()
    {
        onInteraction = true;
        UImanager._interactionEnable.gameObject.SetActive(true);

    }
    private void InteractionDisable()
    {
        onInteraction = false;
        UImanager._interactionEnable.gameObject.SetActive(false);
    }
    void Interaction()
    {
        if (actionable != null && onInteraction == true && Input.GetKeyDown(KeyCode.LeftControl))
        {
            actionable.Interact();
            InteractionEnable();
        }
        if (onInteraction == false)
        {
            InteractionDisable();
        }
    }
    void OnInteraction()
    {
        if (actionable != null && actionable.IsInteractable())
        {
            InteractionEnable();
        }
    }
    void OutInteraction()
    {
        InteractionDisable();
        actionable = null;
    }
    void Death()
    {
        if (_health <= 0)
        {
            _health = 0;
            gameObject.SetActive(false);
            Debug.Log("DEAD");
            UImanager.LoseCanvas.SetActive(true);
            UImanager.DeathText.SetActive(true);
            bgm.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            bgm.release();
            FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Death");
        }
        else if (UImanager.Timer <= 0)
        {
            gameObject.SetActive(false);
            Debug.Log("TIME OUT");
            UImanager.LoseCanvas.SetActive(true);
            UImanager.TimeOutText.SetActive(true);
            bgm.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            bgm.release();
            FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Death");
        }
        else if(transform.position.y <= -5)
        {
            gameObject.SetActive(false);
            Debug.Log("DEAD");
            UImanager.LoseCanvas.SetActive(true);
            UImanager.DeathText.SetActive(true);
            bgm.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            bgm.release();
            FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Death");
        }
    }
    void bgmBehaviour()
    {
        bgm.setParameterByName("Health", health);

        switch (UImanager.Timer)
        {
            case (130):
                bgm.setParameterByName("Intensity", 1);
                break;
            case (120):
                bgm.setParameterByName("Intensity", 2);
                break;
            case (100):
                bgm.setParameterByName("Intensity", 3);
                break;

        }
    }
}
