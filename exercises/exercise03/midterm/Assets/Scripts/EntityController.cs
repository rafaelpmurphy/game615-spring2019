using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EntityController : MonoBehaviour
{
    public float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;

    public Text loseText;
    public bool hunting = false;

    public float patrolSpeed = 5f;
    private float waitTime;
    public float startWaitTime;
    public Transform moveSpot;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    private void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();

        waitTime = startWaitTime;
        moveSpot.position = new Vector3(Random.Range(minX, maxX), 0.0f, Random.Range(minZ, maxZ));
    }

    private void Update()
    {
        {
            float distance = Vector3.Distance(target.position, transform.position);
            if (distance <= lookRadius)
            {
                agent.SetDestination(target.position);
                hunting = true;
                SetloseText();
            }
            else
            {
                hunting = false;
                SetloseText();
                transform.position = Vector3.MoveTowards(transform.position, moveSpot.position, patrolSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.position, moveSpot.position) < .5f);
                {
                    if (waitTime <= 0)
                    {
                        moveSpot.position = new Vector3(Random.Range(minX, maxX), 0.0f, Random.Range(minZ, maxZ));
                        waitTime = startWaitTime; 
                    } 
                    else
                    {
                        waitTime -= Time.deltaTime;
                    }
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
    void SetloseText()
    {
        if (hunting)
        {
            loseText.text = "The Entity has Found You";
        }
        else 
        {
            loseText.text = "";       
        }
    }
}
