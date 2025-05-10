using UnityEngine;

public class EnemyBullets : MonoBehaviour
{
    public GameObject enemyBullets;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Structure")){
            Destroy(gameObject);
        }
    }
}
