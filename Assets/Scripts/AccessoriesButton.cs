using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoriesButton : MonoBehaviour
{
    private Theodore theodore;
    private void Awake()
    {
        theodore = FindObjectOfType<Theodore>();
    }
    public void GlassesToggle()
    {
        if (TheodoreBusy())
        {
            return;
        }
        theodore.hasGlasses = !theodore.hasGlasses;
        theodore.UpdateAccessories();
    }

    public void ScarfToggle()
    {
        if (TheodoreBusy())
        {
            return;
        }
        theodore.hasScarf = !theodore.hasScarf;
        theodore.UpdateAccessories();
    }

    public void HatToggle()
    {
        if (TheodoreBusy())
        {
            return;
        }
        theodore.hasHat = !theodore.hasHat;
        theodore.UpdateAccessories();
    }

    private bool TheodoreBusy()
    {
        return theodore.isEating;
    }
}
