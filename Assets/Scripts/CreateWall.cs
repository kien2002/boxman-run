using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWall : MonoBehaviour {

    //các khối vật cản
    public GameObject wallBasic;
    public GameObject coindichuyen;
    public GameObject dadichuyen;
    public GameObject coinroi;
    //GameObject vừa tạo
    public GameObject obvitri;
    public GameObject vitricoin;
    public GameObject vitriDa;
    public GameObject vitriroi;
    // Use this for initialization

    float i;

    void Start()
    {
        //chạy Creat();
        StartCoroutine(Creat());
        StartCoroutine(Creact());
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            i = 10;
            Instantiate(coinroi, transform.position, Quaternion.identity);
        }
    }

    IEnumerator Creat()
    {
        //đợi 3s
        yield return new WaitForSeconds(Random.Range(1f, 2.5f));
        //lấy vị trí để sinh ra
        Vector3 temp = obvitri.transform.position;
        //randum chiều cao
        temp.y = Random.Range(-6f, -2.8f);
        //Instantiate sinh ra wallbasic, temp vector3 
        Instantiate(wallBasic, temp, Quaternion.identity);
        StartCoroutine(Creat());
    }
    //IEnumerator CreatDa()
    //{
    //    //đợi 3s
    //    yield return new WaitForSeconds(Random.Range(5f, -0.5f));
    //    //lấy vị trí để sinh ra
    //    Vector3 temp = vitriDa.transform.position;
    //    //randum chiều cao
    //    temp.y = Random.Range(4f, -1f);
    //    Instantiate(dadichuyen, temp, Quaternion.identity);
    //    StartCoroutine(CreatDa());
    //}
    IEnumerator Creact()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 1f));
        //lấy vị trí để sinh ra
        Vector3 temp = vitricoin.transform.position;
       
        //randum chiều cao
        temp.y = Random.Range(0.2f,1.5f);
       
        //Instantiate sinh ra wallbasic, temp vector3 
        Instantiate(coindichuyen, temp, Quaternion.identity);

        StartCoroutine(Creact());
    }

}
