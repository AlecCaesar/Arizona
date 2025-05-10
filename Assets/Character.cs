using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5f;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector3 direction){
        if(direction == Vector3.zero){
            return;
        }
        direction.Normalize();
        controller.Move(direction * speed * Time.deltaTime);
    }

    public void MoveToward(Vector3 target){
        Vector3 direction = target - transform.position;
        Move(direction);
    }


}
