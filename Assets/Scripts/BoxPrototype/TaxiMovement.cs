using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaxiMovement : MonoBehaviour
{
    public float speed;
    public GameObject WinScreen;
    public TextMeshProUGUI remainingPassengers;

    private Rigidbody rBody;
    private int passengers = 3;
    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        remainingPassengers.SetText(passengers.ToString());

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if(passengers == 0)
        {
            WinScreen.SetActive(true);
            return;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        rBody.transform.position = rBody.transform.position + (movement * speed);
    }

    private void OnTriggerEnter(Collider collision)
    {
        collision.gameObject.SetActive(false);
        passengers--;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision mit");
        rBody.transform.position = this.position;
    }
}
