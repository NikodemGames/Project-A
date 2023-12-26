using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class SelectUnit : MonoBehaviour
{

    private void Start()
    {
        Invoke(nameof(Test),.5f);
    }





    //public void Recruit()
    //{
    //    TeamSlots.instance.Add(Database.Instance.Tokens[0]);

    //}
    //private void Update()
    //{

    //    if (TeamSlots.instance.units.Contains(unitToken))
    //    {

    //        button.interactable=false;
    //    }
    //    else
    //    {
    //        button.interactable=true;
    //    }
    //}
    public void Test()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            Image childImage = child.gameObject.GetComponent<Image>();
            UnitHolder slot = child.gameObject.GetComponent<UnitHolder>();
            if (i < Database.Instance.Tokens.Count)
            {
                childImage.sprite = Database.Instance.Tokens[i].Sprite;
                slot.unitToken = Database.Instance.Tokens[i];
            }
            else childImage.sprite = null;

        }
    }
}
