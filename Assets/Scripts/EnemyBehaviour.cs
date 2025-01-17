using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI; // moviendo agentes enemigos 2

public class EnemyBehaviour : MonoBehaviour
{
    // moviendo agentes enemigos 1 \/\/\/\/
    public Transform patrolRoute;
    public List<Transform> locations;
    
    // moviendo agentes enemigos 1 /\/\/\/\

    public Transform player; // busqueda de jugador 1

    // moviendo agentes enemigos 2 \/\/\/\/
    private int _locationIndex = 0;
    private NavMeshAgent _agent;
    
    // moviendo agentes enemigos 2 /\/\/\/\
    
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>(); // moviendo agentes enemigos 2
        
        InitialitePatrolRoute(); // moviendo agentes enemigos 1
        
        MoveToNextPatrolLocation(); // moviendo agentes enemigos 2

        player = GameObject.Find("Player").transform; // busqueda de jugador 1

    }

    // Update is called once per frame
    void Update()
    {
        // moviendo agentes enemigos 3 \/\/\/\/
        if (_agent.remainingDistance < 0.2f && !_agent.pathPending)
        {
            MoveToNextPatrolLocation();
            
        }
        // moviendo agentes enemigos 3 /\/\/\/\
        
    }
    
    // moviendo agentes enemigos 1 \/\/\/\/
    void InitialitePatrolRoute()
    {
        foreach (Transform child in patrolRoute)
        {
            locations.Add(child);
            
        }
        
    }
    
    // moviendo agentes enemigos 1 /\/\/\/\

    // moviendo agentes enemigos 2 \/\/\/\/
    void MoveToNextPatrolLocation()
    {
        if (locations.Count == 0) // moviendo agentes enemigos 3
            return; // moviendo agentes enemigos 3
        
        _agent.destination = locations[_locationIndex].position;

        _locationIndex = (_locationIndex + 1) % locations.Count; // moviendo agentes enemigos 3

    }
    
    // moviendo agentes enemigos 2 /\/\/\/\

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            _agent.destination = player.position; // busqueda de jugador 1
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
