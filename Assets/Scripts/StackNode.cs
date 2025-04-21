using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackNode<T>
{
    #region Properties
    private T value;
    private StackNode<T> prev;
    #endregion

    #region Getters
    public T Value => value;
    public StackNode<T> Prev => prev;
    #endregion

    #region Constructors
    public StackNode(T value)
    {
        this.value = value;
        this.prev = null;
    }
    public void SetPrev(StackNode<T> prev)
    {
        this.prev = prev;
    }
    #endregion

}