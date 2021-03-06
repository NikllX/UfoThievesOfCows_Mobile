using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRocket : MonoBehaviour
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
            int randSec = Random.Range(2, 4);
            yield return new WaitForSeconds(randSec);
            float rotY = Random.Range(0, 2);
            float posX = transform.position.x;
            if (rotY == 0)
            {
                rotY = 0;
                posX = transform.position.x;
            }
            else
            {
                rotY = -180;
                posX = transform.position.x * -1;
            }
            float PosYDiaposon = Random.Range(0, 4.5f);
            if (GameObject.Find("Player") != null)
            {
                var rotation = Quaternion.Euler(0, rotY, 0);
                GameObject newGObject = Instantiate(GObject, new Vector3(posX, PosYDiaposon, 0), rotation);
                newGObject.GetComponent<MoveCow>().direction = dir;
                Destroy(newGObject, 15);
            }


        }
    }
}
