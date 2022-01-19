using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditBuilt : MonoBehaviour
{
    RaycastHit hit;
    private int layer_mask;
    [SerializeField]
    private GameObject furniture;
    public GameObject Info;
    private bool onOff = false;
    //public Material glowSelect;
    //public Material defaultSelect;
    //private string selectTag = "Selected";

    void Start()
    {
        layer_mask = LayerMask.GetMask("Furniture");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Info.SetActive(onOff);
            onOff = !onOff;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);     
        if (Physics.Raycast(ray, out hit, 500.0f, layer_mask))
        {
            // Nebaigtas metodas, kuris užvedus pelę ant objekto jį paryškina(nesigavo gražinti į pradinę material būseną)

            //if (hit.transform.CompareTag(selectTag))
            //{
            //    if (hit.transform.GetComponent<Renderer>() != null)
            //    {
            //        hit.transform.GetComponent<Renderer>().material = glowSelect;
            //    }
            //}
            //hit.transform.GetComponent<Renderer>().material = defaultSelect;

            // Gauną blueprint iš raycast ir sukurią naują blueprint objektą
            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("Hit2");
                furniture = hit.transform.GetComponent<SavedBluePrint>().blueprint;
                //Debug.Log(furniture.name);
                furniture.transform.rotation = hit.transform.rotation;
                Destroy(hit.transform.gameObject);
                Instantiate(furniture);
            }
        }

    }
}
