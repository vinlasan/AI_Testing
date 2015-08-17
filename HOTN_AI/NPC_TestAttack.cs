using UnityEngine;
using System.Collections;

public class NPC_TestAttack : MonoBehaviour {

	public bool blnContactWithPlayer;

	void Start()
	{
		blnContactWithPlayer = false;
	}

	void OnTriggerEnter(Collider c)
	{
		if (c.CompareTag ("Player"))
		{
			blnContactWithPlayer = true;
			c.GetComponent<StatusC>().OnDamage ((int)this.GetComponentInParent<NPC_Base>().intDamage, 0);
			blnContactWithPlayer = false;
			//this.GetComponentInParent<NPC_Base>().DoDamage(c.collider.gameObject, this.GetComponentInParent<NPC_Base>().intDamage);
		} 
	}

}
