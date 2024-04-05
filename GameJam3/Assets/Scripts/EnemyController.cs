using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public int routine;

    public float timer;
    public float degree;
    public float walkSpeed;
    public float attackDistance;
    [Range(0, 360)]
    public float visionRange;
    public float radius;


    public bool isAttacking;
    public bool hasLineOfSight;

    public Animator enemyAnimator;

    public GameObject target;

    public EnemyRange range;

    public NavMeshAgent agent;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    public Quaternion angle;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        target = GameObject.Find("Player");
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }
    // Update is called once per frame
    void Update()
    {
        EnemyBehavior();

        Debug.Log(hasLineOfSight);
    }

    public void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < visionRange / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleMask))
                {
                    hasLineOfSight = true;
                }
                else
                {
                    hasLineOfSight = false;
                }
            }
            else
            {
                hasLineOfSight = false;
            }

        }
        else if (hasLineOfSight)
        {
            hasLineOfSight = false;
        }
    }


    public void EnemyBehavior()
    {
        if (!hasLineOfSight)
        {
            agent.enabled = true;
            enemyAnimator.SetBool("run", false);
            timer += 1 * Time.deltaTime;
            if (timer >= 4)
            {
                routine = Random.Range(0, 2);
                timer = 0;
            }
            switch (routine)
            {
                case 0:
                    enemyAnimator.SetBool("walk", false);

                    break;

                case 1:
                    degree = Random.Range(0, 360);
                    angle = Quaternion.Euler(0, degree, 0);
                    routine++;

                    break;

                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 0.5f);
                    transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
                    enemyAnimator.SetBool("walk", true);
                    break;
            }
        }
        else if (hasLineOfSight)
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);

            agent.enabled = true;
            agent.SetDestination(target.transform.position);

            if (Vector3.Distance(transform.position, target.transform.position) > attackDistance && !isAttacking)
            {
                enemyAnimator.SetBool("walk", false);
                enemyAnimator.SetBool("run", true);
            }
            else if (!isAttacking)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 1);
                enemyAnimator.SetBool("walk", false);
                enemyAnimator.SetBool("run", false);
            }
        }
        
        if (isAttacking)
        {
            agent.enabled = false;
        }

    }

    public void EndAttackAnimation()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > attackDistance + 0.2f)
        {
            enemyAnimator.SetBool("attack", false);
        }

        isAttacking = false;
        range.GetComponent<CapsuleCollider>().enabled = true;

    }
}

