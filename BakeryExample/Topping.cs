using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BakeryExample
{
    /// <summary>
    /// מחלקה המייצגת תוספת
    /// </summary>
    public class Topping
    {
        #region תכונות
        private string name;//שם תוספת
        private double price;//מחיר תוספת
        #endregion

        #region constructor

        /// <summary>
        /// פעולה בונה המקבלת שם ומחיר 
        /// ומחזירה אובייקט תוספת חדש 
        /// </summary>
        /// <param name="name">שם תוספת</param>
        /// <param name="price">מחיר תוספת</param>
        public Topping(string name, double price)
        {
            this.name = name;
            this.price = price;
        }
        #endregion
        #region copy constructor
        /// <summary>
        /// פעולה בונה מעתיקה 
        /// המקבלת אובייקט תוספת ומחזירה אובייקט חדש 
        /// המכיל את אותם ערכים כמו האובייקט שהתקבל כפרמטר
        /// </summary>
        /// <param name="topping">התוספת ממנה יש להעתיק נתונים</param>

        //הפעלת פעולה בונה אחרת באמצעות 
        //:this(...)
        public Topping(Topping topping):this(topping.name, topping.price) { }
        #endregion

        #region Getters
        public string GetName() { return name; }    
        public double GetPrice() { return price; }
        #endregion

        #region Setters
        public void SetName(string name) { this.name = name; }      
        #endregion

        #region האם תוספת שוקולד
        public bool IsChocolate() { return name == "Chocolate"; }
        #endregion
    }
}
