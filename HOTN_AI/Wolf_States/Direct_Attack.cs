using System.Collections;
using AssemblyCSharp;
using UnityEngine;

public class Direct_Attack : NPC_State<Wolf_Behavior> {
    private Wolf_Behavior wolf;
    public int maxAttackCombo, currentCombo;
    public float attackTimer, delayTimer;
	public bool attackExecuted = false;

    public Direct_Attack(Wolf_Behavior w)
    {
        wolf = w;
        maxAttackCombo = 3;
    }

    public override void Enter(Wolf_Behavior w)
    {
        attackTimer = delayTimer = 5;
    }

    public override void Execute(Wolf_Behavior w)
    {
        if(InAttackRange(1.5f))
        {
            Attack();
            attackTimer = delayTimer;
        }  
        w.StateManager.ChangeState(w.maneuver);
    }

    public override void Exit(Wolf_Behavior w)
    {
    }

    private bool InAttackRange(float range)
    {
        if (Vector3.Distance(wolf.goTarget.transform.position, wolf.transform.position) <= range)
            return true;
        else return false;
    }

    private void Attack()
    {
		if (!attackExecuted) 
		{
			wolf.transform.LookAt (wolf.goTarget.transform);
			GameObject hitbox = GameObject.Instantiate (wolf.HitBox, wolf.attackpoint.transform.position, wolf.attackpoint.transform.rotation) as GameObject;

			hitbox.GetComponent<BulletStatusC> ().Setting(5,100,"Enemy", wolf.transform.gameObject);

			GameObject.Destroy (hitbox);
            attackExecuted = true;
            currentCombo++;
		}
    }
}
