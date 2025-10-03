
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Player
{
    public class JumpState : State
    {

        public JumpState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            player.anim.SetBool("jump", true);
            player.anim.SetBool("attack", false);
            player.anim.SetBool("run", false);
            player.anim.SetBool("run2", false);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            if(player.isGrounded)
            {
                base.LogicUpdate();
                player.CheckForIdle();
                //Debug.Log("checking for idle");
                player.CheckForAttack();
                //Debug.Log("checking for attack");
                player.CheckForRun();
                //Debug.Log("checking for run");

            }
        }

        public override void PhysicsUpdate()
        {
            if (player.isGrounded)
            {
                Vector3 jumpMovement = new Vector3(0.0f, 1.0f, 0.0f);
                player.rb.linearVelocity = jumpMovement * 10;
            }
            //player.rb.AddForce(new Vector3(0, 6, 0), ForceMode2D.Impulse);;
            // base.PhysicsUpdate();
        }


    }

}