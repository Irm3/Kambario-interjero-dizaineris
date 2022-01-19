using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Placement : MonoBehaviour
{
    public GameObject furniture; // baldų objektas
    public Material yellow, red, green, original, blue, yellowtrans, redtrans, greentrans, originaltrans, bluetrans; // material spalvos
    [SerializeField]
    private GameObject Selector; // manager, kuris atsakingas už jau padėtų objektų redagavimą
    [SerializeField]
    private GameObject Panel; // panelė iš kurios galima pasirinkti norimus baldus
    [SerializeField]
    private Camera cam; // pagrindinė kamera
    private float mouseRotation; // pelės scroll wheel pasukimas
    private int layer_mask; // kaukė
    RaycastHit hit; // raycast info
    Vector3 direction; // ašis

    void Start()
    {
        GetComponentInChildren<MeshRenderer>().material = originaltrans; // default spalva blueprinte
        furniture.GetComponentInChildren<MeshRenderer>().material = original; // default spalva objektui
        Selector = GameObject.FindGameObjectWithTag("Selector"); // suranda select manager
        Panel = GameObject.FindGameObjectWithTag("Panel"); // suranda panelę
        Panel.SetActive(false); // išjungia panelę, nes jau pasirinktas objektas
        Selector.SetActive(false); // išjungia select manager, kad statant naują objektą neleistu redaguoti
        direction = Vector3.up; // default ašis objekto sukimui
        cam = Camera.main; // padaroma pagrindine kamera
        layer_mask = 1 << LayerMask.NameToLayer("Furniture") | 1 << LayerMask.NameToLayer("Walls"); // kaukės raycastui, kad atpažintu redaguojamus objektus ir sienas su grindimis
    }

    void Update()
    {

        //----------------- Objekto rotacijos ašies keitimas -----------------
        if (Input.GetKeyDown(KeyCode.Q))
        {
            direction = Vector3.up;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector3.forward;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            direction = Vector3.right;
        }
        mouseRotation = Input.mouseScrollDelta.y;
        transform.Rotate(direction, mouseRotation * 10f);
        //----------------------------------------------------------

        //----------------- Objekto drag pagal pelę -----------------
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 500.0f, layer_mask))
        {
            transform.position = hit.point;
        }
        //----------------------------------------------------------

        //----------------- Pelės mygtukų paspaudimai -----------------
        if (Input.GetMouseButtonDown(0) /*&& !Physics.Raycast(ray, out hit, 500.0f, layer_mask)*/)
        {
            Instantiate(furniture, transform.position, transform.rotation);      
        }
        // norint atšauktį veiksmą right clicku
        if (Input.GetMouseButtonDown(1))
        {
            Selector.SetActive(true);
            Panel.SetActive(true);
            Destroy(gameObject);
        }
        //----------------------------------------------------------

        //----------------- Keisti daiktų spalvoms -----------------
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            GetComponentInChildren<MeshRenderer>().material = redtrans;
            furniture.GetComponentInChildren<MeshRenderer>().material = red;
        }

        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            GetComponentInChildren<MeshRenderer>().material = yellowtrans;
            furniture.GetComponentInChildren<MeshRenderer>().material = yellow;
        }

        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            GetComponentInChildren<MeshRenderer>().material = bluetrans;
            furniture.GetComponentInChildren<MeshRenderer>().material = blue;
        }

        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            GetComponentInChildren<MeshRenderer>().material = greentrans;
            furniture.GetComponentInChildren<MeshRenderer>().material = green;
        }

        else if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            GetComponentInChildren<MeshRenderer>().material = originaltrans;
            furniture.GetComponentInChildren<MeshRenderer>().material = original;
        }
        //----------------------------------------------------------
    }
}
