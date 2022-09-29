using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlenderBehaviour : MonoBehaviour
{
    private Rigidbody rb;

    public NavMeshAgent agent;

    public LayerMask whatIsPlayer;

    public Transform player;

    // Patrolling
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    public Vector3 terrainDimensions = new Vector3(100, 1, 100);

    // States
    [Header("States")]
    public float sightRange;
    public float attackRange;
    public bool playerInAttackRange;

    // Teleport timer
    [Header("TP Timer")]
    [SerializeField] private float teleportTimeLeft = 1;
    public bool teleportTimerOn = false;

    private void Awake()
    {
        if (player == null)
            player = GameObject.Find("Player").transform;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        teleportTimerOn = true;
    }

    // Update is called once per frame
    private void Update()
    {
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInAttackRange) ChasePlayer();
        if (playerInAttackRange) AttackPlayer();
    }

    //private void Patrolling()
    //{
    //    if (!walkPointSet) searchWalkPoint();

    //    if (walkPointSet) agent.SetDestination(walkPoint);

    //    Vector3 distanceToWalkPoint = transform.position - walkPoint;

    //    if (distanceToWalkPoint.magnitude < 1.0f)
    //        walkPointSet = false;


    //}

    //private void searchWalkPoint()
    //{
    //    float RandomZ = Random.Range(-walkPointRange, walkPointRange);
    //    float RandomX = Random.Range(-walkPointRange, walkPointRange);

    //    walkPoint = new Vector3(transform.position.x + RandomX, transform.position.y, transform.position.z + RandomZ);

    //    if (Physics.Raycast(walkPoint, -transform.up, 2.0f, whatIsGround))
    //        walkPointSet = true;
    //}

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        teleportAround();
    }

    private void teleportAround()
    {
        if (teleportTimerOn)
        {
            if (teleportTimeLeft > 0)
            {
                teleportTimeLeft -= Time.deltaTime; 
            }
            else
            {
                teleportTimeLeft = 1;
                Debug.Log("Timer done!");

                var teleportRandomX = Random.Range(-terrainDimensions.x, terrainDimensions.x);
                var teleportRandomZ = Random.Range(-terrainDimensions.z, terrainDimensions.z);
                transform.Translate(new Vector3(teleportRandomX, terrainDimensions.y, teleportRandomZ));
            }    
        }
        else
        {
            return;
        }
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        Destroy(player.gameObject);
    }

}
