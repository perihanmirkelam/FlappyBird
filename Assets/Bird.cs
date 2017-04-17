using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{

    public int yukariSabiti = 4;
    public Rigidbody2D rb;
    public int speed = 5;
    public Text countText;

    bool isDead;
    // Use this for initialization
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        if (!isDead)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //üç boyutlu vektör
                //transform.position += Vector3.right * yukariSabiti; //yanlış yol
                rb.AddForce(Vector2.up * yukariSabiti);
            }
        }
        else
        {
            countText.text = "Game Over!";
        }

    }

     void OnCollisionEnter2D(Collision2D coll){
        if (coll.gameObject.tag == "block")
        {
            isDead = true;
            print("Dead");
        }    
    }

 

}