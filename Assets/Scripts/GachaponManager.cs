using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaponManager : MonoBehaviour
{
    public Canvas buttons;
    public Canvas gachas;

    private int numButtons;

    private void Awake()
    {
        numButtons = buttons.transform.childCount;
    }

    public void Enable()
    {
        for (int i=0; i<numButtons; i++)
        {
            GameObject accessory = buttons.transform.GetChild(i).gameObject;
            if (!accessory.activeInHierarchy)
            {
                StartCoroutine(EnableAccessory(accessory.name));
                return;
            }
        }
    }

    public IEnumerator EnableAccessory(string accessory)
    {
        GameObject accessoryGacha = gachas.transform.Find(accessory).gameObject;
        accessoryGacha.SetActive(true);
        yield return new WaitForSeconds(2f); //hacky, hard coded time of animation
        accessoryGacha.SetActive(false);
        buttons.transform.Find(accessory).gameObject.SetActive(true);
    }
}
