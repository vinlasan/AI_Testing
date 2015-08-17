using System.Collections;
using UnityEngine;
namespace AssemblyCSharp

{
	public class Wolf_Behavior : NPC_Base
	{
		
		public GameObject HitBox, attackpoint;
        public State_Manager<Wolf_Behavior> StateManager; //this exist
        public Direct_Attack d_Attack;
	    public Maneuver maneuver;

		void Start(){
            StateManager = new State_Manager<Wolf_Behavior>(this);
            maneuver = new Maneuver(this);
            d_Attack = new Direct_Attack(this);
            attackpoint = this.transform.FindChild("AttackPoint").gameObject;
			blnAlive = true;
			nmpPath = new NavMeshPath ();
			nmaAgent = this.gameObject.GetComponent<NavMeshAgent> ();
			intHealth = 50;
			intDamage = 2000;
			blnExecBehavior = false;
		}
		void Update(){
            if (d_Attack.attackExecuted)
            {
                d_Attack.attackTimer -= Time.deltaTime;
            }  
		}

		void FixedUpdate(){
			if (goTarget != null) {
				if (blnPossibleTargetInRange) {
					StartCoroutine (DecisionMaker ());
				}
			}
		}

		public override void TakeDamage(int tdAmount){
			intHealth -= tdAmount;
			if (intHealth < 1)
				Destroy (gameObject);
		}

		public override IEnumerator DecisionMaker ()
		{
			StateManager.UpdateState();
            if (Vector3.Distance(goTarget.transform.position, this.transform.position) <= 3f)
                StateManager.ChangeState(d_Attack);
            else
            {
                StateManager.ChangeState(maneuver);
                d_Attack.attackExecuted = false;
            }
			yield return new WaitForSeconds(1.5f);
		}
	}
}

