using UnityEngine;

public class BaseAI : MonoBehaviour
{
    public string stateImIn = "Nothing";
    public float stateTime = 0f;
    public int stateTick = 0;

    public delegate void StateFunction();
    StateFunction currentState;


    protected void Awake()
    {
        ChangeState(NothingState);
    }

    protected void Update()
    {
        if(currentState == null){
            return;
        }
        stateTick += 1;
        stateTime += Time.deltaTime;
        currentState();    
    }

    protected void NothingState(){
        stateImIn ="Nothing";
    }

    public void ChangeState(StateFunction newState){
        currentState = newState;
        stateTime = 0f;
        stateTick = 0;
    }
}
