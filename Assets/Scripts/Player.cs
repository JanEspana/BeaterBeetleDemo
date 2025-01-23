using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{
    public Camera cam;
    public float calories;
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
}
