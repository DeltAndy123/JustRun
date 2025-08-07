using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;


public class Player : MonoBehaviour
{
    // Inspector variables
    public float speed = 5;
    public float jumpStrength = 6;
    public LayerMask platformLayer;
    public Transform groundCheckPoint;
    public int maxHits = 4;
    public List<GameObject> cracks;
    public Image damageFlash;
    public float damageFlashTime = 0.5f;
    public float damageFlashInitialAlpha = 0.75f;
    public Laser laser;
        
    
    // Components
    private Rigidbody2D _rb;
    private Animator _anim;
    
    // Input actions
    private InputAction _moveAction;
    private InputAction _jumpAction;
    
    // Other variables
    private bool _canJump;
    private JumpOrb _touchingJumpOrb;
    private float _jumpOrbStrength;

    private int _hitsTaken;
    private float _damageFlashAlpha;
    
    // Start is called before the first frame update
    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _jumpAction = InputSystem.actions.FindAction("Jump");
        
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var xVelocity = _moveAction.ReadValue<float>();
        float yVelocity = _rb.velocity.y;

        bool startedJumping = _jumpAction.WasPressedThisFrame();
        bool jumping = _jumpAction.IsPressed();
        
        if (startedJumping && _touchingJumpOrb)
        {
            // Jump orb
            yVelocity = _jumpOrbStrength;
        }
        else if (jumping && _canJump)
        {
            // Jump from platform
            yVelocity = jumpStrength;
            _canJump = false;
            _anim.SetBool("onGround", false);
        }
        
        _rb.velocity = new Vector2(xVelocity * speed, yVelocity);
        _anim.SetFloat("xSpeed", Mathf.Abs(xVelocity));
        _anim.SetFloat("yVelocity", yVelocity);

        if (xVelocity > 0)
        {
            // Right
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y,
                transform.localScale.z);
        }
        else if (xVelocity < 0)
        {
            // Left
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y,
                transform.localScale.z);
        }


        if (_damageFlashAlpha > 0) _damageFlashAlpha -= Time.deltaTime / damageFlashTime / damageFlashInitialAlpha;
        damageFlash.color = new Color(damageFlash.color.r, damageFlash.color.g, damageFlash.color.b, _damageFlashAlpha);
    }
    

    private bool IsOnGround()
    {
        return Physics2D.OverlapCircle(groundCheckPoint.position, 0.15f, platformLayer);
    }
    

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (IsOnGround())
        {
            _canJump = true;
            _anim.SetBool("onGround", true);
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!IsOnGround())
        {
            _canJump = false;
            _anim.SetBool("onGround", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.CompareTag("Death"))
        {
            SceneManager.LoadScene("Lose");
        }

        if (triggerCollider.CompareTag("OutOfScreen"))
        {
            if (GameManager.HasCheckpoint())
            {
                TakeDamage();
                GameManager.GoToCheckpoint();
            }
            else
            {
                SceneManager.LoadScene("Lose");
            }
        }

        if (triggerCollider.CompareTag("Laser"))
        {
            TakeDamage();
        }

        var orb = triggerCollider.GetComponent<JumpOrb>();
        if (orb == null) return;

        _touchingJumpOrb = orb;
        _jumpOrbStrength = orb.jumpStrength;
    }

    private void OnTriggerExit2D(Collider2D triggerCollider)
    {
        var orb = triggerCollider.GetComponent<JumpOrb>();
        if (orb == null) return;
        
        _touchingJumpOrb = null;
    }


    public void TakeDamage()
    {
        _damageFlashAlpha = damageFlashInitialAlpha;
        _hitsTaken++;
        if (_hitsTaken >= maxHits)
        {
            SceneManager.LoadScene("Lose");
        }
        else
        {
            cracks[_hitsTaken - 1].SetActive(true);
        }
    }
}