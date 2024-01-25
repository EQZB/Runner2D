using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CatBehavior : MonoBehaviour
{
    private CharacterController cat;
    private Vector3 direction;

    public float gravity = 9.81f * 2f;
    public float jumpForce = 8f;
    private float doubleJump = 0f;
    bool jumping;
    bool doublejumping;
    //int VelocityHash;
    //float gameSpeed = 1f;

    //[SerializeField] private AudioSource bonk;

    Animator animator;

    private void Awake()
    {

        
        cat = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        //VelocityHash = Animator.StringToHash("gameSpeed");
    }

    private void Start(){

        animator.speed = 1f;
    }

    private void OnEnable()
    {

        direction = Vector3.zero;
    }

    private void Update()
    {
        //gameSpeed = GameManager.Instance.gameSpeed;
        animator.speed = (GameManager.Instance.gameSpeed) * Time.deltaTime;
        direction += Vector3.down * gravity * Time.deltaTime;

         if (cat.isGrounded)
        {
            doubleJump = 0f;
            jumping = false;
            doublejumping = false;
            animator.SetBool("Jump", false);
            animator.SetBool(("Double Jump"), false);

            if (Input.GetButtonDown("Jump"))
            {
                animator.SetBool("Jump", true);
                animator.SetBool(("Double Jump"), false);
                direction = Vector3.up * jumpForce;
                doubleJump += 1f;
                jumping = true;

            
            }
            else if (Input.GetButtonUp("Jump"))
            {

                jumping = false;
                
            }
            

            
        }

        if (cat.isGrounded == false)
        {
            if (doubleJump < 2f)
            {

                if (Input.GetButtonDown("Jump"))
                {

                    animator.SetBool("Jump", false);
                    animator.SetBool(("Double Jump"), true);
                    direction = Vector3.up * jumpForce;
                    doubleJump += 1f;
                    doublejumping = true;

                    
                }

                else if (Input.GetButtonUp("Jump"))
                {

                    doublejumping = false;
                
                }
            }

        }
        

        cat.Move(direction * Time.deltaTime);

    }

    //public void OnTriggerEnter(Collider other){

    //    if (other.CompareTag("obstacle")){
     //       soundEffectsLayers.Instance.bonk();
      //  }
   // }
}
