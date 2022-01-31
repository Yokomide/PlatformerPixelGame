using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Core.Character
{
    public class PlayerMovement : MonoBehaviour
    {
        private Animator _anim;
        private Rigidbody2D body;


        public CharacterController2D controller;
        public bool Invincible { get; set; }
        public PlayerData PlayerData { get; set; }
        public CamController camController;

        public float runSpeed = 40f;
        private bool isDying;
        float horizontalMove = 0f;
        private bool jump = false;

        public float HeroHP = 100;
        public bool CanBeHit => hitProtectionTimer <= 0;
        private float hitProtectionDuration = 1.0f;
        private float hitProtectionTimer;

        public static PlayerMovement Instance { get; private set; }
        //public event Action OnDeath;
        private void Awake()
        {
            if (Instance == null)
                Instance = this;

            body = GetComponent<Rigidbody2D>();

            PlayerData = new PlayerData();
            PlayerData.maxHP = 100;
            PlayerData.HP = PlayerData.maxHP;
        }
        void Start()
        {

            _anim = GetComponent<Animator>();


        }
        void Update()
        {
            if (hitProtectionTimer > 0)
                hitProtectionTimer -= Time.deltaTime;

            _anim.SetFloat("speed", Mathf.Abs(horizontalMove));

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }
            if (HeroHP <= 0)
            {

                Destroy(gameObject);
            }

            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        }

        private void FixedUpdate()
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
            jump = false;
        }

        public void Hurt(int damage, Vector2 recoilForce, float vignetteIntensity = 0.7f, bool killRecoil = true)
        {
            if (hitProtectionTimer > 0 || isDying)
                return;

            SetHealth(PlayerData.HP - damage);
            _anim.SetTrigger("TakeDmg");
            float shakeIntensity = 8f;
           camController.ShakeCamera(shakeIntensity, .1f);

            
            if (PlayerData.HP <= 0)
            {
                if (!Invincible)
                {
                    KillPlayer(killRecoil);
                    //animator.SetTrigger(CharacterAnimations.Die);
                }
            }
            

            hitProtectionTimer = hitProtectionDuration;
          //  Instantiate(hurtFlashObject, transform.position, Quaternion.identity);
          //  GuiManager.Instance.FadeHurtVignette(vignetteIntensity);
           // GameManager.Instance.FreezeTime(0.02f);

            DoRecoil(recoilForce);
        }
        public void SetHealth(int hp)
        {
            PlayerData.HP = hp;
        }
        public void KillPlayer(bool recoil)
        {
            if (isDying)
                return;

            Invincible = true;

            if (recoil)
            {
                DoRecoil(new Vector2(0, 400.0f));
            }

            //SoundManager.Instance.PlaySound(deathSound, 1, audioSource);
            isDying = true;
            _anim.SetTrigger("IsDying");
            Debug.Log("Здох");
            //OnDeath?.Invoke();
        }

        public void DoRecoil(Vector2 recoilForce, bool resetVelocity = false)
        {
            if (resetVelocity)
                body.velocity = Vector3.zero;

            body.AddForce(recoilForce);
        }
    }
}
