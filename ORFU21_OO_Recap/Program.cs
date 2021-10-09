using System;

namespace ORFU21_OO_Recap
{
    class Program
    {
        static void Main(string[] args)
        {
            myClass car1 = new myClass();   //To create a new instance of a class (run it in memory and prepare for use)
                                    //Also called creating an "Object" as a more general term, while "instancing"
                                    //is used for referring to a specific class
                                    //"car1" is later used to call specific methods and objects inside the
                                    //class that it represents (in this case, class Car)
            car1._brand = "Volvo";  //Using "car1" we can also give class variables information.
                                    //We can access the "_brand" field from outside its class because we marked
                                    //its synlighet as "public" in the class                        
                                    //The "_brand" variable of the "car1" instance is now "Volvo" since we declared
                                    //_brand as a string.
            myClass car2 = new myClass("Volvo", "ABC 123"); //With Constructors we can create a new instance of a class
                                                    //and immedietly populate its fields like this.
                                                    //Every new instance of the "Car" class has all the declared
                                                    //fields inside it, waiting to be filled.

            myClass car3 = new myClass(1500, "Red");        //A constructor will be chosen for this instance by C# depending
                                                    //on what Arguments we use as parameters. Even though we
                                                    //Instanced this class with _weight and _colour, it still has 
                                                    //_regNumber and _brand ready and waiting to be filled.

            myClass car4 = new();                       //This shortform can be used to instance a class without arguments.
            myClass car5 = new("Saturn", "XYZ 789");    //And this one with arguments.

            myClass car6 = new(2000, "Blue");   //Instances a new Class called car6 with 2 arguments
            car6.Repaint("Red");            //Invokes the Repaint method with "Ferrari Red" as an argument
            car6.ShowStats();               //Invokes the ShowStats method
            bool isRedOrNo = car6.IsCarRed();   //Invokes the IsCarRed method and stores the returned value
                                                //in the isRedOrNo bool variable. We could use this in a if/else

            myClass car7 = new();
            string returnString = car7.ShowInput("This is my argument"); //Invokes the ShowInput method and stores the returned value
            Console.WriteLine(returnString);                             //in the returnString variable.
                                                                         //We can then use the returnString variable as usual

            myClass car8 = new("Volvo", "QWE 567");
            car8.ShowStats();
            string car8ShowStats = car8.ShowStatsReturn();
            Console.WriteLine(car8ShowStats);

            Console.WriteLine("\nCar 9------Överlagring------");
            myClass car9 = new(2000, "Yellow");
            car9.Overlagring(); //This will return 101, as _weight is set to 100 with överlagring, then 1 is added

            Console.WriteLine("\nCar 10------Överlagring .this ------");
            myClass car10 = new myClass(5000, "White");
            car10.OverlagringThis(); //Will show 5001, as we forced _weight to use the value from the
                                     //field with "this.". Must use .this when specifiying what variable to
                                     //write to console.
            Console.WriteLine("\nCar 11------Methods with same name------");
            myClass car11 = new myClass();
            car11.ShortMethod();
            car11.GearUp();     //Will return 1
            car11.GearUp(5);    //Will return 6

            Console.WriteLine("\nCar 12------Get and Set------");
            myClass car12 = new();
            car12.SetAge(5);    //Uses a setter to SET the private _age field inside the class from outside.
            int car12Age = car12.GetAge();     //Uses a getter to GET the value of the private _age field from inside the class
            Console.WriteLine($"Car 12 age = {car12Age}");


            Console.WriteLine("\nCar 13------Properties------");
            myClass car13 = new();
            car13.PropertyWidth = 10; //With a property, we can set getters and setters quickly by invoking the properties Name
            car13.PropertyHeight = 5;
            Console.WriteLine($"Current PropertyWidth  = {car13.PropertyWidth}"); //This is how we can get the value from a property
            //Console.WriteLine($"Current PropertyHeight = {car13.PropertyHeight}"); //Unable to get value from a Set-Only property
            Console.WriteLine($"Current PropertyArea   = {car13.PropertyArea}");

            Console.WriteLine("\nCar 14------Auto-Implement Properties------");
            myClass car14 = new();
            car14.AutoPropBredth = 5; //This code will automatically set the bredth as "value" and set get to return said value.
            car14.AutoPropDepth = 10;
            Console.WriteLine($"Area = {car14.AutoPropArea}");

            Console.WriteLine("\nCar 15------Object-Initialiser------");
            //If there are many different parameters in your constructors, it can be difficult to know what value goes where eg:
            //MyClass myVar = new MyClass (15,10,15,play,red,down,5,125);
            //with the Object-Initializer syntax it's possible to name each parameter and add values to them seperatly.
            myClass car15 = new myClass()
            {
                ObjInitWidth = 15, //Arguments are seperated by a ,
                ObjInitHeight = 12,
                //ObjInitDepth = 7 //This will not run as the Properties SET is private and can't be accessed from outside the class.
            };
            car15.ObjInitHeight = 20;
            //car15.ObjInitWidth = 12; //This doesn't work becuase ObjInitWidth property is INIT
        }
    }
}
