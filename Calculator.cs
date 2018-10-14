using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballScoreCalculator
{
    class Calculator
    {
#region INSTANCE VARIABLES

        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        Dictionary<int, int> tempDictionary = new Dictionary<int, int>();

        private const int TOUCHDOWN_W1PT = 7;
        private const int TOUCHDOWN_W2PT = 8;
        private const int FIELD_GOAL = 3;
        private const String TIE = "Tie Game!!";

        private int team1Score, team2Score;

#endregion 

#region CONSTRUCTORS
        public Calculator(int sc1, int sc2)
        {
            dictionary.Add(TOUCHDOWN_W2PT, 0);
            dictionary.Add(TOUCHDOWN_W1PT, 0);
            dictionary.Add(FIELD_GOAL, 0);

            tempDictionary.Add(TOUCHDOWN_W2PT, 0);
            tempDictionary.Add(TOUCHDOWN_W1PT, 0);
            tempDictionary.Add(FIELD_GOAL, 0);

            Team1Score = sc1;
            Team2Score = sc2;
            PointDeficit = 0;            
            NumOfFGs = 0;
            NumTchdn1Pt = 0;
            NumTchdn2Pt = 0;
            Message = TIE;

            calculateScore();
        }

#endregion

#region PROPERTIES

        public int Team1Score
        {
            get { return team1Score; }
            set { team1Score = Math.Abs(value); }
        }

        public int Team2Score
        {
            get { return team2Score; }
            set { team2Score = Math.Abs(value); }
        }

        public int PointDeficit { get; set; }       

        public int NumOfPoss
        {
            get
            {                
				return dictionary[TOUCHDOWN_W2PT] + dictionary[TOUCHDOWN_W1PT] + dictionary[FIELD_GOAL];  
            }
        } 

        public int NumOfFGs { get; set; }               
        public string Message { get; set; }       
        public int NumTchdn1Pt { get; set; }        
        public int NumTchdn2Pt { get; set; }   
     
#endregion

#region PUBLIC METHODS

        public void setScore(int sc1, int sc2)
        {
            Team1Score = sc1;
            Team2Score = sc2;

            calculateScore();
        }

#endregion

#region PRIVATE METHODS

        private void calculateScore()
        {          
            PointDeficit = Math.Abs(Team1Score - Team2Score);              

            if (PointDeficit == 0)
                Message = TIE;
            else
            {				
                miniCalc(PointDeficit);
				NumTchdn2Pt = dictionary[TOUCHDOWN_W2PT];
				NumTchdn1Pt = dictionary[TOUCHDOWN_W1PT];
				NumOfFGs = dictionary[FIELD_GOAL]; 
                Message = NumOfPoss + "-possession game: " + NumTchdn2Pt + " touchdown(s) w/2-pt conversion, " + NumTchdn1Pt + 
							" touchdown(s) w/extra pt , and " + NumOfFGs + " field goal(s) needed to tie or take the lead."; 
            }                  
        }

        private void miniCalc(int number)
        {
            if (number < 4)
            {
                dictionary[FIELD_GOAL] = 1;
            }
            else if (number > 3 && number < 8)
            {
                dictionary[TOUCHDOWN_W1PT] = 1;
            }
            else if(number == 9 || number == 10)
            {
                dictionary[TOUCHDOWN_W1PT] = 1;
                dictionary[FIELD_GOAL] = 1;
            }
            else
            {
                dictionary[TOUCHDOWN_W2PT] = number / TOUCHDOWN_W2PT;
				if(number % TOUCHDOWN_W2PT != 0)
					miniCalc(number % TOUCHDOWN_W2PT);
            }
         }

#endregion               
    }
}