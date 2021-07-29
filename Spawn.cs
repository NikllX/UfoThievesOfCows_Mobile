using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject GObject;
    public Vector2 dir;
    void Start()
    {
        StartCoroutine(Spawner());
    }
    IEnumerator Spawner()
    {
        while (true)
        {
            int randSec = Random.Range(4, 8);
            yield return new WaitForSeconds(randSec);
            float rotY = Random.Range(0, 2);
            float posX = transform.position.x;
            if (rotY == 0)
            {
                rotY = 0;
                posX = transform.position.x;
            }else
            {
                rotY = -180;
                posX = transform.position.x * -1;
            }
            if (GameObject.Find("Player") != null)
            {
                var rotation = Quaternion.Euler(0, rotY, 0);
                GameObject newGObject= Instantiate(GObject, new Vector3(posX, transform.position.y, 0), rotation);
                newGObject.GetComponent<MoveCow>().direction = dir;
                Destroy(newGObject, 15);
            }
        }
    }
}

