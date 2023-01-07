using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private int points;
    public Text score;
    public GameObject KillSphere;
    public GameObject PointSphere;
    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        points = 0;
        InvokeRepeating("SpawnKillSphere",4.6f,1.1f);
        InvokeRepeating("SpawnPointSphere", 0.9f, 2.2f);
        InvokeRepeating("SpawnKillSphere", 30f, 3.3f);
        InvokeRepeating("SpawnKillSphere", 60f, 4.4f);
        InvokeRepeating("SpawnKillSphere", 90f, 1.1f);
        InvokeRepeating("SpawnKillSphere", 120f, 2.2f);
    }
    private void SpawnKillSphere()
    {
        float randomX = Random.Range(-8, 9);
        Vector3 randomSpawnPosition = new Vector3(randomX, 37, 0);
        Instantiate(KillSphere, randomSpawnPosition, Quaternion.identity);
    }

    private void SpawnPointSphere()
    {
        float randomX = Random.Range(-9, 9);
        Vector3 randomSpawnPosition = new Vector3(randomX, 37, 0);
        Instantiate(PointSphere, randomSpawnPosition, Quaternion.identity);
    }
    // Update is called once per frame

    void Update()
    {
        score.text = "Punkty: " + points.ToString();
    }

    private void FixedUpdate()
    {
        float input = Input.GetAxis("Horizontal");
        Vector3 forceVector = Vector3.right * input * 111;
        //Debug.Log(forceVector.ToString());
        rb.AddForce(forceVector);
    }
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("KillSphere"))
        {
            //Koniec gry - Game Over
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (other.gameObject.CompareTag("PointSphere"))
        {
            //Punkt
            points++;
        }
        Destroy(other.gameObject);
    }
}