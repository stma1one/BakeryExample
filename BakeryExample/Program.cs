namespace BakeryExample
{
    internal class Program
    {

        public static void PrintTotalPrice(Bagel[] pastery)
        {
            double totalPrice = 0;
            for (int i = 0; i < pastery.Length; i++)
            {
                totalPrice+= pastery[i].GetPrice(); 
            }
            Console.WriteLine(totalPrice);
        }
        static void Main(string[] args)
        {
            #region מערך תוספות
            Topping[] golda = new Topping[4];
            golda[0] = new Topping("Chocolate", 5);
            golda[1] = new Topping("Halwa", 2);
            golda[2] = new Topping("M&M", 1);
            golda[3] = new Topping("Vanilla", 2);
            #endregion



            Bagel b1 = new Bagel("kuku", 40);
            b1.AddTopping(golda[0]);
            b1.AddTopping(golda[2]);

            #region עקרון ההכמסה
            Topping[] b1Toppings=b1.GetToppings();
            b1Toppings[0] = golda[3];
            //הריצו שורה זו פעם עם עקרון ההכמסה  ובפעם בלי
            //(ראו פעולת GetToppings)
            Console.WriteLine("------b1 Bagel-----"  );
            Console.WriteLine(b1);
            #endregion

            #region הבדל בין סוגי העתקות
            //הריצו שורה זו עם עקרון ההכמסה
            //אבל פעם SHALLOW COPY
            //ופעם נוספת עם DEEP COPY
            //ראו פעולה מאחזרת של תכונת התוספות
            b1Toppings[1].SetName("THIS IS A NEW NAME");
            Console.WriteLine("------b1 Bagel-----");
            Console.WriteLine(b1);
            #endregion

            Bagel b2 = new Bagel("Kiki", 25);
            b2.AddTopping(golda[3]);
            Console.WriteLine("------b2 Bagel-----");
            Console.WriteLine(b2);
            Bagel[] bagles= new Bagel[2];
            bagles[0] = b1;
            bagles[1] = b2;
            Console.WriteLine("------Total Price-----");
            PrintTotalPrice(bagles);

        }
    }
}