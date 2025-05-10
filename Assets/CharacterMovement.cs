using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 2f;
    
    

    public void MoveToward(Vector3 target){
        Vector3 direction = target - transform.position;
        Move(direction);
    }

    public void Move(Vector3 direction){
        transform.position += direction * speed * Time.deltaTime;
    }

   
}
