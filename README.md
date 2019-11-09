# #NVJOB Simple Pool

Version 1.2.1

This is a simple pool for optimizing object loading.<br>
All objects in the pool are loaded during initialization, and then retrieved from the pool and returned back to the pool without sacrificing performance.<br>
The pool allows you to completely abandon Instantiate and Destroy after initialization.

![GitHub Logo](https://raw.githubusercontent.com/nvjob/nvjob.github.io/master/repo/unity%20assets/nvjob%20simple%20pool/12/pic/1.gif)

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

https://www.youtube.com/watch?v=fhuhPnpSoJU

![GitHub Logo](https://raw.githubusercontent.com/nvjob/nvjob.github.io/master/repo/unity%20assets/nvjob%20simple%20pool/12/pic/1.jpg)

-------------------------------------------------------------------

**Authors:**<br>
#NVJOB Nicholas Veselov - https://nvjob.github.io

**License:**<br>
MIT License<br>
Clarification of licenses - https://nvjob.github.io/mit-license

**Support:**<br>
https://nvjob.github.io/support

**Report a Problem / Issue Tracker / FAQ:**<br>
https://nvjob.github.io/reportaproblem
