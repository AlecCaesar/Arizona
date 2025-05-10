using UnityEngine;

public class Enemy : MonoBehaviour
{
   public Player player;
   public int enemyHealthLeft = 0;
   public int maxEnemyHealth = 1;
   public AudioSource audioSource;
   public AudioClip enemyDeath;



void Awake()
{
    enemyHealthLeft = maxEnemyHealth;
}

     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Bullet")){
            HurtEnemy(other.gameObject);
        }
    }


    void HurtEnemy(GameObject bullet){
        enemyHealthLeft--;
        Destroy(bullet);
        if(enemyHealthLeft == 0){
            audioSource.resource = enemyDeath;
            audioSource.Play(); 
            Destroy(gameObject, .5f);
            
            
            
        }
    }


}
