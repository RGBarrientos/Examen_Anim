using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI2 : MonoBehaviour
{
    [SerializeField]
    GameObject target;

    NavMeshAgent agent;

    int pointPatroll;

    [SerializeField]
    GameObject[] patrollZones;

    [SerializeField]
    float persecutionRange;

    [SerializeField]
    float Attack1Range;


    bool persecution = false;

    bool rangePersecution;
    bool rangeAttack1;

    [SerializeField]
    LayerMask isLayer;

    Animator EnemyAnimator;




    const float patrolSpeed = 2f;
    const float pursuitSpeed = 3.5f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (patrollZones.Length > 0)
        {
            pointPatroll = Random.Range(0, patrollZones.Length);
            Debug.Log(pointPatroll);
        }
        else
        {
            Debug.LogWarning("No patrol zones assigned.");
        }
        EnemyAnimator = GetComponent<Animator>();

        
    }

    void Update()
    {
        if (!persecution)
        {

            agent.SetDestination(patrollZones[pointPatroll].transform.position);
        }
        else
        {

            agent.SetDestination(target.transform.position);
            //agent.stoppingDistance=2;
        }
        Persecution();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Patroll"))
        {
            int point;
            do
            {
                point = Random.Range(0, patrollZones.Length);
            } while (point == pointPatroll);

            pointPatroll = point;
            Debug.Log("punto de patrullaje: "+pointPatroll);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, persecutionRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Attack1Range);
    }

    void Persecution()
    {
        rangePersecution = Physics.CheckCapsule(transform.position,
        transform.position, persecutionRange, isLayer);

        rangeAttack1 = Physics.CheckCapsule(transform.position,
        transform.position, Attack1Range, isLayer);

        if (rangePersecution)
        {
            persecution = true;
            agent.speed = pursuitSpeed;
            agent.stoppingDistance=3;
            if(rangeAttack1){
                transform.LookAt(target.transform);
                EnemyAnimator.SetBool("Walk", false);
                EnemyAnimator.SetBool("Attack1", true);
            }

        }
        else
        {

            persecution = false;
            agent.speed = patrolSpeed;
            agent.stoppingDistance=0;
            EnemyAnimator.SetBool("Walk", true);
            EnemyAnimator.SetBool("Attack1", false);

        }
    }
}
