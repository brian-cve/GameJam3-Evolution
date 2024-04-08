using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    public Animator animator;
    public EnemyController enemy;
    public Canvas gameOverCanvas;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PJ"))
        {
            animator.SetBool("walk", false);
            animator.SetBool("run", false);
            animator.SetBool("attack", true);
            enemy.isAttacking = true;
            gameOverCanvas.gameObject.SetActive(true);
            if(enemy.intrudersSoundPlayed == true)
            {
                enemy.enemyAudio.PlayOneShot(enemy.humanNeutralizedSound);
            }
            GetComponent<CapsuleCollider>().enabled = false;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
