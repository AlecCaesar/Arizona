
using UnityEngine;

public class EnemyAI : BaseAI
{
    Vector3 wanderPosition = Vector3.zero;
    public CharacterMovement characterMovement;


    protected void Awake(){
        base.Awake();
        characterMovement = GetComponent<CharacterMovement>();
        ChangeState(WanderState);
    }

   public void WanderState(){
        stateImIn = "Wander State";
        if(stateTick == 1){
            wanderPosition = transform.position + new Vector3(Random.Range(-10f,10f),0,Random.Range(-10f,10f));

        }
        characterMovement.MoveToward(wanderPosition);

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
}
