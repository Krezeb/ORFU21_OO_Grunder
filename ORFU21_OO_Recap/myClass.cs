using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORFU21_OO_Recap
{
    class myClass //Syntax: class UpperCamelCase
    {
        private string _regNumber;  //Private fields are only useable inside the class
        public string _brand;       //Public fields are useable throughout the whole
                                    //program using an instance variable.
                                    //Syntax: synlighet typ _namn;

        public myClass() : this (0,"Unknown")   //Using :this() can give default parameters to an instance
        {                                   //with missing arguements, and send them to a Constructor with
        }                                   //Parameters that match. Eg. :this("No Brand", "No Reg")
                                            //Will then send those default arguments to a constructor
                                            //that fits.



        public myClass(string brand, string regNumber)  //Multiple classes can exist as long as their
        {                                           //parameters are different. The parameters are
            _brand = brand;                         //information that is sent from program.cs
            _regNumber = regNumber;                 //Constructors like this are often used to change
        }                                           //information inside private fields as well as 
                                                    //other class fields. 

        private int _weight;                    //While constructor parameters are deleted after the 
        private string _colour;                 //constructor has closed, fields are still here.
                                                //If we want parameters to survive, they have to 
                                                //be saved as fields.
        public myClass(int weight, string colour)
        {
            _weight = weight;       //This code saves the parameter as a class field.
            _colour = colour;
            Console.WriteLine("This constructor has a Weight and Colour parameter!");
            Console.WriteLine($"This vehicle weighs {_weight} and is {_colour}!");
            //Simple code can be run inside constructors aswell
        }

        public void Repaint (string colour) //With this method we can change _colour of a instanced class
        {                                   //Since code is run downwards
            Console.WriteLine($"REPAINTING: Old Colour = {_colour}"); //This _colour will show the original colour
            _colour = colour;   //This replaces the old _colour with the parameter recieved when we invoked this method
        }
        public void ShowStats() //With this method we can display 3 current fields for the class
        {
            Console.WriteLine($"The Brand  is: {_brand}");
            Console.WriteLine($"The Colour is: {_colour}");
            Console.WriteLine($"The Weight is: {_weight}");   
        }

        public string ShowStatsReturn() //With this method we can return 1 variable back to where it was invoked
        {
            return $"The Reg nr is: {_regNumber}";
        }

        public bool IsCarRed() //With this method we must return a value to program.cs
        {
            return _colour == "Red";    //if _colour is "Red" return true. We can use multiple returns 
                                        //as necessary
        }

        public string ShowInput(string input) //We can send all basic variable type back to where it was invoked
        {
            return $"The input is {input}"; //This will send this string back to where it was invoked
        }                                   //It is possible to use fields as nessesary inside methods

        public void Overlagring()  //This method is överlagrade as there are 2 variables inside
                            //with the same name. One has local-scope, the other has class-scope
        {
            int _weight = 100; //Local-scope. As Code is run top-down, this variable sets the _weight field to 100
            _weight++;//Then this code changes the above local-scope variable instead of the field.
            Console.WriteLine($"The överlagrade weight is: {_weight}");
        }

        public void OverlagringThis()
        {
            int _weight = 100;
            this._weight++; //We can force the metod to ignore the local-scope using "this."
            Console.WriteLine($"The överlagrade weight using \"this.\" is: {this._weight}");
            //Not using "this." in the WriteLine will return the original field value.
        }

        public void ShortMethod() => Console.WriteLine("This is a Short Expression");
        //Om metoden är jättekort kan man använda ovanstående kod. Kallas för Expression-Body syntax
        //Fungerar bara med Expressions (en kodrad), inte med statements (flera kodrader)

        private int _currentGear = 0;

        //public void GearUp()
        //{
        //    Console.WriteLine($"Current Gear (noParam) : {++_currentGear}");
        //}
        public void GearUp() //As with empty constructors, empty methods should be avoided.                  
        {
            GearUp(1);//Invoke another method instead with a "default" argument
        }

        public void GearUp(int upMoar) //2 methods can use the same name as long as different parameters are used
        {
            Console.WriteLine($"Current Gear (UpMoar) : {_currentGear + upMoar}");
        }

        private int _age;

        public int GetAge() //Simple getter. It returns the current saved _age field value.
        {
            return _age;
        }

        public void SetAge(int age) //Simple setter for _age. If the parameter is wrong, it's adjusted
        {
            if (age < 0) { age = 0; }; //If age is below 0, change age to 0
            if (age > 25) { age = 25; }; //If age is over 100, change to 25
            _age = age;//set value of private class _age field to value of method age value
        }

        private int _propertyWidth;     //En field som används till properties kallas också för en Backing Field.
        private int _propertyHeight;    
        public int PropertyWidth //Properties are like constructors. UpperCamelCase. Bakes in Getters and Setters
        {
            get { return _propertyWidth; }
            set { _propertyWidth = value; } //"value" is a special variable in C#. It always represents the parameter
                                            //sent into the property. Here we set the class field to "value"
        }
        public int PropertyHeight
        {
            set { _propertyHeight = value; } //Set-Only property.
        }

        public int PropertyArea //Code can be used in properties
        {
            get { return _propertyWidth * _propertyHeight; } //Get-Only property.
        }

        //Auto-Implement Properties are even shorter, but aren't as flexible
        public int AutoPropBredth { get; set; } //With AutoProps we have to use the Name of the property to manipulate
                                                //the data since no seperate fields are used.
        public int AutoPropDepth { get; set; }

        public int AutoPropArea 
        { get { return AutoPropBredth* AutoPropDepth; } } //Get-Only Autoprop with code






        public int ObjInitWidth { get; init; }  //Using "init;" instead of "set;" will make the value immutable
                                                //after being created when using an Object-Initialiser
        public int ObjInitHeight { get; set; }

        public int ObjInitDepth { get; private set; }  //Using "private set" in a property will allow changes from
                                                        //inside the class, but not from outside

        public int ObjInitArea
        { get { return ObjInitWidth * ObjInitHeight * ObjInitDepth; } } //Get-Only


    }
}
