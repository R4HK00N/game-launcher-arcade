using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInfo : MonoBehaviour
{
    int index = 0;
    public NewGameDetector newGameDetector;

    public void SetIndex(int i)
    {
        index = i;
    }

    public int GetIndex()
    {
        return index;
    }

    public int GetIndexInWindow(int _index)
    {
        int result = 0;

        for (int i = _index; i > 5; result++)
        {
            _index -= 5;
        }

        return result;
    }
}
