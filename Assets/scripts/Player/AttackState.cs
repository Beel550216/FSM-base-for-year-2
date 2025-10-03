using UnityEngine;


namespace Player
{
    public class AttackState : State
    {
        public AttackState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {

            player.anim.SetBool("attack", true);
            player.anim.SetBool("jump", false);
            player.anim.SetBool("run", false);
            player.anim.SetBool("run2", false);

            player.attackEnded = false;
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
            player.CheckForRun();
            Debug.Log("checking for run");
            player.CheckForJump();
            Debug.Log("checking for jump");
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }


        public void AttackEnd()
        {
            if( player.attackEnded )
            {
                player.anim.SetBool("attack", false);
                player.anim.SetBool("idle", true);
            }

        }

    }

}
