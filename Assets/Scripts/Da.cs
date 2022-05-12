using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Da : MonoBehaviour
{
    public SoundManager audioSource;
    public float speed = 10f;
   
    // Use this for initialization
    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
       
    }
    void Update()
    {
        //cho di chuyển 
        transform.Translate(Vector3.left * speed * Time.deltaTime);


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Dead")
        {
            Destroy(gameObject);
        }
    }
}
