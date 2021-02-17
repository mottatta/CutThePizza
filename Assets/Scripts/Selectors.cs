using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectors : MonoBehaviour
{
    public SelectorGroups[] selectors;

    public void SetSelectorNumDenom(int num, int index)
    {
        selectors[index].EbableSelectors(num);
    }
}
