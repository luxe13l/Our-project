using System.Timers;
using System.Threading;
using System.Transactions;
using System.Collections.Specialized;
using System;
using UnityEngine;

public class CarController : MonoBehaviour
{
  private Rigidbody _rb;
  public float speed = 5f, finalSpeed = 15f, rotateSpeed = 50f;
  private bool isClicked;

  public enum Axis 
  {
    Vertical, Horizotal
  }

  public Axis CarAxis;

  private enum Direction 
  {
    Right, Left, Top, Bottom, None
  }

  private Direction CarDirectionX = Direction.None;
  private Direction CarDirectionY = Direction.None;




  private float curPointX, curPointY;
  [NonSerializedAttribute] public Vector3 FinalPosition;

  void Awake()
  {
    _rb = GetComponent<Rigidbody>();
  }

  void OnMouseDown()
  {
    curPointX = Input.mousePosition.x;
    curPointY = Input.mousePosition.y;
  }

  void OnMouseUp() 
  {
    if(!StartGame.IsGameStarted ) return;
    
    
    
    if(Input.mousePosition.x - curPointX > 0)
        CarDirectionX = Direction.Right;
    else
        CarDirectionX = Direction.Left;
    
    if(Input.mousePosition.y - curPointY > 0)
        CarDirectionY = Direction.Top;
    else
        CarDirectionY = Direction.Bottom;
    
        isClicked = true;

  }
  void Update()
  {
    if(FinalPosition.x !=0)
    {
      transform.position = Vector3.MoveTowards(transform.position, FinalPosition, finalSpeed * Time.deltaTime);

      Vector3 lookAtPos = FinalPosition -transform.position;
      lookAtPos.y = 0;
      transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lookAtPos), Time.deltaTime * rotateSpeed);
    }

     if(transform.position == FinalPosition)
        Destroy(gameObject);
  }



  void FixedUpdate()
  {
    Vector3 whichWay = CarAxis == Axis.Horizotal ? Vector3.forward : Vector3.left;
    
    
    speed = Mathf.Abs(speed);
    if(CarDirectionX == Direction.Left && CarAxis == Axis.Horizotal)
        speed *= -1;
    else if(CarDirectionY == Direction.Bottom&& CarAxis == Axis.Vertical)
        speed *= -1;
    
    if(isClicked && FinalPosition.x == 0)
    _rb.MovePosition(_rb.position + whichWay * speed * Time.fixedDeltaTime);
  }

  void OnTriggerStay(Collider other) 
  {
   
  if(other.CompareTag("Car") || other.CompareTag("Barrier"))
  {
    if(CarAxis == Axis.Horizotal && isClicked)
        {
            float adding = CarDirectionX == Direction.Left ? 0.5f : -0.5f;
            transform.position = new Vector3(transform.position.x, 0, transform.position.z + adding);
        }
    
    if(CarAxis == Axis.Vertical&& isClicked)
        {
          float adding = CarDirectionY == Direction.Top ? 0.5f : -0.5f;
          transform.position = new Vector3(transform.position.x + adding, 0, transform.position.z);
        }







    isClicked = false;
  }  
  
  }
}
