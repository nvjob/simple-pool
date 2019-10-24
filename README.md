# #NVJOB Simple Pool

Version 1.2

This is a simple pool for optimizing object loading.<br>
All objects in the pool are loaded during initialization, and then retrieved from the pool and returned back to the pool without sacrificing performance.<br>
The pool allows you to completely abandon Instantiate and Destroy after initialization.

![GitHub Logo](https://raw.githubusercontent.com/nvjob/nvjob.github.io/master/repo/unity%20assets/nvjob%20simple%20pool/12/pic/1.gif)

### Prerequisites

To work on the project, you will need a Unity version of at least 2019.1.8 (64-bit).

### Information

Getting an object from a pool:
```
GameObject obj = SimplePool.GiveObj(0);
```
After all the transformations of the object, activate it:
```
obj.SetActive(true);
```
Return object to the pool, remove from the scene:
```
SimplePool.Takeobj(obj);
```

![GitHub Logo](https://raw.githubusercontent.com/nvjob/nvjob.github.io/master/repo/unity%20assets/nvjob%20simple%20pool/12/pic/1.png)

-------------------------------------------------------------------

### Authors
Designed by #NVJOB Nicholas Veselov - https://nvjob.github.io

### License
MIT License - https://nvjob.github.io/mit-license

### Donate
Help for this project - https://nvjob.github.io/donate
