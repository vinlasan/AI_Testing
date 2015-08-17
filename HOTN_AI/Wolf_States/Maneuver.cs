using AssemblyCSharp;
using UnityEngine;

public class Maneuver : NPC_State<Wolf_Behavior>
{
    private Wolf_Behavior wolf;

    public Maneuver(Wolf_Behavior w)
    {
        wolf = w;
    }

    public override void Enter(Wolf_Behavior npc)
    {
        
    }

    public override void Execute(Wolf_Behavior npc)
    {
        SetPath(new Vector3(0,0,0));
    }

    public override void Exit(Wolf_Behavior npc)
    {
    }

    public void SetPath(Vector3 modifier)
    {
        wolf.nmaAgent.CalculatePath(wolf.goTarget.transform.position + modifier, wolf.nmpPath);
        /*if (wolf.line != null)
        {
            wolf.line.SetVertexCount(wolf.nmpPath.corners.Length);
            for (int i = 0; i < wolf.nmpPath.corners.Length; i++)
            {
                wolf.line.SetPosition(i, wolf.nmpPath.corners[i]);
            }
        }*/
        wolf.transform.LookAt(wolf.goTarget.transform);
        wolf.nmaAgent.SetDestination(wolf.goTarget.transform.position);
    }
}
