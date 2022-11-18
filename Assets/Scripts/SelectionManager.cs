/*Christian Cerezo */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SelectionManager : MonoBehaviour
{
    //The selectable tag is applied to objects that a player can select via raycast
    [SerializeField] private string selectableTag = "Selectable";

    [SerializeField] private List<Image> Crosshairs;
    Graphic m_Graphic;

    private Transform _selection;



    // Update is called once per frame
    void Update()
    {

        //crosshairs are white while a selectable item is not in focus
        if (_selection != null)
        {
            foreach(Image crossHair in Crosshairs)
            {
                m_Graphic = crossHair.GetComponent<Graphic>();
                m_Graphic.color = Color.white;
            }
            
            _selection = null;
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //crosshairs become green when a selectable item IS in focus
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            
            if (selection.CompareTag(selectableTag))
            {
                foreach (Image crossHair in Crosshairs)
                {
                    m_Graphic = crossHair.GetComponent<Graphic>();
                    m_Graphic.color = Color.green;
                }            

                _selection = selection;
            }
          
        }

        //defines what happens when an item is selected
        if(Input.GetMouseButtonDown(0) && _selection)
        {
            Debug.Log("Mouse is down, _selection is true");
      
          
            // checks if an item has an ItemObject component before deleting from items
            if(hit.transform.gameObject.TryGetComponent<ItemObject>(out ItemObject item))
            {
                //item is deleted from item list
                Debug.Log(item.referenceItem.displayName);
                item.OnHandlePickupItem();
            }                 
        }
    }
}
