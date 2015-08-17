using UnityEngine;
using System.Collections;

public class NPC_DetectionZone : MonoBehaviour {

	public string strDetectionTargetTag;

	void OnTriggerEnter(Collider c)
	{
		if (c.CompareTag ("Player")) 
		{
			this.gameObject.GetComponentInParent<NPC_Base>().blnPossibleTargetInRange = true;
			this.gameObject.GetComponentInParent<NPC_Base>().goTarget = c.collider.gameObject;
			//goTarget = AcquireTarget("Player");
			//colBS = colBehaviorStates.Maneuver;
			//blnDecide = true;
		} //else colBS = colBehaviorStates.Idle;
	}

	void OnTriggerExit()
	{
		//this.gameObject.GetComponentInParent<NPC_Base>().blnPossibleTargetInRange = false;
	}
}
