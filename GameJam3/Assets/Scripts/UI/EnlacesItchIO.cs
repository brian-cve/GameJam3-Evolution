using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlacesItchIO : MonoBehaviour
{
    // Start is called before the first frame update

    public void itchioLink(string link)
    {
        Application.OpenURL(link);
    }
}
