using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class DrawManager : MonoBehaviour
{
    [SerializeField]
    public GameObject linePrefab;
    public GameObject currentLine;
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;

    public GameObject bottle;

    public Rigidbody2D rigidBody;

    public bool isLine;
    public bool isDrop;
    public bool isHolding;

    public bool V24Active;

    public List<Vector2> fingerPositions;

    public Flowchart flowchart;

    public float targetTime = 5.0f;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (V24Active == true)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            bottle.transform.position = Vector2.Lerp(transform.position, mousePosition, 1f);

            targetTime -= Time.deltaTime;

            if (targetTime <= 0.0f)
            {
                timerEnded();
            }

            if (Input.GetMouseButtonDown(0))
            {
                CreateLine();
            }

            if (Input.GetMouseButton(0))
            {
                Vector2 tempFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (Vector2.Distance(tempFingerPos, fingerPositions[fingerPositions.Count - 1]) > -0.1f)
                {
                    UpdateLine(tempFingerPos);
                }
            }

        }
    }


    void CreateLine()
    {
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
        fingerPositions.Clear();
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        lineRenderer.SetPosition(0, fingerPositions[0]);
        lineRenderer.SetPosition(1, fingerPositions[1]);

        edgeCollider.points = fingerPositions.ToArray();
    }

    void UpdateLine(Vector2 newFingerPos)
    {
        fingerPositions.Add(newFingerPos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newFingerPos);
        edgeCollider.points = fingerPositions.ToArray();
    }

    void timerEnded()
    {
        flowchart.SetBooleanVariable("doneDrawing", true);
    }

    public void View24Playing()
    {
        V24Active = true;
    }

    public void View24NotPlaying()
    {
        V24Active = false;
    }
}