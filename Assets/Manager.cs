using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public Transform myCamera;
    public Transform myBird;
    public Transform kolonlar;
    public Transform background;
    public Transform sky;
    public Transform grass;
    float columnDistance = 20f;
    float skyDistance = 43.64f;
    public Text countText;
    private int score;


    // Use this for initialization
    void Start () {
        CreateColumns();
        score = 0;
        setScoreText();
        //Invoke("CreateColumns",2); //bir kere çalıştırır
        InvokeRepeating("CreateColumns", 1, 3);
        InvokeRepeating("CreateGrass", 1, 6);
        InvokeRepeating("setScoreText", 4f, 3.1f);
    }

    void CreateGrass() {
        Instantiate(background, new Vector3(skyDistance, 2.332f, 0), Quaternion.identity);
        skyDistance += 43.64f;
    }
    void CreateColumns()
    {
        Instantiate(kolonlar, new Vector3(columnDistance, Random.Range(-1, 8f), 0), Quaternion.identity);
        columnDistance += 15;

    }

    // Update is called once per frame
    void Update () {
        myCamera.transform.position = 
            new Vector3(myBird.transform.position.x, myCamera.transform.position.y, myCamera.transform.position.z);
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pick Up"))
        {
            collision.gameObject.SetActive(false);
            score += 1;
        }

        
    }
    void setScoreText()
    {
        countText.text = "Score: " + score.ToString();
        score += 1;
    }


}
