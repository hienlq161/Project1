using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBar : MonoBehaviour
{
    public float speed;
    public float distance;
    int count;
    public int maxCount;
    private void Start()
    {
        count = 0;
    }
    public void ScrollLeft()
    {
        if (count < maxCount)
        {
            Vector3 target = transform.position - distance * new Vector3(1, 0, 0);
            transform.position = Vector3.Lerp(transform.position, target, speed);
            count++;
        }
        else return;
        
    }
    public void ScrollRight()
    {
        if (count > 0)
        {
            Vector3 target = transform.position + distance * new Vector3(1, 0, 0);
            transform.position = Vector3.Lerp(transform.position, target, speed);
            count--;
        }
        else return;

    }
}
