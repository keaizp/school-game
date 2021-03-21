using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EventTrigger : MonoBehaviour
{
    public Text positionText;
    private Vector2 inital_position;
    private Vector2 mouse_position;
    private Vector2 touch1;
    private Vector2 touch2;
    private Vector2 pos;
    private float plane_width;
    private float plane_height;
    private float width;
    private float height;
    private float scale;
    private float scaleSpeed = 1;
    private float oriscale;
    private float min = 0.4F, max = 1.0F;
    //设置一个状态机
    private bool isDoubleFinger = false;
    // Start is called before the first frame update
    void Start()
    {
        plane_width = this.transform.parent.GetComponent<RectTransform>().rect.width;
        plane_height = this.transform.parent.GetComponent<RectTransform>().rect.height;
        width = this.GetComponent<RectTransform>().rect.width;
        height = this.GetComponent<RectTransform>().rect.height;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BeginDrag()
    {
        isDoubleFinger = false;
        mouse_position = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2);
        inital_position = new Vector2(this.transform.localPosition.x, this.transform.localPosition.y);
        if (Input.touchCount == 2)
        {
            isDoubleFinger = true;
            touch1 = Input.GetTouch(0).position;
            touch2 = Input.GetTouch(1).position;
            pos = new Vector2((touch1.x + touch2.x) / 2, (touch1.y + touch2.y) / 2);
            oriscale = this.transform.localScale.x;
        }
    }

    public void Drag()
    {
        if (isDoubleFinger)
        {
            //两指缩放比例
            float scale = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position) / Vector2.Distance(touch1, touch2);

            scale = (scale - 1) * scaleSpeed;

            if (this.transform.localScale.x <= min && scale < 0)
                return;
            if (this.transform.localScale.x >= max && scale > 0)
                return;
            this.transform.localScale = new Vector2(oriscale+scale,oriscale+scale);
            
        }
        if(!isDoubleFinger)
        {
            this.transform.localPosition = inital_position + (new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2) - mouse_position);
        }
        
    }

    public void EndDrag()
    {
        positionText.text = Input.touchCount.ToString();
        float scale_width, scale_height;
        scale_width = this.width * this.transform.localScale.x;
        scale_height = this.height * this.transform.localScale.y;
        if (this.transform.localPosition.x + scale_width / 2 < this.plane_width / 2)
        {
            this.transform.localPosition = new Vector2(this.plane_width / 2 - scale_width / 2, this.transform.localPosition.y);
        }
        if(this.transform.localPosition.y + scale_height / 2 < this.plane_height / 2)
        {
            this.transform.localPosition = new Vector2(this.transform.localPosition.x, this.plane_height / 2 - scale_height / 2);
        }
        if(this.transform.localPosition.x - scale_width / 2 > - this.plane_width / 2)
        {
            this.transform.localPosition = new Vector2(scale_width / 2 - this.plane_width / 2, this.transform.localPosition.y);
        }
        if(this.transform.localPosition.y - scale_height / 2 > - this.plane_height / 2)
        {
            this.transform.localPosition = new Vector2(this.transform.localPosition.x, scale_height / 2 - this.plane_height / 2);
        }
    }
}
