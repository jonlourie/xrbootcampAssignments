using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRenderDraw : MonoBehaviour
{

    [SerializeField]
    private Transform endPosition;

    [SerializeField]
    private Transform startPostion;

    private Vector3 firstVector;

    private Vector3 secondVector;

    [SerializeField]
    private LineRenderer line;

    private List<Vector3> pointList = new List<Vector3>();


    // Start is called before the first frame update
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {
        DrawLine();
        pointList.Clear();

    }


    private void DrawLine()
    {
        firstVector = startPostion.position;
        secondVector = endPosition.position;

        //for (float r = 0; r <= 1; r += 1.0f)
        //{
        //Vector3 _bezierPoint = Vector3.Lerp(firstVector, secondVector, 0.5f);


        //}

        pointList.Add(firstVector);
        pointList.Add(secondVector);

        line.positionCount = pointList.Count;
        line.SetPositions(pointList.ToArray());
    }

   

  


}
