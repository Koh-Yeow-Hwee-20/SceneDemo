using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject gamescoreGO;

    float speed = 5.0f;
    int iCount = 10;
    int TotalPowerUpLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TotalPowerUpLeft = GameObject.FindGameObjectsWithTag("PowerUp").Length;
        Debug.Log("Total PowerUps LEFT: " + TotalPowerUpLeft.ToString());

        if(TotalPowerUpLeft == 0)
        {
            Debug.Log("Going OVER to new SCENE NOW when ALL power ups are taken");
            SceneManager.LoadScene("EndScene");
        }
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            iCount--;
            gamescoreGO.GetComponent<Text>().text = "Game Score: " + iCount.ToString();

            if(iCount == 0)
            {
                Debug.Log("Going OVER to new SCENE NOW");
                SceneManager.LoadScene("EndScene");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            iCount++;
            gamescoreGO.GetComponent<Text>().text = "Game Score: " + iCount.ToString();

            Destroy(other.gameObject);
        }
    }
}
