using UnityEngine;

public class PlayerBullets : MonoBehaviour
{
    public GameObject bullets;
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
