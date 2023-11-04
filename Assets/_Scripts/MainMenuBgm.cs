using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBgm : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundCollection.instance.ChangeAndPlayBgm(0);
    }
}
