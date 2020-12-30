using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{

    static public bool m_full = false;

    static public Inventory m_inventory = null;

    [SerializeField] GameObject[] m_inventoryStorage = null;

    [SerializeField] int m_inventorySize = 4;
    [SerializeField] GameObject[] m_inventorySquares = null;
    

    // Start is called before the first frame update
    void Start()
    {
        m_inventory = this;

        m_inventoryStorage = new GameObject[m_inventorySize];

        for (int i=0; i< m_inventorySize; i++)
        {

            m_inventoryStorage[i] = null;

        }
    }

    // Update is called once per frame
    public void InventoryUpdate(GameObject p_pickedUpItem = null)
    {

        for (int i = 0; i < m_inventorySize; i++)
        {
            if (m_inventoryStorage[i] == null)
            {
                m_inventoryStorage[i] = Instantiate(p_pickedUpItem,transform);
                m_inventoryStorage[i].SetActive(false);
                Instantiate(m_inventoryStorage[i], transform);

                break;
            }
        }


        InventoryMerge();
        InventorySort();
        InventoryApplyEffects();

        bool full = true;

        for (int i = 0; i < m_inventorySize; i++)
        {
            if (m_inventoryStorage[i] == null) full = false;
        }

        m_full = full;


        InventoryUpdateUI();
    }

    public void InventoryMerge()
    {
        for (int i = 0; i < m_inventorySize; i++)
        {
            if (m_inventoryStorage[i] != null && m_inventoryStorage[i].GetComponent<BonusSpawn>().m_canLevelUp)
            {
                for (int j = 0; j < m_inventorySize; j++)
                {
                    if (m_inventoryStorage[j] != null)
                    {
                        if (m_inventoryStorage[i].GetComponent<BonusSpawn>().m_selectedPrefab.name == m_inventoryStorage[j].GetComponent<BonusSpawn>().m_selectedPrefab.name && j != i)
                        {
                            Debug.Log(i);
                            Debug.Log(j);
                            m_inventoryStorage[i] = m_inventoryStorage[i].GetComponent<BonusSpawn>().m_LevelUpItem;
                            m_inventoryStorage[j] = null;

                            i = 0;
                            j = 0;
                            break;
                        }
                    }
                }
            }
        }

    }

    public void InventorySort()
    {
        for (int i = 0; i < m_inventorySize; i++)
        {
            if (m_inventoryStorage[i] != null)
            {
                for (int j = 0; j < i; j++)
                {
                    if (m_inventoryStorage[j] == null)
                    {
                        m_inventoryStorage[j] = m_inventoryStorage[i];
                        m_inventoryStorage[i] = null;

                    }
                }
            }
        }

    }

    public void InventoryApplyEffects()
    {
        for (int i = 0; i < m_inventorySize; i++)
        {
            if (m_inventoryStorage[i] != null)
            {
                m_inventoryStorage[i].GetComponent<BonusSpawn>().ApplyEffect();
            }
        }

    }

    public void DestroyItem(int p_itemIndex)
    {
        if (m_inventoryStorage[p_itemIndex] != null)
        {
            //if(!PlayerJump.m_script.m_isGrounded) PlayerJump.m_script.Jump(m_inventoryStorage[p_itemIndex].GetComponent<BonusSpawn>().m_destroyJumpForce);
            PlayerJump.m_script.Jump(m_inventoryStorage[p_itemIndex].GetComponent<BonusSpawn>().m_destroyJumpForce);
            m_inventoryStorage[p_itemIndex] = null;
        }

        InventorySort();
        InventoryApplyEffects();

        InventoryUpdateUI();
    }

    public void InventoryUpdateUI()
    {
        for (int i = 0; i < m_inventorySize; i++)
        {
            if (m_inventoryStorage[i] != null)
            {
                m_inventorySquares[i].GetComponent<Image>().sprite = m_inventoryStorage[i].GetComponent<BonusSpawn>().m_uiSprite;
            }
            else
            {
                m_inventorySquares[i].GetComponent<Image>().sprite = null;
            }
        }
    }
}
