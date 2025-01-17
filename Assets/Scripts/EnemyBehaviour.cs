using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // moviendo agentes enemigos \/\/\/\/
    public Transform patrolRoute;
    public List<Transform> locations;
    
    // moviendo agentes enemigos /\/\/\/\
    
    // Start is called before the first frame update
    void Start()
    {
        InitialitePatrolRoute(); // moviendo agentes enemigos
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    
    // moviendo agentes enemigos \/\/\/\/
    void InitialitePatrolRoute()
    {
        foreach (Transform child in patrolRoute)
        {
            locations.Add(child);
            
        }
        
    }
    // moviendo agentes enemigos /\/\/\/\

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            Debug.Log("Enemy on sight! KILL KILL KILL! WRAHHHH!!!");

        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Player")
        {
            Debug.Log("Enemy has escaped!");

        }
        
    }

}
