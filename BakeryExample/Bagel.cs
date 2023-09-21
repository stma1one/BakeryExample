using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryExample
{
    /// <summary>
    /// מחלקה המייצגת מאפה
    /// </summary>
    public  class Bagel
    {
        #region קבועים
        private const int BASIC_PRICE = 10;
        private const int MAX_TOPPINGS = 10;
        private const int EXTRA_CHOCOLATE = 3;
        #endregion

        #region תכונות
        private string name;//שם מאפה
        private Topping[] toppings;//מערך התוספות
        private double weight;//משקל הפריט

        #region תוספת תכונות
        //על מנת לשמור על מיקום התוספות נוסיף מונה
        private int currentPos;
        #endregion
        #endregion

        #region Constructor/c'tor/פעולה בונה
        public Bagel(string name, double weight)
        {
            //this->להבדיל בין תכונה לבין פרמטר של הפעולה
            this.name = name;
            this.weight = weight;
            //נגדיר מערך בגודל הנדרש
            toppings= new Topping[MAX_TOPPINGS];
            //התא הפנוי הוא התא הראשון
            currentPos = 0; 
        }
        #endregion

        #region פעולה מתארת ToString
        public override string ToString()
        {
            string str=$"{this.name} with the following toppings:\n";
            if (currentPos == 0)
            {
                return str + " no Toppings";
            }
            //נרוץ על מערך התוספות. בגלל שלא נרצה שאחרי התוספת האחרונה 
            //יהיה פסיק מיותר. רוץ עד התא לפני אחרון
            //ונטפל בתוספת האחרונה בנפרד
            for(int i=0; i<currentPos-1; i++) 
            {
                str += $"{toppings[i].GetName()},\t";
            }
            return str + toppings[currentPos - 1].GetName()+$" total: {GetPrice()}";
        }
        #endregion

        #region פעולות Getters - מאחזרות
        //אחזור שם מאפה
        public string GetName() 
        {
            return name;
        }
        //אחזור משקל
        public double GetWeight()
        {
            return weight;
        }

        //אחזור תוספות
        //שמירה על עקרון ההכמסה דורש שיכפול עמוק 
        //(deep copy מול shallow copy)
        public Topping[] GetToppings()
        {
            #region ללא שמירה על עקרון ההכמסה
            //return this.toppings;
            #endregion
            #region עם שמירה על עקרון ההכמסה
            //נקצה מקום חדש בזיכרון ככמות התוספות הנוכחית
            Topping[] copy = new Topping[currentPos];
            for (int i = 0; i < currentPos; i++)
            {
                #region shallow copy
                //המקום החדש יצביע לאובייקט תוספת *קיים*בתוספות
                //copy[i]=toppings[i];
                #endregion
                #region Deep Copy
                //המקום החדש יצביע לאובייקט תוספת חדש המכיל את אותם ערכים
                //של תוספת קיימת -שכפול
                copy[i]=new Topping(toppings[i]);
                #endregion
            }
            #endregion
            return copy;

        }
        #endregion

        #region הוספת תוספת
        public void AddTopping(Topping top)
        {
            if (currentPos < toppings.Length)
            {
                toppings[currentPos] = top;
                currentPos++;
                //אפשרי לאחד את הכל לשורה אחת
                //toppings[currentPos++]=top;
            }
        }
        #endregion

        #region חישוב מחיר
        public double GetPrice()
        {
            //מחיר בסיסי
            double price = BASIC_PRICE;
            //האם נדרש תוספת מחיר עבור שוקולד
            bool hasChoclate = false;
            //נסרוק את התוספות לחישוב המחיר
            for (int i = 0; i < currentPos; i++)
            {
                //אם יש שוקולד- נדרש תוספת
                //אופציה א
                //if (toppings[i].GetName()== "Chocolate")
                //אופציה ב
                if (toppings[i].IsChocolate())
                    hasChoclate=true;
                //בכל מקרה נוסיף למחיר הבסיסי את מחיר התוספת
                price += toppings[i].GetPrice();
            }
            //נוסיף את תוספת מחיר השוקולד במקרה הצורך
            if (hasChoclate)
                return price + EXTRA_CHOCOLATE;
            return price;
        }
        #endregion
    }
}
