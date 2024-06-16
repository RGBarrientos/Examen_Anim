using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ObjectsCount : MonoBehaviour
{
 

    int berry = 0;
    [SerializeField]
    TMP_Text TextBerryCount;
    [SerializeField]
    int recoledBerrys;
    //scale trannsform
    Vector3 scale;

    [SerializeField]
    GameObject message;

    [SerializeField]
    TMP_Text messageText;


    [SerializeField]
    int x=1;
    int y=1;
    int z=1;
    playerLife life;



    void Start(){
        //scale = transform.localScale
        scale = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z);
        life = GetComponent<playerLife>();

    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag.Equals("CherryBerry")){
            //BerrysCount();
            berry += 1;
            TextBerryCount.text = berry.ToString();
            Destroy(other.gameObject);

        }
    }

    void Update()
    {
        if(Input.GetKeyDown("q")){
            if(berry >= recoledBerrys){
                transform.localScale = new Vector3(x,y,z);
                life.getDamage = false;
                StartCoroutine("timeToGrowUp");
                Debug.Log("Poder disponible");
                berry -= recoledBerrys;
                TextBerryCount.text = berry.ToString();
                

            }else{
                Debug.Log("Necesitas más");
                messageText.text = "Necesitas más";
                message.SetActive(true);
                StartCoroutine("TimeToMessage");
            }

        }
    }

       IEnumerator TimeToGrowUp(){
        yield return new WaitForSeconds(5);
        transform.localScale = scale;
        life.getDamage = true;
    }

    IEnumerator TimeToMessage(){
        yield return new WaitForSeconds(2);
        message.SetActive(false);
        messageText.text="";
    }




}
