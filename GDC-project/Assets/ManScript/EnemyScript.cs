using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    GameObject player;
    GameObject pointHandler;

    public float moveSpeed;

    // Start is called before the first frame update
    void Start() //her finder Enemy player
    {
        player = GameObject.FindWithTag("Player");
        pointHandler = GameObject.FindWithTag("PointHandler");
    }

    // Update is called once per frame
    void Update()
    {
        //moveHandler();
        //CheckForSceneRestart();

        gameObject.GetComponent<NavMeshAgent>().destination = player.transform.position;
    }

    /*void moveHandler() //her er direction altså vi tager A-B vektor 
    {
        Vector3 enemyPos = transform.position;
        Vector3 playerPos = player.transform.position;
        Vector3 moveDirection = (playerPos - enemyPos).normalized;

        gameObject.GetComponent<Rigidbody>().velocity = moveDirection * moveSpeed;

    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject ManPlayer = collision.gameObject;
            ManMove ManComponent = ManPlayer.GetComponent<ManMove>();
            SceneManager.LoadScene("horro game");


        }

        //FindAllExplodables();
    }
    private void onCollisionEnter(Collision other)
    { 

        bool isEnemy = other.gameObject.tag == "Enemy";
        if (isEnemy)
        {
            Destroy(other.gameObject);
        }

    }


}


