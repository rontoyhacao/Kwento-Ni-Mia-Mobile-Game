using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ObjDrag : MonoBehaviour
{
    [HideInInspector]public Vector2 SavePosition;
    [HideInInspector]public bool IsAboveObj;

    Transform SaveObj;

    public int Id;
    public TextMeshProUGUI Text;

    [Space]

    public UnityEvent OnDragTrue;

    // Start is called before the first frame update
    void Start()
    {
        SavePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        SoundCollection.instance.CallSfx(0);
    }

    private void OnMouseUp()
    {
        if(IsAboveObj)
        {
            int idDropLocation = SaveObj.GetComponent<DropLocation>().Id;
            string dropLocationFigureOfSpeechType = SaveObj.GetComponent<DropLocation>().FigureOfSpeechType;
            string selectedFigureOfSpeechTypeText = this.Text.text;

            if(Id == idDropLocation || selectedFigureOfSpeechTypeText == dropLocationFigureOfSpeechType)
            {
                transform.SetParent(SaveObj);
                transform.localPosition = Vector3.zero;
                transform.localScale = new Vector2(1f, 1f);

                SaveObj.GetComponent<SpriteRenderer>().enabled = false;
                SaveObj.GetComponent<Rigidbody2D>().simulated = false;
                SaveObj.GetComponent<BoxCollider2D>().enabled = false;

                gameObject.GetComponent<BoxCollider2D>().enabled = false;

                OnDragTrue.Invoke();

                GameSystem.Instance.CurrentDataSet++;
                Data.ScoreData += 200;

                SoundCollection.instance.CallSfx(1);
            }
            else
            {
                transform.position = SavePosition;
                Data.LivesData--;
                Data.TimerData-=5;
                SoundCollection.instance.CallSfx(2);
            }
        }
        else
        {
            transform.position = SavePosition;
        }
    }

    private void OnMouseDrag()
    {
        if (!GameSystem.Instance.GameOver)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = pos;
        }
    }

    private void OnTriggerStay2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Drop")) 
        {
            IsAboveObj = true;
            SaveObj = trig.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Drop"))
        {
            IsAboveObj = false;
        }
    }
}
