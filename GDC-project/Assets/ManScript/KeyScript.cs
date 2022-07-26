using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    bool Key = false;




    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            Destroy(gameObject);
            Key = true;
            
            if (collision.gameObject.tag == ("Door"))
            {
                Collider.enabled = false;
            }
        }
    }



   
   
}

