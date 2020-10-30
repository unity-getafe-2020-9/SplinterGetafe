using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static bool key = false;

    public static bool HasKey()
    {
        return key;
    }
    public static void SetKeyTrue()
    {
        key = true;
    }

}
