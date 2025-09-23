using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTurning : MonoBehaviour//, IDamageable
{
    public CharacterController characterController; public float speed = 1f;

    [Header("player Status")]
    public List<Collider> Colliders;
    public float turnSpeed = 1f;
    public float gravity = -9.8f;
    public float jumpSpeed = 15f;
    private float _Speed = 0f;

    public Animator animator;

    
    [Header("Run Setup")]
    public KeyCode keyRun = KeyCode.LeftShift;
    public float speedRun = 1.5f;


    [Header("Life")]
    public HealthBase healthBase;


    private bool _alive = true;

    private void OnValidate()
    {
        if (healthBase == null) healthBase = GetComponent<HealthBase>();
    }

    private void Awake()
    {
        OnValidate();
        healthBase.OnDamage += Damage;
        healthBase.OnKill += OnKill;

    }

    #region LIFE

    private void Revive()
    {
        _alive = true;
        healthBase.ResetLife();
        animator.SetTrigger("Revive");
        Invoke(nameof(TurnOnColliders), 0.1f);
        Respawn();

    }
    private void TurnOnColliders()
    {
        Colliders.ForEach(i => i.enabled = true);
    }

    private void OnKill(HealthBase h)
    {
        if (_alive)
        {
            _alive = false;
            animator.SetTrigger("Death");
            Colliders.ForEach(i => i.enabled = false);

            Invoke(nameof(Revive), 1f);
        }
    }

    private void Damage(HealthBase h)
    {
        //Damage(h);
        ShakeCamera.Instance.Shake();
    }

    public void Damage(float damage)
    {

        //Damage(damage);
        //throw new System.NotImplementedException();
    }
    #endregion
  
    void Update() 
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);
        var inputAxisVertical = Input.GetAxis("Vertical");
        var speedVector = transform.forward * inputAxisVertical * speed;

        if (characterController.isGrounded) { _Speed = 0; if (Input.GetKeyDown(KeyCode.Space)) { _Speed = jumpSpeed; } }

        var isWalking = inputAxisVertical != 0;
        if (isWalking) 
        { 
            if (Input.GetKey(keyRun)) 
            { 
                speedVector *= speedRun; animator.speed = speedRun;
            } else 
            { 
                animator.speed = 1; 
            } 
        }

        _Speed -= gravity * Time.deltaTime;
        speedVector.y = _Speed;
        characterController.Move(speedVector * Time.deltaTime);

        animator.SetBool("Run", inputAxisVertical != 0);

        /*if (inputAxisVertical != 0) 
        { 
            animator.SetBool("Run", true);
        } else
        { 
            animator.SetBool("Run", false);
        }*/
    }

    [NaughtyAttributes.Button]
    public void Respawn()
    {
        if (CheckPointManager.Instance.HasCheckPoint()) 
        {
            transform.position = CheckPointManager.Instance.GetPositionFromLastCheckPoint();
        }
    }
}
