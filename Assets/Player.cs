using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    // Start is called before the first frame update

    float horizontalMove;
    float verticalMove;
    float alturaMove;
    Vector3 playerInput;
    [SerializeField]
    CharacterController player;
    [SerializeField]
    
    
    public float playerSpeed = 3.0f;
    Vector3 movePlayer;
    [SerializeField]
    Camera mainCamera;
    Vector3 camForward; //camara hacia adeñante
    Vector3 camRight;

    Animator playerAnim;
    // Gravity
    [SerializeField]
    float gravity = 9.8f;
    float fallSpeed;

    void Start()
    {
        player = GetComponent<CharacterController>();
        playerAnim = GetComponent<Animator>();
       // mainCamera = GetComponent
    }

    // Update is called once per frame
    void Update()
    {
       //FirtsMove();
       horizontalMove = Input.GetAxis("Horizontal");
       //Debug.Log(horizontalMove);
       verticalMove = Input.GetAxis("Vertical");

       playerInput = new Vector3(horizontalMove,0,verticalMove);
       playerInput = Vector3.ClampMagnitude(playerInput,1);


       //alturaMove = Input.GetAxis("Vertical");
       camDirection();
       movePlayer=playerInput.x * camRight + playerInput.z * camForward;

       player.transform.LookAt(player.transform.position + movePlayer);

       PlayerAnim();

       UseGravity();

       player.Move(movePlayer * playerSpeed * Time.deltaTime);

    }

    void FirtsMove(){
         if(Input.GetKey("w")){
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        }

        if(Input.GetKey("s")){
            transform.Translate(Vector3.back * playerSpeed * Time.deltaTime);
        }

        if(Input.GetKey("d")){
            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
        }

        if(Input.GetKey("a")){
            transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);
        }
    }

    void camDirection(){
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y=0;
        camForward=camForward.normalized;

    }

    void PlayerAnim(){
        if(horizontalMove != 0 || verticalMove != 0){
            if(Input.GetKey(KeyCode.LeftShift)){
                playerAnim.SetBool("Idle",false);
                playerAnim.SetBool("Run",true);
                playerAnim.SetBool("Walk",false);
                playerSpeed = 6;
            }else{
                playerAnim.SetBool("Idle",false);
                playerAnim.SetBool("Run",false);
                playerAnim.SetBool("Walk",true);
                playerSpeed = 3;
            }       
        }else{
            playerAnim.SetBool("Idle",true);
            playerAnim.SetBool("Walk",false);
            playerAnim.SetBool("Run",false);
        }
    }

    void UseGravity(){
        if(player.isGrounded){
            fallSpeed= -gravity * Time.deltaTime;
            movePlayer.y=fallSpeed;
        } else {
            fallSpeed -= gravity * Time.deltaTime;
            movePlayer.y = fallSpeed;
        }
    }
}
