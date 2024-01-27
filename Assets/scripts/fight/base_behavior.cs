using UnityEngine;

public class base_behavior : MonoBehaviour
{
    public int team;

    // Links to the different behavior components
    public seek_script seek;
    public Seek seekScript;

    // Intelligent movement scripts
    public Agent agentScript;

    public float maxSpeed;

    public GameObject target;
    public UnitFSM state;

    public enum UnitFSM // States
    {
        Seek
    }

    // Start is called before the first frame update
    void Start()
    {
        agentScript = gameObject.AddComponent<Agent>(); // Add agent
        agentScript.maxSpeed = maxSpeed;

        changeState(UnitFSM.Seek);  // Start with Seek state
    }

    // Update is called once per frame
   

    public void changeState(UnitFSM new_state)
    {
        state = new_state;

        switch (new_state)
        {
            case UnitFSM.Seek:
                if (gameObject.GetComponent<seek_script>() == null)
                {
                    seek = gameObject.AddComponent<seek_script>();
                }
                break;
        }
    }
}
