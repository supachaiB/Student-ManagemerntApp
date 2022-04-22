using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_ManagementApp
{
    internal class GPACalculator
    {
        private double sum = 0;
        private int n = 0;
        private double max = 0;
        private double min = 0;
        
        
        /// <summary>
        /// Add new GPA to class
        /// </summary>
        /// <param name="gpa">gpa score</param>
        public void addGPA(double gpa /*string name*/)
        {
            this.sum += gpa;
            this.n++;
 


            if (this.max < gpa)
            {
                this.max = gpa;
                //this.nameMax = name;

            }

            if (this.max > gpa)
            {
                this.min = gpa;
               // this.nameMin = name;

            }


        }

        
        public double getGPAx()
        {
            double result = this.sum / this.n;
            return result;
        }
        public double getMax()
        {
            return this.max;
        }

        public double getMin()
        {

            return this.min;
        }

    }
}
