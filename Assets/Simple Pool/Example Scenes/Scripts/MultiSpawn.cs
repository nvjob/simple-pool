// MIT license (https://nvjob.github.io/mit-license)
// #NVJOB Nicholas Veselov - https://nvjob.github.io


using System.Collections;
using UnityEngine;
using System.Collections.Generic;


///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


public class MultiSpawn : MonoBehaviour
{
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    public float crackScale = 1.2f;
    public int amountObj = 2;

    //--------------

    static WaitForSeconds delay0 = new WaitForSeconds(1.0f);
    Transform thisTransform;
    float objPoolScale;
    List<GameObject> childList = new List<GameObject>();


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    void Awake()
    {
        //--------------

        thisTransform = transform;

        //--------------
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    void Start()
    {
        //--------------

        objPoolScale = 1.0f / amountObj;
        StartCoroutine("ObjSpawn");

        //--------------
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    IEnumerator ObjSpawn()
    {
        //--------------

        while (true)
        {
            yield return delay0;

            for (int z = 0; z < amountObj; z++)
            {
                for (int y = 0; y < amountObj; y++)
                {
                    for (int x = 0; x < amountObj; x++)
                    {
                        yield return null;

                        int randomObj = Random.Range(0, SimplePool.numObjectsList);
                        GameObject obj = SimplePool.GiveObj(randomObj); // Pool gives object. Instead of using - GameObject obj = Instantiate(Object)

                        if (obj != null)
                        {
                            obj.transform.SetPositionAndRotation(thisTransform.position, Random.rotation);
                            obj.transform.parent = thisTransform;
                            obj.transform.localScale = Vector3.one * objPoolScale / crackScale;
                            float st = objPoolScale * 0.5f - 0.5f;
                            float ot = objPoolScale * crackScale;
                            obj.transform.localPosition = new Vector3(st + x * ot, st + y * ot, st + z * ot);
                            obj.SetActive(true); // After all the transformations of the object, activate it.
                            childList.Add(obj);
                        }
                    }
                }
            }

            yield return delay0;

            for (int n = 0; n < childList.Count; n++)
            {
                yield return null;

                SimplePool.Takeobj(childList[n]); // Оbject is returned to the pool. Instead of using - Destroy(Object)
            }

            childList = new List<GameObject>();
        }

        //--------------
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}