using UnityEngine;

public class Enemy : MonoBehaviour
{
   public Player player;
   public int currentHealth = 1;

    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.CompareTag("Bullet")){
    //         player.DamageTaken(other.gameObject);
            
    //     }
    // }
}
