using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class build_1 : MonoBehaviour
{
    public GameObject furniture_blueprint;

    /// <summary>
    /// Paspaudus mygtuką vykdomas metodas, kuri sukurią naują blueprint
    /// </summary>
    public void Spawn()
    {
        Instantiate(furniture_blueprint);
    }
}
