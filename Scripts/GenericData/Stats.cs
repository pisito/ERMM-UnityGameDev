using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ERMM.GenericData
{
    public class Stats : MonoBehaviour
    {
        // Attributes
        public int str = 10; // Strength
        public int intg = 10; // Intelligence, 'int' is a reserved keyword in C#, so we use 'intg' instead
        public int agi = 10; // Agility
        public int vit = 10; // Vitality
        public int mag = 10; // Magic

        // Methods to modify each stat
        public void ModifyStr(int amount)
        {
            str += amount;
        }

        public void ModifyIntg(int amount)
        {
            intg += amount;
        }

        public void ModifyAgi(int amount)
        {
            agi += amount;
        }

        public void ModifyVit(int amount)
        {
            vit += amount;
        }

        public void ModifyMag(int amount)
        {
            mag += amount;
        }
    }
}
