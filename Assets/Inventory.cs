using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] Transform slotHolder;
    List<Image> Slots;
    [SerializeField] List<Item> items;
    [SerializeField] int curSlot = 0;
    [SerializeField] Image selectedSlotImg;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bibliaMoc;
    [SerializeField] Transform hand;
    void Start()
    {
        Physics2D.IgnoreLayerCollision(25, 26);
        foreach(Transform slot in slotHolder)
        {
            Slots.Add(slot.gameObject.GetComponent<Image>());
        }
        UpdateItems();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            curSlot = 0;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            curSlot = 1;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2)) {
            curSlot = 2;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2)) {
            curSlot = 3;
        }
        //selectedSlotImg.rectTransform.position= Slots[curSlot].rectTransform.position;

        if(Input.GetMouseButtonDown(0) && items[curSlot] != null)
        {
            if(items[curSlot].name == "Krzy¿")
            {
                Vector3 camPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                GameObject bulletInst = Instantiate(bullet, hand.position, Quaternion.identity);
                bulletInst.GetComponent<Rigidbody2D>().velocity = new Vector2(camPos.x - transform.position.x, camPos.y - transform.position.y).normalized * 10.0f;
            }else if(items[curSlot].name == "Biblia")
            {
                Instantiate(bibliaMoc, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            }
        }
    }

    void UpdateItems()
    {
        int slot = 0;
        foreach(Item item in items)
        {
            Slots[slot].sprite = item.ItemSprite;
            slot++;
        }
    }
}
