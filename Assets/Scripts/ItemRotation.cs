using UnityEngine;

public class ItemRotation : MonoBehaviour
{
    public int rotationSpeed = 100;
    private Transform _itemTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        _itemTransform = this.GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _itemTransform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
        
    }
}
