# #NVJOB Simple Pool 1.2.1
#### [nvjob.github.io/unity/nvjob-simple-pool](https://nvjob.github.io/unity/nvjob-simple-pool)

![GitHub Logo](https://raw.githubusercontent.com/nvjob/nvjob.github.io/master/repo/unity%20assets/nvjob%20simple%20pool/12/pic/1.jpg)

This is a simple pool for optimizing object loading.

Permanent creation and destruction of objects in your scene, very expensive in terms of memory management, use the Simple Pool object pool to save memory and improve performance.

All objects in the pool are loaded during initialization, and then retrieved from the pool and returned back to the pool without sacrificing performance.<br>
The pool allows you to completely abandon Instantiate and Destroy after initialization.

-------------------------------------------------------------------

### Prerequisites

To work on the project, you will need a Unity version of at least 2019.1.8 (64-bit).

### Information

#### Getting an object from a pool:
```
GameObject obj = SimplePool.GiveObj(0);
```
SimplePool.GiveObj() instead of using Instantiate(Object).<br>
SimplePool.GiveObj(numElement)-> numElement - number of the Element in editor (SimplePool).

![GitHub Logo](https://raw.githubusercontent.com/nvjob/nvjob.github.io/master/repo/unity%20assets/nvjob%20simple%20pool/12/pic/3.jpg)

#### After all the transformations of the object, activate it:
```
obj.SetActive(true);
```
#### Return object to the pool, remove from the scene:
```
SimplePool.Takeobj(obj);
```
SimplePool.Takeobj() instead of using - Destroy(Object).<br>
SimplePool.Takeobj(GameObject)-> GameObject - is an object that to be returned to the pool.

#### The number of elements in the editor (SimplePool):
```
SimplePool.numObjectsList
```
#### Checking that the pool is not empty:
```
GameObject obj = SimplePool.GiveObj(0);
if (obj != null)
{
}
```
If the pool is empty it will return null.

#### Example script:
```
using UnityEngine;

public class Example : MonoBehaviour
{
    GameObject obj;

    void Start()
    {
        if(SimplePool.numObjectsList == 0) obj = SimplePool.GiveObj(0);
        else obj = SimplePool.GiveObj(Random.Range(0, SimplePool.numObjectsList));
        if (obj != null)
        {
            obj.transform.SetPositionAndRotation(transform.position, transform.rotation);
            obj.transform.parent = transform;
            obj.SetActive(true);
            Invoke("DestroyObject", 5);
        }
    }

    void DestroyObject()
    {
        SimplePool.Takeobj(obj);
    }
}
```

#### Video manual:
https://www.youtube.com/watch?v=fhuhPnpSoJU

-------------------------------------------------------------------

![GitHub Logo](https://raw.githubusercontent.com/nvjob/nvjob.github.io/master/repo/unity%20assets/nvjob%20simple%20pool/12/pic/1.gif)

-------------------------------------------------------------------

**Authors:** [#NVJOB. Developer Nicholas Veselov. Разработчик Николай Веселов. Санкт-Петербург.](https://nvjob.github.io)

**License:** MIT License. [Clarification of licenses](https://nvjob.github.io/mit-license).

**Sorry:** This project is currently frozen and cannot be supported or updated due to its complete non-profitability.
