using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(MoveToPoint))]
public class Movement : MonoBehaviour
{   
    public LayerMask movementMask;
    public Interractions focus;
    
    MoveToPoint point;
    
    void Start() 
    {
        point = GetComponent<MoveToPoint>();
    }

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            MoveToCursor();
            RemoveFocus();
        }
        if (Input.GetMouseButtonDown(1))
        {
            ClickToObjects();
        }
        if (Input.GetKey(KeyCode.E))
        {
            GetComponent<Animator>().SetTrigger("Wave");
        }
    }

    private void MoveToCursor()
    {
        Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        bool isHit = Physics.Raycast(rayCast, out hitInfo, 100, movementMask);
        if (isHit == true)
        {
            point.ToPoint(hitInfo.point);
        }
    }

    private void ClickToObjects()
    {
        Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        bool isHit = Physics.Raycast(rayCast, out hitInfo, 100);
        if (isHit == true)
        {
            Interractions interractions = hitInfo.collider.GetComponent<Interractions>();
            if (interractions != null)
            {
                SetFocus(interractions);
            }
        }
    }

    void SetFocus (Interractions newFocus)
    {
        if (newFocus != null)
        {
            if (focus != null)
            {
                focus.OffFocused();
            }
            focus = newFocus;
            point.FollowObject(newFocus);
        }
        
        newFocus.OnFocused(transform);
    }

    void RemoveFocus ()
    {
        if (focus != null)
        {
            focus.OffFocused();
        }
        focus = null;
        point.StopFollowObject();
    }

}