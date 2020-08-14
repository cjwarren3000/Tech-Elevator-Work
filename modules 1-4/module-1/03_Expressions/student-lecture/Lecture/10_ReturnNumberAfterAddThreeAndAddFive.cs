using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    public partial class LectureExample
    {
        /*
        10.This method will take a number and do the following things to it:
            If addThree is true, we'll add three to that number
            If addFive is true, we'll add five to that number
            We'll then return the result
            TOPIC: Stacking Conditional Logic
        */
        public int ReturnNumberAfterAddThreeAndAddFive(int number, bool addThree, bool addFive)
        {
            if (addThree)
            {
                number = number + 3;
            }

            // Why can't we use an else here?
            //because if you put an else in, the number will never be checked against addFive,
            //since it will be resolved after addThree.

            if (addFive == true)
            {
                number += 5;
            }

            return number;
        }
    }
}
