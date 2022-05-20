using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMovement : MonoBehaviour
{
    public GameObject stage;
    public GameObject stagePrefab;
    public GameObject stageContainer;
    private float startingPos;
    private float currentPos;
    float sizeMesh;
    public float speed;
    void Start()
    {
        sizeMesh = gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Renderer>().bounds.size.z;
        startingPos = -sizeMesh;
    }

    
    void Update()
    {
        stage.transform.Translate(Vector3.back * speed * Time.deltaTime);
        if (transform.position.z < startingPos)
        {
            GameObject g = Instantiate(stagePrefab, new Vector3(0, 0, -startingPos), new Quaternion(0, 0, 0, 0), stageContainer.transform);
            g.transform.localPosition = new Vector3(0, 0, -startingPos);
            startingPos -= sizeMesh;
            print(startingPos);
        }
    }
}
