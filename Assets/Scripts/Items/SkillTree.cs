using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Menu
{
    public class SkillTree : MonoBehaviour
    {
        [SerializeField] List<Skill> skillList;
        List<Item> purchasedSkills;
        List<int> skillsBought;
        [SerializeField] SkillHandler skillHandler;

        void Start()
        {
            RefreshSkills();
        }

        void Update()
        {

        }

        public void RefreshSkills()
        {
            foreach (Skill s in skillList)
            {
                s.CheckIfUnlockable();
            }
        }

        public void AddItem(Item item, Skill skill)
        {
            if(skillsBought == null)
            {
                skillsBought = new List<int>();
            }
            skillsBought.Add(skill.id);
            skillHandler.SaveGame(skillsBought);

            bool alreadyHasItem = false;
            if (purchasedSkills != null)
            {
                foreach (Item i in purchasedSkills)
                {
                    if (i == item)
                    {
                        alreadyHasItem = true;
                    }
                }
            }
            else
            {
                purchasedSkills = new List<Item>();
            }
            if (!alreadyHasItem)
            {
                purchasedSkills.Add(item);
                skillHandler.AddItems(item);
            }
        }

        public void LoadGame()
        {
            if (File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "playerData.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + Path.DirectorySeparatorChar + "playerData.dat", FileMode.OpenOrCreate);
                SkillSave data = (SkillSave)bf.Deserialize(file);
                file.Close();
                int[] ids = data.SkillList;
                foreach(int i in ids)
                {
                    foreach(Skill s in skillList)
                    {
                        if (i == s.id)
                        {
                            s.FreePurchase();
                            AddItem(s.itemToGivePlayer, s);
                        }
                    }
                }
            }
        }

        private void OnEnable()
        {
            LoadGame();
        }
    }
}
