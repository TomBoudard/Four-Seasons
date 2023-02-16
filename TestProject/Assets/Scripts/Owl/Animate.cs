using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isJumpingHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        // Create a hash of the variable we are looking for
        isWalkingHash = Animator.StringToHash("isWalking");
        isJumpingHash = Animator.StringToHash("isJumping");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isJumping = animator.GetBool(isJumpingHash);
        bool movementPressed = Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right");
        bool jumpPressed = Input.GetButtonDown("Jump");

        if (!isWalking && movementPressed){
            animator.SetBool("isWalking", true);
        }
        if (isWalking && !movementPressed){
            animator.SetBool("isWalking", false);
        }
        if (!isJumping && jumpPressed){
            animator.SetBool("isJumping", true);
        }
        if (isJumping && !jumpPressed){
            animator.SetBool("isJumping", false);
        }
    }
}
