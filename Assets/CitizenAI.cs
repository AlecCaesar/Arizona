using UnityEngine;
using UnityEngine.AI;

public class CitizenAI : BaseAI, IInteractable
{
    public Character character;
    public Dialogue dialogue;
    
    public NavMeshAgent agent;
   
   void Awake()
   {
        base.Awake();
        ChangeState(WanderState);
   }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }


    Vector3 wanderPosition = Vector3.zero;
    public void WanderState(){
        stateImIn = "Wander State";
        if(stateTick == 1){
            wanderPosition = transform.position + new Vector3(Random.Range(-5f,5f),0,Random.Range(-5f,5f));

        }
        character.MoveToward(wanderPosition);

        if(Vector3.Distance(transform.position, wanderPosition) < 1f){
            ChangeState(PauseState);
        }
   }

   void PauseState(){
    stateImIn = "Pause State";

    if(stateTime > 2f){
        ChangeState(WanderState);
    }
   }

    public string GetDescription(){
        return "Talk";
    }
    public void Interact(){
        dialogue.StartDialogue();
        
    }
}
