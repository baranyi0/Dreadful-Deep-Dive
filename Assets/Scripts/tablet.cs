using UnityEngine;
using UnityEngine.UI;

public class tablet : MonoBehaviour
{
    [TextArea][SerializeField] string log;
    [SerializeField] Text ui; 
    [SerializeField] GameObject PDA;
    [SerializeField] FPSController controller;
    private Transform player;
    bool canBePickedUp;
    BoxCollider boxCollider;
    public Proximity pr;

    public bool first, last;

    public GameObject key, carve;
    public ObjectController obj;

    public GameObject endingTrigger, newDirectionalLight, wall;
    public void PickUp()
    {
        if (first)
        {
            key.SetActive(true);
            carve.SetActive(true);
            obj.extraInfo = "There is something carved in the door: 'Key is in the storage room'";
        }
        if (last)
        {
            endingTrigger.SetActive(true);
            newDirectionalLight.SetActive(true);
            wall.SetActive(true);
        }

        pr.i++;
        boxCollider.enabled = false;
        canBePickedUp = true;
        PDA.SetActive(true);
        ui.text = log;
        controller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    private void Update()
    {
        if (canBePickedUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, 25 * Time.unscaledDeltaTime);

            if (transform.position == player.transform.position)
            {
                Destroy(gameObject);
            }
        }
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        boxCollider = GetComponent<BoxCollider>();
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();
    }
}
