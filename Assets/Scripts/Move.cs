using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    public int speed = 500;
    private bool isMovingRight = false;
    private bool isMovingLeft = false;
    private bool isMovingUp = false;
    private bool isMovingDown = false;
    private bool canRotate = true;
    public bool EnteredTrigger;
    public GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && !isMovingRight)
        {
            CancelInvoke();
            InvokeRepeating(nameof(RollRight), 0.2f, 0.2f);
            isMovingLeft = false;
            isMovingUp = false;
            isMovingDown = false;
            isMovingRight = true;
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) && !isMovingUp)
        {
            CancelInvoke();
            InvokeRepeating(nameof(RollUp), 0.2f, 0.2f);
            isMovingRight = false;
            isMovingUp = true;
            isMovingDown = false;
            isMovingLeft = false;
        }
        if (!EnteredTrigger)
        {
            Debug.Log("hello");
        }
    }

    private void RollRight()
    {
        if (canRotate)
            StartCoroutine(Roll(Vector3.right));
    }

    private void RollUp()
    {
        if (canRotate)
            StartCoroutine(Roll(Vector3.forward));
    }

    IEnumerator Roll(Vector3 direction)
    {
        float remainingAngle = 90;
        Vector3 rotationCenter = transform.position + direction / 2f + Vector3.down / 2f;
        Vector3 rotationAxis = Vector3.Cross(Vector3.up, direction);
        canRotate = false;
        while (remainingAngle > 0)
        {
            float rotationAngle = Mathf.Min(Time.deltaTime * speed, remainingAngle);
            transform.RotateAround(rotationCenter, rotationAxis, rotationAngle);
            remainingAngle -= rotationAngle;
            yield return null;
        }
    }
    void OnCollisionEnter(Collision collision)
    {

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Ground")
        {
            canRotate = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Ground")
        {
            collision.rigidbody.useGravity = true;
            collision.rigidbody.isKinematic = false;

            Destroy(collision.gameObject, 3);
            gameManager.AddScore();
        }
    }
    void OnTriggerExit(Collider other)
    {
        Collider temp = other.GetComponent<Collider>();
        if (temp != null)
        {
            Invoke(nameof(Reset), 2);
        }
    }
    void OnTriggerStay(Collider other)
    {
        Collider temp = other.GetComponent<Collider>();
        if (temp != null)
        {
            EnteredTrigger = true;
        }
    }
    void Reset()
    {
        SceneManager.LoadScene(0);
    }
}
