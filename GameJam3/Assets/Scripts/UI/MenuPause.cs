using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    [SerializeField] private AudioClip startSound;
    public GameObject ObjetoMenuPausa;
    public bool Pausa = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pausa == false)
            {
                ObjetoMenuPausa.SetActive(true);
                Pausa = true;

                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                AudioManager1.Instance.PlaySound(startSound);
            }
            else if (Pausa == true)
            {
                Resume();
            }
        }
    }

    public void Resume()
    {
        ObjetoMenuPausa.SetActive(false);
        Pausa = false;
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        AudioManager1.Instance.PlaySound(startSound);
    }


    public void ReturnMenu(string nameMenu)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(nameMenu);
        AudioManager1.Instance.PlaySound(startSound);

    }





}
