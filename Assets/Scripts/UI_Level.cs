using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Level : MonoBehaviour
{
    [SerializeField]
    // Start is called before the first frame update
    GameObject panelPause;

    [SerializeField]
    GameObject panelMes;

    bool active = false;
    void Start()
    {
        panelPause.SetActive(false);
        panelMes.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            active = !active; 
            if(active){
                 panelPause.SetActive(true);
            }else{
                 panelPause.SetActive(false);
            }
        }
    }

    public void Restart(){
        panelPause.SetActive(false);
        active = !active;
    }

    public void Exit(){
        SceneManager.LoadScene("Menu");
    }
}
