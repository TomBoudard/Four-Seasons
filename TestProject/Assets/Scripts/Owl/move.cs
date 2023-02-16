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
        private string oldkey;
        
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
                     // Rotation
                    Vector3 direction = new Vector3(0,0,0);
                    if (Input.GetKeyDown(KeyCode.LeftArrow) && oldkey != "left")
                    {
                            oldkey = "left";
                            direction = new Vector3(0, 90, 0);
                            transform.eulerAngles = direction;
                    } 
                    else if (Input.GetKeyDown(KeyCode.RightArrow) && oldkey != "right")
                    {
                            oldkey = "right";
                            direction = new Vector3(0, -90, 0);
                            transform.eulerAngles = direction;
                    }
                    else if(Input.GetKeyDown(KeyCode.DownArrow) && oldkey != "down"){
                            oldkey = "down";
                            direction = new Vector3(0, 0, 0);
                            transform.eulerAngles = direction;
                    }
                    else if(Input.GetKeyDown(KeyCode.UpArrow) && oldkey != "up"){
                            oldkey = "up";
                            direction = new Vector3(0,180,0);
                            transform.eulerAngles = direction;
                    }
                    // Move thanks to the vertical axis (up down arrow or W S)
                    moveVector = new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal"));

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
               
                Controller.Move(moveVector * speed * Time.deltaTime);
            }
        }
    }
}