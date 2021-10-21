using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster_Movement : MonoBehaviour
{
    
    public NavMeshAgent agent;
    [SerializeField]
    private Transform player;

    public LayerMask whatIsGround, whatIsPlayer;
    /*
    //Spider Health
    public int maxHealth = 20;
    [SerializeField]
    private int Damage = 1;
    public int currentHealth;
    [SerializeField]
    private GameObject _spiderhealthbar;
    [SerializeField]
    private GameObject _spidertarget;
    */
    //[SerializeField]
    //private HealthBar healthBar;

    //random number
    int numm;

    //patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public float timeBetweenNewMovePoint;
    private bool alreadyMoved;

    //Attaking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    //public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //Animaton
    private Animator _animator;
    private bool move = true;

    //Player Health
    // [SerializeField]
    // private Player_Health _playerhealth;

    // Sound
    //private AudioManager _audioManager;

    private bool alreadywalking;

    /*
    private bool playedSound;
    private bool endedSound;

    private bool patrolling;

    private bool chasingorattacking;

    public bool BossSpider;
    */

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();

      // _audioManager = FindObjectOfType<AudioManager>();
    }

    /*
    private void Start()
    {
     
        currentHealth = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
        if (_audioManager == null)
        {
            _audioManager = FindObjectOfType<AudioManager>();
        }
        if (BossSpider)
        {
            InvokeRepeating(nameof(ShouldPlaySound), 5f, 4f);
        }
    }
    */

    private void Update()
    {
        if (move)
        {
            //Check for sight and attack range
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

            if (!playerInSightRange && !playerInAttackRange)
            {
                Patrolling();               
            }
            if (playerInSightRange && !playerInAttackRange)
            {
                ChasePlayer();          
            }
            if (playerInAttackRange && playerInSightRange)
            {
                AttackPlayer();    
            }
        }
    }

    /*
    private void ShouldPlaySound()
    {
        if (chasingorattacking && !playedSound)
        {
            //  playedSound = true;
            PlaySpiderSound();
        }
        else if (patrolling && !endedSound)
        {

            StopSpiderSound();
        }
    }
    */



    private void Patrolling()
    {
        if (!walkPointSet && !alreadyMoved) 
        {
            SearchWalkPoint(); 
            
            alreadyMoved = true;
            Invoke(nameof(ResetPatrolPoint), timeBetweenNewMovePoint);
        }
       

        if (walkPointSet) 
        {
            agent.SetDestination(walkPoint); 
            _animator.SetBool("walking", true);
            alreadywalking = false;
        }
           

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f) 
        {
            _animator.SetBool("walking", false);
            walkPointSet = false;
        }
            
            

        //  _audioManager.Stop("Theme2");
        //  if (!_audioManager.isPlaying("Theme1")) _audioManager.Play("Theme1");
    }

    private void ResetPatrolPoint()
    {
        alreadyMoved = false;
    }

    private void SearchWalkPoint()
    {
        //Calcutlate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        if(!alreadywalking)
            _animator.SetBool("walking", true); alreadywalking = true;

    }

    private void PlaySpiderSound()
    {
       // _audioManager.PlaySpiderSound();

    }

    private void StopSpiderSound()
    {
       // _audioManager.StopSpiderSound();

    }

    private void AttackPlayer()
    {


        agent.SetDestination(transform.position);    //Make spider stop
        

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            /*
            ///Attack code here
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            ///End of attack code
            */


            //numm = Random.Range(0, 2);

            //if (numm == 1)
            //{ _animator.Play("Spider_Attack_Melee"); }  //Animation event triggers HitPlayer()
            //else
            _animator.SetBool("walking", false);

            { _animator.Play("attack"); }

            alreadyAttacked = true;
            alreadywalking = false;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    public void HitPlayer()
    {
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (playerInAttackRange)
        {
            //_playerhealth.TakeDamage(Damage);
        }

    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

   




    //If Spider gets hit

    /*
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

      //  healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            agent.SetDestination(transform.position);
            move = false;

            _spiderhealthbar.SetActive(false);
            _spidertarget.SetActive(false);
            _animator.Play("Spider_Dying");
            Invoke(nameof(DestroySpider), 5f);
        }

    }
    private void DestroySpider()
    {
        Destroy(gameObject);
    }
 */

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

}
