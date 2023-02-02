using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyNamespace
{
    public class move : MonoBehaviour
    {
        public float speed = 4f;
        public float jump_force = 6f;
        public float gravity = 20f;
        CharacterController Controller;
        bool can_double_jump = false;
        private Vector3 moveVector = Vector3.zero;
        private Vector3 dash_force = new Vector3(6, 0, 0);
        public float time_dash = 3f;
        bool can_dash = false;
        public float global_time_for_dash = 0f;
        public bool player_movement = false;
       
        // Start is called before the first frame update
        void Start()
        {
            Controller = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (player_movement)
            {
                // If the player is on the ground we can jump
                if (Controller.isGrounded)
                {
                    // Move thanks to the vertical axis (up down arrow or W S)
                    moveVector = new Vector3(-Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
                    moveVector = transform.TransformDirection(moveVector);

                    if (Input.GetButtonDown("Jump"))
                    {
                        moveVector.y = jump_force;
                        can_double_jump = true;
                    }
                }
                else
                {   // If the player is not on the ground we can double jump
                    if (Input.GetButtonDown("Jump") && can_double_jump)
                    {
                        moveVector.y = jump_force;
                        can_double_jump = false;
                    }
                }

                global_time_for_dash += Time.deltaTime;
                
                // Delay for the dash
                if (time_dash < global_time_for_dash)
                {
                    can_dash = true;
                }

                // Dash 
                if (Input.GetKeyDown(KeyCode.LeftShift) && can_dash)
                {
                    Vector3 world_dash_vector = transform.TransformVector(dash_force);
                    can_dash = false;
                    moveVector -= world_dash_vector;
                    global_time_for_dash = 0;
                }

                // Gravity and transforms to the global world
                moveVector.y -= gravity * Time.deltaTime;
                float direction;
                if (Input.mousePosition.x < 20)
                {
                    direction = -1;
                }
                else if (Input.mousePosition.x > 20 && Input.mousePosition.x < 800){
                    direction = 0;
                }
                else{
                    direction = 1;
                }
                Vector3 rotation = Vector3.up;
                rotation.y = direction * Time.deltaTime * speed * 10;
                transform.Rotate(rotation);
                Controller.Move(moveVector * speed * Time.deltaTime);
            }
        }
    }
}