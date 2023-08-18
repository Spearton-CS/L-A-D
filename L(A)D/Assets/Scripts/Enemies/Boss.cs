using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    private CloseCombatEnemy script;
    private void Start()
    {
        script = GetComponent<CloseCombatEnemy>();
    }
    private void Update()
    {
        if(script.isDie)
        {
            PlayerPrefs.SetInt("IsEnd", 1);
            SceneManager.LoadScene("MainMenu");
        }
    }
}
