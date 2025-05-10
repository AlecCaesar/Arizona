using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
   
   public float speed = 5f;
   public int maxHealth = 5;
   public int healthLeft = 0;
   public int questsDone = 0;
   bool hasObject = false;
   

   public Rigidbody rb;

   [Header("Weapon Settings")]
   public GameObject bulletPrefab;
   public float bulletSpeed = 30f;
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
   public AudioClip collectItem;



   
    
    
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
        if(direction == Vector3.zero){
            return;
        }
    }


    


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("AmmoRefill")){
            RefillAmmo(other.gameObject);
        }

        if (other.gameObject.CompareTag("Enemy Bullet")){
            DamageTaken(other.gameObject);

            if(healthLeft == 0){
                SceneManager.LoadScene("Death Scene");
                Cursor.lockState = CursorLockMode.None;
            }
        }

        if(other.gameObject.CompareTag("Health")){
            RefillHealth(other.gameObject);
            
        }

        if(other.gameObject.CompareTag("Quest")){
            questsDone++;
        }

        //OBJECT
        if(other.gameObject.CompareTag("Object")){
            hasObject = true;
            audioSource.resource = collectItem;
            audioSource.Play();
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("Saloon Door")){
            SceneManager.LoadScene("Saloon");
        }

        if(other.gameObject.CompareTag("Saloon Exit")){
            if(hasObject){
                SceneManager.LoadScene("GamePlay 1");
            }
            else{
                return;
            }
        }

        if(other.gameObject.CompareTag("House Door")){
            SceneManager.LoadScene("House");
        }

        if(other.gameObject.CompareTag("House Exit")){
            if(hasObject){
                SceneManager.LoadScene("GamePlay 2");
            }
            else{
                return;
            }
        }
        if(other.gameObject.CompareTag("Town Hall Door")){
            SceneManager.LoadScene("Town Hall");
        }

        if(other.gameObject.CompareTag("Town Hall Exit")){
            if(hasObject){
                SceneManager.LoadScene("Win Scene");
                Cursor.lockState = CursorLockMode.None;
            }
            else{
                return;
            }
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
