using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{
    public Camera cam;
    public float calories;
    public float gainedCalories=100;
    public bool isBlocking;
    public override void CheckIfAlive(bool hasKnockback)
    {
        if (hasKnockback)
        {
            Debug.Log("Implement knockback");
        }
        if (HP <= 0)
        {
            HP = 0;
            Die();
        }
    }
    public override void Die()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<Movement>().enabled = false;
        gameObject.GetComponent<AttackManager>().enabled = false;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        cam.gameObject.GetComponent<CameraFollow>().enabled = false;

        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MainMenuDemo");
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isBlocking = true;
            //busca movement de este objeto
            gameObject.GetComponent<Movement>().speed=0;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isBlocking = false;
            gameObject.GetComponent<Movement>().speed = 10;
        }
    }
}
