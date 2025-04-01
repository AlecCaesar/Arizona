

using UnityEngine;

public class Player : MonoBehaviour
{
   
   public float speed = 5f;
   public int maxHealth = 5;
   public int healthLeft = 0;

   public Rigidbody rb;

   [Header("Weapon Settings")]
   public GameObject bulletPrefab;
   public float bulletSpeed = 20f;
   public float rotationSpeed = 10f;
   public Transform firePoint;
   public int maxBullets = 6;
   public int bulletsLeft = 0;
   [Header("Audio")]
   public AudioSource audioSource;
   public AudioClip obtainHealth;
   public AudioClip obtainAmmo;
   public AudioClip takeDamage;
   public AudioClip gunFire; 

   
    
    
    void Awake()
    {
        bulletsLeft = maxBullets;
        healthLeft = maxHealth;
    }
    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked; 
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    public void Move(Vector3 direction){
        transform.position += direction * speed * Time.deltaTime;
    }

    


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("AmmoRefill")){
            RefillAmmo(other.gameObject);
        }

        if (other.gameObject.CompareTag("Bullet")){
            DamageTaken(other.gameObject);
        }

        if(other.gameObject.CompareTag("Health")){
            RefillHealth(other.gameObject);
            
        }
    }

    public void Bullets(){
        if(bulletsLeft < 1 ){
            return;
        }
        bulletsLeft--;
        audioSource.resource = gunFire;
        audioSource.Play(); 
        GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().linearVelocity = firePoint.forward * bulletSpeed;
        Destroy(newBullet, 5f);
    }

    void RefillAmmo(GameObject ammo){
        audioSource.resource = obtainAmmo;
        audioSource.Play();
        bulletsLeft = maxBullets;
        Destroy(ammo);
    }

    void RefillHealth(GameObject health){
        audioSource.resource = obtainHealth;
        audioSource.Play();
        healthLeft = maxHealth;
        Destroy(health);
    }

    public void DamageTaken(GameObject bullet){
        audioSource.resource = takeDamage;
            audioSource.Play();
            healthLeft--;
    }
}
