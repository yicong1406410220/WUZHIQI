using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildBase : MonoBehaviour {

    public ChildBase Instance;

    public ChildType childType = ChildType.NULL;

    public int locationX = 0;
    public int locationY = 0;

    public int roundNumber = 0;

    public void SetLocationXY(int x, int y)
    {
        locationX = x;
        locationY = y;
    }

    // Use this for initialization
    public void Start () {
        Instance = this;
        //Debug.Log("初始化ChildBase");
        Init();
    }

    public virtual void Init()
    {
    }

}

public enum ChildType
{
    NULL,
    White,
    Black,
}