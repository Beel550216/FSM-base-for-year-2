
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
namespace Player
{
    public class RunningState : State
    {
        // constructor
        public RunningState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            player.anim.SetBool("run", true);
            player.anim.SetBool("jump", false);
            player.anim.SetBool("attack", false);

            if (Input.GetKey("a"))
            {
                player.anim.SetBool("run2", true);
            }
            else
            {
                player.anim.SetBool("run2", false);
                player.anim.SetBool("run2", false);
            }

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
            base.LogicUpdate();
            player.CheckForIdle();
            Debug.Log("checking for idle");
            player.CheckForJump();
            Debug.Log("checking for jump");
            player.CheckForAttack();
            Debug.Log("checking for attack");
            player.CheckForRun();
            Debug.Log("checking for run");
        }

        public override void PhysicsUpdate()
        {
            if(Input.GetKey("a"))
            {
                player.rb.linearVelocity = new Vector2(-3f, player.rb.linearVelocity.y);
            }
            if(Input.GetKey("d"))
            {
                player.rb.linearVelocity = new Vector2(3f, player.rb.linearVelocity.y);
            }
            //base.PhysicsUpdate();
        }
    }
}