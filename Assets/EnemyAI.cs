
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class EnemyAI : BaseAI
{
   
    public Character character;
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public Transform enemyFirePoint;
    public float enemyBulletSpeed = 2f;
    public AudioSource audioSource;
    public AudioClip shooting;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
   

    protected void Awake(){ // no need to change 4/28
        base.Awake(); //Insure all code from BaseAI is run from this class
        character = GetComponent<Character>();
        ChangeState(AttackPlayer);
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
       
    }

    protected void Update()
    {
        base.Update();
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if(playerInAttackRange && playerInSightRange){
            AttackPlayer();
        }
    }

    Vector3 wanderPosition = Vector3.zero;
   

    private void AttackPlayer(){
        transform.LookAt(player);
        if(!alreadyAttacked){
        GameObject newBullet = Instantiate(projectile, enemyFirePoint.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().linearVelocity = enemyFirePoint.forward * enemyBulletSpeed;
        Destroy(newBullet, 5f);
            audioSource.resource = shooting;
            audioSource.Play(); 
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack(){
        alreadyAttacked = false;
    }

}
