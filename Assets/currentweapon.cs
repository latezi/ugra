using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currentweapon : MonoBehaviour
{
    public static Iweapon currentweapon_1 = null;
    public static bool ismag1pnplace = false;
    
    public static Iweapon currentweapon_2 = null;
    public static bool ismag2pnplace = false;

    public static Iweapon Currentweapon_1
    {
        get
        {
            return currentweapon_1;
        }
        set
        {
            currentweapon_1 = value;
        }
    }
    public static Iweapon Currentweapon_2
    {
        get
        {
            return currentweapon_2;
        }
        set
        {
            currentweapon_2 = value;
        }
    }
    public static bool Ismag1pnplace
    {
        get
        {
            return ismag1pnplace;
        }
        set
        {
            ismag1pnplace = value;
        }
    }
    public static bool Ismag2pnplace
    {
        get
        {
            return ismag2pnplace;
        }
        set
        {
            ismag2pnplace = value;
        }
    }
}
