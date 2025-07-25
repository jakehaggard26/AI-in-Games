// WIP
using UnityEngine;

public class PathFollowing : KinematicSeek
{
    private float pathOffset = 0f;
    private int currentParam = 0;
    private Path path;

    public PathFollowing(Transform character) : base(character)
    {
        path = character.GetComponent<AgentController>().Path;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override KinematicSteeringOutput getSteering(Transform character)
    {
        // Find closest position on the path
        currentParam = path.getParameter(character.position, currentParam);

        // Get next position wrt to the closest position on the path
        if (currentParam >= path.getPath().Length - 1)
        {
            currentParam = 0;
        }
        else
        {
            currentParam++;
        }

        

        // Set target + Offset Position
        Vector3 target = path.getPosition(currentParam) + new Vector3(Random.Range(0, pathOffset), 0f ,Random.Range(0f, pathOffset));

        Debug.Log("Path Following Parameter: " + currentParam + "\tDistance: " + Vector3.Distance(path.getPosition(currentParam), character.position));

        // return base.getSteering(target, character);
        return base.getSteering(target, character);
    }
}
