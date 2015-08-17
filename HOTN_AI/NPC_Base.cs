using UnityEngine;
using System.Collections;

//Different behavioral states for the NPC

[RequireComponent (typeof(NavMeshAgent))]
public abstract class NPC_Base : MonoBehaviour {

	public float intHealth;
	public float intDamage;
	public bool blnAlive, blnPossibleTargetInRange, blnExecBehavior;
	public GameObject goTarget;
    public AnimationClip[] colAnimations;
    public NavMeshPath nmpPath;
    public NavMeshAgent nmaAgent;
    public struct Drop 
    {
        string strDropType;
        int intValue;
        int intAmount;
        GameObject goItem;
    }
	
	public abstract void TakeDamage (int tdAmount); //receives damage from other players
	public abstract IEnumerator DecisionMaker (); //decides upon the action to take
}
