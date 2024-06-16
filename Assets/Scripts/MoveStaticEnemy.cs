using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStaticEnemy : MonoBehaviour
{
    [SerializeField]
    float walkSpeed = 3.0f;

    Vector3 initialPosition; // almacena posicion inicial
    Vector3 endPosition; // almacena la posicion final 

    [SerializeField]
    int metersOfWalk;
     
    Vector3 rotation;

     [SerializeField]
     bool leftStart;
    // Start is called before the first frame update
    void Start()
    {
      if(leftStart){
        initialPosition = transform.position;
        endPosition = new Vector3(initialPosition.x,initialPosition.y,initialPosition.z + metersOfWalk);
        rotation = transform.eulerAngles;
      }else{
        initialPosition = transform.position;
        endPosition = new Vector3(initialPosition.x,initialPosition.y,initialPosition.z - metersOfWalk);
        rotation = transform.eulerAngles;
      }

    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
      if(leftStart){
         if(transform.position.z > endPosition.z){
          transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z );
         }else{
         if(transform.position.z < initialPosition.z){
          transform.eulerAngles = rotation;
          //new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z );
      }
         }
       
    }else{
      if(transform.position.z < endPosition.z){
          transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z );
         }else{
         if(transform.position.z > initialPosition.z){
          transform.eulerAngles = rotation;
          //new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z );
      }

    }
}
    }
}

