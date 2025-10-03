using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.VFX;

namespace Player
{


    public class PlayerScript : MonoBehaviour
    {
        public Rigidbody2D rb;
        public Animator anim;
        public SpriteRenderer sr;


        // variables holding the different player states
        public IdleState idleState;
        public RunningState runningState;
        public JumpState jumpState;                                  ////////////
        public AttackState attackState;

        public StateMachine sm;
        public bool isGrounded;

        public bool attackEnded;
        public PlayerInfo playerInfo;



        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            sm = gameObject.AddComponent<StateMachine>();
            anim = GetComponent<Animator>();
            sr = GetComponent<SpriteRenderer>();

            // add new states here
            idleState = new IdleState(this, sm);
            runningState = new RunningState(this, sm);
            jumpState = new JumpState(this, sm);                     ///////////
            attackState = new AttackState(this, sm);
            playerInfo.health = 50f;
            playerInfo.lives = 3;
            playerInfo.playerName = "Duckther";

            // initialise the statemachine with the default state
            sm.Init(idleState);
        }

        // Update is called once per frame
        public void Update()
        {
            sm.CurrentState.LogicUpdate();

            //output debug info to the canvas
            string s;
            s = string.Format("last state={0}\ncurrent state={1}", sm.LastState, sm.CurrentState);

            UIscript.ui.DrawText(s);

            UIscript.ui.DrawText(isGrounded.ToString());

        }



        private void OnCollisionStay2D(Collision2D collision)
        {
            isGrounded = true;
            print("is Grounded");
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            isGrounded = false;
            print("isn't Grounded");
        }


        void FixedUpdate()
        {
            sm.CurrentState.PhysicsUpdate();
        }



        public void CheckForRun()
        {
            if (Input.GetKey("a")) // key held down
            {
                sr.flipX = true;
                sm.ChangeState(runningState);
                return;
            }
            if (Input.GetKey("d"))
            {
                sr.flipX = false;
                sm.ChangeState(runningState);
                return;

            }

        }


        public void CheckForIdle()
        {
            if (Input.GetKey("i")) // key held down
            {
                sm.ChangeState(idleState);
            }

        }


        public void CheckForJump()                             //////////////
        {
            if (Input.GetKeyDown("w") && isGrounded == true) // key held down
            {
                /*Vector3 jumpMovement = new Vector3(0.0f, 1.0f, 0.0f);
                rb.linearVelocity = jumpMovement * 10;*/
                sm.ChangeState(jumpState);
                print("changing to jumpstate");
                return;
            }

        }

        public void CheckForAttack()                             //////////////
        {
            if (Input.GetKeyDown("x"))
            {
                sm.ChangeState(attackState);
                return;
            }

        }


        //put animation event logic here
        public void AttackEnded()
        {
            attackEnded = true;
            sm.ChangeState(idleState);
        }

    }

}