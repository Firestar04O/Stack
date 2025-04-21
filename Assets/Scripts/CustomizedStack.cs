using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizedStack <T> : Stack<T>
{
    public virtual T PopCustomized()
    {
        if (last == null)
            return default;

        T value = last.Value;
        last = last.Prev;
        count--;
        return value;
    }
}
