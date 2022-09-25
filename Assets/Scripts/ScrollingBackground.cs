using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float speed = 4f;

    private Vector3 start_position;

    private void Start(){
    
        start_position = transform.position;
    }

    private void Update(){

        transform.Translate(translation: Vector3.down * speed * Time.deltaTime);
        if(transform.position.y < -10f){

            transform.position = start_position;
        }
    }
}
