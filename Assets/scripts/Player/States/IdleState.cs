
using UnityEngine;
namespace Player
{
    public class IdleState : State
    {
        // constructor
        public IdleState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            player.anim.Play("idle");

            player.anim.SetBool("jump", false);
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
            player.CheckForRun();
            Debug.Log("checking for run");
            player.CheckForJump();                ////////////
            Debug.Log("checking for jump");
            player.CheckForAttack();                ////////////
            Debug.Log("checking for attack");
            base.LogicUpdate();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}