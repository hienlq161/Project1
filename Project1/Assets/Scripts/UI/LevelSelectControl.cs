
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectControl : MonoBehaviour
{
    public static LevelSelectControl instance { get; private set; }
    [SerializeField] List<GameObject> lv;
    public int lockLv; 
    private void Awake()
    {
        if (instance != null && instance != this) Destroy(this);
        instance = this;
        lockLv = 2;
        print(lockLv);
        UnLockLevel(1);
        //lock from lv 3
        for (int i = lockLv; i <= lv.Count; i++)
        {
            lv[i - 1].GetComponent<LevelSelect>().Lock();
        }

    }
    private void Start()
    {
       
    }
    public void UnLockLevel(int x)
    {
        if (lv.Count >= x) lv[x - 1].GetComponent<LevelSelect>().Unlock();
        else return;
    }

}
