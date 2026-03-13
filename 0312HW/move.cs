using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public int state = 0;
    public float moveSpeed = 5f;
    public GameObject sphere;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   

        float movex = Input.GetAxis("Horizontal"); //a d
        float movez = Input.GetAxis("Vertical"); //w s

        Vector3 moveDir = new Vector3(movex, 0, movez); //移動x,z 向量 y=0 =>避免往上或往下漂
        transform.Translate(moveDir * moveSpeed * Time.deltaTime); // 物體移動速度


        
        
    }

    void OnMouseDown()
    {
        //for debug
        Debug.Log("點擊偵測成功！當前 state: " + state);
        GetComponent<Renderer>().material.color = Color.yellow;

        state--;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "Sphere") // 方塊碰到圓形就會被destroy
        {
            Destroy(col.gameObject);
        }
        /*
        else
        {
            col.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        */
    }

}
