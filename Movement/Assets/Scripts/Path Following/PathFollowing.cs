// WIP
using UnityEngine;

public class PathFollowing : KinematicSeek
{
    private float pathOffset = 0f;
    private int currentParam = 0;
    private Path path;
    private Transform character;

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

        // Set target + Offset Position
        Vector3 target = path.getPosition(currentParam) + new Vector3(Random.Range(0, pathOffset), 0f ,Random.Range(0f, pathOffset));

        Debug.Log("Path Following Parameter: " + currentParam);
        Debug.Log("Path Following Target: " + target);

        return base.getSteering(target, character);
    }
}
