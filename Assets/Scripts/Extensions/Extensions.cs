using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static int IndexOfWithNumberOf(this string _value, char _symbol, int _symbolNumber)
    {
        int _count = 0;

        for(int i = 0; i < _value.Length; i++)
        {
            if (_value[i] == _symbol) _count++;
            if (_count == _symbolNumber) return i;
        }
        return -1;
    }
}
