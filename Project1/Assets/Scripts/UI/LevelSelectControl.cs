
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectControl : MonoBehaviour
{
    public static LevelSelectControl instance { get; private set; }
    [SerializeField] List<GameObject> lv;
    public static int lockLv = 7; 
    private void Awake()
    {
        if (instance != null && instance != this) Destroy(this);
        else instance = this;
        
        //lock from lv lockLv
        for (int i = lockLv; i < lv.Count; i++)
        {
            lv[i].GetComponent<LevelSelect>().Lock();
        }
        for (int i = 1; i < lockLv; i++)
        {
            UnLockLevel(i);
        }
    }
   
    public void UnLockLevel(int x)
    {
        if (lv.Count >= x) lv[x].GetComponent<LevelSelect>().Unlock();
        else return;
    }

}
