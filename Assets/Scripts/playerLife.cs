using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerLife : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]

    float life=100.0f;
    
    [SerializeField]
    float damage=10.0f;

    float actualyLife;

    [SerializeField]
    Image lifeImage;

    public bool getDamage = true;


    void Start()
    {
        actualyLife=life;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag.Equals("Enemy")){
            PlayerHealth();
        }


    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag.Equals("Bonus")){
            //BerrysCount();
            RecoveryPlayerHealth();
            Destroy(other.gameObject);

        }
    }


     void PlayerHealth(){
        if(getDamage){
            if(life > 0){
                actualyLife -= life * 0.1f;
                float percentegeLife = actualyLife / life;
                lifeImage.fillAmount = percentegeLife;
            }else
            {
                Debug.Log("GAME OVER");
            }
        }
        
    }

    void RecoveryPlayerHealth(){
        if(getDamage){
            if(life > 0){
                actualyLife += life * 0.1f;
                float percentegeLife = actualyLife / life;
                lifeImage.fillAmount = percentegeLife;
                Debug.Log("BONUS OBTENIDO");
                
            }else
            {
                Debug.Log("GAME OVER");
            }
        }
        
    }

}
