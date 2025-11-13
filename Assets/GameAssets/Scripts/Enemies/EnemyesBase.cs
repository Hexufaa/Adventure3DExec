using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Animation;
using UnityEngine.Events;

namespace Enemy 
{

    public class EnemyesBase : MonoBehaviour, IDamageable
    {

        public Collider Collider;
        public float startLife = 10f;
        public Flashcolor Flashcolor;
        public ParticleSystem ParticleSystem;
        public float DeathDuration = 1f;
        public bool lookAtPlayer = false;



        [SerializeField] private AnimationBase _animationBase;
        [SerializeField] private float _currentLife;
        private PlayerControllerTurning _player;

        [Header("Animation")]
        public float startAnimationDuration = 0.2f;
        public Ease startAnimationDurationEase = Ease.OutBack;
        public bool startWithAnimation = true;

        [Header("Event")]
        public UnityEvent OnKillEvent;


        private void Awake()
        {
            Init();
        }

        private void Start()
        {
            _player = GameObject.FindObjectOfType<PlayerControllerTurning>();
        }

        protected void ResetLife()
        {
            _currentLife = startLife;
        }

        protected virtual void Init()
        {
            ResetLife();
            if (startWithAnimation) BornAnimation();
        }

        protected virtual void Kill()
        {
            OnKill();
        }

        protected virtual void OnKill()
        {
            if (Collider != null) { Collider.enabled = false; }
            Destroy(gameObject, DeathDuration);
            PlayAnimationByTrigger(AnimationType.DEATH);
            OnKillEvent?.Invoke();
        }

        public void OnDamage(float f)
        {
            if (Flashcolor != null) Flashcolor.Flash();
            if (ParticleSystem != null) ParticleSystem.Emit(15);
            _currentLife -= f;

            //transform.position -= transform.forward;

            if (_currentLife <= 0) 
            {
                Kill();
            }
        }

        #region ANIMATION

        private void BornAnimation()
        {
            transform.DOScale(0, startAnimationDuration).SetEase(startAnimationDurationEase).From();
        }

        public void PlayAnimationByTrigger(AnimationType animationType)
        {
            _animationBase.PlayAnimationByTrigger(animationType);
        }

        #endregion

        //debug

        //private void Update() {  }

        public void Damage(float damage)
        {
            Debug.Log("Damage");
            OnDamage(damage);
        }

        private void OnCollisionEnter(Collision collision)
        {
            PlayerControllerTurning p = collision.transform.GetComponent<PlayerControllerTurning>();
            if (p != null)
            {
                p.healthBase.Damage(1);
            }
        }

        public virtual void Update()
        {

            if (lookAtPlayer)
            {
                transform.LookAt(_player.transform.position);
            }

        }

    }

}
