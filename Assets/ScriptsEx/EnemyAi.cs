using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent enemy; //��

    public Transform player; //�÷��̾�

    public LayerMask whatIsGround, whatIsPlayer; // ��, �÷��̾� ���̾� Ȯ��

    //Patroling
    public Vector3 walkPoint; // Ai �̵����� ����
    bool walkPointSet; // �̵������� �����Ǿ��°�
    public float walkPointRange; // �̵����� ���� ����

    //Attacking
    public float timeBetweenAttacks; // ���� �ð�
    bool alreadyAttacked; // �̹� ������ ������ �ִ°�

    //States
    public float sightRange, attackRange; // Ž������, ���ݹ���
    bool playerInSightRange, playerInAttackRange; // �÷��̾ Ž�������� ���Դ°�, �÷��̾ ���ݹ����� ���Դ°�

    public GameObject enemyBullet; // �� �Ѿ�

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // �÷��̾ �þ߹���, ���ݹ����� �ִ���
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling(); // ����
        if (playerInSightRange && !playerInAttackRange) ChasePlayer(); // ����
        if (playerInSightRange && playerInAttackRange) AttackPlayer(); // ����
    }

    void Patroling()
    {
        if(!walkPointSet) SearchWalkPoint();

        if(walkPointSet)
            enemy.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        // walkPoint�� �����ϸ� walkPoint�� false�� �ϰ� �ٽ� ����
        if(distanceToWalkPoint.magnitude < 5f)
            walkPointSet = false;
    }
    void SearchWalkPoint() // walkPoint ����
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        
        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
    void ChasePlayer()
    {
        enemy.SetDestination(player.position);
    }
    void AttackPlayer() // ����
    {
        enemy.SetDestination(transform.position);
        transform.LookAt(player);
        if(!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(enemyBullet, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * 10f, ForceMode.Impulse);
            rb.AddForce(transform.up * 10f, ForceMode.Impulse);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
