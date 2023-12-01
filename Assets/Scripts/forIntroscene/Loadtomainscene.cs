using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadtomainscene : MonoBehaviour
{
    // Start is called before the first frame update
    public void loadtomainscene()
    {
        SceneManager.LoadScene("Size modified Mainscene");
    }
}
