namespace Individual.Exercises.Classes
{
    public class HomeworkAssignment
    {
        //constructors
       public HomeworkAssignment(int possibleMarks, string submitterName)
        {
             PossibleMarks = possibleMarks;
             SubmitterName = submitterName;
        }
        
        //properties
       public int EarnedMarks
        {
            get; set;
        }
       public int PossibleMarks
        {
            get;
        }
       public string SubmitterName
        {
            get;
        }

        string letterGrade = "";

       public string LetterGrade
        {
            get
            {

                if ((double)EarnedMarks / (double)PossibleMarks >= 0.90)
                {
                    letterGrade = "A";
                }
                else if ((double)EarnedMarks / (double)PossibleMarks >= 0.80 &&
                    (double)EarnedMarks / (double)PossibleMarks < 0.90)
                {
                    letterGrade = "B";
                }
                else if ((double)EarnedMarks / (double)PossibleMarks >= 0.70 &&
                    (double)EarnedMarks / (double)PossibleMarks < 0.80)
                {
                    letterGrade = "C";
                }
                else if ((double)EarnedMarks / (double)PossibleMarks >= 0.60 &&
                    (double)EarnedMarks / (double)PossibleMarks < 0.70)
                {
                    letterGrade = "D";
                }
                else
                {
                    letterGrade = "F";
                }
                return letterGrade;
            }
        }
       



    }
}
