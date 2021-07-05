using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currentweapon : MonoBehaviour
{
    public static Iweapon currentweapon_1 = null;
    //public static bool ismag1pnplace = false;

    public static GameObject parent;

    public static Iweapon currentweapon_2 = null;
    //public static bool ismag2pnplace = false;

    public static List<Itarget> targets = new List<Itarget>();

    public static GameObject Parent
    {
        get
        {
            return parent;
        }
    }

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
    public static List<Itarget> Targets
    {
        get
        {
            return targets;
        }
    }
    public static void adder(Itarget targ)
    {
        targets.Add(targ);
    }

    public static void vklucheniekubov()
    {
        Itarget[] targets11 = Targets.ToArray();
        foreach (var o in targets11)
        {
            if (o != null)
            {
                o.setplayer();
            }
        }
    }
}
