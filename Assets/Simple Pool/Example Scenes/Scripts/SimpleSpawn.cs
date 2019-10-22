// MIT license (https://nvjob.github.io/mit-license)
// #NVJOB Nicholas Veselov - https://nvjob.github.io


using System.Collections;
using UnityEngine;


///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


public class SimpleSpawn : MonoBehaviour
{
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    static WaitForSeconds delay0 = new WaitForSeconds(1.0f), delay1 = new WaitForSeconds(4.0f);
    Transform thisTransform;


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    void Awake()
    {
        //--------------

        thisTransform = transform;
        StartCoroutine("ObjSpawn");

        //--------------
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    IEnumerator ObjSpawn()
    {
        while (true)
        {
            //--------------

            yield return delay0;

            GameObject obj = SimplePool.GiveObj(Random.Range(0, SimplePool.numObjectsList)); // Pool gives object. Instead of using - GameObject obj = Instantiate(Object)

            obj.transform.SetPositionAndRotation(thisTransform.position, Random.rotation);
            obj.transform.parent = thisTransform;

            obj.SetActive(true); // After all the transformations of the object, activate it.

            yield return delay1;

            //--------------

            SimplePool.Takeobj(obj); // Оbject is returned to the pool. Instead of using - Destroy(Object)

            //--------------
        }
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}