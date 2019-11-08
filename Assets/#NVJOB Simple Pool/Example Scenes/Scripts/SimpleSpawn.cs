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

            // SimplePool.GiveObj() - pool gives object.
            // Instead of using - GameObject obj = Instantiate(Object).
            // SimplePool.GiveObj(numElement)-> numElement - number of the item in editor (SimplePool).
            GameObject obj = SimplePool.GiveObj(Random.Range(0, SimplePool.numObjectsList));

            if (obj != null) // Checking that the pool is not empty.
            {
                obj.transform.SetPositionAndRotation(thisTransform.position, Random.rotation);
                obj.transform.parent = thisTransform;

                // After all the transformations of the object, activate it.
                obj.SetActive(true);

                yield return delay1;

                //--------------

                // SimplePool.Takeobj() - object is returned to the pool. Instead of using - Destroy(Object).
                // SimplePool.Takeobj(GameObject)-> GameObject - is an object that to be returned to the pool.
                SimplePool.Takeobj(obj);
            }

            //--------------
        }
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}