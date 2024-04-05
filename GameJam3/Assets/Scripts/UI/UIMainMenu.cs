using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private AudioClip startSound;
    // Start is called before the first frame update
    public void StartLevel(string NameLevel)
    {
        SceneManager.LoadScene(NameLevel);
    }

    // Update is called once per frame
    public void buttonSfx()
    {
        AudioManager1.Instance.PlaySound(startSound);
    }
}
