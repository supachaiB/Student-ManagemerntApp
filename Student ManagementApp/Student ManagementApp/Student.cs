using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_ManagementApp
{
    internal class Student
    {
        private string _id;
        private string _name;   
        private string _major;

        //constructor
        public  Student(string id, string name, string major)
        {
            this._id = id;
            this._name = name;  
            this._major = major;
 
        }

        //encapsualtion
        public string getId() {
            return this._id; 
        }
        public string getName() { 
            return this._name; 
        }
        public string getMajor() { 
            return this._major; 
        }

    }
}
