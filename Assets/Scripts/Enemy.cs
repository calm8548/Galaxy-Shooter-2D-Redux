using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;


// Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(random, random, 0);
    }

    // Update is called once per frame
    void Update()
    {        
        transform.Translate(Vector3.down * _speed * Time.deltaTime);       
        if (transform.position.y <= -5f)
        {
            transform.position = new Vector3(Random.Range(-11.3f,11.3f), 5f, 0);
        }       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);
        }

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

    }
}
