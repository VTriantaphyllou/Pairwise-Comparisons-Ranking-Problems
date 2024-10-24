using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppl_CDP_Analysis_for_RR_problem1
{
    // *********************************************************************************************************************
    // ***
    // *** This program prepares data that I can use for my analysis of the Rank Reversal (RR) problem within a single
    // *** Saaty pairwise matrix.   It works as follows:
    // *** First consider N random values such that the Saaty scale of [1/9, 9] can be applied.
    // *** Get the ranking R0.  This is the real ranking that w ewill use to compare other rankings with.
    // *** Use the above values to consider all pairwise comparisons with continuous values.  This is the RCP matrix in my papers.
    // *** From the above matrix form the CDP matrix by using the standard Saaty sacle {1/9, 1/8, 1/7. 1/6. 1/5, ..., 1, 2, 3, ..., 6, 7, 8, 9]
    // *** Get the ranking from the CDP matrix.  This is R1.
    // *** Compare the two rankings R0 and R1.  Also, record some other values as explained later.
    // ***
    // *********************************************************************************************************************
    // *********************************************************************************************************************
    // *** by Vangelis Triantaphyllou, Baton Rouge, LA, October 2024.                                                    ***
    // *** Individual methods work fine, but some segments of this code may have bugs.  Some propriatery parts were      ***
    // *** removed as not all results have been published or sent for publication yet.                                   ***
    // *********************************************************************************************************************


    //......................................................................................
    // *********************************************************************************************************************
    class Dummy1_Demo
    { // *** Begin Class ***
      // *** Local variable declarations *** 
      // private int i, j;

        public void Dummy1(string Original_Dataset_Name1)
        { // *** Begin Method *** 


            //             Performance1 = 1.00; // <----  Van: A DUMMY statement.  DELETE it when done!!!! 

        } // *** End   Method ***
    }; // *** End Class ***
       // *********************************************************************************************************************
       //......................................................................................
  
    // *********************************************************************************************************************
    class Copy_PC_Matrix1_Demo
    { // *** Begin Class ***
      // *** Local variable declarations *** 
      private int i, j;

        public void Copy_PC_Matrix1 (int Size1, double [,] Input_PC_Matrix, out double [,] Output_PC_Matrix )
        { // *** Begin Method *** 
            Output_PC_Matrix = new double[30, 30];
             
            Output_PC_Matrix[1, 1] = 1.0;

            for (i = 1; i <= Size1; i++)
            {
                for (j=1;j <= Size1;j++)
                { Output_PC_Matrix[i,j] = Input_PC_Matrix[i, j]; 

                };
            };

        } // *** End   Method ***
    }; // *** End Class ***
       // *********************************************************************************************************************

    // *********************************************************************************************************************
    class Copy_Vector1_Demo
    { // *** Begin Class ***
      // *** Local variable declarations *** 
        private int i, j;

        public void Copy_Vector1 (int Size1, double[] Input_Vector, double[] Output_Vector)
        { // *** Begin Method *** 

            for (i = 1; i <= Size1; i++)
            { Output_Vector[i] = Input_Vector[i]; };

        } // *** End   Method ***
    }; // *** End Class ***
       // *********************************************************************************************************************

    // *********************************************************************************************************************
    class Copy_INT_Vector1_Demo
    { // *** Begin Class ***
      // *** Local variable declarations *** 
        private int i, j;

        public void Copy_INT_Vector1(int Size1, int [] Input_Vector, int [] Output_Vector)
        { // *** Begin Method *** 

            for (i = 1; i <= Size1; i++)
            { Output_Vector[i] = Input_Vector[i]; };

        } // *** End   Method ***
    }; // *** End Class ***
       // *********************************************************************************************************************

    class MainProgram
    { // *** begin class MainProgram ***


        // *********************************************************************************
        // *** The following function prints on the screen ("Console") a pairwise matrix ***  
        // *********************************************************************************
        public void Print_Pairwise_Matrix1(double[,] Pairwise_Matrix1, int N)
        { int i, j;
            double Value1;

            Console.WriteLine(" ************************************************ ");

            for (i = 1; i <= N; i++)
            {
                Console.WriteLine(" ");
                for (j = 1; j <= N; j++)
                {
                    Value1 = Pairwise_Matrix1[i, j];
                    Console.Write(Value1 + "   ");
                }
            }

            Console.WriteLine("  ");
            Console.WriteLine(" ************************************************ ");
        }


        // *********************************************************************************************************************
        class Scan_Pairwise_Matrix_for_Reciprocity_Violations1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i, j;

            public void Scan_Pairwise_Matrix_for_Reciprocity_Violations1(double[,] Pairwise_Matrix1, int Size1, out int No_of_Cases1)
            { // *** Begin Method *** 

                No_of_Cases1 = 0;

                for (i = 1; i <= Size1; i++)
                { for (j = i + 1; j <= Size1; j++)
                    { if (Pairwise_Matrix1[i, j] != (1.0 / Pairwise_Matrix1[j, i]))
                        { No_of_Cases1 = No_of_Cases1 + 1; }  // *** A violation of the reciprocity property has been found!
                    }
                }

            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************



        // *********************************************************************************************************************
        class Derive_Two_CDP_Matrices_from_Single_CDP_Matrix1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i, j;

            public void Derive_Two_CDP_Matrices_from_Single_CDP_Matrix1(double[,] Input_CDP_Matrix1, int Size1, out double[,] CDP_Matrix1, out double[,] CDP_Matrix2)
            { // *** Begin Method *** 
                CDP_Matrix1 = new double[30, 30];
                CDP_Matrix2 = new double[30, 30];

                // *** We first form CDP_Matrix1 which is based on the upper half of the Input CDP matrix ****            
                for (i = 1; i <= Size1; i++)
                {
                    CDP_Matrix1[i, i] = 1.0;
                    for (j = i + 1; j <= Size1; j++)
                    {
                        CDP_Matrix1[i, j] = Input_CDP_Matrix1[i, j];
                        CDP_Matrix1[j, i] = 1.0 / CDP_Matrix1[i, j];
                    }
                }

                // *** We now form CDP_Matrix2 which is based on the LOWER half of the Input CDP matrix ****            
                for (j = 1; j <= Size1; j++)
                {
                    CDP_Matrix2[j, j] = 1.0;
                    for (i = 1; i < j; i++)
                    {
                        CDP_Matrix2[j, i] = Input_CDP_Matrix1[j, i];
                        CDP_Matrix2[i, j] = 1.0 / CDP_Matrix2[j, i];
                    }
                }

            } // *** End Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************


        // *********************************************************************************************************************
        class Derive_The_Relative_Priorities_from_PC_Matrix1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i, j;
            private double[] Geometric_Means1 = new double[30];
            private double Product1, Sum1, Value1;

            public void Derive_The_Relative_Priorities_from_PC_Matrix1(double[,] PC_Matrix1, int Size1, out double[] Priority_Vector1)
            { // *** Begin Method ***   
                Priority_Vector1 = new double[30];
                //  VAN:  VERIFY EVERYTHING !!!!  

                // *** First, compute the products of each row ***
                //

                for (i = 1; i <= Size1; i++)
                {
                    Product1 = 1.0;
                    for (j = 1; j <= Size1; j++)
                    {
                        Product1 = Product1 * PC_Matrix1[i, j];
                    };
                    Geometric_Means1[i] = Product1;

                }

                // ******************************************************************************************
                // *** Calculate the geometric means now by taking the N-th root o fthe previous products *** 
                // *** Careful!  That Exponnet (i.e., 1 / Size1) has to be a double (real) number!        ***
                // *** This is why I use <1.0> instead of <1> in th eC# function <Math.Pow> below!        ***
                // ******************************************************************************************
                for (i = 1; i <= Size1; i++)
                {
                    Value1 = Geometric_Means1[i];
                    // this takes the N-th root now (N = Size1) of each row product.  *** 
                    Geometric_Means1[i] = Math.Pow(Value1, 1.0 / Size1);
                }

                // ***  Find the sum of the GMs now ***
                Sum1 = 0.0; // *** Initialization ***
                for (i = 1; i <= Size1; i++)
                {
                    Sum1 = Sum1 + Geometric_Means1[i];
                }

                // *** Normalize the Geometric Means (GMs) now! ***
                for (i = 1; i <= Size1; i++)
                {
                    Geometric_Means1[i] = Geometric_Means1[i] / Sum1;
                }

                // *** This normalized vector of the GMs, is our desired priority vector! ***
                for (i = 1; i <= Size1; i++)
                {
                    Priority_Vector1[i] = Geometric_Means1[i];
                }

            } // *** End Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************


        // *********************************************************************************************************************
        class Derive_The_Rankings_from_Priority_Vector1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i, Rank1;
            private double Maximum_Value1;
            double[] Temp_Vector1 = new double[30];

            public void Derive_The_Rankings_from_Priority_Vector1(double[] Priority_Vector1, int Size1, out int[] Rankings1)
            { // *** Begin Method ***   
                Rankings1 = new int[30];
                //Priority_Vector1 = new double[30];  <-------------  THIS WAS A HUGE ERROR!!!! 
                double[] Temp_Vector1 = new double[30];
                // **************************************************************************************************************
                // *** This method takes as input a priority vactor and its size, and it returns the corresponding rankings.  ***
                // *** Ranking value = 1 means the BEST value (= the Top ranking).                                            ***
                // *** Becaue of teh Saaty scale approximations, w emay have multiple alternatives with a ranking value = 1!  ***
                // **************************************************************************************************************

                // *** Transfer the Priority Vector1 into a Temporary vector to change its conetx as we move along ***
                for (i = 1; i <= Size1; i++)
                {
                    Temp_Vector1[i] = Priority_Vector1[i];
                }

                // *** Initialization ***
                Rank1 = 0;

            // *** Fing the currently available max value ***
            // *** This is PASS #1 **************************
            Label4: Maximum_Value1 = -9.0;  // *** Assigned to something negative on purpose ***

                for (i = 1; i <= Size1; i++)
                {
                    if (Temp_Vector1[i] > Maximum_Value1)
                    {
                        Maximum_Value1 = Temp_Vector1[i];
                    };
                };

                if (Maximum_Value1 < 0)
                {   // *** If this <if> is invoked, it means we ar edone and w eshould jump out of this looping ***
                    goto Label3;
                };

                // *** At this point we have the max value of the items no assigned to a rank yet.  ***
                // *** This is PASS #2:  Go and assign the currently top rank to all items that have value  ***
                // *** equal to <Maximum_Value1> ***
                Rank1 = Rank1 + 1;
                for (i = 1; i <= Size1; i++)
                {
                    if (Temp_Vector1[i] == Maximum_Value1)
                    {
                        Rankings1[i] = Rank1;   // *** Note that now the index is <j>  ***
                        Temp_Vector1[i] = -99.00;
                    };
                };

                goto Label4;

            Label3: i = 0;  // *** This is a dummy statement used for this Label to get out of that loop *** 

            } // *** End Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************




        // *********************************************************************************************************************
        class Compare_Two_Rankings1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i, j, KSum1;

            public void Compare_Two_Rankings1(int[] Ranking_Vector1, int[] Ranking_Vector2, int Size1, out int KResult1)
            { // *** Begin Method ***   
                // **************************************************************************************************************
                // *** This method takes as input two Ranking Vectors (integer values).   It comapres them and returns the    ***
                // *** value of a single integer variable <KResult1> with the following interpretation:                       ***
                // ***                                                                                                        ***
                // ***    if <KREsult1> =  0; --> no conflict!   They agree 100% on all rankings!                             *** 
                // ***    if <KResult1> =  1; --> They agree on the top alt., but they DO NOT agree 100% on all rankings.     ***
                // ***    if <KResult1> = -9; --> ( MINUS 9) They do not agree on the top alternative!                        ***
                // ***                                                                                                        ***
                // **************************************************************************************************************
                //Ranking_Vector1 = new int[30]; TERRIBLE MISTAKE!!!!!!
                //Ranking_Vector2 = new int[30]; TERRIBLE MISTAKE!!!!!!

                KResult1 = -9;   // *** This is the defaul.  That is, they do not agree on the top alternative (item)! 

                KSum1 = 0;       // *** Initialization ***
                for (i = 1; i <= Size1; i++)
                {
                    // *****************************************************************
                    // *** It is important to use Absolute or Squared values or      ***
                    // *** they may cancel out and thus be misleading occasionally!  ***
                    // *****************************************************************
                    KSum1 = KSum1 + Math.Abs(Ranking_Vector1[i] - Ranking_Vector2[i]);
                };

                if (KSum1 == 0)
                {  // *** The two rankings are IDENTICAL! ***
                    KResult1 = 0;      // *** Note that KResult1 = 0 <==> We have no conflicting ranking! They agree 100%!  ****
                    goto Label_Exit1;  // *** Get out!  We are done! ***   
                };

                // *** If we get to this point it means that the two rankings ARE NOT IDENTICAL! ***

                // **************************************************************** 
                // *** We check now if they agree on the top alternative.       ***
                // *** If they do, then KResult1 = 1                            ***
                // ****************************************************************
                for (i = 1; i <= Size1; i++)
                {
                    if (Ranking_Vector1[i] == 1)
                    {
                        for (j = 1; j <= Size1; j++)
                        {
                            if ((i == j) & (Ranking_Vector2[j] == 1))
                            {
                                KResult1 = 1;       // *** Item <i> in Vector1 and item <j> in Vector2 are both equal (i.e., i=j)
                                                    // *** and of rank value = 1.  That is, both are ranked at the top position! *** 
                                                    // Console.WriteLine(" They agree on the top position!  i = j ---> " + i + "   " + j);
                                goto Label_Exit1;
                            }
                        };
                    };
                };

            Label_Exit1: i = 1; // this is a dummy statement ***

            } // *** End Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************


        class Compute_Ranking_Difference1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i, j, KSum1;
            private double Sum1;

            public void Compute_Ranking_Difference1(int[] Ranking_Vector1, int[] Ranking_Vector2, int Size1, out double Normalized_Difference1)
            { // *** Begin Method ***   

                // **************************************************************************************************************
                // *** This method takes as input two Ranking Vectors (integer values).   It finds their difference and then  ***
                // *** normlaizes it                                                                                          ***
                // **************************************************************************************************************
                //Ranking_Vector1 = new int[30]; TERRIBLE MISTAKE!!!!!!
                //Ranking_Vector2 = new int[30]; TERRIBLE MISTAKE!!!!!!

                Sum1 = 0.0; // Initialization 

                for (i = 1; i <= Size1; i++)
                {
                    // *****************************************************************
                    // *** It is important to use Absolute values or                 ***
                    // *** they may cancel out and thus be misleading occasionally!  ***
                    // *****************************************************************
                    Sum1 = Sum1 + Math.Abs(Ranking_Vector1[i] - Ranking_Vector2[i]);
                };

                Normalized_Difference1 = Sum1 / (1.0 * Size1);

                // some debugging now! 
                // It has been verified!!!! It is good!
                //Console.WriteLine();
                //Console.WriteLine(" ---- inside new method ----");
                //for (i=1; i <= Size1; i++)
                //{
                //    Console.WriteLine("  i = " + i + " Rank1[i] = " + Ranking_Vector1[i] + " Rank2[i] = " + Ranking_Vector2[i] );
                //};
                //Console.WriteLine(" Normalized Difference -----> " + Normalized_Difference1);
                //Console.WriteLine(" -------------------- ");

            } // *** End Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************


        // *********************************************************************************************************************
        class Scan_Interval_for_Reciprocity_Violations1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i, j, KViolation_Flag1;
            private string Output_Interval_Scan_Results_File;
            double Limit12, Best_Saaty_Value1, Best_Inv_Saaty_Value1;
            double Inv1, Inv2, Inv12;
            double Distance0, Distance1, Distance2, Distance12, Step1;
            double Inv_Distance1, Inv_Distance2, Inv_Distance12, Inv_Distance0;

            public void Scan_Interval_for_Reciprocity_Violations1(double Limit1, double Limit2)
            { // *** Begin Method ***   
              // **************************************************************************************************************
              // *** This method takes as input the values of two integers Limit1 and Limit2.
              // *** We assume that Limit2 = Limit1 + 2.  As an example, w ehave Limit1 = and Limit2 = 4.
              // *** Mext we scan the interval [Limit1,  Limit2] with a step value = Step1 (a small value less than 1,
              // *** say Step1 = 0.001).  At each value (= Distance0) we check the best Saaty value for the PC that
              // *** corresponds to that value and also to its inverse.  If the initial best Saaty value disagrees with
              // *** the best Saaty value for the inverse (i.e., the reciprocity requirement is vilated), this is
              // *** reported both on the screen and it is recorded on a file for later (graphical) analysis and
              // *** presentation.
              // **************************************************************************************************************
              // 

                // ********************************************************************************************
                // *** The Output file can be found as follows:                                             ***
                // *** From th emain folder with this application go to: bib/Debug/net6.0-window/MyProjectFiles1   *** 
                // *** You will find it there!                                                              ***
                // ********************************************************************************************
                Output_Interval_Scan_Results_File = @"MyProjectFiles1\OUTPUT Interval Scan1.TXT";
                System.IO.StreamWriter file1 = new System.IO.StreamWriter(Output_Interval_Scan_Results_File);

                file1.WriteLine(" ************************************************ ");

                Step1 = 0.001; // *** Initialization to some small step size ***

                Limit12 = (Limit1 + Limit2) / 2.00;

                Inv1 = 1 / Limit1;
                Inv12 = 1 / Limit12;
                Inv2 = 1 / Limit2;

                Distance0 = Limit1; // *** We will start the scanning from the Limit1 value and
                                    // *** will proceed all the way to Limit2 value.
                                    // *** With step size = <Step1> ****

                while (Distance0 <= Limit2)
                {
                    Distance1 = Math.Abs(Distance0 - Limit1);
                    Distance12 = Math.Abs(Distance0 - Limit12);
                    Distance2 = Math.Abs(Distance0 - Limit2);

                    Inv_Distance0 = 1.00 / Distance0;

                    //VAN:  I AM NOT SURE THESE FORMULAS ARE CORRECT.  BUT IT DOES NOT MATTER BECAUSE
                    //      I HAVE DEVELOPED RESULTS ANALYTICALLY IN THE PAPER!
                    Inv_Distance1 = Math.Abs(Inv1 - Inv_Distance0);
                    Inv_Distance12 = Math.Abs(Inv12 - Inv_Distance0);
                    Inv_Distance2 = Math.Abs(Inv2 - Inv_Distance0);

                    // *************************************************************************************************************
                    // *** First we examine exhaustively all cases for the best Saaty value for the 1st PC (Pairwise Comparison) *** 
                    // ************************************************************************************************************* 
                    if ((Distance1 <= Distance12) & (Distance1 < Distance2))
                    { // *** The best approximation for the 1st PC is that the Saaty number should be <Limit1> ***
                        Best_Saaty_Value1 = Limit1;
                    };

                    if ((Distance12 < Distance1) & (Distance12 < Distance2))
                    { // *** The best approximation for the 1st PC is that the Saaty number should be <Limit12> ***
                        Best_Saaty_Value1 = Limit12;
                    };
                    if ((Distance2 <= Distance12) & (Distance2 < Distance1))
                    { // *** The best approximation for the 1st PC is that the Saaty number should be <Limit2> ***
                        Best_Saaty_Value1 = Limit2;
                    };

                    // *** Print out the resulst for the first Pairwise Comparison ****
                    Console.WriteLine(" Dist0, S_Val1, Lim1, Lim2, Lim12, Dst1, Dst2, Dst12 = " + Distance0 + " " + Best_Saaty_Value1 + " " + Limit1 + " " + Limit2 + " " + Limit12 + " " + Distance1 + " " + Distance2 + " " + Distance12);

                    // *************************************************************************************************************
                    // *** Next, we examine exhaustively all cases for the best Saaty value for the 2nd PC (Pairwise Comparison) *** 
                    // ************************************************************************************************************* 
                    if ((Inv_Distance1 <= Inv_Distance12) & (Inv_Distance1 < Inv_Distance2))
                    { // *** The best approximation for the 1st PC is that the Saaty number should be < 1 / Limit1 > ***
                        Best_Inv_Saaty_Value1 = Inv1;
                    };

                    if ((Inv_Distance12 < Inv_Distance1) & (Inv_Distance12 < Inv_Distance2))
                    { // *** The best approximation for the 1st PC is that the Saaty number should be <Limit12> ***
                        Best_Inv_Saaty_Value1 = Inv12;
                    };
                    if ((Inv_Distance2 <= Inv_Distance12) & (Inv_Distance2 < Inv_Distance1))
                    { // *** The best approximation for the 1st PC is that the Saaty number should be <Limit2> ***
                        Best_Inv_Saaty_Value1 = Inv2;
                    };

                    // *** Print out the resulst for the second Pairwise Comparison ****
                    Console.WriteLine(" Dist0, INV_S_Val1, INV1, INV2, INV12, Inv_Dst1, Inv_Dst2, Inv_Dst12 = " + Distance0 + " " + Best_Inv_Saaty_Value1 + " " + Inv1 + " " + Inv2 + " " + Inv12 + " " + Inv_Distance1 + " " + Inv_Distance2 + " " + Inv_Distance12);

                    if (Best_Saaty_Value1 != (1 / Best_Inv_Saaty_Value1))
                    {
                        KViolation_Flag1 = 1; // *** YES! A reciprocal property violation has occured ***
                        Console.WriteLine(" A VIOLATION was found with the previous two-line data! ");
                    }
                    if (Best_Saaty_Value1 == (1 / Best_Inv_Saaty_Value1))
                    {
                        KViolation_Flag1 = 0; // *** No reciprocal property violation has occured ***
                        Console.WriteLine(" ALL IS FINE with the previous two-line data! ");
                    }


                    file1.WriteLine(Distance0 + "  " + KViolation_Flag1 + "     " + Best_Saaty_Value1 + "  " + (1 / Best_Inv_Saaty_Value1) + "  " + Best_Inv_Saaty_Value1 + "  " + Distance1 + "  " + Distance12 + " " + Distance2 + "     " + Inv_Distance1 + "  " + Inv_Distance12 + "   " + Inv_Distance2);

                    Distance0 = Distance0 + Step1;
                };

                file1.WriteLine(" ************************************************ ");
                file1.Close();

            } // *** End Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************




        // *********************************************************************************************************************
        class Scan_Values_in_Saaty_Interval_for_reciprocal_Problem1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
          // private int i, j;
            private double Step1, Starting_Value1, Upper_Limit1, Saaty_Value1, Saaty_Value2;
            private double Current_Value1, Inverse_Current_Value1, Inverse_Saaty_Value1, Failure_Ratio1;
            private int K1_Counter, K2_Counter, Total_Iterations1;

            public void Scan_Values_in_Saaty_Interval_for_reciprocal_Problem1()
            { // *** Begin Method *** 

                Starting_Value1 = 1.00 / 9.0; // *** This is the starting value for my search **************
                Upper_Limit1 = 9.0;         // *** This is the uppe rlimit of Saaty's sacle            ***
                Step1 = 0.0005;              // *** This is the step I will scan the interval [1/9, 9]  ***
                Current_Value1 = Starting_Value1; // *** Initialization ***

                K1_Counter = 0;
                K2_Counter = 0;
                Console.WriteLine(" Initialized Current Value = " + Current_Value1);

                while (Current_Value1 <= Upper_Limit1)
                { // *** begin while-loop ***
                  //   Console.WriteLine(" Inside Loop Current Value = " + Current_Value1);
                  // *************************************************** 
                  // *** Check for that "reciprocal abnorality" now! ***

                    MainProgram pr = new MainProgram();  // *** Creating a class Object ***

                    // *** Use that approximating function here!!!!!!!!!!!!!!!
                    Saaty_Value1 = pr.Approximate_Using_Saaty_Scale1(Current_Value1);

                    Inverse_Current_Value1 = 1 / Current_Value1;
                    Saaty_Value2 = pr.Approximate_Using_Saaty_Scale1(Inverse_Current_Value1);

                    Inverse_Saaty_Value1 = 1 / Saaty_Value1;

                    if (Inverse_Saaty_Value1 == Saaty_Value2)
                    {
                        Console.WriteLine(" Rec prop is sat!  V1 / S_V1 & Inv_V1 / S_V2 = " + Current_Value1 + "  " + Saaty_Value1 + "    &   " + Inverse_Current_Value1 + "  " + Saaty_Value2);
                        //                        Console.WriteLine(" The rec pr is satisfied! Saaty_Val1   & Saaty_Val2 = " + Saaty_Value1 + "  " + Saaty_Value2);
                        K1_Counter = K1_Counter + 1;
                    } else
                    {
                        Console.WriteLine(" Rec prop is VIOL! V1 / S_V1 & Inv_V1 / S_V2  = " + Current_Value1 + "  " + Saaty_Value1 + "    &   " + Inverse_Current_Value1 + "  " + Saaty_Value2);
                        //   Console.WriteLine(" The rec pr is VIOLATED! Saaty_Val1   & Saaty_Val2  = " + Saaty_Value1 + "  " + Saaty_Value2);
                        K2_Counter = K2_Counter + 1;
                    }

                    Current_Value1 = Current_Value1 + Step1; // *** Increment for the next iteration ***


                    // *** end while-loop ***
                }

                Total_Iterations1 = K1_Counter + K2_Counter;
                Failure_Ratio1 = (K2_Counter * 100.0) / Total_Iterations1;
                Console.WriteLine();
                Console.WriteLine(" Iterations, NO violations, Nu. of violations, Failure Ratio = " + Total_Iterations1 + "  " + K1_Counter + "   " + K2_Counter + "   " + Failure_Ratio1 + " %  ");
                Console.WriteLine();


            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************



        // **********************************************************************************
        // *** This function takes as input a real number from the interval [1/9,  9] and ***
        // *** return the closet value to it from the values permited by the Saaty scale. ***
        // *** That is, the 17 values: {1/9, 1/8, 1/7, ..., 1, 2, 3, ..., 7, 8, 9}.       ***
        // **********************************************************************************
        public double Approximate_Using_Saaty_Scale1(double True_Value1)
        {
            double Return_Saaty_Value1;
            double[] All_Saaty_Values1 = new double[18];
            int i1;
            double Min1, Square_Difference1;

            // *** Initialize with all the values in Saaty's scale ***
            All_Saaty_Values1[1] = 1 / 9.0;
            All_Saaty_Values1[2] = 1 / 8.0;
            All_Saaty_Values1[3] = 1 / 7.0;
            All_Saaty_Values1[4] = 1 / 6.0;
            All_Saaty_Values1[5] = 1 / 5.0;
            All_Saaty_Values1[6] = 1 / 4.0;
            All_Saaty_Values1[7] = 1 / 3.0;
            All_Saaty_Values1[8] = 1 / 2.0;
            All_Saaty_Values1[9] = 1.0;
            All_Saaty_Values1[10] = 2.0;
            All_Saaty_Values1[11] = 3.0;
            All_Saaty_Values1[12] = 4.0;
            All_Saaty_Values1[13] = 5.0;
            All_Saaty_Values1[14] = 6.0;
            All_Saaty_Values1[15] = 7.0;
            All_Saaty_Values1[16] = 8.0;
            All_Saaty_Values1[17] = 9.0;
            // *** End of initializations ****

            // *** Find now the Saaty value that is closest to <True_Value1> **********************
            Min1 = 9999.0;             // *** An arbitraly VERY large value for initialization ***
            Return_Saaty_Value1 = 1.11; // *** A dummy statmenet to avoid a stupid error?       ***

            for (i1 = 1; i1 <= 17;)
            { // *** begin for i1-loop ***

                // Square_Difference1 = (True_Value1 - All_Saaty_Values1[i1]) * (True_Value1 - All_Saaty_Values1[i1]);

                // *** This code is OK now.  I have a truly VERY large initialization value for the <Min1> and all is fine now! ***
                Square_Difference1 = Math.Abs(True_Value1 - All_Saaty_Values1[i1]); // *** ACTUALLY, IT IS THE ABSOLUTE VALUE DIFFERENCE! 
                if (Square_Difference1 < Min1)
                { Min1 = Square_Difference1;
                    Return_Saaty_Value1 = All_Saaty_Values1[i1];
                };

                i1 = i1 + 1;
                // *** end for i1-loop ***
            };
            //Console.WriteLine("        True Value1 = " + True_Value1 + "   Saaty Value ---> " + Return_Saaty_Value1);
            // Now we provide the return statement  
            return Return_Saaty_Value1;
        }

        // *********************************************************************************************************************
        class Explore_Reciprocal_Property_Matrices1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 

            public void Explore_Reciprocal_Property_Matrices1()
            { // *** Begin Method *** 

                // **************************************
                // *** Variable declarations section. ***
                // **************************************
                string Output_CDP_Analysis1_File;
                int i, j, N, K;
                double u1, Min_Random_Value1, Max_Random_Value1, Max_Ratio1, Min_Ratio1;

                int[] Ranking_R0 = new int[100];
                double[] Real_Values_of_the_Alternatives = new double[100];
                double[] Bad_Real_Values_of_the_Alternatives = new double[100];
                double[,] RCP_Matrix1 = new double[30, 30];
                double[,] CDP_Matrix1 = new double[30, 30];
                double[,] Bad_RCP_Matrix1 = new double[30, 30];
                double[,] Bad_CDP_Matrix1 = new double[30, 30];


                double True_Value1, Saaty_Value1, Ratio_Defective_Matrices1;
                int Cases1, Max_Number_Cases1, Iterations1, Counter_Defective_Matrics1;

                Random rand = new Random();    //reuse this if you are generating many random doubles (real) numbers uniform in (0,1) ***


                // ************************************ 
                // *** Object declarations section. ***
                // ************************************
                Scan_Values_in_Saaty_Interval_for_reciprocal_Problem1_Demo object1 = new Scan_Values_in_Saaty_Interval_for_reciprocal_Problem1_Demo();
                Scan_Pairwise_Matrix_for_Reciprocity_Violations1_Demo object2 = new Scan_Pairwise_Matrix_for_Reciprocity_Violations1_Demo();
                Copy_PC_Matrix1_Demo object3 = new Copy_PC_Matrix1_Demo();
                Copy_Vector1_Demo object4 = new Copy_Vector1_Demo();

                // *** end of the Object declaration section. ********


                MainProgram pr1 = new MainProgram();  // *** Creating a class Object ***
                MainProgram pr = new MainProgram();  // *** Creating a class Object ***

                // goto Label2;

                // *** end of the Variable declaration section. ****** 

                // ***  Console.WriteLine(" \n We just started!   Hit CR once to move on...");
                // ***  Console.ReadLine();
                // *************************************************************
                // *** Assign some numerical values to my key parameters now ***

                K = 0;  // *** This is the counter of how many cases I had to search to find an appropriate matrix consistent with Saaty's scale!
                N = 4;  // *** The max number of items to be compared by means of pairwis ecomparisons is equal to 30 ***
                        // **************************************************************



                // ********************************************************************************************
                // *** The Output file can be found as follows:                                             ***
                // *** From th emain folder with this application go to: bib/Debug/net6.0-windows/MyProjectFiles1   *** 
                // *** You will find it there!                                                              ***
                // ********************************************************************************************
                Output_CDP_Analysis1_File = @"MyProjectFiles1\OUTPUT CDPMatrix Analysis1.TXT";
                System.IO.StreamWriter file1 = new System.IO.StreamWriter(Output_CDP_Analysis1_File);

                file1.WriteLine(" ************************************************ ");

                Counter_Defective_Matrics1 = 0;
                Max_Number_Cases1 = -9; // *** Initialize to a megative integer so we can start updating it immediately ***
                for (Iterations1 = 1; Iterations1 <= 10000; Iterations1++)
                { // *** begin Iterations1-loop ****************** 

                // *** Get N randmom values uniformly disributed in [0, 1] and load them in my array <Real_Values_of_the_Alternatives[] 

                Label1: K = K + 1;
                    for (i = 1; i <= N; i++)
                    {  // begin for i-loop ***
                       // *** Recall that this is stated more above: double u1 = rand.NextDouble(); //these are uniform(0,1) random doubles
                        u1 = rand.NextDouble();
                        Real_Values_of_the_Alternatives[i] = u1;
                    }; // *** end for i-loop ***

                    // ***************************************************************************************************************************************
                    // *** Now we need to find out if the ratio <Ratio_Max> of the Max such value divided by the Min such value is less than or equal to 9 ***
                    // *** and the ratio <Ratio_Min> of the <1 / Ratio_MaxGet> is larger than or equal to 1/9                                              ***
                    // *** Thus, first find the <Min_Random_Value1> and <Max_Random_Value1> values!                                                        ***
                    // ***************************************************************************************************************************************

                    // *** Some initializations now *********************************************      
                    Min_Random_Value1 = 99.0; // *** An arbitrarily large value out of range ***
                    Max_Random_Value1 = -99.0; // *** An arbitrarily samll value out of range ***

                    for (i = 1; i <= N; i++)
                    {  // begin for i-loop ***
                        if (Real_Values_of_the_Alternatives[i] >= Max_Random_Value1)
                        { Max_Random_Value1 = Real_Values_of_the_Alternatives[i]; };

                        if (Real_Values_of_the_Alternatives[i] <= Min_Random_Value1)
                        { Min_Random_Value1 = Real_Values_of_the_Alternatives[i]; };
                    }; // *** end for i-loop ***
                    Max_Ratio1 = Max_Random_Value1 / Min_Random_Value1;
                    Min_Ratio1 = 1.0 / Max_Ratio1;

                    if ((Min_Ratio1 < 1 / 9.0) || (Max_Ratio1 > 9.0))
                    { goto Label1; };

                    for (i = 1; i <= N; i++)
                    {  // begin for i-loop ***
                       //   file1.WriteLine(" i = " + i + " Stored Value --> " + Real_Values_of_the_Alternatives[i]);

                    }; // *** end for i-loop ***

                    // *** We build the RCP matrix now!  ****************
                    for (i = 1; i <= N; i++)
                    {  // begin for i-loop ***
                        for (j = 1; j <= N; j++)
                        {  // begin for j-loop ***
                            RCP_Matrix1[i, j] = Real_Values_of_the_Alternatives[i] / Real_Values_of_the_Alternatives[j];
                        }; // *** end for j-loop ***
                    }; // *** end for i-loop ***


                    // pr.Print_Pairwise_Matrix1(RCP_Matrix1, N);

                    // file1.WriteLine(" We prepare the CDP Matrix no! ");
                    // *** We build the RCP matrix now!  ****************
                    for (i = 1; i <= N; i++)
                    {  // begin for i-loop ***
                        for (j = 1; j <= N; j++)
                        {  // begin for j-loop ***

                            True_Value1 = RCP_Matrix1[i, j];

                            // *** Use that approximating function here!!!!!!!!!!!!!!!
                            Saaty_Value1 = pr.Approximate_Using_Saaty_Scale1(True_Value1);
                            CDP_Matrix1[i, j] = Saaty_Value1;
                        }; // *** end for j-loop ***
                    }; // *** end for i-loop ***



                    // pr.Print_Pairwise_Matrix1(CDP_Matrix1, N);

                    file1.Close();


                    object2.Scan_Pairwise_Matrix_for_Reciprocity_Violations1(CDP_Matrix1, N, out Cases1);

                    if (Cases1 > 0)
                    {
                        Counter_Defective_Matrics1 = Counter_Defective_Matrics1 + 1;

                        if (Cases1 > Max_Number_Cases1)
                        {
                            Max_Number_Cases1 = Cases1;
                            // *** Copy the pertinent vector and PC matrices now! ***
                            object4.Copy_Vector1(N, Real_Values_of_the_Alternatives, Bad_Real_Values_of_the_Alternatives);
                            object3.Copy_PC_Matrix1(N, RCP_Matrix1, out Bad_RCP_Matrix1);
                            object3.Copy_PC_Matrix1(N, CDP_Matrix1, out Bad_CDP_Matrix1);
                        };

                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine(" Violations have been detected!  No of Cases ===> " + Cases1);
                        Console.WriteLine(" ****************************************************");
                        Console.WriteLine();

                        Console.WriteLine(" The real values of the N items are as follows: ");
                        int ii1;
                        for (ii1 = 1; ii1 <= N; ii1++)
                        {
                            Console.Write("  " + Real_Values_of_the_Alternatives[ii1]);
                        };
                        Console.WriteLine();
                        Console.WriteLine(" ________________________________________________ ");
                        Console.WriteLine();


                        Console.WriteLine(" ___  The RCP Matrix is ____________");

                        pr.Print_Pairwise_Matrix1(RCP_Matrix1, N);

                        Console.WriteLine();
                        Console.WriteLine(" ___  The CDP Matrix is ____________");

                        pr.Print_Pairwise_Matrix1(CDP_Matrix1, N);

                        Console.WriteLine(" ****************************************************");

                    }

                }; // *** end Iterations1-loop ****


                Ratio_Defective_Matrices1 = (Counter_Defective_Matrics1 * 100.0) / Iterations1;
                Console.WriteLine();
                Console.WriteLine(" ________________________________________________ ");
                Console.WriteLine("  Ratio of Defective Matrices = " + Ratio_Defective_Matrices1 + " %  ");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(" ==================================================== ");
                Console.WriteLine(" Maximum number of cases within a single matrix = " + Max_Number_Cases1);
                Console.WriteLine();
                Console.WriteLine(" The real values for the following matrices are next:");

                for (i = 1; i <= N; i++)
                { Console.Write("  " + Bad_Real_Values_of_the_Alternatives[i]); };
                Console.WriteLine();

                Console.WriteLine(" ___  The BAD RCP Matrix is ____________");
                pr1.Print_Pairwise_Matrix1(Bad_RCP_Matrix1, N);
                Console.WriteLine(" ___  The BAD CDP Matrix is ____________");
                pr1.Print_Pairwise_Matrix1(Bad_CDP_Matrix1, N);

                Console.WriteLine(" ________________________________________________ ");
                Console.WriteLine();






            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************


        // *********************************************************************************************************************
        class Explore_Reciprocal_Property_Matrices1a_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 

            public void Explore_Reciprocal_Property_Matrices1a()
            { // *** Begin Method *** 

                // **************************************
                // *** Variable declarations section. ***
                // **************************************
                string Output_CDP_Analysis1_File;
                int i, j, N, K;
                double u1, Min_Random_Value1, Max_Random_Value1, Max_Ratio1, Min_Ratio1;

                int[] Ranking_R0 = new int[100];
                double[] Real_Values_of_the_Alternatives = new double[100];
                double[] Bad_Real_Values_of_the_Alternatives = new double[100];
                double[,] RCP_Matrix1 = new double[30, 30];
                double[,] CDP_Matrix1 = new double[30, 30];
                double[,] Bad_RCP_Matrix1 = new double[30, 30];
                double[,] Bad_CDP_Matrix1 = new double[30, 30];


                double True_Value1, Saaty_Value1, Ratio_Defective_Matrices1;
                int Cases1, Max_Number_Cases1, Iterations1, Counter_Defective_Matrices1;

                Random rand = new Random();    //reuse this if you are generating many random doubles (real) numbers uniform in (0,1) ***


                // ************************************ 
                // *** Object declarations section. ***
                // ************************************
                Scan_Values_in_Saaty_Interval_for_reciprocal_Problem1_Demo object1 = new Scan_Values_in_Saaty_Interval_for_reciprocal_Problem1_Demo();
                Scan_Pairwise_Matrix_for_Reciprocity_Violations1_Demo object2 = new Scan_Pairwise_Matrix_for_Reciprocity_Violations1_Demo();
                Copy_PC_Matrix1_Demo object3 = new Copy_PC_Matrix1_Demo();
                Copy_Vector1_Demo object4 = new Copy_Vector1_Demo();

                // *** end of the Object declaration section. ********


                MainProgram pr1 = new MainProgram();  // *** Creating a class Object ***
                MainProgram pr = new MainProgram();  // *** Creating a class Object ***

                // goto Label2;

                // *** end of the Variable declaration section. ****** 

                // ***  Console.WriteLine(" \n We just started!   Hit CR once to move on...");
                // ***  Console.ReadLine();
                // *************************************************************
                // *** Assign some numerical values to my key parameters now ***

                K = 0;  // *** This is the counter of how many cases I had to search to find an appropriate matrix consistent with Saaty's scale!
                N = 4;  // *** The max number of items to be compared by means of pairwis ecomparisons is equal to 30 ***
                        // **************************************************************



                // ****************************************************************************************************
                // *** The Output file can be found as follows:                                                     ***
                // *** From the main folder with this application go to: bib/Debug/net6.0-windows/MyProjectFiles1   *** 
                // *** You will find it there!                                                                      ***
                // ****************************************************************************************************
                Output_CDP_Analysis1_File = @"MyProjectFiles1\OUTPUT CDPMatrix Analysis1a.TXT";
                System.IO.StreamWriter file1 = new System.IO.StreamWriter(Output_CDP_Analysis1_File);

                file1.WriteLine(" ************************************************ ");

                Counter_Defective_Matrices1 = 0;
                Max_Number_Cases1 = -9; // *** Initialize to a negative integer so we can start updating it immediately ***
                for (Iterations1 = 1; Iterations1 <= 10000; Iterations1++)
                { // *** begin Iterations1-loop ****************** 

                // *** Get N randmom values uniformly disributed in [0, 1] and load them in my array <Real_Values_of_the_Alternatives[] 

                Label1: K = K + 1;
                    for (i = 1; i <= N; i++)
                    {  // begin for i-loop ***
                       // *** Recall that this is stated more above: double u1 = rand.NextDouble(); //these are uniform(0,1) random doubles
                        u1 = rand.NextDouble();
                        Real_Values_of_the_Alternatives[i] = u1;
                    }; // *** end for i-loop ***

                    // ***************************************************************************************************************************************
                    // *** Now we need to find out if the ratio <Ratio_Max> of the Max such value divided by the Min such value is less than or equal to 9 ***
                    // *** and the ratio <Ratio_Min> of the <1 / Ratio_MaxGet> is larger than or equal to 1/9                                              ***
                    // *** Thus, first find the <Min_Random_Value1> and <Max_Random_Value1> values!                                                        ***
                    // ***************************************************************************************************************************************

                    // *** Some initializations now *********************************************      
                    Min_Random_Value1 = 99.0; // *** An arbitrarily large value out of range ***
                    Max_Random_Value1 = -99.0; // *** An arbitrarily samll value out of range ***

                    for (i = 1; i <= N; i++)
                    {  // begin for i-loop ***
                        if (Real_Values_of_the_Alternatives[i] >= Max_Random_Value1)
                        { Max_Random_Value1 = Real_Values_of_the_Alternatives[i]; };

                        if (Real_Values_of_the_Alternatives[i] <= Min_Random_Value1)
                        { Min_Random_Value1 = Real_Values_of_the_Alternatives[i]; };
                    }; // *** end for i-loop ***
                    Max_Ratio1 = Max_Random_Value1 / Min_Random_Value1;
                    Min_Ratio1 = 1.0 / Max_Ratio1;

                    if ((Min_Ratio1 < 1 / 9.0) || (Max_Ratio1 > 9.0))
                    { goto Label1; };

                    for (i = 1; i <= N; i++)
                    {  // begin for i-loop ***
                       //   file1.WriteLine(" i = " + i + " Stored Value --> " + Real_Values_of_the_Alternatives[i]);

                    }; // *** end for i-loop ***

                    // *** We build the RCP matrix now!  ****************
                    for (i = 1; i <= N; i++)
                    {  // begin for i-loop ***
                        for (j = 1; j <= N; j++)
                        {  // begin for j-loop ***
                            RCP_Matrix1[i, j] = Real_Values_of_the_Alternatives[i] / Real_Values_of_the_Alternatives[j];
                        }; // *** end for j-loop ***
                    }; // *** end for i-loop ***


                    // pr.Print_Pairwise_Matrix1(RCP_Matrix1, N);

                    // file1.WriteLine(" We prepare the CDP Matrix now! ");
                    // *** We build the CDP matrix now!  ****************
                    for (i = 1; i <= N; i++)
                    {  // begin for i-loop ***
                        for (j = 1; j <= N; j++)
                        {  // begin for j-loop ***

                            True_Value1 = RCP_Matrix1[i, j];

                            // *** Use that approximating function here!!!!!!!!!!!!!!!
                            Saaty_Value1 = pr.Approximate_Using_Saaty_Scale1(True_Value1);
                            CDP_Matrix1[i, j] = Saaty_Value1;
                        }; // *** end for j-loop ***
                    }; // *** end for i-loop ***



                    // pr.Print_Pairwise_Matrix1(CDP_Matrix1, N);

                    file1.Close();


                    object2.Scan_Pairwise_Matrix_for_Reciprocity_Violations1(CDP_Matrix1, N, out Cases1);

                    if (Cases1 > 0)
                    {
                        Counter_Defective_Matrices1 = Counter_Defective_Matrices1 + 1;

                        if (Cases1 > Max_Number_Cases1)
                        {
                            Max_Number_Cases1 = Cases1;
                            // *** Copy the pertinent vector and PC matrices now! ***
                            object4.Copy_Vector1(N, Real_Values_of_the_Alternatives, Bad_Real_Values_of_the_Alternatives);
                            object3.Copy_PC_Matrix1(N, RCP_Matrix1, out Bad_RCP_Matrix1);
                            object3.Copy_PC_Matrix1(N, CDP_Matrix1, out Bad_CDP_Matrix1);
                        };

                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine(" Violations have been detected!  No of Cases ===> " + Cases1);
                        Console.WriteLine(" ****************************************************");
                        Console.WriteLine();

                        Console.WriteLine(" The real values of the N items are as follows: ");
                        int ii1;
                        for (ii1 = 1; ii1 <= N; ii1++)
                        {
                            Console.Write("  " + Real_Values_of_the_Alternatives[ii1]);
                        };
                        Console.WriteLine();
                        Console.WriteLine(" ________________________________________________ ");
                        Console.WriteLine();


                        Console.WriteLine(" ___  The RCP Matrix is ____________");

                        pr.Print_Pairwise_Matrix1(RCP_Matrix1, N);

                        Console.WriteLine();
                        Console.WriteLine(" ___  The CDP Matrix is ____________");

                        pr.Print_Pairwise_Matrix1(CDP_Matrix1, N);

                        Console.WriteLine(" ****************************************************");

                    }

                }; // *** end Iterations1-loop ****


                Ratio_Defective_Matrices1 = (Counter_Defective_Matrices1 * 100.0) / Iterations1;
                Console.WriteLine();
                Console.WriteLine(" ________________________________________________ ");
                Console.WriteLine("  Ratio of Defective Matrices = " + Ratio_Defective_Matrices1 + " %  ");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(" ==================================================== ");
                Console.WriteLine(" Maximum number of cases within a single matrix = " + Max_Number_Cases1);
                Console.WriteLine();
                Console.WriteLine(" The real values for the following matrices are next:");

                for (i = 1; i <= N; i++)
                { Console.Write("  " + Bad_Real_Values_of_the_Alternatives[i]); };
                Console.WriteLine();

                Console.WriteLine(" ___  The BAD RCP Matrix is ____________");
                pr1.Print_Pairwise_Matrix1(Bad_RCP_Matrix1, N);
                Console.WriteLine(" ___  The BAD CDP Matrix is ____________");
                pr1.Print_Pairwise_Matrix1(Bad_CDP_Matrix1, N);

                Console.WriteLine(" ________________________________________________ ");
                Console.WriteLine();






            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************



        // *********************************************************************************************************************
        class Explore_Rank_Conflicts_PC_Matrices1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 

            public void Explore_Rank_Conflicts_PC_Matrices1()
            { // *** Begin Method *** 

                // **************************************
                // *** Variable declarations section. ***
                // **************************************
                string Output_CDP_Analysis2a_File, Output_CDP_Analysis2b_File;
                string Output_CDP_Example3_File;
                int i, j, N, Nmax, Nmin, K, KResult1, KResult1a, KResult1b, KResult1ab, KResult11a, KResult11b;
                Double u1, Min_Random_Value1, Max_Random_Value1, Max_Ratio1, Min_Ratio1;

                int[] Ranking_R0 = new int[30];
                int[] Ranking_R1 = new int[30];
                int[] Ranking_R1A = new int[30];
                int[] Ranking_R1B = new int[30];


                double[] Priority_Vector0 = new double[30];
                double[] Priority_Vector1 = new double[30];
                double[] Priority_Vector1A = new double[30];
                double[] Priority_Vector1B = new double[30];

                double[] Real_Values_of_the_Alternatives = new double[30];
                double[] Bad_Real_Values_of_the_Alternatives = new double[30];
                double[,] RCP_Matrix1 = new double[30, 30];
                double[,] CDP_Matrix1 = new double[30, 30];
                double[,] Bad_RCP_Matrix1 = new double[30, 30];
                double[,] Bad_CDP_Matrix1 = new double[30, 30];
                double[,] Reciprocal_CDP_Matrix1A = new double[30, 30];
                double[,] Reciprocal_CDP_Matrix1B = new double[30, 30];

                double True_Value1, Saaty_Value1, Ratio_Defective_Matrices1;
                int Iterations1, Max_Iterations1, No_of_Violations1;
                int KCounter_Rank_Abnorm_A1, KCounter_Rank_Abnorm_A2, KCounter_Rank_Abnorm_B1, KCounter_Rank_Abnorm_B2;
                int KCounter_2_Saaty_Matrices_Disagree1;

                // *** end of the Variable declaration section. ****** 

                Random rand = new Random();    //reuse this if you are generating many random doubles (real) numbers uniform in (0,1) ***


                // ************************************ 
                // *** Object declarations section. ***
                // ************************************
                Scan_Values_in_Saaty_Interval_for_reciprocal_Problem1_Demo object1 = new Scan_Values_in_Saaty_Interval_for_reciprocal_Problem1_Demo();
                Scan_Pairwise_Matrix_for_Reciprocity_Violations1_Demo object2 = new Scan_Pairwise_Matrix_for_Reciprocity_Violations1_Demo();
                Copy_PC_Matrix1_Demo object3 = new Copy_PC_Matrix1_Demo();
                Copy_Vector1_Demo object4 = new Copy_Vector1_Demo();
                Derive_Two_CDP_Matrices_from_Single_CDP_Matrix1_Demo object5 = new Derive_Two_CDP_Matrices_from_Single_CDP_Matrix1_Demo();
                Derive_The_Relative_Priorities_from_PC_Matrix1_Demo object6 = new Derive_The_Relative_Priorities_from_PC_Matrix1_Demo();
                Derive_The_Rankings_from_Priority_Vector1_Demo object7 = new Derive_The_Rankings_from_Priority_Vector1_Demo();
                Compare_Two_Rankings1_Demo object8 = new Compare_Two_Rankings1_Demo();


                // *** end of the Object declaration section. ********




                MainProgram pr1 = new MainProgram();  // *** Creating a class Object ***
                MainProgram pr = new MainProgram();  // *** Creating a class Object ***

                // ***  Console.WriteLine(" \n We just started!   Hit CR once to move on...");
                // ***  Console.ReadLine();
                // *************************************************************

                // ********************************************************************************************
                // *** The Output file can be found as follows:                                             ***
                // *** From the main folder with this application go to: bib/Debug/net6.0-windows/MyProjectFiles1   *** 
                // *** You will find it there!                                                              ***
                // ********************************************************************************************
                Output_CDP_Analysis2a_File = @"MyProjectFiles1\OUTPUT CDP Analysis2a.TXT";
                System.IO.StreamWriter file1 = new System.IO.StreamWriter(Output_CDP_Analysis2a_File);


                Max_Iterations1 = 1000000; // *** Sample size for each value of <n> ***// 

                file1.WriteLine(" ************************************************ ");
                file1.WriteLine(" *** This file was produced by Method <Explore_Rank_Conflicts_PC_Matrices1()> *** ");
                file1.WriteLine(" *** This file was originally created at the follwoing subdirectory: *** ");
                file1.WriteLine(" *** From the main folder with this application go to: < bib/Debug/net6.0-windows/MyProjectFiles1 > *** ");
                file1.WriteLine(" *** This is the file with the results regarding having RC violations and Ranking abnormalities.   *** ");
                file1.WriteLine(" *** Used for my PAPER #1 which was first submitted to EJOR  in the Summer of 2022 ");
                file1.WriteLine(" *** and then revised in the Fall of 2022 *** ");
                file1.WriteLine(" ************************************************ ");
                file1.WriteLine(" *** ");
                file1.WriteLine(" ***  Sample size ----> " + Max_Iterations1);
                file1.WriteLine(" ***  N    KCounter1     KCounter2  KCounter3     KCounter4  KCounter_All_RC_Violations1  Average_No_of_RC_Violations1     Ratio1 %  Ratio2 %");
                file1.WriteLine(" ***");
                file1.WriteLine(" ************************************************ ");



                Output_CDP_Analysis2b_File = @"MyProjectFiles1\OUTPUT CDP Analysis2b.TXT";
                System.IO.StreamWriter file2 = new System.IO.StreamWriter(Output_CDP_Analysis2b_File);

                file2.WriteLine(" ************************************************ ");
                file2.WriteLine(" *** This file was produced by Method <Explore_Rank_Conflicts_PC_Matrices1()> *** ");
                file2.WriteLine(" *** This file was originally created at the follwoing subdirectory: *** ");
                file2.WriteLine(" *** From the main folder with this application go to: < bib/Debug/net6.0-windows/MyProjectFiles1 > *** ");
                file2.WriteLine(" *** This is the file with the results regarding different types of ranking abnormalities");
                file2.WriteLine(" *** Fo rinstance, when the ranking sfrom th etwo Saaty matrices disagree ***");
                file2.WriteLine(" *** (in terms of the TOP or ANY alternative) i.e., 2 sub-cases *** ");
                file2.WriteLine(" *** or they agree but disagree with the REAL rankings (i.e., 2 more sub-cases) ***");
                file2.WriteLine(" *** Used for my PAPER #1 which was first submitted to EJOR  in the Summer of 2022 ");
                file2.WriteLine(" *** and then revised in the Fall of 2022 *** ");
                file2.WriteLine(" ************************************************ ");
                file2.WriteLine(" *** ");
                file2.WriteLine(" ***  Sample size ----> " + Max_Iterations1);
                file2.WriteLine(" ***  N   All-Ranking-Abnormalities     2_Saaty_Matrices_Disagree1   R-Abnorm_A-1  R-Abnorm_A-2        R-Abnorm_B-1  R-Abnorm_B-2 ");
                file2.WriteLine(" ***");
                file2.WriteLine(" ************************************************ ");


                // file2.WriteLine(" ************************************************ ");


                // *** Assign some numerical values to my key parameters now ***
                Nmax = 20;  // *** The max number of items to be compared by means of pairwise comparisons is equal to 30 ***
                            // *** In other words, this is the maximum size of the matrices!      ***                
                            // **********************************************************************
                Nmin = 2;


                K = 0;     // *** This is the counter of how many cases I had to search to find an appropriate matrix consistent with Saaty's scale!

                for (N = Nmin; N <= Nmax; N++)
                { // for <N-loop>


                    int KCounter1, KCounter2, KCounter3, KCounter4;

                    // ***  <KCounter1>  This counter keeps track of cases with    reciprocal violations AND      ranking problems  ***
                    // ***  <KCounter2>  This counter keeps track of cases with NO reciprocal violations AND with ranking problems  ***
                    // ***  <KCounter3>  This counter keeps track of cases with NO reciprocal violations AND NO   ranking problems  ***
                    // ***  <KCounter4>  This counter keeps track of cases with    reciprocal violations AND NO   ranking problems  ***

                    // *** Initialiazations ***
                    KCounter1 = 0;
                    KCounter2 = 0;
                    KCounter3 = 0;
                    KCounter4 = 0;
                    // -----------------------
                    KCounter_Rank_Abnorm_A1 = 0;
                    KCounter_Rank_Abnorm_A2 = 0;
                    KCounter_Rank_Abnorm_B1 = 0;
                    KCounter_Rank_Abnorm_B2 = 0;
                    KCounter_2_Saaty_Matrices_Disagree1 = 0;
                    // -----------------------

                    int Total_RC_Violations1;
                    double Average_No_of_RC_Violations1;
                    Total_RC_Violations1 = 0; // *** Initialization *** // 



                    for (Iterations1 = 1; Iterations1 <= Max_Iterations1; Iterations1++)
                    { // *** begin Iterations1-loop ****************** 

                    // *** Get N randmom values uniformly disributed in [0, 1] and load them in my array <Real_Values_of_the_Alternatives[] 

                    Label1: K = K + 1;
                        for (i = 1; i <= N; i++)
                        {  // begin for i-loop ***
                           // *** Recall that this is stated more above: double u1 = rand.NextDouble(); //these are uniform(0,1) random doubles
                            u1 = rand.NextDouble();
                            Real_Values_of_the_Alternatives[i] = u1;
                        }; // *** end for i-loop ***

                        // ***************************************************************************************************************************************
                        // *** Now we need to find out if the ratio <Ratio_Max> of the Max such value divided by the Min such value is less than or equal to 9 ***
                        // *** and the ratio <Ratio_Min> of the <1 / Ratio_MaxGet> is larger than or equal to 1/9                                              ***
                        // *** Thus, first find the <Min_Random_Value1> and <Max_Random_Value1> values!                                                        ***
                        // ***************************************************************************************************************************************

                        // *** Some initializations now *********************************************      
                        Min_Random_Value1 = 99.0; // *** An arbitrarily large value out of range ***
                        Max_Random_Value1 = -99.0; // *** An arbitrarily samll value out of range ***

                        for (i = 1; i <= N; i++)
                        {  // begin for i-loop ***
                            if (Real_Values_of_the_Alternatives[i] >= Max_Random_Value1)
                            { Max_Random_Value1 = Real_Values_of_the_Alternatives[i]; };

                            if (Real_Values_of_the_Alternatives[i] <= Min_Random_Value1)
                            { Min_Random_Value1 = Real_Values_of_the_Alternatives[i]; };
                        }; // *** end for i-loop ***
                        Max_Ratio1 = Max_Random_Value1 / Min_Random_Value1;
                        Min_Ratio1 = 1.0 / Max_Ratio1;

                        if ((Min_Ratio1 < 1 / 9.0) || (Max_Ratio1 > 9.0))
                        { goto Label1; };

                        // *** We build the RCP matrix now!  ****************
                        for (i = 1; i <= N; i++)
                        {  // begin for i-loop ***
                            for (j = 1; j <= N; j++)
                            {  // begin for j-loop ***
                                RCP_Matrix1[i, j] = Real_Values_of_the_Alternatives[i] / Real_Values_of_the_Alternatives[j];
                            }; // *** end for j-loop ***
                        }; // *** end for i-loop ***

                        // *** We build the CDP matrix now!  ****************
                        for (i = 1; i <= N; i++)
                        {  // begin for i-loop ***
                            for (j = 1; j <= N; j++)
                            {  // begin for j-loop ***

                                True_Value1 = RCP_Matrix1[i, j];

                                // *** Use that approximating function here!
                                Saaty_Value1 = pr.Approximate_Using_Saaty_Scale1(True_Value1);
                                CDP_Matrix1[i, j] = Saaty_Value1;
                            }; // *** end for j-loop ***
                        }; // *** end for i-loop ***

                        // edw1! 
                        // ****************************************************************************
                        // *** Check to see if the current CDP matrix has any reciprocal violations ***
                        object2.Scan_Pairwise_Matrix_for_Reciprocity_Violations1(CDP_Matrix1, N, out No_of_Violations1);

                        object6.Derive_The_Relative_Priorities_from_PC_Matrix1(RCP_Matrix1, N, out Priority_Vector0);
                        object7.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector0, N, out Ranking_R0);

                        object6.Derive_The_Relative_Priorities_from_PC_Matrix1(CDP_Matrix1, N, out Priority_Vector1);
                        object7.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector1, N, out Ranking_R1);

                        object8.Compare_Two_Rankings1(Ranking_R0, Ranking_R1, N, out KResult1);

                        object5.Derive_Two_CDP_Matrices_from_Single_CDP_Matrix1(CDP_Matrix1, N, out Reciprocal_CDP_Matrix1A, out Reciprocal_CDP_Matrix1B);

                        object6.Derive_The_Relative_Priorities_from_PC_Matrix1(Reciprocal_CDP_Matrix1A, N, out Priority_Vector1A);
                        object7.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector1A, N, out Ranking_R1A);

                        object6.Derive_The_Relative_Priorities_from_PC_Matrix1(Reciprocal_CDP_Matrix1B, N, out Priority_Vector1B);
                        object7.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector1B, N, out Ranking_R1B);


                        object8.Compare_Two_Rankings1(Ranking_R0, Ranking_R1A, N, out KResult1a);
                        object8.Compare_Two_Rankings1(Ranking_R0, Ranking_R1B, N, out KResult1b);

                        object8.Compare_Two_Rankings1(Ranking_R1A, Ranking_R1B, N, out KResult1ab);


                        object8.Compare_Two_Rankings1(Ranking_R1, Ranking_R1A, N, out KResult11a);
                        object8.Compare_Two_Rankings1(Ranking_R1, Ranking_R1B, N, out KResult11b);






                        int ii1, ia1;


                        // ***  <KCounter1>  This counter keeps track of cases with    reciprocal violations AND      ranking problems  ***
                        // ***  <KCounter2>  This counter keeps track of cases with NO reciprocal violations AND with ranking problems  ***
                        // ***  <KCounter3>  This counter keeps track of cases with NO reciprocal violations AND NO   ranking problems  ***
                        // ***  <KCounter4>  This counter keeps track of cases with    reciprocal violations AND NO   ranking problems  ***

                        if ((No_of_Violations1 > 0) && ((KResult1a != 0) || (KResult1b != 0) || (KResult1ab != 0)))
                        { KCounter1 = KCounter1 + 1; };

                        if ((No_of_Violations1 == 0) && ((KResult1a != 0) || (KResult1b != 0) || (KResult1ab != 0)))
                        { KCounter2 = KCounter2 + 1; };

                        if ((No_of_Violations1 == 0) && !((KResult1a != 0) || (KResult1b != 0) || (KResult1ab != 0)))
                        { KCounter3 = KCounter3 + 1; };

                        if ((No_of_Violations1 > 0) && !((KResult1a != 0) || (KResult1b != 0) || (KResult1ab != 0)))
                        { KCounter4 = KCounter4 + 1; };


                        Total_RC_Violations1 = Total_RC_Violations1 + No_of_Violations1;

                        // *********************************************************
                        // *** These are the results to record in <file2>  ***
                        // *************************************************************************************************************************************
                        if (KResult1ab == -9)
                        { KCounter_Rank_Abnorm_A1 = KCounter_Rank_Abnorm_A1 + 1; };  // *** The two Saaty matrices disagree on the TOP alternative *** 

                        if (KResult1ab == 1)
                        { KCounter_Rank_Abnorm_A2 = KCounter_Rank_Abnorm_A2 + 1; };  // *** The two Saaty matrices agree on the TOP alternative BUT they disagree on some other alts. *** 

                        if ((KResult1ab == 0) && (KResult1a == -9))
                        { KCounter_Rank_Abnorm_B1 = KCounter_Rank_Abnorm_B1 + 1; };  // *** The two Saaty matrices AGREE 100% with each other but they disagree with the REAL top alt *** 

                        if ((KResult1ab == 0) && (KResult1a == 1))
                        { KCounter_Rank_Abnorm_B2 = KCounter_Rank_Abnorm_B2 + 1; };  // *** The two Saaty matrices AGREE 100% with each other also they agree with the REAL top but disagree with other REAL alts. *** 

                        if (KResult1ab != 0)
                        { KCounter_2_Saaty_Matrices_Disagree1 = KCounter_2_Saaty_Matrices_Disagree1 + 1; }; // *** The two Saaty matrices DISAGREE somewhere (top or any alternative) *** 



                        //  Console.WriteLine(" +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                        //  Console.WriteLine("  Iteration No =  " + Iterations1 + "  KCounter1 =" + KCounter1 + " KCounter2 = " + KCounter2 + "         KCounter3 = " + KCounter3 + "   KCounter4 = " + KCounter4);
                        //  Console.WriteLine(" *************************************************************************************************************");


                        goto Label_jump1;


                        if ((KResult1a == -9) || (KResult1b == -9) || (KResult1ab == -9))
                        {

                            Console.WriteLine(" *************  We start a new Example here! ********************************* ");
                            Console.WriteLine("  ");

                            //Console.WriteLine(" N  KResult1 KResult1a KResult1b  KResult1ab KResult11a  KResult11b ==> " + N + "    " + KResult1 + "  " + KResult1a + "  " + KResult1b + "    " + KResult1ab + "  " + KResult11a + "  " + KResult11b);
                            Console.WriteLine(" N  (R0 & Matrix1)   (R0 & MatrixA)   (R0 & MatrixB)  (MatrixA & MatrixB)   (Matrix1 & MatrixA)   (Matrix1 & MatrixB) ==> " + N + "    " + KResult1 + "  " + KResult1a + "  " + KResult1b + "    " + KResult1ab + "  " + KResult11a + "  " + KResult11b);
                            Console.WriteLine("  Number of Reciprocity Violations = " + No_of_Violations1);
                            Console.WriteLine("  Some key RANKINGS ");
                            Console.WriteLine("  True R0     Matrix1     MatrixA       MatrixB     ");
                            Console.WriteLine(" *************************************************************************************************************");
                            // Console.WriteLine("  Iteration No =  " + Iterations1 + "  KCounter1 =" + KCounter1 + " KCounter2 = " + KCounter2 + "         KCounter3 = " + KCounter3 + "   KCounter4 = " + KCounter4);

                            for (ii1 = 1; ii1 <= N; ii1++)
                            {
                                Console.WriteLine("  " + Ranking_R0[ii1] + "             " + Ranking_R1[ii1] + "             " + Ranking_R1A[ii1] + "    " + Ranking_R1B[ii1]);
                            };

                            Console.WriteLine("___________________________________________");
                            Console.WriteLine();
                            Console.WriteLine();

                            double Sum1a;
                            Sum1a = 0.0; // *** initialization 

                            for (ia1 = 1; ia1 <= N; ia1++)
                            {
                                Sum1a = Sum1a + Real_Values_of_the_Alternatives[ia1];
                            };

                            // *** Normalize them now! 
                            for (ia1 = 1; ia1 <= N; ia1++)
                            {
                                Real_Values_of_the_Alternatives[ia1] = Real_Values_of_the_Alternatives[ia1] / Sum1a;
                            };


                            for (ia1 = 1; ia1 <= N; ia1++)
                            {
                                Console.WriteLine("  ia1 = " + ia1 + "  Real Value ---> " + Real_Values_of_the_Alternatives[ia1]);
                            };

                            // *** We dump some partial results for debugging purpose now ******************************** 
                            Console.WriteLine();
                            Console.WriteLine(" ___ The Original RCP Matrix is:___________________________________________ ");
                            Console.WriteLine();

                            pr.Print_Pairwise_Matrix1(RCP_Matrix1, N);

                            Console.WriteLine(" ________________________________________________ ");
                            Console.WriteLine();

                            Console.WriteLine();
                            Console.WriteLine(" ___ The Correspodning CDP Matrix is:___________________________________________ ");
                            Console.WriteLine();

                            pr.Print_Pairwise_Matrix1(CDP_Matrix1, N);

                            Console.WriteLine(" ________________________________________________ ");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine(" ___ CDP Matrix 1A is:___________________________________________ ");
                            Console.WriteLine();

                            pr.Print_Pairwise_Matrix1(Reciprocal_CDP_Matrix1A, N);

                            Console.WriteLine(" ________________________________________________ ");
                            Console.WriteLine();

                            Console.WriteLine();
                            Console.WriteLine(" ___ CDP Matrix 1B is:___________________________________________ ");
                            Console.WriteLine();

                            pr.Print_Pairwise_Matrix1(Reciprocal_CDP_Matrix1B, N);

                            Console.WriteLine(" ________________________________________________ ");
                            Console.WriteLine();

                            for (ia1 = 1; ia1 <= N; ia1++)
                            {
                                Console.WriteLine(" ia1 ---> " + ia1 + "  Val0 = " + Priority_Vector0[ia1] + "  Rank0 = " + Ranking_R0[ia1] + "    Val1 = " + Priority_Vector1[ia1] + " Rank1 = " + Ranking_R1[ia1] + "  KResult1 --> " + KResult1);

                            }

                            Console.WriteLine(" ********************************************** ");
                            Console.WriteLine(" ************* This is the end of the current Example ********************************* ");
                            Console.WriteLine();
                            Console.WriteLine();


                        };

                        if (KResult1 != -9)
                        {
                            goto Label_jump1;
                        };


                        // *** We dump some partial results for debugging purpose now ******************************** 
                        Console.WriteLine();
                        Console.WriteLine(" ___ The Original RCP Matrix is:___________________________________________ ");
                        Console.WriteLine();

                        pr.Print_Pairwise_Matrix1(RCP_Matrix1, N);

                        Console.WriteLine(" ________________________________________________ ");
                        Console.WriteLine();

                        Console.WriteLine();
                        Console.WriteLine(" ___ The Correspodning CDP Matrix is:___________________________________________ ");
                        Console.WriteLine();

                        pr.Print_Pairwise_Matrix1(CDP_Matrix1, N);

                        Console.WriteLine(" ________________________________________________ ");
                        Console.WriteLine();

                        int i1;
                        for (i1 = 1; i1 <= N; i1++)
                        {
                            Console.WriteLine(" i1 ---> " + i1 + "  Val0 = " + Priority_Vector0[i1] + "  Rank0 = " + Ranking_R0[i1] + "    Val1 = " + Priority_Vector1[i1] + " Rank1 = " + Ranking_R1[i1] + "  KResult1 --> " + KResult1);

                        }

                        Console.WriteLine(" *************____________________********************************* ");
                        Console.WriteLine();
                        Console.WriteLine();









                        goto Label_jump1;

                        if (No_of_Violations1 > 0)
                        {   // *** This CDP matrix has some reciprocity violations.  At least one of them! *** 
                            // *** Therefore, the following two matrices are DIFFERENT of each other!      ***
                            // *** If we have no such conflicts, these two matrices will be IDENTICAL!     ***
                            // *******************************************************************************
                            object5.Derive_Two_CDP_Matrices_from_Single_CDP_Matrix1(CDP_Matrix1, N, out Reciprocal_CDP_Matrix1A, out Reciprocal_CDP_Matrix1B);

                            Console.WriteLine();
                            Console.WriteLine(" ___ The Original CDP Matrix is:___________________________________________ ");
                            Console.WriteLine();

                            pr.Print_Pairwise_Matrix1(CDP_Matrix1, N);

                            Console.WriteLine(" ________________________________________________ ");
                            Console.WriteLine();

                            Console.WriteLine(" ___  Matrix1 is: ____________");

                            pr.Print_Pairwise_Matrix1(Reciprocal_CDP_Matrix1A, N);

                            Console.WriteLine();
                            Console.WriteLine(" ___  Matrix2 is: ____________");

                            pr.Print_Pairwise_Matrix1(Reciprocal_CDP_Matrix1B, N);

                            Console.WriteLine(" ****************************************************");

                        }
                        else
                        {
                            // *** We have no reciprocity conflicts ***



                        };






                    Label_jump1: i = -9; // a dummy statement to jump over some not needed code now ***



                    }; // *** end Iterations1-loop ****



                    double Ratio1, Ratio2;
                    Ratio1 = (KCounter1 * 100.00) / (KCounter1 + KCounter4);
                    Ratio2 = (KCounter2 * 100.00) / (KCounter2 + KCounter3);

                    int KCounter_All_RC_Violations1, KCounter_All_Ranking_Abnormalities1;
                    KCounter_All_RC_Violations1 = KCounter1 + KCounter4;
                    Average_No_of_RC_Violations1 = (Total_RC_Violations1 * 1.00) / Max_Iterations1;
                    KCounter_All_Ranking_Abnormalities1 = KCounter1 + KCounter2;

                    // Console.WriteLine(" +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                    Console.WriteLine("  N --> " + N + "  KCntr1 =" + KCounter1 + " KCntr2 = " + KCounter2 + "         KCntr3 = " + KCounter3 + "   KCntr4 = " + KCounter4 + " All RC Viols =" + KCounter_All_RC_Violations1 + " Aver RC Viols = " + Average_No_of_RC_Violations1 + "  R1 = " + Ratio1 + " %    R2 = " + Ratio2 + " % ");
                    file1.WriteLine("  " + N + "  " + KCounter1 + "  " + KCounter2 + "          " + KCounter3 + "   " + KCounter4 + "   " + KCounter_All_RC_Violations1 + "   " + Average_No_of_RC_Violations1 + "       " + Ratio1 + "  " + Ratio2);
                    // Console.WriteLine(" *************************************************************************************************************");
                    file2.WriteLine("  " + N + "  " + KCounter_All_Ranking_Abnormalities1 + "         " + KCounter_2_Saaty_Matrices_Disagree1 + "  " + KCounter_Rank_Abnorm_A1 + "  " + KCounter_Rank_Abnorm_A2 + "        " + KCounter_Rank_Abnorm_B1 + "  " + KCounter_Rank_Abnorm_B2);




                };  // *** end for <N-loop> 



                file1.WriteLine(" ***************  The End ****************************** ");
                file1.Close();



                file2.WriteLine(" *********  THE END ****************************** ");
                file2.Close();


                // file1.Close();

                // ****************************************************
                // *** Some notes for me.  Develop the following methods / procedures / subroutines:
                // (1)    Given is a PC matrix and its size.  Extract the relative priorities by approximating the eigenvector.
                // -----> Item (1) has all code written.  VAN:  Verify it!!!   

                // (2)    Given a vector with relative priorities and its size, extract the rankings of the items.
                // -----> Item (2) has all code written.  VAN:  Verify it!!!   



                // (3)    Given two vectors (integer values) with priorities and their common size, determine conflicts:
                //                            (a) In terms of the top alternative
                //                            (b) In terms of any alternative
                //                            (c) Determine whether the conflict is that items collapse and have same rank but no conflict.

                // (4)     Determine whether combining the two CDP matrices gives us any advantages.  

                // (5)     Determine whether processing the original CDP matrix, even when it exhibits reprocity conflicts, is better than 
                //         trying to first "fix" the reciprocity conflicts.

                // (6)     Ultimately, answer the questions:  (i) How bad is this reciprocity problem?  (ii) What can w edo to aleviate this 
                //         problem?
                //
                //




            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************



        // *********************************************************************************************************************
        class Explore_Saaty_Case_Study_for_Rank_Conflicts_Type2_PC_Matrices1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 

            public void Explore_Saaty_Case_Study_for_Rank_Conflicts_Type2_PC_Matrices1()
            { // *** Begin Method *** 

                // **************************************
                // *** Variable declarations section. ***
                // **************************************
                string Output_CDP_Analysis2_File;
                string Output_CDP_Example3_File;
                int i, j, N, Nmax, Nmin, K, KResult1, KResult1a, KResult1b, KResult1ab, KResult11a, KResult11b;
                int KResult01, KResult02, KResult12;
                Double u1, Min_Random_Value1, Max_Random_Value1, Max_Ratio1, Min_Ratio1;

                int[] Ranking_R0 = new int[30];
                int[] Ranking_R1 = new int[30];
                int[] Ranking_R2 = new int[30];
                int[] Ranking_R1A = new int[30];
                int[] Ranking_R1B = new int[30];


                double[] Priority_Vector0 = new double[30];
                double[] Priority_Vector1 = new double[30];
                double[] Priority_Vector2 = new double[30];
                double[] Priority_Vector1A = new double[30];
                double[] Priority_Vector1B = new double[30];

                double[] Real_Values_of_the_Alternatives = new double[30];
                double[] Bad_Real_Values_of_the_Alternatives = new double[30];
                double[,] RCP_Matrix1 = new double[30, 30];
                double[,] CDP_Matrix1 = new double[30, 30];
                double[,] CDP_Matrix2 = new double[30, 30];
                double[,] Bad_RCP_Matrix1 = new double[30, 30];
                double[,] Bad_CDP_Matrix1 = new double[30, 30];
                double[,] Reciprocal_CDP_Matrix1A = new double[30, 30];
                double[,] Reciprocal_CDP_Matrix1B = new double[30, 30];

                double True_Value1, Saaty_Value1, Ratio_Defective_Matrices1;
                double Ratio1, Sum_Ratio1, Average_Ratio1, Average_Ratio2, Average_Ratio3, Average_Ratio4, Percentage4;
                int Iterations1, Max_Iterations1, No_of_Violations1;
                int Iterations2, Max_Iterations2;

                int KCounter1, KCounter2, KCounter3, KCounter4, IndexK4;
                int ii1, ia1;



                // *** end of the Variable declaration section. ****** 

                Random rand = new Random();    //reuse this if you are generating many random doubles (real) numbers uniform in (0,1) ***


                // ************************************ 
                // *** Object declarations section. ***
                // ************************************
                Scan_Values_in_Saaty_Interval_for_reciprocal_Problem1_Demo object1 = new Scan_Values_in_Saaty_Interval_for_reciprocal_Problem1_Demo();
                Scan_Pairwise_Matrix_for_Reciprocity_Violations1_Demo object2 = new Scan_Pairwise_Matrix_for_Reciprocity_Violations1_Demo();
                Copy_PC_Matrix1_Demo object3 = new Copy_PC_Matrix1_Demo();
                Copy_Vector1_Demo object4 = new Copy_Vector1_Demo();
                Derive_Two_CDP_Matrices_from_Single_CDP_Matrix1_Demo object5 = new Derive_Two_CDP_Matrices_from_Single_CDP_Matrix1_Demo();
                Derive_The_Relative_Priorities_from_PC_Matrix1_Demo object6 = new Derive_The_Relative_Priorities_from_PC_Matrix1_Demo();
                Derive_The_Rankings_from_Priority_Vector1_Demo object7 = new Derive_The_Rankings_from_Priority_Vector1_Demo();
                Compare_Two_Rankings1_Demo object8 = new Compare_Two_Rankings1_Demo();
                Case_Study5_Demo object9 = new Case_Study5_Demo();
                Compare_Two_Priority_Vectors1_Demo object10 = new Compare_Two_Priority_Vectors1_Demo(); 
                // *** end of the Object declaration section. ********




                MainProgram pr1 = new MainProgram();  // *** Creating a class Object ***
                MainProgram pr = new MainProgram();  // *** Creating a class Object ***

                // ***  Console.WriteLine(" \n We just started!   Hit CR once to move on...");
                // ***  Console.ReadLine();
                // *************************************************************

                // ********************************************************************************************
                // *** The Output file can be found as follows:                                             ***
                // *** From th emain folder with this application go to: bib/Debug/net6.0-windows/MyProjectFiles1   *** 
                // *** You will find it there!                                                              ***
                // ********************************************************************************************
                Output_CDP_Analysis2_File = @"MyProjectFiles1\OUTPUT CDPMatrix SaatyCaseStudy1.TXT";
                System.IO.StreamWriter file1 = new System.IO.StreamWriter(Output_CDP_Analysis2_File);

                file1.WriteLine(" ************************************************ ");

                Output_CDP_Example3_File = @"MyProjectFiles1\OUTPUT CDP Example3.TXT";
                System.IO.StreamWriter file2 = new System.IO.StreamWriter(Output_CDP_Example3_File);

                file2.WriteLine(" ************************************************ ");




                // *** Assign some numerical values to my key parameters now ***
                Nmax = 20;  // *** The max number of items to be compared by means of pairwis ecomparisons is equal to 30 ***
                            // *** In other words, this is the maximum size of the matrices!      ***                
                            // **********************************************************************
                Nmin = 2;

                Max_Iterations1 = 1;
                Max_Iterations2 = 10;

                Console.WriteLine(" *************************************************** ");
                K = 0;     // *** This is the counter of how many cases I had to search to find an appropriate matrix consistent with Saaty's scale!

                //for (N = Nmin; N <= Nmax; N++)
                //{ // for <N-loop>


                object9.Case_Study5(out Real_Values_of_the_Alternatives, out N);

                // ***  <KCounter1>  This counter keeps track of cases with    reciprocal violations AND      ranking problems  ***
                // ***  <KCounter2>  This counter keeps track of cases with NO reciprocal violations AND with ranking problems  ***
                // ***  <KCounter3>  This counter keeps track of cases with NO reciprocal violations AND NO   ranking problems  ***
                // ***  <KCounter4>  This counter keeps track of cases with    reciprocal violations AND NO   ranking problems  ***


                Sum_Ratio1 = 0.0; // *** Initialization

                // for (Iterations1 = 1; Iterations1 <= Max_Iterations1; Iterations1++)
                { // *** begin Iterations1-loop ****************** 

                    // *** Initialiazations ***
                    KCounter1 = 0;
                    KCounter2 = 0;
                    KCounter3 = 0;
                    KCounter4 = 0;

                    // KResult1 = 0; 
                    IndexK4 = 0;


                    // *** Get N randmom values uniformly disributed in [0, 1] and load them in my array <Real_Values_of_the_Alternatives[] 


                    // *** We build the RCP matrix now!  ****************
                    for (i = 1; i <= N; i++)
                    {  // begin for i-loop ***
                        for (j = 1; j <= N; j++)
                        {  // begin for j-loop ***
                            RCP_Matrix1[i, j] = Real_Values_of_the_Alternatives[i] / Real_Values_of_the_Alternatives[j];
                        }; // *** end for j-loop ***
                    }; // *** end for i-loop ***

                    // *** We build the initial CDP matrix now!  ****************
                    for (i = 1; i <= N; i++)
                    {  // begin for i-loop ***
                        for (j = 1; j <= N; j++)
                        {  // begin for j-loop ***
                            True_Value1 = RCP_Matrix1[i, j];
                            // *** Use that approximating function here!
                            Saaty_Value1 = pr.Approximate_Using_Saaty_Scale1(True_Value1);
                            CDP_Matrix1[i, j] = Saaty_Value1;
                        }; // *** end for j-loop ***
                    }; // *** end for i-loop ***


                    Console.WriteLine(" *************  We start a Saaty Case Study here! ********************************* ");
                    Console.WriteLine("  ");
                    double Sum1a;
                    Sum1a = 0.0; // *** initialization 

                    for (ia1 = 1; ia1 <= N; ia1++)
                    {
                        Sum1a = Sum1a + Real_Values_of_the_Alternatives[ia1];
                    };

                    // *** Normalize them now! 
                    for (ia1 = 1; ia1 <= N; ia1++)
                    {
                        Real_Values_of_the_Alternatives[ia1] = Real_Values_of_the_Alternatives[ia1] / Sum1a;
                    };

                    Console.WriteLine();
                    Console.WriteLine("  The original data for this Saaty case Study are as follows: ");
                    Console.WriteLine();
                    for (ia1 = 1; ia1 <= N; ia1++)
                    {
                        Console.WriteLine("  ia1 = " + ia1 + "  Real Value ---> " + Real_Values_of_the_Alternatives[ia1]);
                    };


                    Console.WriteLine();
                    Console.WriteLine(" ___ The Original RCP Matrix1 is:___________________________________________ ");
                    Console.WriteLine();

                    pr.Print_Pairwise_Matrix1(RCP_Matrix1, N);

                    Console.WriteLine(" ________________________________________________ ");
       
                    Console.WriteLine();
                    Console.WriteLine(" ___ The Original CDP Matrix1 is:___________________________________________ ");
                    Console.WriteLine();

                    pr.Print_Pairwise_Matrix1(CDP_Matrix1, N);

                    Console.WriteLine(" ________________________________________________ ");
                    Console.WriteLine();


                    object6.Derive_The_Relative_Priorities_from_PC_Matrix1(RCP_Matrix1, N, out Priority_Vector0);
                    object7.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector0, N, out Ranking_R0);

                    object6.Derive_The_Relative_Priorities_from_PC_Matrix1(CDP_Matrix1, N, out Priority_Vector1);
                    object7.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector1, N, out Ranking_R1);
                    
                    Console.WriteLine();
                    Console.WriteLine(" The ORIGINAL priority vector and corresponding ranking are as follows: ");
                    for (i = 1; i <= N; i++)
                    {
                        Console.WriteLine("  i = " + i + " Vect0[i] = " + Priority_Vector0[i] + "    Rank0[i] = " + Ranking_R0[i] );
                    };

                    // *** We build the second CDP matrix <CDP_Matrix2> now!  ****************
                    for (i = 1; i <= N; i++)
                    {  // begin for i-loop ***
                        for (j = 1; j <= N; j++)
                        {  // begin for j-loop ***

                            True_Value1 = Priority_Vector1[i] / Priority_Vector1[j];

                            // *** Use that approximating function here!
                            Saaty_Value1 = pr.Approximate_Using_Saaty_Scale1(True_Value1);
                            CDP_Matrix2[i, j] = Saaty_Value1;
                        }; // *** end for j-loop ***
                    }; // *** end for i-loop ***
                    

                    object6.Derive_The_Relative_Priorities_from_PC_Matrix1(CDP_Matrix2, N, out Priority_Vector2);
                    object7.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector2, N, out Ranking_R2);

                    object8.Compare_Two_Rankings1(Ranking_R1, Ranking_R2, N, out KResult12);

                    // *** We compare the two priority vectors now.  This is the very first time we do that.  After that, we will do it whitin the WHILE loop ***
                    object10.Compare_Two_Priority_Vectors1(Priority_Vector1, Priority_Vector2, N, out KResult1);





                    // ********************************************************************************************************
                    // ***  We have the initial data to start the iterative process to check how the results converge etc.  ***
                    // ********************************************************************************************************
                    Iterations2 = 1; // *** We already had one iteration!  Thus, initialization = 1 ***

                    Console.WriteLine();

                    Console.WriteLine(" ============================================================================================ ");
                    Console.WriteLine("  Iteration number -----------> " + Iterations2);
                    Console.WriteLine();
                    Console.WriteLine(" ___ The CDP Matrix1 is:___________________________________________ ");
                    Console.WriteLine();

                    pr.Print_Pairwise_Matrix1(CDP_Matrix1, N);

                    Console.WriteLine(" ________________________________________________ ");

                    Console.WriteLine();
                    Console.WriteLine(" ___ This is CDP Matrix2 ___________________________________________ ");
                    Console.WriteLine();

                    pr.Print_Pairwise_Matrix1(CDP_Matrix2, N);

                    Console.WriteLine(" ________________________________________________ ");
                    Console.WriteLine();

                    Console.WriteLine(" The 2 priority vectors and corresponding 2 ranking vectors are as follows: ");
                    for (i = 1; i <= N; i++)
                    {
                        Console.WriteLine("  i = " + i + " Vect1[i] = " + Priority_Vector1[i] + " Vect2[i] = " + Priority_Vector2[i] + "    Rank1[i] = " + Ranking_R1[i] + "  Rank2[i] = " + Ranking_R2[i]);
                    };
                    Console.WriteLine("   KResult12 = " + KResult12);
                    Console.WriteLine("  End of this iteration ********************** ");
                   // Console.WriteLine(" ============================================= ");
                    Console.WriteLine(" ============================================================================================ ");
                    Console.WriteLine();




                    // **********************************************************************************************************
                    // ***  We have the initial data to start a new iterative process to check how the results converge etc.  ***
                    // **********************************************************************************************************


                    while (KResult1 == 1 )
                    //for (Iterations2 = 1; Iterations2 <= Max_Iterations2; Iterations2++)
                    {

                        Iterations2 = Iterations2 + 1;

                        // ************************************************
                        // *** We copy CDP_Matrix2 into new CDP_Matrix1 ***
                        // ************************************************
                        for (i = 1; i <= N; i++)
                        {  // begin for i-loop ***
                            for (j = 1; j <= N; j++)
                            {  // begin for j-loop ***
                                CDP_Matrix1[i, j] = CDP_Matrix2[i, j];
                            }; // *** end for j-loop ***
                        }; // *** end for i-loop ***

                        object6.Derive_The_Relative_Priorities_from_PC_Matrix1(CDP_Matrix1, N, out Priority_Vector1);
                        object7.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector1, N, out Ranking_R1);

                        // *** We build the new CDP matrix <CDP_Matrix2> now!  ****************
                        for (i = 1; i <= N; i++)
                        {  // begin for i-loop ***
                            for (j = 1; j <= N; j++)
                            {  // begin for j-loop ***

                                True_Value1 = Priority_Vector1[i] / Priority_Vector1[j];

                                // *** Use that approximating function here!
                                Saaty_Value1 = pr.Approximate_Using_Saaty_Scale1(True_Value1);
                                CDP_Matrix2[i, j] = Saaty_Value1;
                            }; // *** end for j-loop ***
                        }; // *** end for i-loop ***

                        object6.Derive_The_Relative_Priorities_from_PC_Matrix1(CDP_Matrix2, N, out Priority_Vector2);
                        object7.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector2, N, out Ranking_R2);


                        // *** We compare the two priority vectors now.  Now this is whitin the WHILE loop ***
                        object10.Compare_Two_Priority_Vectors1(Priority_Vector1, Priority_Vector2, N, out KResult1);


                        // **************************************************************************************************************
                        // ***    if <KREsult1> =  0; --> no conflict!   They agree 100% on all rankings!                             *** 
                        // ***    if <KResult1> =  1; --> They agree on the top alt., but they DO NOT agree 100% on all rankings.     ***
                        // ***    if <KResult1> = -9; --> ( MINUS 9) They do not agree on the top alternative!                        ***
                        // **************************************************************************************************************
                        //...object8.Compare_Two_Rankings1(Ranking_R0, Ranking_R1, N, out KResult01);
                        //...object8.Compare_Two_Rankings1(Ranking_R0, Ranking_R2, N, out KResult02);
                        object8.Compare_Two_Rankings1(Ranking_R1, Ranking_R2, N, out KResult12);



                        Console.WriteLine();

                        Console.WriteLine(" ============================================================================================ ");
                        Console.WriteLine("  Iteration number -----------> " + Iterations2 );
                        
                        Console.WriteLine();
                        Console.WriteLine(" ___ The CDP Matrix1 is:___________________________________________ ");
                        Console.WriteLine();

                        pr.Print_Pairwise_Matrix1(CDP_Matrix1, N);

                        Console.WriteLine(" ________________________________________________ ");

                        Console.WriteLine();
                        Console.WriteLine(" ___ This is CDP Matrix2 ___________________________________________ ");
                        Console.WriteLine();

                        pr.Print_Pairwise_Matrix1(CDP_Matrix2, N);

                        Console.WriteLine(" ________________________________________________ ");
                        Console.WriteLine();

                        Console.WriteLine(" The 2 priority vectors and corresponding 2 ranking vectors are as follows: ");
                        for (i = 1; i <= N; i++)
                        {
                            Console.WriteLine("  i = " + i + " Vect1[i] = " + Priority_Vector1[i] + " Vect2[i] = " + Priority_Vector2[i] + "    Rank1[i] = " + Ranking_R1[i] + "  Rank2[i] = " + Ranking_R2[i]);
                        };
                        Console.WriteLine("   KResult12 = " + KResult12);
                        Console.WriteLine("  End of this iteration ********************** ");
                        Console.WriteLine(" ============================================================================================ ");
                        Console.WriteLine();





                        // ***************************************************************************************
                        // *** Print out the current results now.  Good for debugging!                         ***
                        // ***************************************************************************************
                        //Console.WriteLine("  ");
                        //Console.WriteLine("  ");
                        // Console.WriteLine("     N --> " + N + "   Iteration1 = " + Iterations1 + "   Iterations2 --> " + Iterations2 + "  KResult12 = " + KResult12);
                        //... Console.WriteLine("     KResult R0_R1 = " + KResult01 + "  KResult R0_R2 = " + KResult02 + "     KResult R1_R2 = " + KResult12);
                        //... file1.WriteLine("     N --> " + N + "   Iteration1 = " + Iterations1 );
                        //... file1.WriteLine("     KResult R0_R1 = " + KResult01 + "  KResult R0_R2 = " + KResult02 + "     KResult R1_R2 = " + KResult12);
                        // if (KResult01 == -9)
                        {
                            //   Console.WriteLine(" KResult01 ==========================================================>  " + KResult01);
                            //   file2.WriteLine(" KResult01 ==========================================================>  " + KResult01);
                        };

                        for (i = 1; i <= N; i++)
                        {  // begin for i-loop ***
                           //... Console.WriteLine("  i --> " + i + " Rank R0 = " + Ranking_R0[i] + "       Rank R1 = " + Ranking_R1[i] + " Rank R2 = " + Ranking_R2[i]);
                        }; // *** end for i-loop ***


                        // *** Use the current <Priority_Vector2> to build the next <CDP_Matrix1> matrix and start over ***
                        for (i = 1; i <= N; i++)
                        {  // begin for i-loop ***
                            for (j = 1; j <= N; j++)
                            {  // begin for j-loop ***

                                True_Value1 = Priority_Vector2[i] / Priority_Vector2[j];

                                // *** Use that approximating function here!
                                Saaty_Value1 = pr.Approximate_Using_Saaty_Scale1(True_Value1);
                                CDP_Matrix1[i, j] = Saaty_Value1;
                            }; // *** end for j-loop ***
                        }; // *** end for i-loop ***

                        // KCounter1 = KCounter1 + KResult01;
                        //... KCounter2 = KCounter2 + KResult02;

                        if (KResult12 != 0)
                        {
                            KCounter3 = KCounter3 + 1;
                            IndexK4 = 1;
                        };

                    }; // *** end <while-loop> *** 


                    object8.Compare_Two_Rankings1(Ranking_R0, Ranking_R2, N, out KResult02);
                    Console.WriteLine("   KResult02 ====> " + KResult02);
                    if (KResult02 != 0)
                    {
                        KCounter2 = KCounter2 + 1;
                    };



                    //Console.WriteLine("  N = " + N + " Iterations1 = " + Iterations1 + "    KResult02 -----> " + KResult02);


                    KCounter1 = KCounter1 + Iterations2;

                    //Console.WriteLine("  N --> " + N + "     KCounter1 = " + KCounter1 + "  KCounter2 = " + KCounter2 + "  KCounter3 = " + KCounter3);
                    Ratio1 = ((KCounter3 * 1.00) / (1.0));

                    KCounter4 = KCounter4 + IndexK4;

                    //if (KCounter3 > 0)
                    //{
                    //    KCounter4 = KCounter4 + 1;
                    // };

                    //Console.WriteLine();
                    //Console.WriteLine("  Out of the WHILE loop! ................");
                    // Console.WriteLine("  N --> " + N + "     KCounter1 = " + KCounter1 + "  KCounter2 = " + KCounter2 + "  KCounter3 = " + KCounter3 + "  KCounter4 = " + KCounter4);
                    // file2.WriteLine("  N --> " + N + "     KCounter1 = " + KCounter1 + "  KCounter2 = " + KCounter2 + "  KCounter3 = " + KCounter3 + "  KCounter4 = " + KCounter4);

                    Sum_Ratio1 = Sum_Ratio1 + Ratio1;

                    // Console.WriteLine("  Ratio1 = " + Ratio1);
                    // Console.WriteLine("  ");
                    // Console.WriteLine("  ");
                    // Console.WriteLine(" ********************************************************* ");

                }; // *** end <Iterations1-loop> ***********************************************************************************


                Console.WriteLine("  N = " + N + "    KCounter2 ==========> " + KCounter2);

                Average_Ratio1 = ((1.0 * KCounter1) / (1.0 * Max_Iterations1));  // *** This is the average number of iterations before convergence! ***
                Average_Ratio2 = ((1.0 * KCounter3) / (1.0 * Max_Iterations1));  // *** This is the average number of different rankings between two concequtive rankings! ***
                Average_Ratio3 = ((1.0 * KCounter4) / (1.0 * Max_Iterations1));
                Average_Ratio4 = ((1.0 * KCounter2) / (1.0 * Max_Iterations1));
                Percentage4 = 100.00 * Average_Ratio4;

                Console.WriteLine("  N ---> " + N + "  Average Ratio1 = " + Average_Ratio1 + "      Average Ratio2 =      " + Average_Ratio2 + "    KCounter4 ---> " + KCounter4);
                file2.WriteLine("    " + N + "   " + Average_Ratio1 + "   " + Average_Ratio2 + "   " + Average_Ratio3 + "      " + Percentage4);

                //  Console.WriteLine("    " + N + "       " + Average_Ratio1 + "      " + Average_Ratio2);

                // Console.WriteLine(" ********************************************************* ");

            //};  // *** end for <N-loop> 

            Console.WriteLine(" ********************************************************* ");

                file1.WriteLine(" *************  the end *********************************** ");
                file1.Close();





            } // *** End   Method ***
    }; // *** End Class ***
           // *********************************************************************************************************************





        // *********************************************************************************************************************
        class Explore_Rank_Conflicts_Type2_PC_Matrices1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 

            public void Explore_Rank_Conflicts_Type2_PC_Matrices1()
            { // *** Begin Method *** 

                // edw2 
                // This is the NEW version of this <method> 
                // *********************************************************************************** 
                // *** This method is used for the data regarding TEST 3 of our EJOR PAPER #1      ***
                // *** Submitted and revised in the summer / fall of 2022.                         ***
                // ***********************************************************************************

                // **************************************
                // *** Variable declarations section. ***
                // **************************************
                string Output_CDP_Analysis2_File;
                string Output_CDP_Study4_File;
                int i, j, N, Nmax, Nmin, K, KResult1, KResult1a, KResult1b, KResult1ab, KResult11a, KResult11b;
                int KResult01, KResult02, KResult12;
                Double u1, Min_Random_Value1, Max_Random_Value1, Max_Ratio1, Min_Ratio1;

                int[] Ranking_R0 = new int[30];
                int[] Ranking_R1 = new int[30];
                int[] Ranking_R2 = new int[30];
                int[] Ranking_R1A = new int[30];
                int[] Ranking_R1B = new int[30];


                double[] Priority_Vector0 = new double[30];
                double[] Priority_Vector1 = new double[30];
                double[] Priority_Vector2 = new double[30];
                double[] Priority_Vector1A = new double[30];
                double[] Priority_Vector1B = new double[30];

                double[] Real_Values_of_the_Alternatives = new double[30];
                double[] Bad_Real_Values_of_the_Alternatives = new double[30];
                double[,] RCP_Matrix1 = new double[30, 30];
                double[,] CDP_Matrix1 = new double[30, 30];
                double[,] CDP_Matrix2 = new double[30, 30];
                double[,] Bad_RCP_Matrix1 = new double[30, 30];
                double[,] Bad_CDP_Matrix1 = new double[30, 30];
                double[,] Reciprocal_CDP_Matrix1A = new double[30, 30];
                double[,] Reciprocal_CDP_Matrix1B = new double[30, 30];

                double True_Value1, Saaty_Value1, Ratio_Defective_Matrices1;
                double Ratio1, Sum_Ratio1, Average_Ratio1, Average_Ratio2, Average_Ratio3, Average_Ratio4, Percentage4;
                double Sum_Ranking_Differences1, Difference1, Average_Ranking_Difference1; 
                int Iterations1, Iterations2, Max_Iterations1, No_of_Violations1;
                //int KResult1;

                int KCounter1, KCounter2, KCounter3, KCounter4, IndexK4;




                // *** end of the Variable declaration section. ****** 

                Random rand = new Random();    //reuse this if you are generating many random doubles (real) numbers uniform in (0,1) ***


                // ************************************ 
                // *** Object declarations section. ***
                // ************************************
                Scan_Values_in_Saaty_Interval_for_reciprocal_Problem1_Demo object1 = new Scan_Values_in_Saaty_Interval_for_reciprocal_Problem1_Demo();
                Scan_Pairwise_Matrix_for_Reciprocity_Violations1_Demo object2 = new Scan_Pairwise_Matrix_for_Reciprocity_Violations1_Demo();
                Copy_PC_Matrix1_Demo object3 = new Copy_PC_Matrix1_Demo();
                Copy_Vector1_Demo object4 = new Copy_Vector1_Demo();
                Derive_Two_CDP_Matrices_from_Single_CDP_Matrix1_Demo object5 = new Derive_Two_CDP_Matrices_from_Single_CDP_Matrix1_Demo();
                Derive_The_Relative_Priorities_from_PC_Matrix1_Demo object6 = new Derive_The_Relative_Priorities_from_PC_Matrix1_Demo();
                Derive_The_Rankings_from_Priority_Vector1_Demo object7 = new Derive_The_Rankings_from_Priority_Vector1_Demo();
                Compare_Two_Rankings1_Demo object8 = new Compare_Two_Rankings1_Demo();
                Compare_Two_Priority_Vectors1_Demo object9 = new Compare_Two_Priority_Vectors1_Demo();
                Compute_Ranking_Difference1_Demo object10 = new Compute_Ranking_Difference1_Demo();

                // *** end of the Object declaration section. ********

                MainProgram pr1 = new MainProgram();  // *** Creating a class Object ***
                MainProgram pr = new MainProgram();  // *** Creating a class Object ***

                // ***  Console.WriteLine(" \n We just started!   Hit CR once to move on...");
                // ***  Console.ReadLine();
                // *************************************************************

                // ****************************************************************************************************
                // *** The Output files can be found as follows:                                                    ***
                // *** From th emain folder with this application go to: bib/Debug/net6.0-windows/MyProjectFiles1   *** 
                // *** You will find it there!                                                                      ***
                // ****************************************************************************************************
                Output_CDP_Analysis2_File = @"MyProjectFiles1\OUTPUT CDPMatrix Analysis3.TXT";
                System.IO.StreamWriter file1 = new System.IO.StreamWriter(Output_CDP_Analysis2_File);



                // Max_Iterations1 = 1000000;
                Max_Iterations1 = 1000000;

                file1.WriteLine(" ************************************************ ");

                Output_CDP_Study4_File = @"MyProjectFiles1\OUTPUT CDP Study TEST3 EJOR1.TXT";
                System.IO.StreamWriter file2 = new System.IO.StreamWriter(Output_CDP_Study4_File);

                file2.WriteLine(" *************************************************** ");
                file2.WriteLine(" *** This is the results for TEST3 for the EJOR1 *** ");
                file2.WriteLine(" *** This is for the EJOR PAPER 1 we submitted / *** ");
                file2.WriteLine(" *** revised in the summer / fall of 2022.       *** ");
                file2.WriteLine(" *************************************************** ");

                file2.WriteLine("  This is for the Study that examines how often we have Type2 ranking issues with CDP matrices ");

                file2.WriteLine("  Number of iterations per case = " + Max_Iterations1);
                file2.WriteLine();
                file2.WriteLine("  <Aver_Ratio1> = The average number of iterations of a sequence before convergence!");
                file2.WriteLine("  <Aver_Ratio2> = The average number of times two consecutive rankinsg were different within the same sequence CDP matrices before convergence. ");
                file2.WriteLine("  <Percentage4> = This is the percentage of times the final ranking was different than the original (= true / hidden) ranking.");
                file2.WriteLine("  <Aver_Ranking_Diff1> = The average ranking difference bween the hidden / tru eranking and the final one.");

                //  Average_Ratio1 = ((1.0 * KCounter1) / (1.0 * Max_Iterations1));  // *** This is the average number of iterations before convergence! ***            
                //  Average_Ratio2 = ((1.0 * KCounter3) / (1.0 * Max_Iterations1));  // *** This is the average number we had different rankings between two concequtive rankings in a sequence! i***
                //  Average_Ratio3 = ((1.0 * KCounter4) / (1.0 * Max_Iterations1));  // *** This is the average number of times a random case was detecte dto have a ranking disagreement   
                //  Average_Ratio4 = ((1.0 * KCounter2) / (1.0 * Max_Iterations1));  // *** This is the average number of cases the final ranking was different than the original one!
                //  Percentage4 = 100.00 * Average_Ratio4;  // *** This is the perecentage of times the final ranking was different than the original (= hidden / true) ranking! 
                //  Average_Ranking_Difference1 = Sum_Ranking_Differences1 / (1.0 * Max_Iterations1); 


                file2.WriteLine();
                file2.WriteLine("  N      Aver_Ratio1    Aver_Ratio2   Aver_Ratio3    Percentage_4    Aver_Ranking_Diff1 ");
                file2.WriteLine("  ");

                KCounter4 = 0; // Keep this here or a STUPID error may be created later on!  *****


                // *** Assign some numerical values to my key parameters now ***
                Nmax = 20; // *** The max number of items to be compared by means of pairwise comparisons is equal to 30 ***
                           // *** In other words, this is the maximum size of the matrices!      ***                
                           // **********************************************************************
                Nmin = 2;


                // Console.WriteLine(" *************************************************** ");
                K = 0;     // *** This is the counter of how many cases I had to search to find an appropriate matrix consistent with Saaty's scale!

                for (N = Nmin; N <= Nmax; N++)
                { // for <N-loop>

                    Sum_Ratio1 = 0.0; // *** Initializations ***
                    KCounter4 = 0;
                    IndexK4 = 0;
                    Sum_Ranking_Differences1 = 0.0; 

                    Difference1 = 0.0; // dummy statement ***
                    
                    // *** Initialiazations ***
                    KCounter1 = 0;
                    KCounter2 = 0;
                    KCounter3 = 0;


                    for (Iterations1 = 1; Iterations1 <= Max_Iterations1; Iterations1++)
                    { // *** begin Iterations1-loop ****************** 

                       

                    // *** Get N randmom values uniformly disributed in [0, 1] and load them in my array <Real_Values_of_the_Alternatives[] >

                    Label1: K = K + 1;
                        for (i = 1; i <= N; i++)
                        {   // begin for i-loop ***
                            // *** Recall that this is stated more above: double u1 = rand.NextDouble(); //these are uniform(0,1) random doubles
                            u1 = rand.NextDouble();
                            Real_Values_of_the_Alternatives[i] = u1;
                        }; // *** end for i-loop ***

                        // ***************************************************************************************************************************************
                        // *** Now we need to find out if the ratio <Ratio_Max> of the Max such value divided by the Min such value is less than or equal to 9 ***
                        // *** and the ratio <Ratio_Min> of the <1 / Ratio_Max> is larger than or equal to 1/9                                                 ***
                        // *** Thus, first find the <Min_Random_Value1> and <Max_Random_Value1> values!                                                        ***
                        // ***************************************************************************************************************************************

                        // *** Some initializations now *********************************************      
                        Min_Random_Value1 = 99.0; // *** An arbitrarily large value out of range ***
                        Max_Random_Value1 = -99.0; // *** An arbitrarily samll value out of range ***

                        for (i = 1; i <= N; i++)
                        {  // begin for i-loop ***
                            if (Real_Values_of_the_Alternatives[i] >= Max_Random_Value1)
                            { Max_Random_Value1 = Real_Values_of_the_Alternatives[i]; };

                            if (Real_Values_of_the_Alternatives[i] <= Min_Random_Value1)
                            { Min_Random_Value1 = Real_Values_of_the_Alternatives[i]; };
                        };  // *** end for i-loop ***

                        Max_Ratio1 = Max_Random_Value1 / Min_Random_Value1;
                        Min_Ratio1 = 1.0 / Max_Ratio1;

                        if ((Min_Ratio1 < 1 / 9.0) || (Max_Ratio1 > 9.0))
                        { goto Label1; };

                        // ********************************************************************************************************
                        // *** We build the initial RCP matrix now!  ***
                        // *********************************************
                        for (i = 1; i <= N; i++)
                        {  // begin for i-loop ***
                            for (j = 1; j <= N; j++)
                            {  // begin for j-loop ***
                                RCP_Matrix1[i, j] = Real_Values_of_the_Alternatives[i] / Real_Values_of_the_Alternatives[j];
                            }; // *** end for j-loop ***
                        }; // *** end for i-loop ***

                        // *********************************************************************************************************
                        // *** We build the initial CDP matrix now!  ***
                        // *********************************************
                        for (i = 1; i <= N; i++)
                        {  // begin for i-loop ***
                            for (j = 1; j <= N; j++)
                            {  // begin for j-loop ***
                                True_Value1 = RCP_Matrix1[i, j];
                                // *** Use that approximating function here!
                                Saaty_Value1 = pr.Approximate_Using_Saaty_Scale1(True_Value1);
                                CDP_Matrix1[i, j] = Saaty_Value1;
                            }; // *** end for j-loop ***
                        }; // *** end for i-loop ***
                           // *********************************************************************************************************
                           // *** My initial CDP matrix is ready now! ***
                           // *******************************************

                        object6.Derive_The_Relative_Priorities_from_PC_Matrix1(RCP_Matrix1, N, out Priority_Vector0);
                        object7.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector0, N, out Ranking_R0);

                        object6.Derive_The_Relative_Priorities_from_PC_Matrix1(CDP_Matrix1, N, out Priority_Vector1);
                        object7.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector1, N, out Ranking_R1);

                        // *** We build the second CDP matrix <CDP_Matrix2> now!  ****************
                        for (i = 1; i <= N; i++)
                        {  // begin for i-loop ***
                            for (j = 1; j <= N; j++)
                            {  // begin for j-loop ***

                                True_Value1 = Priority_Vector1[i] / Priority_Vector1[j];

                                // *** Use that approximating function here!
                                Saaty_Value1 = pr.Approximate_Using_Saaty_Scale1(True_Value1);
                                CDP_Matrix2[i, j] = Saaty_Value1;
                            }; // *** end for j-loop ***
                        }; // *** end for i-loop ***

                        object6.Derive_The_Relative_Priorities_from_PC_Matrix1(CDP_Matrix2, N, out Priority_Vector2);
                        object7.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector2, N, out Ranking_R2);

                        object8.Compare_Two_Rankings1(Ranking_R1, Ranking_R2, N, out KResult12);

                        // *** We compare the two priority vectors now.  This is the very first time we do that.  After that, we will do it whitin the WHILE loop ***
                        object9.Compare_Two_Priority_Vectors1(Priority_Vector1, Priority_Vector2, N, out KResult1);





                        // ********************************************************************************************************
                        // ***  We have the initial data to start the iterative process to check how the results converge etc.  ***
                        // ********************************************************************************************************
                        Iterations2 = 1; // *** We already had one iteration!  Thus, initialization = 1 ***

                        // Console.WriteLine("     N --> " + N + "   Iteration1 = " + Iterations1 + "   Iterations2 --> " + Iterations2 + "  KResult12 = " + KResult12);
                        
                        while ( KResult1 == 1) 
                        
                        { // *** begin while-loop ***

                            Iterations2 = Iterations2 + 1; 

                            //object6.Derive_The_Relative_Priorities_from_PC_Matrix1(CDP_Matrix1, N, out Priority_Vector1);
                            //object7.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector1, N, out Ranking_R1);

                            // ************************************************
                            // *** We copy CDP_Matrix2 into new CDP_Matrix1 ***
                            // ************************************************
                            for (i = 1; i <= N; i++)
                            {  // begin for i-loop ***
                                for (j = 1; j <= N; j++)
                                {  // begin for j-loop ***
                                    CDP_Matrix1[i, j] = CDP_Matrix2[i, j];
                                }; // *** end for j-loop ***
                            }; // *** end for i-loop ***

                            object6.Derive_The_Relative_Priorities_from_PC_Matrix1(CDP_Matrix1, N, out Priority_Vector1);
                            object7.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector1, N, out Ranking_R1);

                            // *** We build the new CDP matrix <CDP_Matrix2> now!  ****************
                            for (i = 1; i <= N; i++)
                            {  // begin for i-loop ***
                                for (j = 1; j <= N; j++)
                                {  // begin for j-loop ***

                                    True_Value1 = Priority_Vector1[i] / Priority_Vector1[j];

                                    // *** Use that approximating function here!
                                    Saaty_Value1 = pr.Approximate_Using_Saaty_Scale1(True_Value1);
                                    CDP_Matrix2[i, j] = Saaty_Value1;
                                }; // *** end for j-loop ***
                            }; // *** end for i-loop ***

                            object6.Derive_The_Relative_Priorities_from_PC_Matrix1(CDP_Matrix2, N, out Priority_Vector2);
                            object7.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector2, N, out Ranking_R2);


                            // *** We compare the two priority vectors now.  Now this is whitin the WHILE loop ***
                            object9.Compare_Two_Priority_Vectors1(Priority_Vector1, Priority_Vector2, N, out KResult1);


                            // **************************************************************************************************************
                            // ***    if <KREsult1> =  0; --> no conflict!   They agree 100% on all rankings!                             *** 
                            // ***    if <KResult1> =  1; --> They agree on the top alt., but they DO NOT agree 100% on all rankings.     ***
                            // ***    if <KResult1> = -9; --> ( MINUS 9) They do not agree on the top alternative!                        ***
                            // **************************************************************************************************************
                            //...object8.Compare_Two_Rankings1(Ranking_R0, Ranking_R1, N, out KResult01);
                            //...object8.Compare_Two_Rankings1(Ranking_R0, Ranking_R2, N, out KResult02);
                            object8.Compare_Two_Rankings1(Ranking_R1, Ranking_R2, N, out KResult12);

                            // ***************************************************************************************
                            // *** Print out the current results now.  Good for debugging!                         ***
                            // ***************************************************************************************
                            //Console.WriteLine("  ");
                            //Console.WriteLine("  ");
                            // Console.WriteLine("     N --> " + N + "   Iteration1 = " + Iterations1 + "   Iterations2 --> " + Iterations2 + "  KResult12 = " + KResult12);
                            //... Console.WriteLine("     KResult R0_R1 = " + KResult01 + "  KResult R0_R2 = " + KResult02 + "     KResult R1_R2 = " + KResult12);
                            //... file1.WriteLine("     N --> " + N + "   Iteration1 = " + Iterations1 );
                            //... file1.WriteLine("     KResult R0_R1 = " + KResult01 + "  KResult R0_R2 = " + KResult02 + "     KResult R1_R2 = " + KResult12);
                           // if (KResult01 == -9)
                            {
                             //   Console.WriteLine(" KResult01 ==========================================================>  " + KResult01);
                             //   file2.WriteLine(" KResult01 ==========================================================>  " + KResult01);
                            };

                            for (i = 1; i <= N; i++)
                            {  // begin for i-loop ***
                                //... Console.WriteLine("  i --> " + i + " Rank R0 = " + Ranking_R0[i] + "       Rank R1 = " + Ranking_R1[i] + " Rank R2 = " + Ranking_R2[i]);
                            }; // *** end for i-loop ***


                            // *** Use the current <Priority_Vector2> to build the next <CDP_Matrix1> matrix and start over ***
                            for (i = 1; i <= N; i++)
                            {  // begin for i-loop ***
                                for (j = 1; j <= N; j++)
                                {  // begin for j-loop ***

                                    True_Value1 = Priority_Vector2[i] / Priority_Vector2[j];

                                    // *** Use that approximating function here!
                                    Saaty_Value1 = pr.Approximate_Using_Saaty_Scale1(True_Value1);
                                    CDP_Matrix1[i, j] = Saaty_Value1;
                                }; // *** end for j-loop ***
                            }; // *** end for i-loop ***

                            // KCounter1 = KCounter1 + KResult01;
                            //... KCounter2 = KCounter2 + KResult02;

                            if (KResult12 != 0)
                            {
                                KCounter3 = KCounter3 + 1;
                                IndexK4 = 1;
                            };

                        }; // *** end <while-loop> *** 


                        object8.Compare_Two_Rankings1(Ranking_R0, Ranking_R2, N, out KResult02);

                        if (KResult02 != 0)
                        {
                            KCounter2 = KCounter2 + 1; // *** The final ranking is different than the original one! ***

                            //*** Compute the difference (= <Differnce1>) between the two rankings ***
                            object10.Compute_Ranking_Difference1(Ranking_R0, Ranking_R2, N, out Difference1);
                            Sum_Ranking_Differences1 = Sum_Ranking_Differences1 + Difference1; 
                        };



                        //Console.WriteLine("  N = " + N + " Iterations1 = " + Iterations1 + "    KResult02 -----> " + KResult02);


                        KCounter1 = KCounter1 + Iterations2;
                         
                        //Console.WriteLine("  N --> " + N + "     KCounter1 = " + KCounter1 + "  KCounter2 = " + KCounter2 + "  KCounter3 = " + KCounter3);
                        Ratio1 = ((KCounter3 * 1.00) / (1.0));

                        KCounter4 = KCounter4 + IndexK4; 
                        
                        //if (KCounter3 > 0)
                        //{
                        //    KCounter4 = KCounter4 + 1;
                        // };

                        //Console.WriteLine();
                        //Console.WriteLine("  Out of the WHILE loop! ................");
                        // Console.WriteLine("  N --> " + N + "     KCounter1 = " + KCounter1 + "  KCounter2 = " + KCounter2 + "  KCounter3 = " + KCounter3 + "  KCounter4 = " + KCounter4);
                        // file2.WriteLine("  N --> " + N + "     KCounter1 = " + KCounter1 + "  KCounter2 = " + KCounter2 + "  KCounter3 = " + KCounter3 + "  KCounter4 = " + KCounter4);

                        Sum_Ratio1 = Sum_Ratio1 + Ratio1;

                        // Console.WriteLine("  Ratio1 = " + Ratio1);
                        // Console.WriteLine("  ");
                        // Console.WriteLine("  ");
                        // Console.WriteLine(" ********************************************************* ");

                    }; // *** end <Iterations1-loop> ***********************************************************************************


                    Console.WriteLine("  N = " + N + "    KCounter2 ==========> " + KCounter2);

                    Average_Ratio1 = ((1.0 * KCounter1) / (1.0 * Max_Iterations1));  // *** This is the average number of iterations before convergence! ***
                    Average_Ratio2 = ((1.0 * KCounter3) / (1.0 * Max_Iterations1));  // *** This is the average number we had different rankings between two concequtive rankings in a sequence! i***
                    Average_Ratio3 = ((1.0 * KCounter4) / (1.0 * Max_Iterations1));  // *** This is the average number of times a random case was detecte dto have a ranking disagreement   
                    Average_Ratio4 = ((1.0 * KCounter2) / (1.0 * Max_Iterations1));  // *** This is the average number of cases the final ranking was different than the original one!
                    Percentage4 = 100.00 * Average_Ratio4;  // *** This is the perecentage of times the final ranking was different than the original (= hidden / true) ranking! 

                    Average_Ranking_Difference1 = Sum_Ranking_Differences1 / (1.0 * Max_Iterations1); 
                    
                    //Console.WriteLine("  N ---> " + N + "  Average Ratio1 = " + Average_Ratio1 + "      Average Ratio2 =      " + Average_Ratio2 + "    KCounter4 ---> " + KCounter4);
                    file2.WriteLine("    " + N + "   " + Average_Ratio1 + "   " + Average_Ratio2 + "   " + Average_Ratio3 + "     " + Percentage4 + "   " + Average_Ranking_Difference1); 

                    //  Console.WriteLine("    " + N + "       " + Average_Ratio1 + "      " + Average_Ratio2);

                    // Console.WriteLine(" ********************************************************* ");

                };  // *** end for <N-loop> 

                Console.WriteLine(" ********************************************************* ");

                file1.WriteLine(" *************  the end *********************************** ");
                file1.Close();


                file2.WriteLine("  ");
                file2.WriteLine(" *********  THE END ****************************** ");
                file2.Close();


                // file1.Close();




            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************





        // *********************************************************************************************************************
        class Explore_Rank_Conflicts_Type2_PC_Matrices0_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 

            public void Explore_Rank_Conflicts_Type2_PC_Matrices0()
            { // *** Begin Method *** 

                // edw02 
                // *** This is the old version of it!   
                // *********************************************************************************** 
                // *** This method is used for the data regarding TEST 3 of our EJOR PAPER #1      ***
                // *** Submitted and revised in the summer / fall of 2022.                         ***
                // ***********************************************************************************

                // **************************************
                // *** Variable declarations section. ***
                // **************************************
                string Output_CDP_Analysis2_File;
                string Output_CDP_Study4_File;
                int i, j, N, Nmax, Nmin, K, KResult1, KResult1a, KResult1b, KResult1ab, KResult11a, KResult11b;
                int KResult01, KResult02, KResult12;
                Double u1, Min_Random_Value1, Max_Random_Value1, Max_Ratio1, Min_Ratio1;

                int[] Ranking_R0 = new int[30];
                int[] Ranking_R1 = new int[30];
                int[] Ranking_R2 = new int[30];
                int[] Ranking_R1A = new int[30];
                int[] Ranking_R1B = new int[30];


                double[] Priority_Vector0 = new double[30];
                double[] Priority_Vector1 = new double[30];
                double[] Priority_Vector2 = new double[30];
                double[] Priority_Vector1A = new double[30];
                double[] Priority_Vector1B = new double[30];

                double[] Real_Values_of_the_Alternatives = new double[30];
                double[] Bad_Real_Values_of_the_Alternatives = new double[30];
                double[,] RCP_Matrix1 = new double[30, 30];
                double[,] CDP_Matrix1 = new double[30, 30];
                double[,] CDP_Matrix2 = new double[30, 30];
                double[,] Bad_RCP_Matrix1 = new double[30, 30];
                double[,] Bad_CDP_Matrix1 = new double[30, 30];
                double[,] Reciprocal_CDP_Matrix1A = new double[30, 30];
                double[,] Reciprocal_CDP_Matrix1B = new double[30, 30];

                double True_Value1, Saaty_Value1, Ratio_Defective_Matrices1;
                double Ratio1, Sum_Ratio1, Average_Ratio1, Average_Ratio2;
                int Iterations1, Max_Iterations1, No_of_Violations1;
                int Iterations2, Max_Iterations2;

                int KCounter1, KCounter2, KCounter3, KCounter4;




                // *** end of the Variable declaration section. ****** 

                Random rand = new Random();    //reuse this if you are generating many random doubles (real) numbers uniform in (0,1) ***


                // ************************************ 
                // *** Object declarations section. ***
                // ************************************
                Scan_Values_in_Saaty_Interval_for_reciprocal_Problem1_Demo object1 = new Scan_Values_in_Saaty_Interval_for_reciprocal_Problem1_Demo();
                Scan_Pairwise_Matrix_for_Reciprocity_Violations1_Demo object2 = new Scan_Pairwise_Matrix_for_Reciprocity_Violations1_Demo();
                Copy_PC_Matrix1_Demo object3 = new Copy_PC_Matrix1_Demo();
                Copy_Vector1_Demo object4 = new Copy_Vector1_Demo();
                Derive_Two_CDP_Matrices_from_Single_CDP_Matrix1_Demo object5 = new Derive_Two_CDP_Matrices_from_Single_CDP_Matrix1_Demo();
                Derive_The_Relative_Priorities_from_PC_Matrix1_Demo object6 = new Derive_The_Relative_Priorities_from_PC_Matrix1_Demo();
                Derive_The_Rankings_from_Priority_Vector1_Demo object7 = new Derive_The_Rankings_from_Priority_Vector1_Demo();
                Compare_Two_Rankings1_Demo object8 = new Compare_Two_Rankings1_Demo();


                // *** end of the Object declaration section. ********




                MainProgram pr1 = new MainProgram();  // *** Creating a class Object ***
                MainProgram pr = new MainProgram();  // *** Creating a class Object ***

                // ***  Console.WriteLine(" \n We just started!   Hit CR once to move on...");
                // ***  Console.ReadLine();
                // *************************************************************

                // ********************************************************************************************
                // *** The Output files can be found as follows:                                            ***
                // *** From th emain folder with this application go to: bib/Debug/net6.0-windows/MyProjectFiles1   *** 
                // *** You will find it there!                                                              ***
                // ********************************************************************************************
                Output_CDP_Analysis2_File = @"MyProjectFiles1\OUTPUT CDPMatrix Analysis3.TXT";
                System.IO.StreamWriter file1 = new System.IO.StreamWriter(Output_CDP_Analysis2_File);

                file1.WriteLine(" ************************************************ ");

                Output_CDP_Study4_File = @"MyProjectFiles1\OUTPUT CDP Study TEST3 EJOR1.TXT";
                System.IO.StreamWriter file2 = new System.IO.StreamWriter(Output_CDP_Study4_File);

                file2.WriteLine(" *************************************************** ");
                file2.WriteLine(" *** This is the results for TEST3 for the EJOR1 *** ");
                file2.WriteLine(" *** This is for the EJOR PAPER 1 we submitted / *** ");
                file2.WriteLine(" *** revised in the summer / fall of 2022.       *** ");
                file2.WriteLine(" *************************************************** ");

                file2.WriteLine("  This is for the Study that examines how often we have Type2 ranking issues with CDP matrices ");
                file2.WriteLine("  N      Average Ratio1         Average Ratio2  ");
                file2.WriteLine("  ");

                KCounter4 = 0; // Keep this here or a STUPID error may be created later on!  *****


                // *** Assign some numerical values to my key parameters now ***
                Nmax = 6;  // *** The max number of items to be compared by means of pairwise comparisons is equal to 30 ***
                           // *** In other words, this is the maximum size of the matrices!      ***                
                           // **********************************************************************
                Nmin = 2;

                Max_Iterations1 = 10;
                Max_Iterations2 = 20;

                Console.WriteLine(" *************************************************** ");
                K = 0;     // *** This is the counter of how many cases I had to search to find an appropriate matrix consistent with Saaty's scale!

                for (N = Nmin; N <= Nmax; N++)
                { // for <N-loop>

                    Sum_Ratio1 = 0.0; // *** Initializations ***
                    KCounter4 = 0;

                    for (Iterations1 = 1; Iterations1 <= Max_Iterations1; Iterations1++)
                    { // *** begin Iterations1-loop ****************** 

                        // *** Initialiazations ***
                        KCounter1 = 0;
                        KCounter2 = 0;
                        KCounter3 = 0;

                    // *** Get N randmom values uniformly disributed in [0, 1] and load them in my array <Real_Values_of_the_Alternatives[] >

                    Label1: K = K + 1;
                        for (i = 1; i <= N; i++)
                        {   // begin for i-loop ***
                            // *** Recall that this is stated more above: double u1 = rand.NextDouble(); //these are uniform(0,1) random doubles
                            u1 = rand.NextDouble();
                            Real_Values_of_the_Alternatives[i] = u1;
                        }; // *** end for i-loop ***

                        // ***************************************************************************************************************************************
                        // *** Now we need to find out if the ratio <Ratio_Max> of the Max such value divided by the Min such value is less than or equal to 9 ***
                        // *** and the ratio <Ratio_Min> of the <1 / Ratio_Max> is larger than or equal to 1/9                                                 ***
                        // *** Thus, first find the <Min_Random_Value1> and <Max_Random_Value1> values!                                                        ***
                        // ***************************************************************************************************************************************

                        // *** Some initializations now *********************************************      
                        Min_Random_Value1 = 99.0; // *** An arbitrarily large value out of range ***
                        Max_Random_Value1 = -99.0; // *** An arbitrarily samll value out of range ***

                        for (i = 1; i <= N; i++)
                        {  // begin for i-loop ***
                            if (Real_Values_of_the_Alternatives[i] >= Max_Random_Value1)
                            { Max_Random_Value1 = Real_Values_of_the_Alternatives[i]; };

                            if (Real_Values_of_the_Alternatives[i] <= Min_Random_Value1)
                            { Min_Random_Value1 = Real_Values_of_the_Alternatives[i]; };
                        };  // *** end for i-loop ***

                        Max_Ratio1 = Max_Random_Value1 / Min_Random_Value1;
                        Min_Ratio1 = 1.0 / Max_Ratio1;

                        if ((Min_Ratio1 < 1 / 9.0) || (Max_Ratio1 > 9.0))
                        { goto Label1; };

                        // ********************************************************************************************************
                        // *** We build the RCP matrix now!  ***
                        // *************************************
                        for (i = 1; i <= N; i++)
                        {  // begin for i-loop ***
                            for (j = 1; j <= N; j++)
                            {  // begin for j-loop ***
                                RCP_Matrix1[i, j] = Real_Values_of_the_Alternatives[i] / Real_Values_of_the_Alternatives[j];
                            }; // *** end for j-loop ***
                        }; // *** end for i-loop ***

                        // *********************************************************************************************************
                        // *** We build the initial CDP matrix now!  ***
                        // *********************************************
                        for (i = 1; i <= N; i++)
                        {  // begin for i-loop ***
                            for (j = 1; j <= N; j++)
                            {  // begin for j-loop ***
                                True_Value1 = RCP_Matrix1[i, j];
                                // *** Use that approximating function here!
                                Saaty_Value1 = pr.Approximate_Using_Saaty_Scale1(True_Value1);
                                CDP_Matrix1[i, j] = Saaty_Value1;
                            }; // *** end for j-loop ***
                        }; // *** end for i-loop ***
                           // *********************************************************************************************************
                           // *** My CDP matrix is ready now! ***
                           // ***********************************

                        object6.Derive_The_Relative_Priorities_from_PC_Matrix1(RCP_Matrix1, N, out Priority_Vector0);
                        object7.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector0, N, out Ranking_R0);



                        // **********************************************************************************************************
                        // ***  We have the initial data to start a new iterative process to check how the results converge etc.  ***
                        // **********************************************************************************************************

                        for (Iterations2 = 1; Iterations2 <= Max_Iterations2; Iterations2++)
                        {
                            object6.Derive_The_Relative_Priorities_from_PC_Matrix1(CDP_Matrix1, N, out Priority_Vector1);
                            object7.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector1, N, out Ranking_R1);

                            // *** We build the new CDP matrix <CDP_Matrix2> now!  ****************
                            for (i = 1; i <= N; i++)
                            {  // begin for i-loop ***
                                for (j = 1; j <= N; j++)
                                {  // begin for j-loop ***

                                    True_Value1 = Priority_Vector1[i] / Priority_Vector1[j];

                                    // *** Use that approximating function here!
                                    Saaty_Value1 = pr.Approximate_Using_Saaty_Scale1(True_Value1);
                                    CDP_Matrix2[i, j] = Saaty_Value1;
                                }; // *** end for j-loop ***
                            }; // *** end for i-loop ***

                            object6.Derive_The_Relative_Priorities_from_PC_Matrix1(CDP_Matrix2, N, out Priority_Vector2);
                            object7.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector2, N, out Ranking_R2);

                            // **************************************************************************************************************
                            // ***    if <KREsult1> =  0; --> no conflict!   They agree 100% on all rankings!                             *** 
                            // ***    if <KResult1> =  1; --> They agree on the top alt., but they DO NOT agree 100% on all rankings.     ***
                            // ***    if <KResult1> = -9; --> ( MINUS 9) They do not agree on the top alternative!                        ***
                            // **************************************************************************************************************
                            object8.Compare_Two_Rankings1(Ranking_R0, Ranking_R1, N, out KResult01);
                            object8.Compare_Two_Rankings1(Ranking_R0, Ranking_R2, N, out KResult02);
                            object8.Compare_Two_Rankings1(Ranking_R1, Ranking_R2, N, out KResult12);

                            // ***************************************************************************************
                            // *** Print out the current results now.  Good for debugging!                         ***
                            // ***************************************************************************************
                            Console.WriteLine("  ");
                            Console.WriteLine("  ");
                            Console.WriteLine("     N --> " + N + "   Iteration1 = " + Iterations1 + " Iteration2 = " + Iterations2);
                            Console.WriteLine("     KResult R0_R1 = " + KResult01 + "  KResult R0_R2 = " + KResult02 + "     KResult R1_R2 = " + KResult12);
                            file1.WriteLine("     N --> " + N + "   Iteration1 = " + Iterations1 + " Iteration2 = " + Iterations2);
                            file1.WriteLine("     KResult R0_R1 = " + KResult01 + "  KResult R0_R2 = " + KResult02 + "     KResult R1_R2 = " + KResult12);
                            if (KResult01 == -9)
                            {
                                Console.WriteLine(" KResult01 ==========================================================>  " + KResult01);
                                file2.WriteLine(" KResult01 ==========================================================>  " + KResult01);
                            };

                            for (i = 1; i <= N; i++)
                            {  // begin for i-loop ***
                                Console.WriteLine("  i --> " + i + " Rank R0 = " + Ranking_R0[i] + "       Rank R1 = " + Ranking_R1[i] + " Rank R2 = " + Ranking_R2[i]);
                            }; // *** end for i-loop ***




                            // *** Use the current <Priority_Vector2> to build the next <CDP_Matrix1> matrix and start over ***
                            for (i = 1; i <= N; i++)
                            {  // begin for i-loop ***
                                for (j = 1; j <= N; j++)
                                {  // begin for j-loop ***

                                    True_Value1 = Priority_Vector2[i] / Priority_Vector2[j];

                                    // *** Use that approximating function here!
                                    Saaty_Value1 = pr.Approximate_Using_Saaty_Scale1(True_Value1);
                                    CDP_Matrix1[i, j] = Saaty_Value1;
                                }; // *** end for j-loop ***
                            }; // *** end for i-loop ***

                            KCounter1 = KCounter1 + KResult01;
                            KCounter2 = KCounter2 + KResult02;
                            KCounter3 = KCounter3 + KResult12;


                        }; // *** end <Iterations2-loop> *** 

                        //Console.WriteLine("  N --> " + N + "     KCounter1 = " + KCounter1 + "  KCounter2 = " + KCounter2 + "  KCounter3 = " + KCounter3);
                        Ratio1 = ((KCounter3 * 1.00) / (1.0));

                        if (KCounter3 > 0)
                        {
                            KCounter4 = KCounter4 + 1;
                        };

                        Console.WriteLine("  N --> " + N + "     KCounter1 = " + KCounter1 + "  KCounter2 = " + KCounter2 + "  KCounter3 = " + KCounter3 + "  KCounter4 = " + KCounter4);
                        file2.WriteLine("  N --> " + N + "     KCounter1 = " + KCounter1 + "  KCounter2 = " + KCounter2 + "  KCounter3 = " + KCounter3 + "  KCounter4 = " + KCounter4);

                        Sum_Ratio1 = Sum_Ratio1 + Ratio1;

                        Console.WriteLine("  Ratio1 = " + Ratio1);
                        Console.WriteLine("  ");
                        Console.WriteLine("  ");
                        Console.WriteLine(" ********************************************************* ");

                    }; // *** end <Iterations1-loop> ****


                    Average_Ratio1 = ((100.0 * Sum_Ratio1) / (1.00 * Max_Iterations1));
                    Average_Ratio2 = ((100.0 * KCounter4) / (1.0 * Max_Iterations1));

                    Console.WriteLine("  N ---> " + N + "  Average Ratio1 = " + Average_Ratio1 + "      Average Ratio2 =      " + Average_Ratio2 + "    KCounter4 ---> " + KCounter4);

                    Console.WriteLine("    " + N + "       " + Average_Ratio1 + "      " + Average_Ratio2);

                    Console.WriteLine(" ********************************************************* ");

                };  // *** end for <N-loop> 

                Console.WriteLine(" ********************************************************* ");

                file1.WriteLine(" *************  the end *********************************** ");
                file1.Close();


                file2.WriteLine("  ");
                file2.WriteLine(" *********  THE END ****************************** ");
                file2.Close();


                // file1.Close();




            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************














        //......................................................................................
        // *********************************************************************************************************************
        class Case_Study1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
           private int i, K;

            public void Case_Study1(out double[] Real_Values1, out int Size1 ) 
            { // *** Begin Method *** 

                // ***********************************************************************************************************
                // *** This is the data from TABLE 3 on comparing protein content in various foods.                        ***
                // *** Note that food item #3 is replaced now with something with very little protein *** 
                // *** It is from the following Saaty publication:                                                         *** 
                // ***                                                                                                     ***
                // *** Saaty, T.L., 2008. Relative measurement and its generalization in decision making why pairwise      *** 
                // *** comparisons are central in mathematics for the measurement of intangible factors the analytic       *** 
                // *** hierarchy/network process. RACSAM-Revista de la Real Academia de Ciencias Exactas, Fisicas y        ***
                // *** Naturales. Serie A. Matematicas, 102(2), pp.251-318.                                                *** 
                // ***********************************************************************************************************
                Real_Values1 = new double [30];

                double[] Real_Values_of_the_Alternatives = new double[30];

                Size1 = 7;
                Real_Values_of_the_Alternatives[1] = 0.370 ;
                Real_Values_of_the_Alternatives[2] = 0.040;
                Real_Values_of_the_Alternatives[3] = 0.020;  // = 0.002 ??  <-----  a very small quantity goes here!
                Real_Values_of_the_Alternatives[4] = 0.070;
                Real_Values_of_the_Alternatives[5] = 0.110;
                Real_Values_of_the_Alternatives[6] = 0.090;
                Real_Values_of_the_Alternatives[7] = 0.320;

            goto Label_Exit1 ;
                // *** taking item #3 (apples) out of the group because it has a value of 0.000 in the original data. 
                Size1 = 6;
                Real_Values_of_the_Alternatives[1] = 0.370;
                Real_Values_of_the_Alternatives[2] = 0.040;
                // Real_Values_of_the_Alternatives[3] = 0.001;
                Real_Values_of_the_Alternatives[3] = 0.070;
                Real_Values_of_the_Alternatives[4] = 0.110;
                Real_Values_of_the_Alternatives[5] = 0.090;
                Real_Values_of_the_Alternatives[6] = 0.320;


            Label_Exit1: K = -9; // a dummy statement goes here ***

                for (i = 1; i <= Size1; i++)
                {
                    Real_Values1[i] = Real_Values_of_the_Alternatives[i];
                }

            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************
           //......................................................................................


        //......................................................................................
        // *********************************************************************************************************************
        class Case_Study2_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i;

            public void Case_Study2(out double[] Real_Values1, out int Size1)
            { // *** Begin Method *** 

                // ***********************************************************************************************************
                // *** This is the data from TABLE 6 regarding the "Law of Optics"                                         ***
                // ***                                                                                                     *** 
                // *** it is from the following Saaty publication:                                                         *** 
                // ***                                                                                                     ***
                // *** Saaty, T.L., 1977. "A scaling method for priorities in hierarchical structures."                    ***
                // *** Journal of mathematical psychology, 15(3), pp.234-281.                                              *** 
                // ***********************************************************************************************************
                Real_Values1 = new double[30];

                double[] Real_Values_of_the_Alternatives = new double[30];

                Size1 = 4;
                Real_Values_of_the_Alternatives[1] = 0.6079;
                Real_Values_of_the_Alternatives[2] = 0.2188;
                Real_Values_of_the_Alternatives[3] = 0.1108;
                Real_Values_of_the_Alternatives[4] = 0.0623;

                for (i = 1; i <= Size1; i++)
                {
                    Real_Values1[i] = Real_Values_of_the_Alternatives[i];
                }

            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************
           //......................................................................................



        //......................................................................................
        // *********************************************************************************************************************
        class Case_Study3_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i;

            public void Case_Study3(out double[] Real_Values1, out int Size1)
            { // *** Begin Method *** 

                // ***********************************************************************************************************
                // *** This is the data from TABLE 5 regarding the relative distances between the city of Philadelphia     ***
                // *** and some other well-known world cities.                                                             *** 
                // *** it is from the following Saaty publication:                                                         *** 
                // ***                                                                                                     ***
                // *** Saaty, T.L., 1977. "A scaling method for priorities in hierarchical structures."                    ***
                // *** Journal of mathematical psychology, 15(3), pp.234-281.                                              *** 
                // ***********************************************************************************************************
                Real_Values1 = new double[30];

                double[] Real_Values_of_the_Alternatives = new double[30];

                Size1 = 6;
                Real_Values_of_the_Alternatives[1] = 5729.0;
                Real_Values_of_the_Alternatives[2] = 7449.0;
                Real_Values_of_the_Alternatives[3] = 660.0;
                Real_Values_of_the_Alternatives[4] = 2732.0;
                Real_Values_of_the_Alternatives[5] = 3658.0;
                Real_Values_of_the_Alternatives[6] = 400.0;

                for (i = 1; i <= Size1; i++)
                {
                    Real_Values1[i] = Real_Values_of_the_Alternatives[i];
                }

            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************
           //......................................................................................


           //......................................................................................
           // *********************************************************************************************************************
        class Case_Study4_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i;

            public void Case_Study4(out double[] Real_Values1, out int Size1)
            { // *** Begin Method *** 

                // ***********************************************************************************************************
                // *** This is the data from TABLE 8 regarding the relative GDPs of seven countries in                     ***
                // *** year 1977.                                                                                          *** 
                // *** it is from the following Saaty publication:                                                         *** 
                // ***                                                                                                     ***
                // *** Saaty, T.L., 1977. "A scaling method for priorities in hierarchical structures."                    ***
                // *** Journal of mathematical psychology, 15(3), pp.234-281.                                              *** 
                // ***********************************************************************************************************
                Real_Values1 = new double[30];

                double[] Real_Values_of_the_Alternatives = new double[30];

                Size1 = 7;
                Real_Values_of_the_Alternatives[1] = 1167.0;
                Real_Values_of_the_Alternatives[2] = 635.0;
                Real_Values_of_the_Alternatives[3] = 120.0;
                Real_Values_of_the_Alternatives[4] = 196.0;
                Real_Values_of_the_Alternatives[5] = 154.0;
                Real_Values_of_the_Alternatives[6] = 294.0;
                Real_Values_of_the_Alternatives[7] = 257.0;

                for (i = 1; i <= Size1; i++)
                {
                    Real_Values1[i] = Real_Values_of_the_Alternatives[i];
                }

            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************
           //......................................................................................


        //......................................................................................
        // *********************************************************************************************************************
        class Case_Study5_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i;

            public void Case_Study5(out double[] Real_Values1, out int Size1)
            { // *** Begin Method *** 

                // ***********************************************************************************************************
                // *** This is the data from TABLE 9 regarding weight comparsons between some simple objects.         *    ***
                // *** This one results in 3 reciprocal conradictions!                                                     *** 
                // *** it is from the following Saaty publication:                                                         *** 
                // ***                                                                                                     ***
                // *** Saaty, T.L., 1977. "A scaling method for priorities in hierarchical structures."                    ***
                // *** Journal of mathematical psychology, 15(3), pp.234-281.                                              *** 
                // ***********************************************************************************************************
                Real_Values1 = new double[30];

                double[] Real_Values_of_the_Alternatives = new double[30];

                Size1 = 5;

                // *** These are the results from Saaty's PC matrix (see also the top of page 257)
                Real_Values_of_the_Alternatives[1] = 0.09;
                Real_Values_of_the_Alternatives[2] = 0.40;
                Real_Values_of_the_Alternatives[3] = 0.18;
                Real_Values_of_the_Alternatives[4] = 0.29;
                Real_Values_of_the_Alternatives[5] = 0.04;


                // *** These are the TRUE (ACTUAL) values!  ***
                Real_Values_of_the_Alternatives[1] = 0.10;
                Real_Values_of_the_Alternatives[2] = 0.39;
                Real_Values_of_the_Alternatives[3] = 0.20;
                Real_Values_of_the_Alternatives[4] = 0.27;
                Real_Values_of_the_Alternatives[5] = 0.04;



                for (i = 1; i <= Size1; i++)
                {
                    Real_Values1[i] = Real_Values_of_the_Alternatives[i];
                }

            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************
           //......................................................................................



        //......................................................................................
        // *********************************************************************************************************************
        class Case_Study6_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i;

            public void Case_Study6(out double[] Real_Values1, out int Size1)
            { // *** Begin Method *** 

                // ***********************************************************************************************************
                // *** This is the data from TABLE 2 on comparing different objects.                                       ***
                // *** It is from the following Saaty publication:                                                         *** 
                // ***                                                                                                     ***
                // *** Saaty, T.L., 2008. Relative measurement and its generalization in decision making why pairwise      *** 
                // *** comparisons are central in mathematics for the measurement of intangible factors the analytic       *** 
                // *** hierarchy/network process. RACSAM-Revista de la Real Academia de Ciencias Exactas, Fisicas y        ***
                // *** Naturales. Serie A. Matematicas, 102(2), pp.251-318.                                                *** 
                // ***********************************************************************************************************
                Real_Values1 = new double[30];

                double[] Real_Values_of_the_Alternatives = new double[30];

                Size1 = 5;
                Real_Values_of_the_Alternatives[1] = 0.471;
                Real_Values_of_the_Alternatives[2] = 0.050;
                Real_Values_of_the_Alternatives[3] = 0.234;
                Real_Values_of_the_Alternatives[4] = 0.149;
                Real_Values_of_the_Alternatives[5] = 0.096;

                for (i = 1; i <= Size1; i++)
                {
                    Real_Values1[i] = Real_Values_of_the_Alternatives[i];
                }

            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************
           //......................................................................................





        
        // *********************************************************************************************************************
        class Analyze_Some_Case_Studies_from_the_Literature1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 

            public void Analyze_Some_Case_Studies_from_the_Literature1()
            { // *** Begin Method *** 

                // ******************************************************************************************
                // *** This explores whether the two Saaty matrices yield wrong rankings.                 ***
                // *** Like the case of Example #3 of PAPER 1 submitted to EJOR (summer / fal lof 2022)   ***
                // *** as my 1st paper of this series of papers.                                          *** 
                // *** It seems like when all the Saaty published case studies are used, no ranking       ***
                // *** Abnormality lik ethe ones described in Example #3 were detected!...                ***
                // *** However, some exhibited RC violations (like Case study 5 with the 5 weights etc.)  ***
                // ******************************************************************************************
                
                // **************************************
                // *** Variable declarations section. ***
                // **************************************
                string Output_CDP_Analysis2_File;
                string Output_CDP_Example3_File;
                int i, j, N, Nmax, Nmin, K, KResult1, KResult1a, KResult1b, KResult1ab, KResult11a, KResult11b;
                Double u1, Min_Random_Value1, Max_Random_Value1, Max_Ratio1, Min_Ratio1;

                int[] Ranking_R0 = new int[30];
                int[] Ranking_R1 = new int[30];
                int[] Ranking_R1A = new int[30];
                int[] Ranking_R1B = new int[30];


                double[] Priority_Vector0 = new double[30];
                double[] Priority_Vector1 = new double[30];
                double[] Priority_Vector1A = new double[30];
                double[] Priority_Vector1B = new double[30];

                double[] Real_Values_of_the_Alternatives = new double[30];
                double[] Bad_Real_Values_of_the_Alternatives = new double[30];
                double[,] RCP_Matrix1 = new double[30, 30];
                double[,] CDP_Matrix1 = new double[30, 30];
                double[,] Bad_RCP_Matrix1 = new double[30, 30];
                double[,] Bad_CDP_Matrix1 = new double[30, 30];
                double[,] Reciprocal_CDP_Matrix1A = new double[30, 30];
                double[,] Reciprocal_CDP_Matrix1B = new double[30, 30];

                double True_Value1, Saaty_Value1, Ratio_Defective_Matrices1;
                int Iterations1, Max_Iterations1, No_of_Violations1;

                // *** end of the Variable declaration section. ****** 

                Random rand = new Random();    //reuse this if you are generating many random doubles (real) numbers uniform in (0,1) ***


                // ************************************ 
                // *** Object declarations section. ***
                // ************************************
                Scan_Values_in_Saaty_Interval_for_reciprocal_Problem1_Demo object1 = new Scan_Values_in_Saaty_Interval_for_reciprocal_Problem1_Demo();
                Scan_Pairwise_Matrix_for_Reciprocity_Violations1_Demo object2 = new Scan_Pairwise_Matrix_for_Reciprocity_Violations1_Demo();
                Copy_PC_Matrix1_Demo object3 = new Copy_PC_Matrix1_Demo();
                Copy_Vector1_Demo object4 = new Copy_Vector1_Demo();
                Derive_Two_CDP_Matrices_from_Single_CDP_Matrix1_Demo object5 = new Derive_Two_CDP_Matrices_from_Single_CDP_Matrix1_Demo();
                Derive_The_Relative_Priorities_from_PC_Matrix1_Demo object6 = new Derive_The_Relative_Priorities_from_PC_Matrix1_Demo();
                Derive_The_Rankings_from_Priority_Vector1_Demo object7 = new Derive_The_Rankings_from_Priority_Vector1_Demo();
                Compare_Two_Rankings1_Demo object8 = new Compare_Two_Rankings1_Demo();
                Case_Study5_Demo object9 = new Case_Study5_Demo();
                Case_Study2_Demo object10 = new Case_Study2_Demo();

                // *** end of the Object declaration section. ********




                MainProgram pr1 = new MainProgram();  // *** Creating a class Object ***
                MainProgram pr = new MainProgram();  // *** Creating a class Object ***

                // ***  Console.WriteLine(" \n We just started!   Hit CR once to move on...");
                // ***  Console.ReadLine();
                


                N = 9;
                int i3;

                int ii1, ia1;


                   object9.Case_Study5(out Real_Values_of_the_Alternatives, out N);
                // object10.Case_Study2(Real_Values_of_the_Alternatives, out N);

                for (i3 = 1; i3 <= N; i3++)
                {
                //    Console.WriteLine("  i = " + i3 + "  True value = " + Real_Values_of_the_Alternatives[i3]);

                };


                // *** We build the RCP matrix now!  ****************
                for (i = 1; i <= N; i++)
                {  // begin for i-loop ***
                    for (j = 1; j <= N; j++)
                    {  // begin for j-loop ***
                        RCP_Matrix1[i, j] = Real_Values_of_the_Alternatives[i] / Real_Values_of_the_Alternatives[j];
                    }; // *** end for j-loop ***
                }; // *** end for i-loop ***

                // *** We build the CDP matrix now!  ****************
                for (i = 1; i <= N; i++)
                {  // begin for i-loop ***
                    for (j = 1; j <= N; j++)
                    {  // begin for j-loop ***

                        True_Value1 = RCP_Matrix1[i, j];

                        // *** Use that approximating function here!
                        Saaty_Value1 = pr.Approximate_Using_Saaty_Scale1(True_Value1);
                        CDP_Matrix1[i, j] = Saaty_Value1;
                    }; // *** end for j-loop ***
                }; // *** end for i-loop ***

                // ****************************************************************************
                // *** Check to see if the current CDP matrix has any reciprocal violations ***
                object2.Scan_Pairwise_Matrix_for_Reciprocity_Violations1(CDP_Matrix1, N, out No_of_Violations1);

                object6.Derive_The_Relative_Priorities_from_PC_Matrix1(RCP_Matrix1, N, out Priority_Vector0);
                object7.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector0, N, out Ranking_R0);

                object6.Derive_The_Relative_Priorities_from_PC_Matrix1(CDP_Matrix1, N, out Priority_Vector1);
                object7.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector1, N, out Ranking_R1);

                object8.Compare_Two_Rankings1(Ranking_R0, Ranking_R1, N, out KResult1);

                object5.Derive_Two_CDP_Matrices_from_Single_CDP_Matrix1(CDP_Matrix1, N, out Reciprocal_CDP_Matrix1A, out Reciprocal_CDP_Matrix1B);

                object6.Derive_The_Relative_Priorities_from_PC_Matrix1(Reciprocal_CDP_Matrix1A, N, out Priority_Vector1A);
                object7.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector1A, N, out Ranking_R1A);

                object6.Derive_The_Relative_Priorities_from_PC_Matrix1(Reciprocal_CDP_Matrix1B, N, out Priority_Vector1B);
                object7.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector1B, N, out Ranking_R1B);


                object8.Compare_Two_Rankings1(Ranking_R0, Ranking_R1A, N, out KResult1a);
                object8.Compare_Two_Rankings1(Ranking_R0, Ranking_R1B, N, out KResult1b);

                object8.Compare_Two_Rankings1(Ranking_R1A, Ranking_R1B, N, out KResult1ab);

                object8.Compare_Two_Rankings1(Ranking_R1, Ranking_R1A, N, out KResult11a);
                object8.Compare_Two_Rankings1(Ranking_R1, Ranking_R1B, N, out KResult11b);


                Console.WriteLine(" *************  We start a new Example here! ********************************* ");
                Console.WriteLine("  ");

                //Console.WriteLine(" N  KResult1 KResult1a KResult1b  KResult1ab KResult11a  KResult11b ==> " + N + "    " + KResult1 + "  " + KResult1a + "  " + KResult1b + "    " + KResult1ab + "  " + KResult11a + "  " + KResult11b);
                Console.WriteLine(" N  (R0 & Matrix1)   (R0 & MatrixA)   (R0 & MatrixB)  (MatrixA & MatrixB)   (Matrix1 & MatrixA)   (Matrix1 & MatrixB) ==> " + N + "    " + KResult1 + "  " + KResult1a + "  " + KResult1b + "    " + KResult1ab + "  " + KResult11a + "  " + KResult11b);
                Console.WriteLine("  Number of Reciprocity Violations = " + No_of_Violations1);
                Console.WriteLine("  Some key RANKINGS ");
                Console.WriteLine("  True R0     Matrix1     MatrixA       MatrixB     ");
                Console.WriteLine(" *************************************************************************************************************");
                // Console.WriteLine("  Iteration No =  " + Iterations1 + "  KCounter1 =" + KCounter1 + " KCounter2 = " + KCounter2 + "         KCounter3 = " + KCounter3 + "   KCounter4 = " + KCounter4);

                for (ii1 = 1; ii1 <= N; ii1++)
                {
                    Console.WriteLine("  " + Ranking_R0[ii1] + "             " + Ranking_R1[ii1] + "             " + Ranking_R1A[ii1] + "    " + Ranking_R1B[ii1]);
                };

                Console.WriteLine("___________________________________________");
                Console.WriteLine();
                Console.WriteLine();

                double Sum1a;
                Sum1a = 0.0; // *** initialization 

                for (ia1 = 1; ia1 <= N; ia1++)
                {
                    Sum1a = Sum1a + Real_Values_of_the_Alternatives[ia1];
                };

                // *** Normalize them now! 
                for (ia1 = 1; ia1 <= N; ia1++)
                {
                    Real_Values_of_the_Alternatives[ia1] = Real_Values_of_the_Alternatives[ia1] / Sum1a;
                };


                for (ia1 = 1; ia1 <= N; ia1++)
                {
                    Console.WriteLine("  ia1 = " + ia1 + "  Real Value ---> " + Real_Values_of_the_Alternatives[ia1]);
                };

                // *** We dump some partial results for debugging purpose now ******************************** 
                Console.WriteLine();
                Console.WriteLine(" ___ The Original RCP Matrix is:___________________________________________ ");
                Console.WriteLine();

                pr.Print_Pairwise_Matrix1(RCP_Matrix1, N);

                Console.WriteLine(" ________________________________________________ ");
                Console.WriteLine();

                Console.WriteLine();
                Console.WriteLine(" ___ The Correspodning CDP Matrix is:___________________________________________ ");
                Console.WriteLine();

                pr.Print_Pairwise_Matrix1(CDP_Matrix1, N);

                Console.WriteLine(" ________________________________________________ ");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(" ___ CDP Matrix 1A is:___________________________________________ ");
                Console.WriteLine();

                pr.Print_Pairwise_Matrix1(Reciprocal_CDP_Matrix1A, N);

                Console.WriteLine(" ________________________________________________ ");
                Console.WriteLine();

                Console.WriteLine();
                Console.WriteLine(" ___ CDP Matrix 1B is:___________________________________________ ");
                Console.WriteLine();

                pr.Print_Pairwise_Matrix1(Reciprocal_CDP_Matrix1B, N);

                Console.WriteLine(" ________________________________________________ ");
                Console.WriteLine();

                for (ia1 = 1; ia1 <= N; ia1++)
                {
                    Console.WriteLine(" ia1 ---> " + ia1 + "  Val0 = " + Priority_Vector0[ia1] + "  Rank0 = " + Ranking_R0[ia1] + "    Val1 = " + Priority_Vector1[ia1] + " Rank1 = " + Ranking_R1[ia1] + "  KResult1 --> " + KResult1);

                }

                Console.WriteLine(" ********************************************** ");
                Console.WriteLine(" ************* This is the end of the current Example ********************************* ");
                Console.WriteLine();
                Console.WriteLine();



            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************






        // edw1  
        // *********************************************************************************************************************
        class Explore_Saaty_Case_Study_for_Reciprocal_Property_Violations1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 

            public void Explore_Saaty_Case_Study_for_Reciprocal_Property_Violations1()
            { // *** Begin Method *** 

                // **************************************
                // *** Variable declarations section. ***
                // **************************************
                string Output_CDP_Analysis2_File;
                string Output_CDP_Example3_File;
                int i, j, N, Nmax, Nmin, K, KResult1, KResult1a, KResult1b, KResult1ab, KResult11a, KResult11b;
                Double u1, Min_Random_Value1, Max_Random_Value1, Max_Ratio1, Min_Ratio1;

                int[] Ranking_R0 = new int[30];
                int[] Ranking_R1 = new int[30];
                int[] Ranking_R1A = new int[30];
                int[] Ranking_R1B = new int[30];


                double[] Priority_Vector0 = new double[30];
                double[] Priority_Vector1 = new double[30];
                double[] Priority_Vector1A = new double[30];
                double[] Priority_Vector1B = new double[30];
                double[] Priority_Vector2 = new double[30];

                double Distance0_1A, Distance0_1B, Distance02, Ratio_1A_2, Ratio_1B_2;

                double[] Real_Values_of_the_Alternatives = new double[30];
                double[] Bad_Real_Values_of_the_Alternatives = new double[30];
                double[,] RCP_Matrix1 = new double[30, 30];
                double[,] CDP_Matrix1 = new double[30, 30];
                double[,] Bad_RCP_Matrix1 = new double[30, 30];
                double[,] Bad_CDP_Matrix1 = new double[30, 30];
                double[,] Reciprocal_CDP_Matrix1A = new double[30, 30];
                double[,] Reciprocal_CDP_Matrix1B = new double[30, 30];

                double[,] CDP_Matrix_with_No_RP_Violations1 = new double[30, 30];

                double True_Value1, Saaty_Value1, Ratio_Defective_Matrices1;
                int Iterations1, Max_Iterations1, No_of_Violations1;

                // *** end of the Variable declaration section. ****** 

                Random rand = new Random();    //reuse this if you are generating many random doubles (real) numbers uniform in (0,1) ***


                // ************************************ 
                // *** Object declarations section. ***
                // ************************************
                Scan_Values_in_Saaty_Interval_for_reciprocal_Problem1_Demo object1 = new Scan_Values_in_Saaty_Interval_for_reciprocal_Problem1_Demo();
                Scan_Pairwise_Matrix_for_Reciprocity_Violations1_Demo object2 = new Scan_Pairwise_Matrix_for_Reciprocity_Violations1_Demo();
                Copy_PC_Matrix1_Demo object3 = new Copy_PC_Matrix1_Demo();
                Copy_Vector1_Demo object4 = new Copy_Vector1_Demo();
                Derive_Two_CDP_Matrices_from_Single_CDP_Matrix1_Demo object5 = new Derive_Two_CDP_Matrices_from_Single_CDP_Matrix1_Demo();
                Derive_The_Relative_Priorities_from_PC_Matrix1_Demo object6 = new Derive_The_Relative_Priorities_from_PC_Matrix1_Demo();
                Derive_The_Rankings_from_Priority_Vector1_Demo object7 = new Derive_The_Rankings_from_Priority_Vector1_Demo();
                Compare_Two_Rankings1_Demo object8 = new Compare_Two_Rankings1_Demo();


                //Case_Study3_Demo object9 = new Case_Study3_Demo();
                Case_Study6_Demo object10 = new Case_Study6_Demo();

                // *** end of the Object declaration section. ********




                MainProgram pr1 = new MainProgram();  // *** Creating a class Object ***
                MainProgram pr = new MainProgram();  // *** Creating a class Object ***

                // ***  Console.WriteLine(" \n We just started!   Hit CR once to move on...");
                // ***  Console.ReadLine();


                int i3;

                int ii1, ia1;


                object10.Case_Study6(out Real_Values_of_the_Alternatives, out N);
                // object10.Case_Study2(out Real_Values_of_the_Alternatives, out N);

                for (i3 = 1; i3 <= N; i3++)
                {
                    //    Console.WriteLine("  i = " + i3 + "  True value = " + Real_Values_of_the_Alternatives[i3]);

                };


                // *** We build the RCP matrix now!  ****************
                for (i = 1; i <= N; i++)
                {  // begin for i-loop ***
                    for (j = 1; j <= N; j++)
                    {  // begin for j-loop ***
                        RCP_Matrix1[i, j] = Real_Values_of_the_Alternatives[i] / Real_Values_of_the_Alternatives[j];
                    }; // *** end for j-loop ***
                }; // *** end for i-loop ***

                // *** We build the CDP matrix now!  ****************
                for (i = 1; i <= N; i++)
                {  // begin for i-loop ***
                    for (j = 1; j <= N; j++)
                    {  // begin for j-loop ***

                        True_Value1 = RCP_Matrix1[i, j];

                        // *** Use that approximating function here!
                        Saaty_Value1 = pr.Approximate_Using_Saaty_Scale1(True_Value1);
                        CDP_Matrix1[i, j] = Saaty_Value1;
                    }; // *** end for j-loop ***
                }; // *** end for i-loop ***

                // ****************************************************************************
                // *** Check to see if the current CDP matrix has any reciprocal violations ***
                object2.Scan_Pairwise_Matrix_for_Reciprocity_Violations1(CDP_Matrix1, N, out No_of_Violations1);

                object6.Derive_The_Relative_Priorities_from_PC_Matrix1(RCP_Matrix1, N, out Priority_Vector0);
                object7.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector0, N, out Ranking_R0);

                object6.Derive_The_Relative_Priorities_from_PC_Matrix1(CDP_Matrix1, N, out Priority_Vector1);
                object7.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector1, N, out Ranking_R1);

                object8.Compare_Two_Rankings1(Ranking_R0, Ranking_R1, N, out KResult1);

                object5.Derive_Two_CDP_Matrices_from_Single_CDP_Matrix1(CDP_Matrix1, N, out Reciprocal_CDP_Matrix1A, out Reciprocal_CDP_Matrix1B);

                object6.Derive_The_Relative_Priorities_from_PC_Matrix1(Reciprocal_CDP_Matrix1A, N, out Priority_Vector1A);
                object7.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector1A, N, out Ranking_R1A);

                object6.Derive_The_Relative_Priorities_from_PC_Matrix1(Reciprocal_CDP_Matrix1B, N, out Priority_Vector1B);
                object7.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector1B, N, out Ranking_R1B);


                object8.Compare_Two_Rankings1(Ranking_R0, Ranking_R1A, N, out KResult1a);
                object8.Compare_Two_Rankings1(Ranking_R0, Ranking_R1B, N, out KResult1b);

                object8.Compare_Two_Rankings1(Ranking_R1A, Ranking_R1B, N, out KResult1ab);

                object8.Compare_Two_Rankings1(Ranking_R1, Ranking_R1A, N, out KResult11a);
                object8.Compare_Two_Rankings1(Ranking_R1, Ranking_R1B, N, out KResult11b);


                // ***************************************************************************************** 


                Console.WriteLine(" *************  We start a new Case Study here! ********************************* ");
                Console.WriteLine("  ");

                Console.WriteLine();
                Console.WriteLine("    Number of Violations ===> " + No_of_Violations1);
                Console.WriteLine();
                Console.WriteLine("    Distance0_1A = " + Distance0_1A + "    Distance0_1B = " + Distance0_1B + "     Distance02 ---> " + Distance02);
                Console.WriteLine("    Ratio_1A_2 --> " + Ratio_1A_2 + "     Ratio_1B_2 ---> " + Ratio_1B_2);
                Console.WriteLine();

                Console.WriteLine("___________________________________________");
                Console.WriteLine();
                Console.WriteLine();

                double Sum1a;
                Sum1a = 0.0; // *** initialization 

                for (ia1 = 1; ia1 <= N; ia1++)
                {
                    Sum1a = Sum1a + Real_Values_of_the_Alternatives[ia1];
                };

                // *** Normalize them now! 
                for (ia1 = 1; ia1 <= N; ia1++)
                {
                    Real_Values_of_the_Alternatives[ia1] = Real_Values_of_the_Alternatives[ia1] / Sum1a;
                };


                for (ia1 = 1; ia1 <= N; ia1++)
                {
                    Console.WriteLine("  ia1 = " + ia1 + "  Real Value ---> " + Real_Values_of_the_Alternatives[ia1]);
                };

                // *** We dump some partial results for debugging purpose now ******************************** 
                Console.WriteLine();
                Console.WriteLine(" ___ The Original RCP Matrix is:___________________________________________ ");
                Console.WriteLine();

                pr.Print_Pairwise_Matrix1(RCP_Matrix1, N);

                Console.WriteLine(" ________________________________________________ ");
                Console.WriteLine();

                Console.WriteLine();
                Console.WriteLine(" ___ The Correspodning CDP Matrix is:___________________________________________ ");
                Console.WriteLine();

                pr.Print_Pairwise_Matrix1(CDP_Matrix1, N);

                Console.WriteLine(" ________________________________________________ ");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(" ___ CDP Matrix 1A is:___________________________________________ ");
                Console.WriteLine();

                pr.Print_Pairwise_Matrix1(Reciprocal_CDP_Matrix1A, N);

                Console.WriteLine(" ________________________________________________ ");
                Console.WriteLine();

                Console.WriteLine();
                Console.WriteLine(" ___ CDP Matrix 1B is:___________________________________________ ");
                Console.WriteLine();

                pr.Print_Pairwise_Matrix1(Reciprocal_CDP_Matrix1B, N);

                Console.WriteLine(" ________________________________________________ ");
                Console.WriteLine();

                for (ia1 = 1; ia1 <= N; ia1++)
                {
                    Console.WriteLine(" ia1 ---> " + ia1 + "  Val0 = " + Priority_Vector0[ia1] + "  Rank0 = " + Ranking_R0[ia1] + "    Val1 = " + Priority_Vector1[ia1] + " Rank1 = " + Ranking_R1[ia1] + "  KResult1 --> " + KResult1);

                }

                Console.WriteLine(" ********************************************** ");
                Console.WriteLine(" ************* This is the end of the current Example ********************************* ");
                Console.WriteLine();
                Console.WriteLine();



            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************





        // *********************************************************************************************************************
        class Explore_Ranking_Changes_after_single_CDP_Application1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 

            public void Explore_Ranking_Changes_after_single_CDP_Application1()
            { // *** Begin Method *** 

                // **************************************
                // *** Variable declarations section. ***
                // **************************************
                string Output_CDP_Analysis5a_File;
                string Output_CDP_Analysis5b_File;
                int i, j, N, Nmax, Nmin, K, KResult1, KResult1a, KResult1b, KResult1ab, KResult11a, KResult11b;
                int KResult01, KResult02, KResult12;
                Double u1, Min_Random_Value1, Max_Random_Value1, Max_Ratio1, Min_Ratio1;

                int[] Ranking_R0 = new int[30];
                int[] Ranking_R1 = new int[30];
                // skt int[] Ranking_R2 = new int[30];
                // skt int[] Ranking_R1A = new int[30];
                // skt int[] Ranking_R1B = new int[30];


                double[] Priority_Vector0 = new double[30];
                double[] Priority_Vector1 = new double[30];
                // skt double[] Priority_Vector2 = new double[30];
                // skt double[] Priority_Vector1A = new double[30];
                // skt double[] Priority_Vector1B = new double[30];

                double[] Real_Values_of_the_Alternatives = new double[30];
                double[] Bad_Real_Values_of_the_Alternatives = new double[30];
                double[,] RCP_Matrix1 = new double[30, 30];
                double[,] CDP_Matrix1 = new double[30, 30];
                double[,] CDP_Matrix2 = new double[30, 30];
                // skt double[,] Bad_RCP_Matrix1 = new double[30, 30];
                // skt double[,] Bad_CDP_Matrix1 = new double[30, 30];
                // skt double[,] Reciprocal_CDP_Matrix1A = new double[30, 30];

                // *** These are the arrays where I am going to keep storing the data for my currently best Example #5 ****  
                double[,] Special_RCP_Matrix1 = new double[30, 30];
                double[,] Special_CDP_Matrix1 = new double[30, 30];
                double[]  Special_Vector1 = new double[30];
                double[]  Special_Vector2 = new double[30];
                int[]     Special_Ranking_R0 = new int[30];
                int[]     Special_Ranking_R1 = new int[30];


                double True_Value1, Saaty_Value1, Ratio_Defective_Matrices1, Normalized_Difference1 ;
                double Ratio1, Ratio2, Sum_Ratio1, Average_Ratio1;
                int Iterations1, Max_Iterations1, No_of_Violations1;
                // skt int Iterations2, Max_Iterations2;

                int KCounter1, KCounter2, KCounter3, KCounter4;
                double Max_Normalized_Difference1, Summation1 ; 

                // skt int ii1, ia1;



                // *** end of the Variable declaration section. ****** 

                Random rand = new Random();    //reuse this if you are generating many random doubles (real) numbers uniform in (0,1) ***


                // ************************************ 
                // *** Object declarations section. ***
                // ************************************
                Scan_Values_in_Saaty_Interval_for_reciprocal_Problem1_Demo object1 = new Scan_Values_in_Saaty_Interval_for_reciprocal_Problem1_Demo();
                Scan_Pairwise_Matrix_for_Reciprocity_Violations1_Demo object2 = new Scan_Pairwise_Matrix_for_Reciprocity_Violations1_Demo();
                Copy_PC_Matrix1_Demo object3 = new Copy_PC_Matrix1_Demo();
                Copy_Vector1_Demo object4 = new Copy_Vector1_Demo();
                Derive_Two_CDP_Matrices_from_Single_CDP_Matrix1_Demo object5 = new Derive_Two_CDP_Matrices_from_Single_CDP_Matrix1_Demo();
                Derive_The_Relative_Priorities_from_PC_Matrix1_Demo object6 = new Derive_The_Relative_Priorities_from_PC_Matrix1_Demo();
                Derive_The_Rankings_from_Priority_Vector1_Demo object7 = new Derive_The_Rankings_from_Priority_Vector1_Demo();
                Compare_Two_Rankings1_Demo object8 = new Compare_Two_Rankings1_Demo();
                Compare_Two_Vectors_for_Type1_Situation_Demo object9 = new Compare_Two_Vectors_for_Type1_Situation_Demo();
                
                //
                //
                // *** end of the Object declaration section. ********




                MainProgram pr1 = new MainProgram();  // *** Creating a class Object ***
                MainProgram pr = new MainProgram();  // *** Creating a class Object ***

                // ***  Console.WriteLine(" \n We just started!   Hit CR once to move on...");
                // ***  Console.ReadLine();
                // *************************************************************

                // ********************************************************************************************
                // *** The Output file can be found as follows:                                             ***
                // *** From th emain folder with this application go to: bib/Debug/net6.0-windows/MyProjectFiles1   *** 
                // *** You will find it there!                                                              ***
                // ********************************************************************************************
                Output_CDP_Analysis5a_File = @"MyProjectFiles1\OUTPUT CDPMatrix Analysis5a.TXT";
                Output_CDP_Analysis5b_File = @"MyProjectFiles1\OUTPUT CDPMatrix Analysis5b.TXT";

                System.IO.StreamWriter file1 = new System.IO.StreamWriter(Output_CDP_Analysis5a_File);
                System.IO.StreamWriter file2 = new System.IO.StreamWriter(Output_CDP_Analysis5b_File);

                Max_Iterations1 = 10000000;

                // Max_Iterations1 = 1000;


                file1.WriteLine(" ******************************************************* ");
                file1.WriteLine(" ***  This study explores what happens if we apply a *** ");
                file1.WriteLine(" ***  CDP matrix only once (1st iteration)           *** ");
                file1.WriteLine(" ***  Number of Iterations = " + Max_Iterations1);
                file1.WriteLine(" ******************************************************* ");
                file1.WriteLine("  ");
                file1.WriteLine("  N      KCounter1   KCounter2      Ratio1    Ratio2      Aver Ratio1     Max Normal Diff    ");
                file1.WriteLine();

                Console.WriteLine(" ******************************************************* ");
                Console.WriteLine(" ***  This study explores what happens if we apply a *** ");
                Console.WriteLine(" ***  CDP matrix only once (1st iteration)           *** ");
                Console.WriteLine(" ***  Number of Iterations = " + Max_Iterations1);
                Console.WriteLine(" ******************************************************* ");
                Console.WriteLine("  ");
                Console.WriteLine("  N      KCounter1   KCounter2      Ratio1    Ratio2      Aver Ratio1     Max Normal Diff    ");
                Console.WriteLine();


                // *** Assign some numerical values to my key parameters now ***
                Nmax = 20;  // *** The max number of items to be compared by means of pairwis ecomparisons is equal to 30 ***
                            // *** In other words, this is the maximum size of the matrices!      ***                
                            // **********************************************************************
                Nmin = 2;


                Max_Normalized_Difference1 = -9.0; // *** a dummy statement again! ***

                // skt *** Sum_Ratio1 = 0.0; // *** Initialization

                
                Console.WriteLine(" *************************************************** ");
                K = 0;     // *** This is the counter of how many cases I had to search to find an appropriate matrix consistent with Saaty's scale!

                for (N = Nmin; N <= Nmax; N++)
                { // for <N-loop>


                    // ***  <KCounter1>  This counter keeps track of cases with where the two rankings (original and one by the single CDP matrix) disagreed
                    // ***               but they agreed on the top alternative (even with multiple top with Ranking_R1 ****
                    // ***  <KCounter2>  This counter keeps track of cases that they disagreed with the top alternative   ***

                    KCounter1 = 0; // *** Initialization ***
                    KCounter2 = 0; // *** Initualization ***



                    Max_Normalized_Difference1 = -9.0; // *** A negative value goes here so it can be updated immediately! ***
                    Summation1 = 0.0; // *** Initialization ***

                    for (Iterations1 = 1; Iterations1 <= Max_Iterations1; Iterations1++)
                    { // *** begin Iterations1-loop ****************** 

                    // *** Get N randmom values uniformly disributed in [0, 1] and load them in my array <Real_Values_of_the_Alternatives[] 

                    Label1: K = K + 1;
                        for (i = 1; i <= N; i++)
                        {  // begin for i-loop ***
                           // *** Recall that this is stated more above: double u1 = rand.NextDouble(); //these are uniform(0,1) random doubles
                            u1 = rand.NextDouble();
                            Real_Values_of_the_Alternatives[i] = u1;
                        }; // *** end for i-loop ***

                        // ***************************************************************************************************************************************
                        // *** Now we need to find out if the ratio <Ratio_Max> of the Max such value divided by the Min such value is less than or equal to 9 ***
                        // *** and the ratio <Ratio_Min> of the <1 / Ratio_MaxGet> is larger than or equal to 1/9                                              ***
                        // *** Thus, first find the <Min_Random_Value1> and <Max_Random_Value1> values!                                                        ***
                        // ***************************************************************************************************************************************

                        // *** Some initializations now *********************************************      
                        Min_Random_Value1 = 99.0; // *** An arbitrarily large value out of range ***
                        Max_Random_Value1 = -99.0; // *** An arbitrarily samll value out of range ***

                        for (i = 1; i <= N; i++)
                        {  // begin for i-loop ***
                            if (Real_Values_of_the_Alternatives[i] >= Max_Random_Value1)
                            { Max_Random_Value1 = Real_Values_of_the_Alternatives[i]; };

                            if (Real_Values_of_the_Alternatives[i] <= Min_Random_Value1)
                            { Min_Random_Value1 = Real_Values_of_the_Alternatives[i]; };
                        }; // *** end for i-loop ***
                        Max_Ratio1 = Max_Random_Value1 / Min_Random_Value1;
                        Min_Ratio1 = 1.0 / Max_Ratio1;

                        if ((Min_Ratio1 < 1 / 9.0) || (Max_Ratio1 > 9.0))
                        { goto Label1; };

                        for (i = 1; i <= N; i++)
                        {  // begin for i-loop ***
                           //   file1.WriteLine(" i = " + i + " Stored Value --> " + Real_Values_of_the_Alternatives[i]);

                        }; // *** end for i-loop ***

                        // *** We build the RCP matrix now!  ****************
                        for (i = 1; i <= N; i++)
                        {  // begin for i-loop ***
                            for (j = 1; j <= N; j++)
                            {  // begin for j-loop ***
                                RCP_Matrix1[i, j] = Real_Values_of_the_Alternatives[i] / Real_Values_of_the_Alternatives[j];
                            }; // *** end for j-loop ***
                        }; // *** end for i-loop ***

                        // *** We build the RCP matrix now!  ****************
                        for (i = 1; i <= N; i++)
                        {  // begin for i-loop ***
                            for (j = 1; j <= N; j++)
                            {  // begin for j-loop ***

                                True_Value1 = RCP_Matrix1[i, j];

                                // *** Use that approximating function here!!!!!!!!!!!!!!!
                                Saaty_Value1 = pr.Approximate_Using_Saaty_Scale1(True_Value1);
                                CDP_Matrix1[i, j] = Saaty_Value1;
                            }; // *** end for j-loop ***
                        }; // *** end for i-loop ***

                                                
                        object6.Derive_The_Relative_Priorities_from_PC_Matrix1(RCP_Matrix1, N, out Priority_Vector0);
                        object7.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector0, N, out Ranking_R0);

                        // skt Console.WriteLine(" *************  The original real values and rankings are as follows: ************************** ");
                    
                    for (i = 1; i <= N; i++)
                    {
                        // skt Console.WriteLine("  i ---> " + i + "  Real Value = " + Priority_Vector0[i] + "       Ranking R0 = " + Ranking_R0[i]);
                    };

                    // skt Console.WriteLine();
                    // skt Console.WriteLine(" ___ The Original RCP Matrix is:___________________________________________ ");
                    // skt Console.WriteLine();

                    // skt pr.Print_Pairwise_Matrix1(RCP_Matrix1, N);

                    // skt Console.WriteLine(" ________________________________________________ ");
                    // skt Console.WriteLine();

                    // skt Console.WriteLine();
                    // skt Console.WriteLine(" ___ The Corresponding CDP Matrix is:___________________________________________ ");
                    // skt Console.WriteLine();

                    // skt pr.Print_Pairwise_Matrix1(CDP_Matrix1, N);

                    // skt Console.WriteLine(" ________________________________________________ ");
                    // skt Console.WriteLine();

                    object6.Derive_The_Relative_Priorities_from_PC_Matrix1(CDP_Matrix1, N, out Priority_Vector1);
                    object7.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector1, N, out Ranking_R1);

                    object8.Compare_Two_Rankings1(Ranking_R0, Ranking_R1, N, out KResult01);

                        if (KResult01 == 1)
                        {
                            object9.Compare_Two_Vectors_for_Type1_Situation(Priority_Vector0, Ranking_R0, Priority_Vector1, Ranking_R1, N, out Normalized_Difference1);

                            // skt Console.WriteLine(" ----------->>>   Max Normal Diff ===>>> " + Max_Normalized_Difference1 + "   Normal  Differnce1 = " + Normalized_Difference1); 
                             

                            Summation1 = Summation1 + Normalized_Difference1;
                            if (Normalized_Difference1 > Max_Normalized_Difference1)
                            {

                                // skt Console.WriteLine(" BEFORE   Max Normalized Difference1 =====>>> " + Max_Normalized_Difference1 + "   Normalized Differnce1 = " + Normalized_Difference1);                                Max_Normalized_Difference1 = Normalized_Difference1;
                                
                                Max_Normalized_Difference1 = Normalized_Difference1;
                                
                                // skt Console.WriteLine(" AFTER    Max Normalized Difference1 =====>>> " + Max_Normalized_Difference1 + "   Normalized Differnce1 = " + Normalized_Difference1); Max_Normalized_Difference1 = Normalized_Difference1;

                                for (i = 1; i <= N; i++)
                                {
                                    Special_Vector1[i] = Priority_Vector0[i];
                                    Special_Vector2[i] = Priority_Vector1[i];
                                    Special_Ranking_R0[i] = Ranking_R0[i];
                                    Special_Ranking_R1[i] = Ranking_R1[i];

                                    for (j = 0; j <= N; j++)
                                    {
                                        Special_RCP_Matrix1[i, j] = RCP_Matrix1[i, j];
                                        Special_CDP_Matrix1[i, j] = CDP_Matrix1[i, j];
                                    };
                                };
                            };
                        };
                        // *** We have stored the data for later use.  We want to get the best ones out <Max_Iterations1> iterations! ***


                        // ***************************************************************************************
                        // *** Print out the current results now                                               ***
                        // ***************************************************************************************


                        // skt Console.WriteLine(" *************  The priority values and rankings from the CDP matrix are as follows: ************************** ");

                        // skt for (i = 1; i <= N; i++)
                        // skt {
                        // skt     Console.WriteLine("  i ---> " + i + "  CDP Value = " + Priority_Vector1[i] + "       Ranking R1 = " + Ranking_R1[i]);
                        // skt };

                        // skt Console.WriteLine("  ");
                        // skt Console.WriteLine("  ");
                        // skt Console.WriteLine("   Comparing the two rankings now ****");

                        // skt for (i = 1; i <= N; i++)
                        // skt {
                        // skt     Console.WriteLine("  i ---> " + i + "        Ranking R0 = " + Ranking_R0[i] + "   Ranking R1 = " + Ranking_R1[i]);
                        // skt };


                        // skt Console.WriteLine("  ");
                        // skt Console.WriteLine("  Ranking Result ===> " + KResult01);
                       // Console.WriteLine("  Ranking Result ===> " + KResult01);

                        if (KResult01 == 1)
                        {
                        // skt    Console.WriteLine("  Ranking Result ================================> " + KResult01);
                            KCounter1 = KCounter1 + 1;
                        };

                        if (KResult01 == -9)
                        {
                        // skt     Console.WriteLine("  Ranking Result ----------------------->>>>>>>> " + KResult01);
                            KCounter2 = KCounter2 + 1;
                        };




                        // skt Console.WriteLine("  ");

                        // skt Console.WriteLine("___________________________________________");
                        // skt Console.WriteLine();
                        // skt Console.WriteLine();


                        // skt Console.WriteLine(" ********************************************** ");
                        // skt Console.WriteLine(" ************* This is the end of the current Example ********************************* ");
                        // skt Console.WriteLine();
                        // skt Console.WriteLine();




                    // skt Console.WriteLine(" ********************************************************* ");

                }; // *** end <Iterations1-loop> ****

                    // skt  Average_Ratio1 = Sum_Ratio1 / (1.00 * Max_Iterations1);

                    Ratio1 = (100.0 * KCounter1) / (1.0 * Max_Iterations1);
                    Ratio2 = (100.0 * KCounter2) / (1.0 * Max_Iterations1);

                    Average_Ratio1 = Summation1 / (1.0 * KCounter1);

                    // skt Console.WriteLine("  N ---> " + N + "  KCounter1 = " + KCounter1 + "  KCounter2 = " + KCounter2 + "    Ratio1 = " + Ratio1 + "  Ratio2 = " + Ratio2 + "  Aver Ratio1 = " + Average_Ratio1 + "  Max Normal Diff = " + Max_Normalized_Difference1);
                    // skt file1.WriteLine(  "  N ---> " + N + "  KCounter1 = " + KCounter1 + "  KCounter2 = " + KCounter2 + "    Ratio1 = " + Ratio1 + "  Ratio2 = " + Ratio2 + "  Aver Ratio1 = " + Average_Ratio1 + "  Max Normal Diff = " + Max_Normalized_Difference1);
                    Console.WriteLine( "   " + N + "  " + KCounter1 + "  " + KCounter2 + "      " + Ratio1 + "  " + Ratio2 + "   " + Average_Ratio1 + "     " + Max_Normalized_Difference1);
                    file1.WriteLine("   " + N + "  " + KCounter1 + "  " + KCounter2 + "      " + Ratio1 + "  " + Ratio2 + "   " + Average_Ratio1 + "     " + Max_Normalized_Difference1);



                    Console.WriteLine(" *******************************************************");
                    Console.WriteLine(" The best example out of " + Max_Iterations1 + "  is as follows:");
                    Console.WriteLine("  ");

                    file2.WriteLine(" *******************************************************");
                    file2.WriteLine(" The best example out of " + Max_Iterations1 + "  is as follows:");
                    file2.WriteLine("  ");
                    file2.WriteLine("  ");


                    Console.WriteLine(" The RCP matrix is:");
                    
                    pr.Print_Pairwise_Matrix1(Special_RCP_Matrix1, N);
                    
                    Console.WriteLine(" ________________________________________________ ");
                    Console.WriteLine();
                    
                    Console.WriteLine();
                    Console.WriteLine(" ___ The Corresponding CDP Matrix is:___________________________________________ ");
                    Console.WriteLine();
                    pr.Print_Pairwise_Matrix1(Special_CDP_Matrix1, N);

                    Console.WriteLine(" ________________________________________________ ");
                    Console.WriteLine();
                    Console.WriteLine(" Vector0   Rank R0        Vector1  Rank R1  ");
                    Console.WriteLine();


                    file2.WriteLine(" ________________________________________________ ");
                    file2.WriteLine();
                    file2.WriteLine(" Vector0   Rank R0        Vector1  Rank R1  ");
                    file2.WriteLine();



                    for (i=1; i <= N; i++)
                    {
                        Console.WriteLine("   i --> " + i + "   Special Vector V1 = " + Special_Vector1[i] + "  Rank = " + Special_Ranking_R0[i] + "      Special Vector2 = " + Special_Vector2[i] + "  Rank = " + Special_Ranking_R1[i]);
                        file2.WriteLine("   i --> " + i + "   Special Vector V1 = " + Special_Vector1[i] + "  Rank = " + Special_Ranking_R0[i] + "      Special Vector2 = " + Special_Vector2[i] + "  Rank = " + Special_Ranking_R1[i]);

                    };
                    
                    
                    // skt Max_Normalized_Difference1 = Max_Normalized_Difference1;
                    Console.WriteLine();
                    Console.WriteLine("    Max Normalzied Difference ==> " + Max_Normalized_Difference1 );
                    Console.WriteLine();
                    Console.WriteLine("   Average_Ratio1 = " + Average_Ratio1);
                    Console.WriteLine(" ***********************************************************************************");

                    file2.WriteLine();
                    file2.WriteLine("    Max Normalzied Difference ==> " + Max_Normalized_Difference1);
                    file2.WriteLine();
                    file2.WriteLine("   Average_Ratio1 = " + Average_Ratio1);
                    file2.WriteLine(" ***********************************************************************************");


                    //.. Console.WriteLine(" ********************************************************* " );

                };  // *** end for <N-loop> 

                Console.WriteLine("   ");
                Console.WriteLine("  ");
                Console.WriteLine(" ****** The END!  *************************************************** ");
                Console.WriteLine("   ");

                file1.WriteLine("  ");
                file1.WriteLine("  ");
                file1.WriteLine(" ********* The END! *************************************** ");
                file1.Close();

                file2.WriteLine("  ");
                file2.WriteLine("  ");
                file2.WriteLine(" *********  The END!  *************************************** ");
                file2.Close();



            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************




        // *********************************************************************************************************************
        class Compare_Two_Vectors_for_Type1_Situation_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i, j, K1, K2;
            private double Difference1, Max_Difference1, Min_Value1;

            public void Compare_Two_Vectors_for_Type1_Situation (double [] Vector1, int [] Ranking_Vector1, double [] Vector2, int [] Ranking_Vector2 , int Size1, out double Normalized_Difference1)
            { // *** Begin Method ***   
              // **************************************************************************************************************
              // *** This method takes as input two Priority Vectors (double/real values) and Ranking Vectors (integer values).  ***
              // *** It compares them and returns the % of change between two items that were different in Vector1 but      ***
              // *** look to be of equal importance in Vector2.  One of the items must have been ranked as #1 (= top one)   ***
              // *** in Vector1.   Furthermore, note that this Method is invoked ONLY when there are multiple items ranked  ***
              // *** as #1 (= top position) in Vector2.                                                                     ***
              // ***                                                                                                        ***
              // *** The output is variable:  <Normalized_Difference1>                                                      *** 
              // ***                                                                                                        ***
              // **************************************************************************************************************

                Max_Difference1 = -9.0; // *** Initialize to something too small (= a negative value!) ***
                Normalized_Difference1 = 0;  // *** Just to avoid that stupid error....  ****
                              
                // **************************************************************** 
                for (i = 1; i <= Size1; i++)
                {
                    // skt if (Ranking_Vector1[i] == 1)
                    // skt {
                        for (j = 1; j <= Size1; j++)
                        {
                            if ((i != j) & (Ranking_Vector2[j] == Ranking_Vector2[i]))
                            {
                            // *** Items <i> and <j> are of the same rank but in Vector1 they are of different value.           ***
                            // *** Note that the entries of Vector1 are all different as they are completely random in [0, 1]!  ***
                            Difference1 = Math.Abs(Vector1[i] - Vector1[j]);
                            if (Difference1 > Max_Difference1)
                            {
                                Max_Difference1 = Difference1;
                                K1 = i;
                                K2 = j;
                            };

                            }
                        };
                    // skt };
                };

                Min_Value1 = Vector1[K1]; // *** Default state.  It may alter if the following condition is satisfied ***
                if (Vector1[K1] > Vector1[K2])
                {
                    Min_Value1 = Vector1[K2];
                };

                Normalized_Difference1 = (100.0 * Max_Difference1) / (Min_Value1);

                // skt Console.WriteLine(" ++++++ Dump some values now for verification purposes! +++++++++++++");
                // skt Console.WriteLine(" K1, K2 ==> " + K1 + "   " + K2 + "    Max_Difference1 = " + Max_Difference1 + "   Normalized_Difference1 = " + Normalized_Difference1);
                // skt Console.WriteLine(" ************************************");
                // skt Console.WriteLine("   ");

            } // *** End Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************


        // *********************************************************************************************************************
        class Compare_Two_Priority_Vectors1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i;
            private double Difference1;

            public void Compare_Two_Priority_Vectors1(double[] Vector1, double[] Vector2, int Size1, out int KResult1)
            { // *** Begin Method ***   
              // **************************************************************************************************************
              // *** This method takes as input two Priority Vectors (double/real values) and compares them.                ***
              // *** If they are identical, the value o fthe utput parameter <KResult1> = 0.  Otherwise, <KResult1> = 1     *** 
              // ***                                                                                                        ***
              // **************************************************************************************************************

                KResult1 = 1;  // *** A dummy statement to avoid that silly error message ***
                Difference1 = 0.0; // Initialization ***

                // **************************************************************** 
                for (i = 1; i <= Size1; i++)
                {
                    Difference1 = Difference1 + Math.Abs(Vector1[i] - Vector2[i]);
                };

                if (Difference1 == 0)
                { KResult1 = 0; };

                // **************************************************** 
                // *** The follwoing is good for debugging purposes ***
                // Console.WriteLine();
                // Console.WriteLine(" ------------------------------------------ ");
                //for (i = 1; i <= Size1; i++)
                // {
                //    Console.WriteLine("  i = " + i + " Vector1 = " + Vector1[i] + " Vector2 = " + Vector2[i]);
                // };
                //Console.WriteLine("  KResult1 ----> " + KResult1);
                //Console.WriteLine(" ------------------------------------------ ");
                //Console.WriteLine();


            } // *** End Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************




        // *********************************************************************************************************************
        class Determine_Distance_Between_Two_Priority_Vectors1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i ;
            private double Difference1, Summation1;

            public void Determine_Distance_Between_Two_Priority_Vectors1(double[] Vector1, double[] Vector2, int Size1, out double Normalized_Difference1)
            { // *** Begin Method ***   
              // ***************************************************************************************************************
              // *** This method takes as input two Priority Vectors (double values) and determines their relative distance. ***
              // *** That is, it first determines their sum of squared distances between the corresponding pairs of entries  ***
              // *** and then it normalizes the sum by dividing by the (common) size of the vecors.                          ***
              // ***                                                                                                         ***
              // ***************************************************************************************************************
              // Vector1 = new double [30];   // <----------------  This was a HUGE error!!!!
              // Vector2 = new double [30];   // <----------------  This was a HUGE error!!!! 

                Summation1 = 0; // *** Initialiation ***

                // **************************************************************** 
                for (i = 1; i <= Size1; i++)
                {
                    // *** Determine the squared difference bwteen two elements now ***
                    Difference1 = (Vector1[i] - Vector2[i])*(Vector1[i] - Vector2[i]);
                    Summation1 = Summation1 + Difference1; 
                };
                
                Normalized_Difference1 = Summation1 / (1.00 * Size1);

            } // *** End Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************



        // *********************************************************************************************************************
        class Generate_a_Random_CDP_Matrix1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 

            public void Generate_a_Random_CDP_Matrix1(int N, out double[] Priority_VectorV0, out double[,] CDP_Matrix1)
            { // *** Begin Method *** 

                // **************************************
                // *** Variable declarations section. ***
                // **************************************
                int i, j;
                double u1, Min_Random_Value1, Max_Random_Value1, Max_Ratio1, Min_Ratio1;
                

                Priority_VectorV0 = new double[30]; // <-------  VERY IMPORTANT TO DO THIS!!!!!!!!
                CDP_Matrix1 = new double[30, 30];   // <-------  VERY IMPORTANT TO DO THIS!!!!!!!!
                
                double [] Real_Values_of_the_Alternatives = new double [30];
                double [,] RCP_Matrix1 = new double [30, 30];
                
                double True_Value1, Saaty_Value1;
                double Summation1;

                // *** end of the Variable declaration section. ****** 

                Random rand = new Random();    //reuse this if you are generating many random doubles (real) numbers uniform in (0,1) ***

                MainProgram pr1 = new MainProgram();  // *** Creating a class Object ***

                // *** Get N randmom values uniformly disributed in [0, 1] and load them in my array <Real_Values_of_the_Alternatives[] 

                Label1: for (i = 1; i <= N; i++)
                        {  // begin for i-loop ***
                           // *** Recall that this is stated more above: double u1 = rand.NextDouble(); //these are uniform(0,1) random doubles
                            u1 = rand.NextDouble();
                            Real_Values_of_the_Alternatives[i] = u1;
                        }; // *** end for i-loop ***

                        // ***************************************************************************************************************************************
                        // *** Now we need to find out if the ratio <Ratio_Max> of the Max such value divided by the Min such value is less than or equal to 9 ***
                        // *** and the ratio <Ratio_Min> of the <1 / Ratio_MaxGet> is larger than or equal to 1/9                                              ***
                        // *** Thus, first find the <Min_Random_Value1> and <Max_Random_Value1> values!                                                        ***
                        // ***************************************************************************************************************************************

                        // *** Some initializations now *********************************************      
                        Min_Random_Value1 = 99.0; // *** An arbitrarily large value out of range ***
                        Max_Random_Value1 = -99.0; // *** An arbitrarily samll value out of range ***

                        for (i = 1; i <= N; i++)
                        {  // begin for i-loop ***
                            if (Real_Values_of_the_Alternatives[i] >= Max_Random_Value1)
                            { Max_Random_Value1 = Real_Values_of_the_Alternatives[i]; };

                            if (Real_Values_of_the_Alternatives[i] <= Min_Random_Value1)
                            { Min_Random_Value1 = Real_Values_of_the_Alternatives[i]; };
                        }; // *** end for i-loop ***
                        Max_Ratio1 = Max_Random_Value1 / Min_Random_Value1;
                        Min_Ratio1 = 1.0 / Max_Ratio1;

                        if ((Min_Ratio1 < 1 / 9.0) || (Max_Ratio1 > 9.0))
                        { goto Label1; };

                        // *** We build the RCP matrix now!  ****************
                        for (i = 1; i <= N; i++)
                        {  // begin for i-loop ***
                            for (j = 1; j <= N; j++)
                            {  // begin for j-loop ***
                                RCP_Matrix1[i, j] = Real_Values_of_the_Alternatives[i] / Real_Values_of_the_Alternatives[j];
                            }; // *** end for j-loop ***
                        }; // *** end for i-loop ***

                        // *** We build the CDP matrix now!  ****************
                        for (i = 1; i <= N; i++)
                        {  // begin for i-loop ***
                            for (j = 1; j <= N; j++)
                            {  // begin for j-loop ***

                                True_Value1 = RCP_Matrix1[i, j];

                                // *** Use that approximating function here!!!!!!!!!!!!!!!
                                Saaty_Value1 = pr1.Approximate_Using_Saaty_Scale1(True_Value1);
                                CDP_Matrix1[i, j] = Saaty_Value1;
                            }; // *** end for j-loop ***
                        }; // *** end for i-loop ***

                // *** Get the normalized priority vector <Priority_Vector0> now!  *** 
                Summation1 = 0.0; // *** Initialization ***

                // *** We first add them up and after that we normalize by dividing by their sum ***
                for (i = 1; i <= N; i++)
                {
                    Summation1 = Summation1 + Real_Values_of_the_Alternatives[i];
                };

                // **************************
                // *** Normalize them now ***
                for (i=1; i<=N; i++)
                {
                    //Priority_Vector0[i] = Real_Values_of_the_Alternatives[i] / Summation1;
                    Priority_VectorV0[i] = Real_Values_of_the_Alternatives[i] / Summation1;
                };

            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************





        //......................................................................................
        // *********************************************************************************************************************
        

    //  edw1  
    // *********************************************************************************************************************
        class Explore_Stochastic_Nature_via_Simulation_and_Petrubations_of_RCP_Matrices1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
          private int i, j, N;
            double[] Priority_VectorV0;
            double[,] RCP_Matrix1;
            double[,] Single_Pertrubed_PC_Matrix2;
            double RRatio1, RRatio2, RRatio3;
            double Sum1, Sum2, Sum3;

             

public void Explore_Stochastic_Nature_via_Simulation_and_Petrubations_of_RCP_Matrices1()
            { // *** Begin Method *** 
                Generate_a_Random_RCP_Matrix1_Demo object1 = new Generate_a_Random_RCP_Matrix1_Demo();
                Explore_a_Single_RCP_Matrix1_Demo object2 = new Explore_a_Single_RCP_Matrix1_Demo();

                int i_max;
                i_max = 100;

                // ---->  NEEDS TO BE VALIDATED <---------------

                N = 6;


                for (N = 3; N <= 20; N++)
                {

                    // **** Initializations ***
                    Sum1 = 0.0; Sum2 = 0.0; Sum3 = 0.0;


                    // ***********************************************************************
                    // *** Generate a single RCP matrix now to exlore it based on the
                    // *** proposed Monte Carlo simulation approach.
                    // ***********************************************************************


                    for (i = 1; i <= 100; i++)
                    {
                        object1.Generate_a_Random_RCP_Matrix1(N, out Priority_VectorV0, out RCP_Matrix1);

                        object2.Explore_a_Single_RCP_Matrix1(N, RCP_Matrix1, Priority_VectorV0, out Single_Pertrubed_PC_Matrix2, out RRatio1, out RRatio2, out RRatio3);

                        Sum1 = Sum1 + RRatio1;
                        Sum2 = Sum2 + RRatio2;
                        Sum3 = Sum3 + RRatio3;
                    };

                    double Average1, Average2, Average3;

                    Average1 = Sum1 / (i_max * 1.0);
                    Average2 = Sum2 / (i_max * 1.0);
                    Average3 = Sum3 / (i_max * 1.0);

                    Console.WriteLine("  N --> " + N + "  Average1 = " + Average1 + "  Average2 = " + Average2 + "  Average3 = " + Average3);

                };




            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************



        // *********************************************************************************************************************
        class Generate_a_Random_RCP_Matrix1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 

            public void Generate_a_Random_RCP_Matrix1(int N, out double[] Priority_VectorV0, out double[,] RCP_Matrix1)
            { // *** Begin Method *** 

                // **************************************
                // *** Variable declarations section. ***
                // **************************************
                int i, j;
                double u1, Min_Random_Value1, Max_Random_Value1, Max_Ratio1, Min_Ratio1;


                Priority_VectorV0 = new double[30]; // <-------  VERY IMPORTANT TO DO THIS!!!!!!!!
                RCP_Matrix1 = new double[30, 30];   // <-------  VERY IMPORTANT TO DO THIS!!!!!!!!

                double[] Real_Values_of_the_Alternatives = new double[30];
                //  double[,] RCP_Matrix1 = new double[30, 30];


                double Summation1;

                // *** end of the Variable declaration section. ****** 

                Random rand = new Random();    //reuse this if you are generating many random doubles (real) numbers uniform in (0,1) ***

                MainProgram pr1 = new MainProgram();  // *** Creating a class Object ***

            // *** Get N randmom values uniformly disributed in [0, 1] and load them in my array <Real_Values_of_the_Alternatives[] 

            Label1: for (i = 1; i <= N; i++)
                {  // begin for i-loop ***
                   // *** Recall that this is stated more above: double u1 = rand.NextDouble(); //these are uniform(0,1) random doubles
                    u1 = rand.NextDouble();
                    Real_Values_of_the_Alternatives[i] = u1;
                }; // *** end for i-loop ***

                // ***************************************************************************************************************************************
                // *** Now we need to find out if the ratio <Ratio_Max> of the Max such value divided by the Min such value is less than or equal to 9 ***
                // *** and the ratio <Ratio_Min> of the <1 / Ratio_MaxGet> is larger than or equal to 1/9                                              ***
                // *** Thus, first find the <Min_Random_Value1> and <Max_Random_Value1> values!                                                        ***
                // ***************************************************************************************************************************************

                // *** Some initializations now *********************************************      
                Min_Random_Value1 = 99.0; // *** An arbitrarily large value out of range ***
                Max_Random_Value1 = -99.0; // *** An arbitrarily samll value out of range ***

                for (i = 1; i <= N; i++)
                {  // begin for i-loop ***
                    if (Real_Values_of_the_Alternatives[i] >= Max_Random_Value1)
                    { Max_Random_Value1 = Real_Values_of_the_Alternatives[i]; };

                    if (Real_Values_of_the_Alternatives[i] <= Min_Random_Value1)
                    { Min_Random_Value1 = Real_Values_of_the_Alternatives[i]; };
                }; // *** end for i-loop ***
                Max_Ratio1 = Max_Random_Value1 / Min_Random_Value1;
                Min_Ratio1 = 1.0 / Max_Ratio1;

                if ((Min_Ratio1 < 1 / 9.0) || (Max_Ratio1 > 9.0))
                { goto Label1; };

                // *** We build the RCP matrix now!  ****************
                for (i = 1; i <= N; i++)
                {  // begin for i-loop ***
                    for (j = 1; j <= N; j++)
                    {  // begin for j-loop ***
                        RCP_Matrix1[i, j] = Real_Values_of_the_Alternatives[i] / Real_Values_of_the_Alternatives[j];
                    }; // *** end for j-loop ***
                }; // *** end for i-loop ***

                // *** Get the normalized priority vector <Priority_Vector0> now!  *** 
                Summation1 = 0.0; // *** Initialization ***

                // *** We first add them up and after that we normalize by dividing by their sum ***
                for (i = 1; i <= N; i++)
                {
                    Summation1 = Summation1 + Real_Values_of_the_Alternatives[i];
                };

                // **************************
                // *** Normalize them now ***
                for (i = 1; i <= N; i++)
                {
                    //Priority_Vector0[i] = Real_Values_of_the_Alternatives[i] / Summation1;
                    Priority_VectorV0[i] = Real_Values_of_the_Alternatives[i] / Summation1;
                };

            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************


       
        // *********************************************************************************************************************
        class Derive_CDP_Matrix_from_RCP_Matrix1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i, j;

            public void Derive_CDP_Matrix_from_RCP_Matrix1 (int Size1, double[,] RCP_Matrix1, out double [,] CDP_Matrix1)
            { // *** Begin Method *** 
                double True_Value1, Saaty_Value1;

                CDP_Matrix1 = new double [30,30];

                MainProgram pr1 = new MainProgram();  // *** Creating a class Object ***


                // ---->  NEEDS TO BE VALIDATED <---------------


                // *** We build the CDP matrix now!  ****************
                for (i = 1; i <= Size1; i++)
                {  // begin for i-loop ***
                    for (j = 1; j <= Size1; j++)
                    {  // begin for j-loop ***

                        True_Value1 = RCP_Matrix1[i, j];

                        // *** Use that approximating function here!!!!!!!!!!!!!!!
                        Saaty_Value1 = pr1.Approximate_Using_Saaty_Scale1(True_Value1);
                        CDP_Matrix1[i, j] = Saaty_Value1;
                    }; // *** end for j-loop ***
                }; // *** end for i-loop ***

            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************



        // *********************************************************************************************************************
        class Explore_a_Single_RCP_Matrix1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i, j, i_max;

            public void Explore_a_Single_RCP_Matrix1(int Size1, double[,] RCP_Matrix1, double[] Priority_Vector_V0, out double[,] Single_Pertrubed_PC_Matrix2, out double RRatio1, out double RRatio2, out double RRatio3)
            { // *** Begin Method *** 

                double[,] Single_Pertrubed_PC_Matrix1;
                double[,] CDP_Matrix0;
                double[,] CDP_Matrix1;
                double[,] Matrix_A;
                double[,] Matrix_B;

                double[] Priority_Vector1, Priority_Vector2;

                double[] Priority_VectorVi;
                Single_Pertrubed_PC_Matrix2 = new double[30, 30];
                double Difference_Vectors01, Difference_Vectors0i, Difference_Vectors1i;
                double Difference_Matrices01, Difference_Matrices0i, Difference_Matrices1i;
                double RatioV0i, RatioV1i, RatioM0i, RatioM1i;
                double Consistency_Value1;
                int No_of_RP_Cases1;
                string Output_Pertrubation_Results_File;
                int[] Ranking_Ri;
                int[] Ranking_R0;
                int[] Ranking_R1;
                int[] Ranking_R2; 

                Ranking_Ri = new int[30];
                Ranking_R0 = new int[30];
                Ranking_R1 = new int[30];
                Ranking_R2 = new int[30];   

                int[] Ranking_Simulated1;
                Ranking_Simulated1 = new int[30];

                int[] Sum_Ri;
                Sum_Ri = new int[30];

                double[] Sum_Vi;
                Sum_Vi = new double[30];

                double [] Sim_Vector1;
                Sim_Vector1 = new double[30];

                double Difference_Sim01, Difference_Sim02;

                double Diff_Sim02, Difference_Sim22; 
                //... , RRatio2;



                // **********************************
                // *** Object declaration section ***
                // **********************************
                Get_a_Random_Single_Petrubed_PC_Matrix1_Demo object1 = new Get_a_Random_Single_Petrubed_PC_Matrix1_Demo();
                Derive_The_Relative_Priorities_from_PC_Matrix1_Demo object2 = new Derive_The_Relative_Priorities_from_PC_Matrix1_Demo();
                Determine_Distance_Between_Two_Priority_Vectors1_Demo object3 = new Determine_Distance_Between_Two_Priority_Vectors1_Demo();
                Determine_Normalized_Distance_Between_Two_PC_Matrices1_Demo object4 = new Determine_Normalized_Distance_Between_Two_PC_Matrices1_Demo();
                Derive_CDP_Matrix_from_RCP_Matrix1_Demo object5 = new Derive_CDP_Matrix_from_RCP_Matrix1_Demo();
                
                Scan_Pairwise_Matrix_for_Reciprocity_Violations1_Demo object7 = new Scan_Pairwise_Matrix_for_Reciprocity_Violations1_Demo();
                Copy_PC_Matrix1_Demo object8 = new Copy_PC_Matrix1_Demo();
                Determine_Matrix_Consistency1_Demo object9 = new Determine_Matrix_Consistency1_Demo();
                Derive_The_Rankings_from_Priority_Vector1_Demo object10 = new Derive_The_Rankings_from_Priority_Vector1_Demo();
                Derive_Two_CDP_Matrices_from_Single_CDP_Matrix1_Demo object11 = new Derive_Two_CDP_Matrices_from_Single_CDP_Matrix1_Demo();


                // ********************************************************************************************
                // *** The Output file can be found as follows:                                             ***
                // *** From th emain folder with this application go to: bib/Debug/net6.0/MyProjectFiles1   *** 
                // *** You will find it there!                                                              ***
                // ********************************************************************************************
                Output_Pertrubation_Results_File = @"MyProjectFiles1\OUTPUT Pertrubation Study1.TXT";
                System.IO.StreamWriter file1 = new System.IO.StreamWriter(Output_Pertrubation_Results_File);


                // ---->  NEEDS TO BE VALIDATED <---------------


                file1.WriteLine(" ************************************************ ");
                file1.WriteLine(" We store here some results regarding our new CDP pertrubation study.  ");
                file1.WriteLine(" That is, the Monte Carlo Simulation idea!");
                file1.WriteLine(" ************************************************ ");
                file1.WriteLine();
                file1.WriteLine("  <i>    Consistency_Value1        RatioV0i  RatioV1i           RatioM0i  RatioM1i  ");
                file1.WriteLine();
                file1.WriteLine();

                object5.Derive_CDP_Matrix_from_RCP_Matrix1(Size1, RCP_Matrix1, out CDP_Matrix0);

                object11.Derive_Two_CDP_Matrices_from_Single_CDP_Matrix1(CDP_Matrix0, Size1, out Matrix_A, out Matrix_B);
                object2.Derive_The_Relative_Priorities_from_PC_Matrix1(Matrix_A, Size1, out Priority_Vector2);
                object10.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector2, Size1, out Ranking_R2);

                double Diff_Real_and_Saaty1;

                object3.Determine_Distance_Between_Two_Priority_Vectors1(Priority_Vector_V0, Priority_Vector2, Size1, out Diff_Real_and_Saaty1);


                object7.Scan_Pairwise_Matrix_for_Reciprocity_Violations1(CDP_Matrix0, Size1, out No_of_RP_Cases1);

                object2.Derive_The_Relative_Priorities_from_PC_Matrix1(RCP_Matrix1, Size1, out Priority_Vector_V0);
                object10.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector_V0, Size1, out Ranking_R0);









                object2.Derive_The_Relative_Priorities_from_PC_Matrix1(CDP_Matrix1, Size1, out Priority_Vector1);
                object10.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector1, Size1, out Ranking_R1);


                double Diff_Real_and_CDP1;
                object3.Determine_Distance_Between_Two_Priority_Vectors1(Priority_Vector_V0, Priority_Vector1, Size1, out Diff_Real_and_CDP1);
                
                object4.Determine_Normalized_Distance_Between_Two_PC_Matrices1(Size1, RCP_Matrix1, CDP_Matrix1, out Difference_Matrices01);

                // *** Start the recording / reporting process now! ***
                //... Console.WriteLine("  <i>    Consistency_Value1      RatioV0i  RatioV1i           RatioM0i  RatioM1i  ");

                // ***********************************************
                // *** This is for the main iterations section ***
                // ***********************************************

                // *******************************************************************
                // *** Initialize the rankings so I can get cumulative results now ***

                for (j = 1; j <= Size1; j++)
                {
                    Sum_Ri[j] = 0; // *** Initialziation ***
                };


                for (j = 1; j <= Size1; j++)
                {
                    Sum_Vi[j] = 0.0; // *** Initialziation ***
                };





                i_max = 1000;  // *** Maximum number of iterations ***

                for (i = 1; i <= i_max; i++)
                { // *** begin <for i-loop> 
                    // ******************************************************************************************************************  
                    // *** IMPORTANT NOTE!   We consider new PC matrices which are (small) perturbations of the initial CDP matrix!   ***
                    // *** This will give us th eopportunity to study the efficacy of the proposed Monte Carluo simulation approach.  ***
                    object1.Get_a_Random_Single_Petrubed_PC_Matrix1(Size1, Priority_Vector1, out Single_Pertrubed_PC_Matrix1);


                    object9.Determine_Matrix_Consistency1(Size1, Single_Pertrubed_PC_Matrix1, out Consistency_Value1);


                    object2.Derive_The_Relative_Priorities_from_PC_Matrix1(Single_Pertrubed_PC_Matrix1, Size1, out Priority_VectorVi);
                    object10.Derive_The_Rankings_from_Priority_Vector1(Priority_VectorVi, Size1, out Ranking_Ri);


                    for (j = 1; j <= Size1; j++)
                    {
                     //   Console.WriteLine("  j ---> " + j + "  Ri = " + Ranking_Ri[j]);
                    };



                    for (j = 1; j <= Size1; j++)
                    {
                        Sum_Ri[j] = Sum_Ri[j] + Ranking_Ri[j];
                    };



                    object3.Determine_Distance_Between_Two_Priority_Vectors1(Priority_Vector_V0, Priority_VectorVi, Size1, out Difference_Vectors0i);
                    object4.Determine_Normalized_Distance_Between_Two_PC_Matrices1(Size1, RCP_Matrix1, Single_Pertrubed_PC_Matrix1, out Difference_Matrices0i);



                    for (j = 1; j <= Size1; j++)
                    {
                        Sum_Vi[j] = Sum_Vi[j] + Priority_VectorVi[j];
                    };



                    object3.Determine_Distance_Between_Two_Priority_Vectors1(Priority_Vector1, Priority_VectorVi, Size1, out Difference_Vectors1i);
                    object4.Determine_Normalized_Distance_Between_Two_PC_Matrices1(Size1, CDP_Matrix1, Single_Pertrubed_PC_Matrix1, out Difference_Matrices1i);

                   // RatioV0i = Difference_Vectors0i / Difference_Vectors01;
                   // RatioM0i = Difference_Matrices0i / Difference_Matrices01;

                  //  RatioV1i = Difference_Vectors1i / Difference_Vectors01;
                  //  RatioM1i = Difference_Matrices1i / Difference_Matrices01;

                    //Console.WriteLine("   i ---> " + i + "  " + Consistency_Value1 + "        " + RatioV0i + "  " + RatioV1i + "         " + RatioM0i + "  " + RatioM1i);
                   // file1.WriteLine("   " + i + "  " + Consistency_Value1 + "       " + RatioV0i + "  " + RatioV1i + "         " + RatioM0i + "  " + RatioM1i);

                }; // *** end <for i-loop>  



                for (j = 1; j <= Size1; j++)
                {
                    Ranking_Ri[j] = Sum_Ri[j];
                };


                for (j = 1; j <= Size1; j++)
                {
                    Sim_Vector1[j] = Sum_Vi[j] / (i_max * 1.0);
                };

                object10.Derive_The_Rankings_from_Priority_Vector1(Sim_Vector1, Size1, out Ranking_Simulated1);


                object3.Determine_Distance_Between_Two_Priority_Vectors1(Priority_Vector_V0, Priority_Vector1, Size1, out Difference_Sim01);
                object3.Determine_Distance_Between_Two_Priority_Vectors1(Priority_Vector_V0, Sim_Vector1, Size1,      out Difference_Sim02);

                //... double RRatio1, RRatio3;

               

                //... Console.WriteLine();
               
                //... Console.WriteLine(" **************************");
                //... Console.WriteLine("  A debugging dump ");
                for (i = 1; i <= Size1; i++)
                {
                   // Console.WriteLine("  i ---> " + i + "  Weight V0 = " + Priority_Vector_V0[i] + "  Rank_R0 = " + Ranking_R0[i] + "  Weight V1 = " + Priority_Vector1[i] + "  Rank_R1 = " + Ranking_R1[i] + "   Rank_Ri = " + Sum_Ri[i]);
                //...     Console.WriteLine((" i --> " + i + " Weight V0 = " + Priority_Vector_V0[i] + " Rank_R0 = " + Ranking_R0[i] + " Weight (Saaty) V2 = " + Priority_Vector2[i] + " Weight V1 = " + Priority_Vector1[i] + " Rank_R1 = " + Ranking_R1[i] + "  Sm Weight Vi = " + Sim_Vector1[i] + " Sm_Rank = " + Ranking_Simulated1[i] + "  Saty Rank = ", Ranking_R2[i]));
                      
                };

                //... Console.WriteLine();
                //... Console.Write(("   Diff Real w. CDP Vector1 ==> ", Diff_Real_and_CDP1, "   Diff Real w. Simulation Results ==> ", Difference_Sim02, "   Diff Real w. Saaty PC Matrix ==> ", Diff_Real_and_Saaty1 ));
                //... Console.WriteLine(); //... Console.WriteLine(); 
                //... Console.Write(String.Format("    RRatio1 = (CDP approach ) / (vector from simulation)  = {0:0.0000} ", RRatio1));
                //... Console.Write(String.Format("   RRatio2 = (Saaty's vector) / (CDP approach) = {0:0.0000} ", RRatio2));
                //... Console.Write(String.Format("   RRatio3 = (Saaty's vector) / (vector from simulation) = {0:0.0000} ", RRatio3 ));
                //... Console.WriteLine(); //... Console.WriteLine(); 

            


                //...  Console.WriteLine(" **************************" ) ;


                file1.WriteLine(" ************************************************ ");
                file1.Close();

            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************



        // *********************************************************************************************************************
        class Determine_Normalized_Distance_Between_Two_PC_Matrices1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i, j;
            private double Sum_of_SQ_Differences, Single_Difference1;

            public void Determine_Normalized_Distance_Between_Two_PC_Matrices1(int Size1, double[,] PC_Matrix1, double[,] PC_Matrix2, out double Normalized_Distance1)
            { // *** Begin Method *** 


                // ---->  NEEDS TO BE VALIDATED <---------------



                Sum_of_SQ_Differences = 0.0;
                Normalized_Distance1 = -99.99;  // <----- kill it when done!

                for (i = 1; i <= Size1; i++)
                {
                    for (j = 1; j <= Size1; j++)
                    {
                        Single_Difference1 = (PC_Matrix1[i, j] - PC_Matrix2[i, j]);
                        Sum_of_SQ_Differences = Sum_of_SQ_Differences + (Single_Difference1 * Single_Difference1);  // *** Add the SQuared difference to the sum! ***
                    };
                };

                // ********************** 
                // *** Normalize now! ***
                Normalized_Distance1 = Sum_of_SQ_Differences / (Size1 * Size1);

                // Normalized_Distance1 = Sum_of_SQ_Differences / ( ( (Size1 * (Size1 - 1))/2.0) ) ; // <----  IS THIS A BETTER APPROACH ??????

            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************



        // *********************************************************************************************************************
        class Determine_Matrix_Consistency1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i, j;
           

            public void Determine_Matrix_Consistency1(int Size1, double[,] PC_Matrix1, out double Consistency_Value1)
            { // *** Begin Method *** 


                // ---->  NEEDS TO BE VALIDATED <---------------


                //  --- NEEDS TO BE DEVELOPED <---------- 




                Consistency_Value1 = -99.0; // Kill it after done!
           
                // Normalized_Distance1 = Sum_of_SQ_Differences / ( ( (Size1 * (Size1 - 1))/2.0) ) ; // <----  IS THIS A BETTER APPROACH ??????

            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************



        // *********************************************************************************************************************
        class Get_a_Random_Single_Petrubed_PC_Matrix1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
          private int i, j;
          private double Old_Value1, New_Value1;
       
            // *********************************************************************************************************************
            public void Get_a_Random_Single_Petrubed_PC_Matrix1 (int Size1, double[] Priority_Vector_V1, out double [,] Pertrubed_PC_Matrix1)
            { // *** Begin Method *** 
                Pertrubed_PC_Matrix1 = new double[30, 30];
                double [,] Pertrubed_PC_Matrix0 = new double[30, 30];
                int No_of_RP_Cases1; 

                // **********************************
                // *** Object declaration section ***
                // **********************************
                
                Scan_Pairwise_Matrix_for_Reciprocity_Violations1_Demo object2 = new Scan_Pairwise_Matrix_for_Reciprocity_Violations1_Demo();
                Copy_PC_Matrix1_Demo object3 = new Copy_PC_Matrix1_Demo();
                Get_a_New_Random_Pertrubed_Single_Value1_Demo object4 = new Get_a_New_Random_Pertrubed_Single_Value1_Demo();



                // ---->  NEEDS TO BE VALIDATED <---------------


                for (i = 1; i <= Size1; i++)
                {
                    for (j = 1; j <= Size1; j++)
                    {
                        Old_Value1 = Priority_Vector_V1[i] / Priority_Vector_V1[j]; //Input_RCP_Matrix[i, j];
                        object4.Get_a_New_Random_Pertrubed_Single_Value1(Old_Value1, out New_Value1);

                        Pertrubed_PC_Matrix0[i, j] = New_Value1;

                    };
                };



            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************



        // *********************************************************************************************************************
        class Get_a_New_Random_Pertrubed_Single_Value1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i, j;

            public void Get_a_New_Random_Pertrubed_Single_Value1(double Old_Value1,  out double New_Value1)
            { // *** Begin Method *** 
                double u1, u2, Upper_Limit1, Lower_Limit1, Length1, Alpha_Percent1 ;
                double Random_Distance_from_Lower_Limit1;

                Alpha_Percent1 = 0.20;  // *** This i sthe radious (as a %) of the range of random perturbations I will consider.  

                Random rand = new Random();    //reuse this if you are generating many random doubles (real) numbers uniform in (0,1) ***




                // ---->  IT NEEDS TO BE VALIDATED <---------------


                Upper_Limit1 = Old_Value1 + (Alpha_Percent1 * Old_Value1) ;
                Lower_Limit1 = Old_Value1 - (Alpha_Percent1 * Old_Value1) ;
                Length1 = Upper_Limit1 - Lower_Limit1;

                u1 = rand.NextDouble();

                Random_Distance_from_Lower_Limit1 = u1 * Length1 ;
                u2 = Lower_Limit1 + Random_Distance_from_Lower_Limit1;

                New_Value1 = u2;
                
            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************


        // *********************************************************************************************************************
        class Explore_Saaty_Values_for_Key_Theorem_Paper2_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i, j, No_of_Iterations1, Indicator1;

            public void Explore_Saaty_Values_for_Key_Theorem_Paper2()
            { // *** Begin Method *** 
                double X1, Y1, U1, U2, Range1, Current_Point1, Step1;

                // ************************************ 
                // *** Object declarations section. ***
                // ************************************
                MainProgram pr = new MainProgram();  // *** Creating a class Object ***

                No_of_Iterations1 = 1000;
                Current_Point1 = 1/ 9.00;

                Range1 = 3.00 - 1 / 9.00;
                Step1 = Range1 / No_of_Iterations1;

                for (i=0; i<No_of_Iterations1; i++)
                {  // *** begin loop-i ***

                    U1 = Current_Point1;
                    // U2 = Current_Point1 * ((4.00 / 3.00) + 0.20);
                    U2 = Current_Point1 * ((4.00 / 3.00) + 0.0);

                    X1 = pr.Approximate_Using_Saaty_Scale1(U1);
                    Y1 = pr.Approximate_Using_Saaty_Scale1(U2);

                    Indicator1 = 0;
                    if (X1 == Y1)
                    {
                        Indicator1 = 1;
                        Console.WriteLine(" i --> " + i + " U1, U2 = " + U1 + " " + U2 + " X1, X2 = " + X1 + " " + Y1 + " Ind =======> " + Indicator1);
                    }
                    else
                    {
                        Console.WriteLine(" i --> " + i + " U1, U2 = " + U1 + " " + U2 + " X1, X2 = " + X1 + " " + Y1 + " Ind => " + Indicator1);
                    };

                    Current_Point1 = Current_Point1 + Step1;
                    // *** end loop-i *** 
                };






            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************


        // <<< These are methods for a new METHOD!  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        // *********************************************************************************************************************
        class Check_for_Different_Ranks1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i ;
            
            public void Check_for_Different_Ranks1(int Size1, int [] Rank_Vector1, out int KAnswer1)
            { // *** Begin Method *** 
                // ****************************************************************************************** 
                // *** This method checks whether my Rank_Vector1 has multiple DIFFERENT ranks.           ***
                // *** That is, ranks that not all are equal to 1                                         ***
                // *** My output variable is assigned 0 or 1 as follows:                                  ***
                // ***      <KAnswer1> = 0   <==> All ranks are equal to each other.  That is, equal to 1 ***
                // ***      <KAnswer1> = 1, otherwise                                                     ***
                // ******************************************************************************************

                KAnswer1 = 0;  // *** the deafault value is no different ranking occurs.  All rankings are identical (i.e., equal to 1) ***

                // ---->  NEEDS TO BE VALIDATED <---------------

                for (i=1; i<=Size1; i++)
                {
                    if (Rank_Vector1[i] != 1)
                    {  // *** I have at least one rank that is different than <1>.  THis is equevalent to NOT having all the ranks equal to <1> ***
                        KAnswer1 = 1;
                        goto EXIT1;
                    };
                };

            EXIT1: i = 99; // *** a dummy statement ***

            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************


        // *********************************************************************************************************************
        class Check_for_Multiple_Identical_Ranks1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i;

            public void Check_for_Multiple_Identical_Ranks1(int Size1, int[] Rank_Vector1, out int KAnswer1)
            { // *** Begin Method *** 
                // ****************************************************************************************** 
                // *** This method checks whether my Rank_Vector1 has multiple IDENTICAL ranks.           ***
                // *** That is, ranks that not all are equal to 1                                         ***
                // *** My output variable is assigned 0 or 1 as follows:                                  ***
                // ***      <KAnswer1> = 1   <==> I have multiple IDENTICAL ranks                         ***
                // ***      <KAnswer1> = 0, otherwise <==> I do not have any multiple IDENTICAL ranks     ***
                // ******************************************************************************************

                KAnswer1 = 1;  // *** the deafault value is that I have some multiple IDENTICAL ranks  ***

                // ---->  NEEDS TO BE VALIDATED <---------------

                for (i = 1; i <= Size1; i++)
                {
                    if (Rank_Vector1[i] == Size1)
                    {  // *** I have all ranks!  All are different of each other   ***
                        KAnswer1 = 0;  // *** There are NO multiple IDENTICAL ranks  *** 
                        goto EXIT1;
                    };
                };

            EXIT1: i = 99; // *** a dummy statement ***

            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************


        // *********************************************************************************************************************
        class Determine_Index_of_ViolationLevel_of_Clustering_Trianta_Yanase_Condition1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i;

            public void Determine_Index_of_ViolationLevel_of_Clustering_Trianta_Yanase_Condition1(double Max_Difference1, double Min_Difference, out double Index1)
            { // *** Begin Method *** 
              // ****************************************************************************************** 
              // *** This method determines the Index1 value.  The higher it is, the most severe the    ***
              // *** <trianta_yanase Condition> is violated!                                            ***
              // *** We avoid to divide by zero and assign a code value in such cases, if they occur.   ***
              // ******************************************************************************************

                // ---->  NEEDS TO BE VALIDATED <---------------


                Index1 = -9.0; // a dummy statement 

                if (Min_Difference == 0.0)
                {
                    // *** We have <Min_Difference1> = 0.  We cannot divide by 0!   Assign the code value <Index1> = - 999.0 and get out! ***
                    Index1 = -999.0;
                    goto EXIT1;
                };
                
                Index1 = Max_Difference1 / Min_Difference;

            EXIT1: i = 99; // *** a dummy statement ***

            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************



        // *********************************************************************************************************************
        class Determine_Min_Difference_Across_Itens_Ranked_Differently1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i, i1, j;

            public void Determine_Min_Difference_Across_Itens_Ranked_Differently1(int Size1, int[] Rank_Vector1, double [] Weights_Vector0 , out double Min_Difference1)
            { // *** Begin Method *** 
                double Difference1, Percent_Difference1, Min_Weight1;
              // ****************************************************************************************** 
              // *** This method checks whether my Rank_Vector1 has multiple IDENTICAL ranks.           ***




                // ******************************************************************************************



                // ---->  NEEDS TO BE VALIDATED <---------------

                Min_Difference1 = + 9999.0 ; // *** Initialization to a rediculously large positive value *** 


                for (i = 1; i < Size1; i++)
                {
                    i1 = i + 1;
                    for (j = i1; j <= Size1; j++)
                    { 
                        if (Rank_Vector1[i] != Rank_Vector1 [j])
                        {
                            // ................. 
                            // *** The ranks of items <i> and <j> are DIFFERENT!  Thus, determine the % (percent) difference in their weights!  ***
                            Min_Weight1 = Weights_Vector0[i];
                            if (Weights_Vector0[j] < Weights_Vector0[i])
                            {
                                Min_Weight1 = Weights_Vector0[j];
                            };

                            Difference1 = Math.Abs(Weights_Vector0[i] - Weights_Vector0[j]); // *** We take the absolute value of the difference! 
                            Percent_Difference1 = ((100.00 * Difference1) / Min_Weight1);
                            if (Percent_Difference1 < Min_Difference1)
                            {
                                Min_Difference1 = Percent_Difference1; // *** Update the current value of <Min_Difference1> ***
                            }

                            // ..................
                            // *** Th eranks of items <i> and <j> are different!  Thus, determine the difference in their weights!  ***

                            //Difference1 = Math.Abs(Weights_Vector0[i] - Weights_Vector0[j]); // *** We take the absolute value of the difference! 
                            //if (Difference1 < Min_Difference1)
                            //{
                            //    Min_Difference1 = Difference1; // *** Update the current value of <Min_Difference1> ***
                            //}
                        };
                    }; // *** end of <j-loop> ***
                }; // *** end of <i-loop> ***

            //EXIT1: i = 99; // *** a dummy statement ***

            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************




        // *********************************************************************************************************************
        class Determine_Max_Difference_Between_Items_Ranked_Identically1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i, i1, j;

            public void Determine_Max_Difference_Between_Items_Ranked_Identically1(int Size1, int[] Rank_Vector1, double[] Weights_Vector0, out double Max_Difference1)
            { // *** Begin Method *** 
                double Difference1, Percent_Difference1, Min_Weight1;
                // ****************************************************************************************** 
                // *** This method checks whether my Rank_Vector1 has multiple IDENTICAL ranks.           ***


                // ******************************************************************************************


                // ---->  NEEDS TO BE VALIDATED <---------------

                Max_Difference1 = -9999.0; // *** Initialization to a rediculously negative value *** 


                for (i = 1; i < Size1; i++)
                {
                    i1 = i + 1;
                    for (j = i1; j <= Size1; j++)
                    {
                        if (Rank_Vector1[i] == Rank_Vector1[j])
                        {
                            // *** The ranks of items <i> and <j> are IDENTICAL!  Thus, determine the % (percent) difference in their weights!  ***
                            Min_Weight1 = Weights_Vector0 [i];
                            if (Weights_Vector0 [j] < Weights_Vector0[i])
                            {
                                Min_Weight1 = Weights_Vector0[j];
                            };

                            Difference1 = Math.Abs(Weights_Vector0[i] - Weights_Vector0[j]); // *** We take the absolute value of the difference! 
                            Percent_Difference1 = ( (100.00 * Difference1) / Min_Weight1) ; 
                            if (Percent_Difference1 > Max_Difference1)
                            {
                                Max_Difference1 = Percent_Difference1; // *** Update the current value of <Min_Difference1> ***
                            }
                        };
                    }; // *** end of <j-loop> ***
                }; // *** end of <i-loop> ***

           // EXIT1: i = 99; // *** a dummy statement ***

            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************




        // *********************************************************************************************************************
        class Explore_Violations_of_Clustering_Trianta_Yanase_Condition1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i, i1, j;

            public void Explore_Violations_of_Clustering_Trianta_Yanase_Condition1()
            { // *** Begin Method *** 
                double[,] CDP_Matrix1;
                int i, j, N, Nmax, Nmin, Max_Number_of_Iterations1;
                double[] Priority_Vector0;
                double[] Priority_Vector1;
                int[] Ranking_Vector1;
                int KAnswer1, KAnswer2;

                double Max_Difference1, Min_Difference1, Index1, Max_Index1;
                double Special_Max_Difference1, Special_Min_Difference1;
                double[] Special_Vector0 = new double[30];
                double[] Special_Vector1 = new double[30];
                int[] Special_Rankings1 = new int[30];

                double[,] Special_CDP_Matrix1 = new double[30, 30];
                double Average_Index1, Summary1, Frequency1;
                int K, KCounter1;

                string Output_Study9_the_Trianta_Test1_File1;
                string Output_Study9_the_Trianta_Test1_File2;
                string Output_Study9_the_Trianta_Test1_File3;


                // ******************************************************************************************************************************** 
                // *** This method explores how frequently and how severey this new type of ranking abnormality occurs on random test problems. ***
                // *** For a given problem size (with N = 2, 3, 4, ..., 20) it considers a random test problem.  That is, first a random weight ***
                // *** problem, then the RCP and the CDP matrix.  After that, it checks what is happening with the way the entities have been   ***
                // *** ranked.  In other words, do we have entities that in reality are different and then are grouped together and at the same ***
                // *** time, do we have entities that in reality are very similar but are grouped differently?  If the answer to these 2        ***
                // *** is "YES", then we record such case for the frequency counter and also compute the <Index1> value for the level of        ***
                // *** severity this phenomenon takes place.                                                                                    ***
                // ********************************************************************************************************************************



                // ---->  NEEDS TO BE VALIDATED <---------------

                // ************************************ 
                // *** Object declarations section. ***
                // ************************************
                Generate_a_Random_CDP_Matrix1_Demo object1 = new Generate_a_Random_CDP_Matrix1_Demo();
                Derive_The_Relative_Priorities_from_PC_Matrix1_Demo object2 = new Derive_The_Relative_Priorities_from_PC_Matrix1_Demo();
                Derive_The_Rankings_from_Priority_Vector1_Demo object3 = new Derive_The_Rankings_from_Priority_Vector1_Demo();

                Check_for_Different_Ranks1_Demo object4 = new Check_for_Different_Ranks1_Demo();
                Check_for_Multiple_Identical_Ranks1_Demo object5 = new Check_for_Multiple_Identical_Ranks1_Demo();
                Determine_Max_Difference_Between_Items_Ranked_Identically1_Demo object6 = new Determine_Max_Difference_Between_Items_Ranked_Identically1_Demo();
                Determine_Min_Difference_Across_Itens_Ranked_Differently1_Demo object7 = new Determine_Min_Difference_Across_Itens_Ranked_Differently1_Demo();
                Determine_Index_of_ViolationLevel_of_Clustering_Trianta_Yanase_Condition1_Demo object8 = new Determine_Index_of_ViolationLevel_of_Clustering_Trianta_Yanase_Condition1_Demo();

                Copy_Vector1_Demo object9 = new Copy_Vector1_Demo();
                Copy_INT_Vector1_Demo object10 = new Copy_INT_Vector1_Demo();
                Copy_PC_Matrix1_Demo object11 = new Copy_PC_Matrix1_Demo();



                MainProgram pr1 = new MainProgram();  // *** Creating a class Object ***

                // *******  End of object declarations *************************************


                Output_Study9_the_Trianta_Test1_File1 = @"MyProjectFiles1\OUTPUT Study9 the Trianta Test1 File1.TXT";
                System.IO.StreamWriter file1 = new System.IO.StreamWriter(Output_Study9_the_Trianta_Test1_File1);
                //..................................  
                Output_Study9_the_Trianta_Test1_File2 = @"MyProjectFiles1\OUTPUT Study9 the Trianta Test1 File2.TXT";
                System.IO.StreamWriter file2 = new System.IO.StreamWriter(Output_Study9_the_Trianta_Test1_File2);
                //...................................
                Output_Study9_the_Trianta_Test1_File3 = @"MyProjectFiles1\OUTPUT Study9 the Trianta Test1 File3.TXT";
                System.IO.StreamWriter file3 = new System.IO.StreamWriter(Output_Study9_the_Trianta_Test1_File3);



                // *** later set them equal to 20 and 2, respectively
                // *** also, that Max_Number_of_Iterations set it to something huge later!

                Nmax = 20; // *** Initialize these 3 values
                Nmin = 3;
                Max_Number_of_Iterations1 = 1000;  // THIS VALUE WILL CHANGE TO A LARGE POSITIVE INTEGER LATER!  Say, equal to 1 million? 

                // *** More initializations ******
                Special_Max_Difference1 = -9.0;
                Special_Min_Difference1 = -9.0;

                file1.WriteLine(" ***************************************************************** ");
                file1.WriteLine(" This is for Study1 that explores failures of the last Triantaphyllou ");
                file1.WriteLine(" Test1 on random test problems of various sizes  ");
                file1.WriteLine(" This the first of two files <File1> that has the summary statistics for my plots!  ");
                file1.WriteLine();
                file1.WriteLine(" Number of Iterations = " + Max_Number_of_Iterations1);
                file1.WriteLine();
                file1.WriteLine(" ***************************************************************** ");
                file1.WriteLine();
                file1.WriteLine(" N       Frequency          Average_Index1        Max_Index1 ");
                file1.WriteLine(" ***************************************************************** ");
                file1.WriteLine();


                file2.WriteLine(" ***************************************************************** ");
                file2.WriteLine(" This is for Study1 that explores failures of the last Triantaphyllou ");
                file2.WriteLine(" Test1 on random test problems of various sizes  ");
                file2.WriteLine(" This the second of two files <File2> that has the best example for each <N> value (size of vector)!");
                file2.WriteLine(" Good for demonstrating the severity of such failures!  ");
                file2.WriteLine();
                file2.WriteLine(" Number of Iterations = " + Max_Number_of_Iterations1);
                file2.WriteLine();
                file2.WriteLine(" ***************************************************************** ");
                file2.WriteLine();
                file2.WriteLine("    The Examples begin now!  ");
                file2.WriteLine(" ***************************************************************** ");
                file2.WriteLine();

                file3.WriteLine(" ***************************************************************** ");
                file3.WriteLine(" This is for Study1 that explores failures of the last Triantaphyllou ");
                file3.WriteLine(" Test1 on random test problems of various sizes  ");
                file3.WriteLine(" This the third file <File3> that has some <Index1> values for some sizes <N>. ");
                file3.WriteLine(" It is good for some sample histograms in the future.  The max values can be way too high!  ");
                file3.WriteLine(" We need this to gain a better understanding of how badly this test is violated!  ");
                file3.WriteLine();
                file3.WriteLine(" Number of Iterations = " + Max_Number_of_Iterations1);
                file3.WriteLine();
                file3.WriteLine(" ***************************************************************** ");
                file3.WriteLine();
                file3.WriteLine("    Values of:");
                file3.WriteLine("    N     i    KCounter1     <Index1>      <Max_Index1>  ");
                file3.WriteLine(" ***************************************************************** ");
                file3.WriteLine();


                for (N = Nmin; N <= Nmax; N++)
                { // *** begin <N-loop> 



                    Max_Index1 = -9.0; // Initialization with a deliberately low value! 
                    Summary1 = 0.0;
                    KCounter1 = 0;

                    for (i = 1; i <= Max_Number_of_Iterations1; i++)
                    { // *** begin <i-loop> 


                        object1.Generate_a_Random_CDP_Matrix1(N, out Priority_Vector0, out CDP_Matrix1);
                        object2.Derive_The_Relative_Priorities_from_PC_Matrix1(CDP_Matrix1, N, out Priority_Vector1);
                        object3.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector1, N, out Ranking_Vector1);
                        object4.Check_for_Different_Ranks1(N, Ranking_Vector1, out KAnswer1);
                        object5.Check_for_Multiple_Identical_Ranks1(N, Ranking_Vector1, out KAnswer2);

                        if ((KAnswer1 == 1) & (KAnswer2 == 1))
                        { // We have a new candidate case! Explore it!!!!
                            object6.Determine_Max_Difference_Between_Items_Ranked_Identically1(N, Ranking_Vector1, Priority_Vector0, out Max_Difference1);
                            object7.Determine_Min_Difference_Across_Itens_Ranked_Differently1(N, Ranking_Vector1, Priority_Vector0, out Min_Difference1);

                            object8.Determine_Index_of_ViolationLevel_of_Clustering_Trianta_Yanase_Condition1(Max_Difference1, Min_Difference1, out Index1);

                            if (Index1 >= 1)
                            {
                                KCounter1 = KCounter1 + 1;
                                Summary1 = Summary1 + Index1;
                                // Console.WriteLine(" i = " + i + "  KCounter1 ---> " + KCounter1 + " Summary1 = " + Summary1 + "  Index1 = " + Index1 + "  Max_Index1 = " + Max_Index1);
                                file3.WriteLine("  " + N + "   " + i + "      " + KCounter1 + "  " + Index1 + "     " + Max_Index1);

                            };

                            if (Index1 > Max_Index1)
                            {
                                Max_Index1 = Index1;
                                Special_Max_Difference1 = Max_Difference1;
                                Special_Min_Difference1 = Min_Difference1;
                                object11.Copy_PC_Matrix1(N, CDP_Matrix1, out Special_CDP_Matrix1);

                                for (K = 1; K <= N; K++)
                                {
                                    Special_Vector0[K] = Priority_Vector0[K];
                                    Special_Vector1[K] = Priority_Vector1[K];
                                    Special_Rankings1[K] = Ranking_Vector1[K];
                                };
                            };


                            goto Exit1;

                            // FOR DEBUGGING PURPOSES!!!!!
                            Console.WriteLine(" *********************************************** ");
                            pr1.Print_Pairwise_Matrix1(CDP_Matrix1, N);
                            Console.WriteLine("  ");
                            Console.WriteLine("  ");
                            Console.Write("  Max_Diff = " + Max_Difference1 + " Min_Diff = " + Min_Difference1 + " Index1 ===> " + Index1);
                            Console.WriteLine();
                            Console.WriteLine();
                            for (j = 1; j <= N; j++)
                            {
                                Console.WriteLine("  j --> " + j + " Vector0[j] = " + Priority_Vector0[j] + " Vector1[j] = " + Priority_Vector1[j] + "  Rank[j] = " + Ranking_Vector1[j]);

                            };

                            Console.WriteLine(" ************** End of Case ********************************* ");
                            Console.WriteLine();
                            Console.WriteLine();


                        }; // ** end <if> 

                    Exit1: j = 3; // a dummy statement to skip the printing /debugging part.


                    }; // *** end <i-loop> 

                    Frequency1 = ((100.0 * KCounter1) / (Max_Number_of_Iterations1 * 1.0));
                    Average_Index1 = (Summary1 / (KCounter1 * 1.0));

                    Console.WriteLine("  ");
                    Console.WriteLine();
                    Console.WriteLine(" ****** Beginning of a New Example ******************* ");
                    Console.WriteLine(" ************************************************************************ ");

                    Console.WriteLine();
                    Console.WriteLine("   N = " + N + "   Max_Index1 ----> " + Max_Index1);
                    Console.WriteLine("  Special_Max_Diff = " + Special_Max_Difference1 + "  Special_Min_Diff = " + Special_Min_Difference1);
                    Console.WriteLine();

                    file2.WriteLine("  ");
                    file2.WriteLine();
                    file2.WriteLine(" ****** Beginning of a New Example ******************* ");
                    file2.WriteLine(" ************************************************************************ ");


                    file2.WriteLine();
                    file2.WriteLine("   N = " + N + "   Max_Index1 ----> " + Max_Index1);
                    file2.WriteLine("  Special_Max_Diff = " + Special_Max_Difference1 + "  Special_Min_Diff = " + Special_Min_Difference1);
                    file2.WriteLine();

                    for (K = 1; K <= N; K++)
                    {
                        Console.WriteLine("  K ---> " + K + "  Vector0[K] = " + Special_Vector0[K] + "       Vector1[K] = " + Special_Vector1[K] + "     Ranking1[K] = " + Special_Rankings1[K]);
                        file2.WriteLine("  K ---> " + K + "  Vector0[K] = " + Special_Vector0[K] + "       Vector1[K] = " + Special_Vector1[K] + "     Ranking1[K] = " + Special_Rankings1[K]);
                    };

                    pr1.Print_Pairwise_Matrix1(Special_CDP_Matrix1, N);

                    Console.WriteLine();
                    Console.WriteLine(" N = " + N + " Frequency = " + Frequency1 + "   Average_Index1 = " + Average_Index1 + "      Max_Index1 = " + Max_Index1);
                    Console.WriteLine();
                    Console.WriteLine(" ****** End of Example ******************* ");
                    Console.WriteLine();

                    file2.WriteLine();
                    file2.WriteLine(" ****** End of Example ******************* ");
                    file2.WriteLine(" ************************************************************************ ");
                    file2.WriteLine();

                    file1.WriteLine("  " + N + "        " + Frequency1 + "       " + Average_Index1 + "          " + Max_Index1);

                    file3.WriteLine(" ************************************************************************ ");
                    file3.WriteLine();

                }; // *** end <N-loop>

                Console.WriteLine();
                Console.WriteLine(" Number of Iterations = " + Max_Number_of_Iterations1);
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine(" ************************* ");

                file1.WriteLine();
                file1.WriteLine(" ******* END OF THE EXPERIMENTS! ******************* ");
                file1.WriteLine();
                file1.WriteLine();

                file2.WriteLine();
                file2.WriteLine(" Number of Iterations = " + Max_Number_of_Iterations1);
                file2.WriteLine();
                file2.WriteLine();
                file2.WriteLine(" ******* END OF THE EXPERIMENTS! ******************* ");
                file2.WriteLine();
                file2.WriteLine();

                file3.WriteLine();
                file3.WriteLine();
                file3.WriteLine(" ******* END OF THE EXPERIMENTS! ******************* ");
                file3.WriteLine();

                file1.Close();
                file2.Close();
                file3.Close();


            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************




        // *********************************************************************************************************************
        class Explore_Violations_of_Clustering_Trianta_Yanase_Condition2_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i, i1, j;

            public void Explore_Violations_of_Clustering_Trianta_Yanase_Condition2()
            { // *** Begin Method *** 
                double[,] CDP_Matrix1;
                int i, j, N, Nmax, Nmin, Max_Number_of_Iterations1;
                double [] Priority_Vector0;
                double[] Priority_Vector1;
                int[] Ranking_Vector1;
                int KAnswer1, KAnswer2;

                double Max_Difference1, Min_Difference1, Index1, Max_Index1;
                double Special_Max_Difference1, Special_Min_Difference1;
                double[] Special_Vector0 = new double [30];
                double[] Special_Vector1 = new double [30];
                int[] Special_Rankings1 = new int [30];

                double[,] Special_CDP_Matrix1 = new double[30, 30];
                double Average_Index1, Summary1, Frequency1, Frequency2, Frequency3, Frequency4, Frequency5, Frequency6 ;
                int K, KCounter1, KCounter2, KCounter3, KCounter4, KCounter5, KCounter6;

                string Output_Study9a_the_Trianta_Test1_File1;
                string Output_Study9a_the_Trianta_Test1_File2;
                string Output_Study9a_the_Trianta_Test1_File3;


                // ******************************************************************************************************************************** 
                // *** This method explores how frequently this new type of ranking abnormality occurs on random test problems. ***
                // *** For a given problem size (with N = 2, 3, 4, ..., 20) it considers a random test problem.  That is, first a random weight ***
                // *** problem, then the RCP and the CDP matrix.  After that, it checks what is happening with the way the entities have been   ***
                // *** ranked.  In other words, do we have entities that in reality are different and then are grouped together?  We check for  ***
                // *** such occurencies when two entities ar egroiuped together and they differ in true weights by a preset percentage amount,  ***
                // *** say, 20%.   We will check different levels here.  This is for PAPER 2.                                                   ***
                // ********************************************************************************************************************************

                //  edw123

                // ---->  NEEDS TO BE VALIDATED <---------------

                // ************************************ 
                // *** Object declarations section. ***
                // ************************************
                Generate_a_Random_CDP_Matrix1_Demo object1 = new Generate_a_Random_CDP_Matrix1_Demo();
                Derive_The_Relative_Priorities_from_PC_Matrix1_Demo object2 = new Derive_The_Relative_Priorities_from_PC_Matrix1_Demo();
                Derive_The_Rankings_from_Priority_Vector1_Demo object3 = new Derive_The_Rankings_from_Priority_Vector1_Demo();

                Check_for_Different_Ranks1_Demo object4 = new Check_for_Different_Ranks1_Demo();
                Check_for_Multiple_Identical_Ranks1_Demo object5 = new Check_for_Multiple_Identical_Ranks1_Demo();
                Determine_Max_Difference_Between_Items_Ranked_Identically1_Demo object6 = new Determine_Max_Difference_Between_Items_Ranked_Identically1_Demo();
                Determine_Min_Difference_Across_Itens_Ranked_Differently1_Demo object7 = new Determine_Min_Difference_Across_Itens_Ranked_Differently1_Demo();
                Determine_Index_of_ViolationLevel_of_Clustering_Trianta_Yanase_Condition1_Demo object8 = new Determine_Index_of_ViolationLevel_of_Clustering_Trianta_Yanase_Condition1_Demo();
                
                Copy_Vector1_Demo object9 = new Copy_Vector1_Demo();
                Copy_INT_Vector1_Demo object10 = new Copy_INT_Vector1_Demo();
                Copy_PC_Matrix1_Demo object11 = new Copy_PC_Matrix1_Demo();



                MainProgram pr1 = new MainProgram();  // *** Creating a class Object ***

                // *******  End of object declarations *************************************


                Output_Study9a_the_Trianta_Test1_File1 = @"MyProjectFiles1\OUTPUT Study9a the Trianta Test1 File1.TXT";
                System.IO.StreamWriter file1 = new System.IO.StreamWriter(Output_Study9a_the_Trianta_Test1_File1);
                //..................................  
                Output_Study9a_the_Trianta_Test1_File2 = @"MyProjectFiles1\OUTPUT Study9a the Trianta Test1 File2.TXT";
                System.IO.StreamWriter file2 = new System.IO.StreamWriter(Output_Study9a_the_Trianta_Test1_File2);
                //...................................
                Output_Study9a_the_Trianta_Test1_File3 = @"MyProjectFiles1\OUTPUT Study9a the Trianta Test1 File3.TXT";
                System.IO.StreamWriter file3 = new System.IO.StreamWriter(Output_Study9a_the_Trianta_Test1_File3);



                // *** later set them equal to 20 and 2, respectively
                // *** also, that Max_Number_of_Iterations set it to something huge later!

                Nmax = 20; // *** Initialize these 3 values
                Nmin = 2;
                Max_Number_of_Iterations1 = 1000000;  // THIS VALUE WILL CHANGE TO A LARGE POSITIVE INTEGER LATER!  Say, equal to 1 million? 

                // *** More initializations ******
                Special_Max_Difference1 = -9.0;
                Special_Min_Difference1 = -9.0;

                file1.WriteLine(" ***************************************************************** ");
                file1.WriteLine(" This is for Study1 that explores failures of the last Triantaphyllou ");
                file1.WriteLine(" Test1 on random test problems of various sizes  ");
                file1.WriteLine(" This the first of two files <File1> that has the summary statistics for my plots!  ");
                file1.WriteLine();
                file1.WriteLine(" Number of Iterations = " + Max_Number_of_Iterations1);
                file1.WriteLine();
                file1.WriteLine(" ***************************************************************** ");
                file1.WriteLine();
                file1.WriteLine(" N    Freq1   Freq2     Freq3    Freq4    Freq5    Freq6  ");

                file1.WriteLine(" ***************************************************************** ");
                file1.WriteLine();



                file2.WriteLine(" ***************************************************************** ");
                file2.WriteLine(" This is for Study1 that explores failures of the last Triantaphyllou ");
                file2.WriteLine(" Test1 on random test problems of various sizes  ");
                file2.WriteLine(" This the second of two files <File2> that has the best example for each <N> value (size of vector)!");
                file2.WriteLine(" Good for demonstrating the severity of such failures!  ");
                file2.WriteLine();
                file2.WriteLine(" Number of Iterations = " + Max_Number_of_Iterations1);
                file2.WriteLine();
                file2.WriteLine(" ***************************************************************** ");
                file2.WriteLine();
                file2.WriteLine("    The Examples begin now!  ");
                file2.WriteLine(" ***************************************************************** ");
                file2.WriteLine();

                file3.WriteLine(" ***************************************************************** ");
                file3.WriteLine(" This is for Study1 that explores failures of the last Triantaphyllou ");
                file3.WriteLine(" Test1 on random test problems of various sizes  ");
                file3.WriteLine(" This the third file <File3> that has some <Index1> values for some sizes <N>. ");
                file3.WriteLine(" It is goodfor some sample histograms in the future.  The max values can be way too high!  "); 
                file3.WriteLine(" We need this to gain a better understanding of how badly this test is violated!  ");
                file3.WriteLine();
                file3.WriteLine(" Number of Iterations = " + Max_Number_of_Iterations1);
                file3.WriteLine();
                file3.WriteLine(" ***************************************************************** ");
                file3.WriteLine();
                file3.WriteLine("    Values of:");
                file3.WriteLine("    N     i    KCounter1     <Index1>      <Max_Index1>  ");
                file3.WriteLine(" ***************************************************************** ");
                file3.WriteLine();


                Console.WriteLine(" N    Freq1   Freq2     Freq3    Freq4    Freq5    F-Freq6  ");

                for (N = Nmin; N <= Nmax; N++)
                { // *** begin <N-loop> 

                    

                    KCounter1 = 0;
                    KCounter2 = 0;
                    KCounter3 = 0;
                    KCounter4 = 0;
                    KCounter5 = 0;
                    KCounter6 = 0;

                    for (i=1; i <= Max_Number_of_Iterations1; i++)
                    { // *** begin <i-loop> 


                     object1.Generate_a_Random_CDP_Matrix1(N, out Priority_Vector0, out CDP_Matrix1);
                     object2.Derive_The_Relative_Priorities_from_PC_Matrix1(CDP_Matrix1, N, out Priority_Vector1);
                     object3.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector1, N, out Ranking_Vector1);
                        //object4.Check_for_Different_Ranks1(N, Ranking_Vector1, out KAnswer1);
                        object5.Check_for_Multiple_Identical_Ranks1(N, Ranking_Vector1, out KAnswer2);

                        // if ( (KAnswer1 == 1) & (KAnswer2 == 1) )
                        if (KAnswer2 == 1)
                        { // We have a new candidate case! Explore it!!!!
                            object6.Determine_Max_Difference_Between_Items_Ranked_Identically1(N, Ranking_Vector1, Priority_Vector0, out Max_Difference1);

                            if (Max_Difference1 >= 5.0)
                            {
                                KCounter1 = KCounter1 + 1;
                            };

                            if (Max_Difference1 >= 10.0)
                            {
                                KCounter2 = KCounter2 + 1;
                            };

                            if (Max_Difference1 >= 15.0)
                            {
                                KCounter3 = KCounter3 + 1;
                            };

                            if (Max_Difference1 >= 20.0)
                            {
                                KCounter4 = KCounter4 + 1;
                            };

                            if (Max_Difference1 >= 25.0)
                            {
                                KCounter5 = KCounter5 + 1;
                            };

                            if (Max_Difference1 >= 30.0)
                            {
                                KCounter6 = KCounter6 + 1;
                            };


                        };
                    }; // *** end <i-loop> 


                    Frequency1 = ((100.0 * KCounter1) / (Max_Number_of_Iterations1 * 1.0));
                    Frequency2 = ((100.0 * KCounter2) / (Max_Number_of_Iterations1 * 1.0));
                    Frequency3 = ((100.0 * KCounter3) / (Max_Number_of_Iterations1 * 1.0));
                    Frequency4 = ((100.0 * KCounter4) / (Max_Number_of_Iterations1 * 1.0));
                    Frequency5 = ((100.0 * KCounter5) / (Max_Number_of_Iterations1 * 1.0));
                    Frequency6 = ((100.0 * KCounter6) / (Max_Number_of_Iterations1 * 1.0));

                    Console.WriteLine("  " + N + "   " + Frequency1 + "   " + Frequency2 + "   " + Frequency3 + "   " + Frequency4 + "   " + Frequency5 + "   " + Frequency6);

                    file1.WriteLine("  " + N + "   " + Frequency1 + "   " + Frequency2 + "   " + Frequency3 + "   " + Frequency4 + "   " + Frequency5 + "   " + Frequency6);

                    // Console.WriteLine();


                    goto Exit2;




                    Average_Index1 = (Summary1 / (KCounter1 * 1.0));

                    Console.WriteLine("  ");
                    Console.WriteLine();
                    Console.WriteLine(" ****** Beginning of a New Example ******************* ");
                    Console.WriteLine(" ************************************************************************ ");

                    Console.WriteLine(); 
                    Console.WriteLine("   N = " + N + "   Max_Index1 ----> " + Max_Index1 );
                    Console.WriteLine("  Special_Max_Diff = " + Special_Max_Difference1 + "  Special_Min_Diff = " + Special_Min_Difference1);
                    Console.WriteLine();

                    file2.WriteLine("  ");
                    file2.WriteLine();
                    file2.WriteLine(" ****** Beginning of a New Example ******************* ");
                    file2.WriteLine(" ************************************************************************ ");
                

                    file2.WriteLine(); 
                    file2.WriteLine("   N = " + N + "   Max_Index1 ----> " + Max_Index1);
                    file2.WriteLine("  Special_Max_Diff = " + Special_Max_Difference1 + "  Special_Min_Diff = " + Special_Min_Difference1);
                    file2.WriteLine();
                    
                    for (K=1; K<=N; K++)
                    {
                        Console.WriteLine("  K ---> " + K + "  Vector0[K] = " + Special_Vector0[K] + "       Vector1[K] = " + Special_Vector1[K] + "     Ranking1[K] = " + Special_Rankings1[K] );
                        file2.WriteLine("  K ---> " + K + "  Vector0[K] = " + Special_Vector0[K] + "       Vector1[K] = " + Special_Vector1[K] + "     Ranking1[K] = " + Special_Rankings1[K]);
                    };
                    
                    pr1.Print_Pairwise_Matrix1(Special_CDP_Matrix1, N);

                    Console.WriteLine();
                    Console.WriteLine(" N = " + N + " Frequency = " + Frequency1 + "   Average_Index1 = " + Average_Index1 + "      Max_Index1 = " + Max_Index1);
                    Console.WriteLine();
                    Console.WriteLine(" ****** End of Example ******************* ");
                    Console.WriteLine();

                    file2.WriteLine();
                    file2.WriteLine(" ****** End of Example ******************* ");
                    file2.WriteLine(" ************************************************************************ ");
                    file2.WriteLine();

                    file1.WriteLine("  " + N + "        " + Frequency1 + "       " + Average_Index1 + "          " + Max_Index1);

                    file3.WriteLine(" ************************************************************************ ");
                    file3.WriteLine();


                Exit2: j = 9; // a dummy statement! 


                }; // *** end <N-loop>

                Console.WriteLine();
                Console.WriteLine(" Number of Iterations = " + Max_Number_of_Iterations1);
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine(" ************************* ");

                file1.WriteLine();
                file1.WriteLine(" ******* END OF THE EXPERIMENTS! ******************* ");
                file1.WriteLine();
                file1.WriteLine();

                file2.WriteLine();
                file2.WriteLine(" Number of Iterations = " + Max_Number_of_Iterations1);
                file2.WriteLine();
                file2.WriteLine();
                file2.WriteLine(" ******* END OF THE EXPERIMENTS! ******************* ");
                file2.WriteLine();
                file2.WriteLine();

                file3.WriteLine();
                file3.WriteLine();
                file3.WriteLine(" ******* END OF THE EXPERIMENTS! ******************* ");
                file3.WriteLine();

                file1.Close();
                file2.Close(); 
                file3.Close(); 


            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************


        //......................................................................................
        
        
        // *********************************************************************************************************************
        class Get_a_New_Permutation1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
           private int i, j;

            public void Get_a_New_Permutation1(int Size1, out int [] New_Permutation1)
            { // *** Begin Method *** 
                New_Permutation1 = new int[30];


                // VALIDATE IT!!!

                // This is a dummy assignment.   It will berandom in the future

                New_Permutation1[1] = 4;
                New_Permutation1[2] = 2;
                New_Permutation1[3] = 3;
                New_Permutation1[4] = 1;

               //  goto Exit1 ;

                New_Permutation1[1] = 4;
                New_Permutation1[2] = 3;
                New_Permutation1[3] = 2;
                New_Permutation1[4] = 1;

                //goto Exit1;

                // Van:  The following permutation looks exhiting!!!!!!....
                New_Permutation1[1] = 4;
                New_Permutation1[2] = 1;
                New_Permutation1[3] = 3;
                New_Permutation1[4] = 2;

                // goto Exit1;

                New_Permutation1[1] = 4;
                New_Permutation1[2] = 3;
                New_Permutation1[3] = 1;
                New_Permutation1[4] = 2;

                New_Permutation1[1] = 1;
                New_Permutation1[2] = 2;
                New_Permutation1[3] = 4;
                New_Permutation1[4] = 3;

                New_Permutation1[1] = 1;
                New_Permutation1[2] = 4;
                New_Permutation1[3] = 2;
                New_Permutation1[4] = 3;


                New_Permutation1[1] = 2;
                New_Permutation1[3] = 4;
                New_Permutation1[3] = 1;
                New_Permutation1[4] = 3;


                New_Permutation1[1] = 3;
                New_Permutation1[2] = 2;
                New_Permutation1[3] = 4;
                New_Permutation1[4] = 1;


            Exit1: i = 9; // a dummy statement 

            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************
           //......................................................................................


        // *********************************************************************************************************************
        class Use_Permutation_to_Adjust_CDP_Matrix1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
          private int i, j, Pi, Pj;

            public void Use_Permutation_to_Adjust_CDP_Matrix1(int Size1, double [,] CDP_Matrix1, int [] Permutation1, out double [,] CDP_Matrix2)
            { // *** Begin Method *** 
                CDP_Matrix2 = new double [30, 30];

                // VALIDATE IT!!! Van:  It is seems to be OK!   QC passed? NOOOOOO!!!!!   ***

                // *** We form the new matrix now 
                for (i=1; i <= Size1; i++)
                {
                    for (j=1; j <= Size1; j++)
                    {
                            Pi = Permutation1 [i];
                            Pj = Permutation1 [j];

                        //    Pi = Permutation1 [j];
                        //    Pj = Permutation1 [i];


                        CDP_Matrix2[i,j] = CDP_Matrix1[Pi,Pj];
                    };
                };

            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************



        // *********************************************************************************************************************
        class Rearrange_Permuted_Rankings1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i, Pi;

            public void Rearrange_Permuted_Rankings1(int Size1, int [] Permutation1, int[] Rankings1, out int [] Rankings2)
            { // *** Begin Method *** 
                Rankings2 = new int [30];

                // VALIDATE IT!!! Van:  It is seems to be OK ???   QC passed? ***

                // *** We re-arrange the contents of Rankings1 to refelct the original vector *** 
                for (i = 1; i <= Size1; i++)
                {
                    Pi = Permutation1[i];
                    Rankings2 [i] = Rankings1[Pi];                
                };

            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************

        // *********************************************************************************************************************
        class Get_Random_Saaty_Vector2_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i, j;

            public void Get_Random_Saaty_Vector2(int Size1, out double[] Vector1)
            { // *** Begin Method *** 
                Vector1 = new double[30];

                // VALIDATE IT!!!  ***

                Vector1[1] = 0.0939;
                Vector1[2] = 0.4503;
                Vector1[3] = 0.3252;
                Vector1[4] = 0.1306;





                // Example #3 from PAPER 1 
                Vector1[1] = 0.1315;
                Vector1[2] = 0.3078;
                Vector1[3] = 0.2247;
                Vector1[4] = 0.3361;
                

            } // *** End   Method ***
        }; // *** End Class ***
        // *********************************************************************************************************************




        // *********************************************************************************************************************
        class Get_Random_Saaty_Vector1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 

            public void Get_Random_Saaty_Vector1(int N, out double [] Random_Saaty_Vector0)
            { // *** Begin Method *** 

                // **************************************
                // *** Variable declarations section. ***
                // **************************************
                int i, j;
                double u1, Min_Random_Value1, Max_Random_Value1, Max_Ratio1, Min_Ratio1;


                Random_Saaty_Vector0 = new double[30]; // <-------  VERY IMPORTANT TO DO THIS!!!!!!!!


                double[] Real_Values_of_the_Alternatives = new double[30];

                double True_Value1, Saaty_Value1;
                double Summation1;

                // *** end of the Variable declaration section. ****** 

                Random rand = new Random();    //reuse this if you are generating many random doubles (real) numbers uniform in (0,1) ***

                MainProgram pr1 = new MainProgram();  // *** Creating a class Object ***

            // *** Get N randmom values uniformly disributed in [0, 1] and load them in my array <Real_Values_of_the_Alternatives[] 

            Label1: for (i = 1; i <= N; i++)
                {  // begin for i-loop ***
                   // *** Recall that this is stated more above: double u1 = rand.NextDouble(); //these are uniform(0,1) random doubles
                    u1 = rand.NextDouble();
                    Real_Values_of_the_Alternatives[i] = u1;
                }; // *** end for i-loop ***

                // ***************************************************************************************************************************************
                // *** Now we need to find out if the ratio <Ratio_Max> of the Max such value divided by the Min such value is less than or equal to 9 ***
                // *** and the ratio <Ratio_Min> of the <1 / Ratio_MaxGet> is larger than or equal to 1/9                                              ***
                // *** Thus, first find the <Min_Random_Value1> and <Max_Random_Value1> values!                                                        ***
                // ***************************************************************************************************************************************

                // *** Some initializations now *********************************************      
                Min_Random_Value1 = 99.0; // *** An arbitrarily large value out of range ***
                Max_Random_Value1 = -99.0; // *** An arbitrarily samll value out of range ***

                for (i = 1; i <= N; i++)
                {  // begin for i-loop ***
                    if (Real_Values_of_the_Alternatives[i] >= Max_Random_Value1)
                    { Max_Random_Value1 = Real_Values_of_the_Alternatives[i]; };

                    if (Real_Values_of_the_Alternatives[i] <= Min_Random_Value1)
                    { Min_Random_Value1 = Real_Values_of_the_Alternatives[i]; };
                }; // *** end for i-loop ***
                Max_Ratio1 = Max_Random_Value1 / Min_Random_Value1;
                Min_Ratio1 = 1.0 / Max_Ratio1;

                if ((Min_Ratio1 < 1 / 9.0) || (Max_Ratio1 > 9.0))
                { goto Label1; };

                // *** Get the normalized priority vector <Priority_Vector0> now!  *** 
                Summation1 = 0.0; // *** Initialization ***

                // *** We first add them up and after that we normalize by dividing by their sum ***
                for (i = 1; i <= N; i++)
                {
                    Summation1 = Summation1 + Real_Values_of_the_Alternatives[i];
                };

                // **************************
                // *** Normalize them now ***
                for (i = 1; i <= N; i++)
                {
                    //Priority_Vector0[i] = Real_Values_of_the_Alternatives[i] / Summation1;
                    Random_Saaty_Vector0[i] = Real_Values_of_the_Alternatives[i] / Summation1;
                };

            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************







        // *********************************************************************************************************************
        class Form_CDP_Matrix1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i, j;

            public void Form_CDP_Matrix1(int Size1, double[,] RCP_Matrix1, out double[,] CDP_Matrix1)
            { // *** Begin Method *** 
                CDP_Matrix1 = new double[30, 30];
                double Current_Value1, Saaty_Value1;


                // VALIDATE IT!!!  ***

                MainProgram pr1 = new MainProgram();  // *** Creating a class Object ***

                for (i = 1; i <= Size1; i++)
                {
                    for (j = 1; j <= Size1; j++)
                    {
                        Current_Value1 = RCP_Matrix1[i, j];

                        // *** Use that approximating function here!!!!!!!!!!!!!!!
                        Saaty_Value1 = pr1.Approximate_Using_Saaty_Scale1(Current_Value1);
                        CDP_Matrix1[i, j] = Saaty_Value1 ;
                    };
                };

            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************


        // *********************************************************************************************************************
        class Form_RCP_Matrix1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i, j;

            public void Form_RCP_Matrix1(int Size1, double [] Vector1, out double[,] RCP_Matrix1)
            { // *** Begin Method *** 
                RCP_Matrix1 = new double[30,30];

                // VALIDATE IT!!!  ***


                for (i = 1; i <= Size1; i++)
                {
                    for (j=1; j <= Size1; j++)
                    {
                        RCP_Matrix1[i,j] = Vector1[i] / Vector1[j] ;                    
                    };
                };

            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************



        // *********************************************************************************************************************
        class Permutate_Real_Vector1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i, j, Pi, Pj;

            public void Permutate_Real_Vector1(int Size1, int[] Permutation1, double [] Vector1, out double [] Vector2)
            { // *** Begin Method *** 
                Vector2 = new double [30];

                // VALIDATE IT!!!  ***

                // *** We re-arrange the contents of Rankings1 to refelct the original vector *** 
                for (i = 1; i <= Size1; i++)
                {
                    Pi = Permutation1[i];
                    Vector2[i] = Vector1[Pi];
                };

            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************



        // *********************************************************************************************************************
        class Before_Permutation_Rankings_Vector1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i, j, Pi, Pj;

            public void Before_Permutation_Rankings_Vector1(int Size1, int[] Permutation1, int [] Rankings1, out int [] Rankings2)
            { // *** Begin Method *** 
                Rankings2 = new int [30];

                // VALIDATE IT!!!  ***

                // *** We re-arrange the contents of Rankings1 to refelct the original vector *** 
                for (i = 1; i <= Size1; i++)
                {
                    Pi = Permutation1[i];
                    Rankings2[Pi] = Rankings1[i];
                };

            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************















        //......................................................................................



        // ********************************************************************* 
        // *** This is for PAPER 3
        // ********************************************************************* 


        // *********************************************************************************************************************
        class Explore_Permutation_Impact_on_Rankings1_Demo
        { // *** Begin Class ***
          // *** Local variable declarations *** 
            private int i, k, i1, j;

            public void Explore_Permutation_Impact_on_Rankings1() 
            { // *** Begin Method *** 
                string Output_Saaty_Matrices_Contradictions_Analysis10_File;

                Output_Saaty_Matrices_Contradictions_Analysis10_File = @"MyProjectFiles1\OUTPUT Saaty Matrices Analysis10.TXT";
                System.IO.StreamWriter file1 = new System.IO.StreamWriter(Output_Saaty_Matrices_Contradictions_Analysis10_File);




                double[,] CDP_Matrix0 ;
                CDP_Matrix0 = new double [30, 30] ;

                double[,] CDP_Matrix1;
                CDP_Matrix1 = new double[30, 30];
                
                double[,] CDP_Matrix1A;
                double[,] CDP_Matrix1B;


                double[] Priority_Vector1;
                Priority_Vector1 = new double[30];

                double[] Priority_Vector2;
                Priority_Vector2 = new double[30];


                double[] Priority_Vector1A;
                Priority_Vector1A = new double [30]; 

                double [] Priority_Vector1B;
                Priority_Vector1B = new double [30];

                int [] Rankings1A; int [] Rankings1B;
                Rankings1A = new int[30]; 
                Rankings1B = new int[30];

                double[] Priority_Vector3A;
                Priority_Vector3A = new double[30];

                double[] Priority_Vector3B;
                Priority_Vector3B = new double[30];

                int[] Rankings3A; int[] Rankings3B;
                Rankings3A = new int[30];
                Rankings3B = new int[30];


                int[] New_Permutation1;
                New_Permutation1 = new int[30];

                double[,] Permutated_CDP_Matrix1;
                Permutated_CDP_Matrix1 = new double[30, 30];

                int[] Rankings1;
                Rankings1 = new int[30];

                int[] Rankings31;
                Rankings31 = new int[30];

                int[] Rankings2A;
                Rankings2A = new int[30];

                int[] Rankings2B;
                Rankings2B = new int[30];

                double[] Random_Vector1;
                Random_Vector1 = new double[30];

                double[] Permuted_Vector1;
                Permuted_Vector1 = new double[30];



                double[,] RCP_Matrix0;
                RCP_Matrix0 = new double[30, 30];

                double[,] RCP_Matrix1;
                RCP_Matrix1 = new double[30, 30];



                int N, Nmin, Nmax, Max_Iterations1 ;
                int KResult1, KResult2, KResult3, Sum1, Sum2, Sum3, Sum41, Sum42, Sum43;
                int KResult31, KResult32, KResult33, Sum31, Sum32, Sum33;
                double Average1, Average2, Average3;

                // ****************************************************************************************** 
                // VAN:  CHANGE THW WORDING NOW!!!

                // *** This method explores the impact different permutations may have on the rankings proposed by CDP matrices
                // *** It cannot consider all possible permutations, thus it samples.  Some may be considred multiple times.  
                // *** If the results ar einteresting, they can be part of PAPER 3 on the ranking groupings abnormality paper.    
                // ******************************************************************************************


                // ---->  NEEDS TO BE VALIDATED <---------------


                // ************************************ 
                // *** Object declarations section. ***
                // ************************************
                Generate_a_Random_CDP_Matrix1_Demo object1 = new Generate_a_Random_CDP_Matrix1_Demo();
                Derive_The_Relative_Priorities_from_PC_Matrix1_Demo object2 = new Derive_The_Relative_Priorities_from_PC_Matrix1_Demo();
                Derive_The_Rankings_from_Priority_Vector1_Demo object3 = new Derive_The_Rankings_from_Priority_Vector1_Demo();
                Derive_Two_CDP_Matrices_from_Single_CDP_Matrix1_Demo object4 = new Derive_Two_CDP_Matrices_from_Single_CDP_Matrix1_Demo();
                Get_a_New_Permutation1_Demo object5 = new Get_a_New_Permutation1_Demo();
                Use_Permutation_to_Adjust_CDP_Matrix1_Demo object6 = new Use_Permutation_to_Adjust_CDP_Matrix1_Demo();
                Rearrange_Permuted_Rankings1_Demo object7= new Rearrange_Permuted_Rankings1_Demo();

                Get_Random_Saaty_Vector1_Demo object8 = new Get_Random_Saaty_Vector1_Demo();
                Permutate_Real_Vector1_Demo object9 = new Permutate_Real_Vector1_Demo();
                Form_RCP_Matrix1_Demo object10 = new Form_RCP_Matrix1_Demo();
                Form_CDP_Matrix1_Demo object11 = new Form_CDP_Matrix1_Demo();
                Before_Permutation_Rankings_Vector1_Demo object12 = new Before_Permutation_Rankings_Vector1_Demo();
                Compare_Two_Rankings1_Demo object13 = new Compare_Two_Rankings1_Demo();




                MainProgram pr1 = new MainProgram();  // *** Creating a class Object ***
                // *** End of Object Declarations **********************

                // FOR DEBUGGING!!!!!!!! 
                // ................................................................ 
                // This is my testing CDP matrix.  It is from PAPER 1
                // other ones will be generated randomly etc....
                CDP_Matrix0[1, 1] = 1.0; CDP_Matrix0[1, 2] = 0.2; CDP_Matrix0[1, 3] = 0.25; CDP_Matrix0[1, 4] = 0.5;
                CDP_Matrix0[2, 1] = 5.0; CDP_Matrix0[2, 2] = 1.0; CDP_Matrix0[2, 3] = 1.00; CDP_Matrix0[2, 4] = 3.0;
                CDP_Matrix0[3, 1] = 3.0; CDP_Matrix0[3, 2] = 0.50; CDP_Matrix0[3, 3] = 1.00; CDP_Matrix0[3, 4] = 2.0;
                CDP_Matrix0[4, 1] = 1.0; CDP_Matrix0[4, 2] = 0.25; CDP_Matrix0[4, 3] = 1.00 / 3.00 ; CDP_Matrix0[4, 4] = 1.0;

                Nmin = 2;
                Nmax = 20;
                Max_Iterations1 = 1000000;
                //Max_Iterations1 = 1000;
                


                Console.WriteLine("  ");
                Console.WriteLine("  This file is the output of the study that explored the ranking differences ");
                Console.WriteLine("  between the two traditional Saaty matrices directly derived from a CDP matrix.");
                Console.WriteLine("  I used these results in my PAPER 3. ");
                Console.WriteLine("  ");
                Console.WriteLine("  Number of iterations = " + Max_Iterations1);
                Console.WriteLine("  N       Aver12      Aver3    The last 2 results are for disagreements on the TOP item ONLY!");
                Console.WriteLine(" ********************************************************************************** ");

                file1.WriteLine("  ");
                file1.WriteLine("  This file is the output of the study that explored the ranking differences ");
                file1.WriteLine("  between the two traditional Saaty matrices directly derived from a CDP matrix.");
                file1.WriteLine("  I used these results in my PAPER 3. ");
                file1.WriteLine("  ");
                file1.WriteLine("  Number of iterations = " + Max_Iterations1);
                file1.WriteLine("  N       Aver12      Aver3   The last 2 results are for disagreements on the TOP item ONLY! ");
                file1.WriteLine(" ********************************************************************************** ");


                for (N = Nmin; N <= Nmax; N++)
                {

                    Sum1 = 0;
                    Sum2 = 0;
                    Sum3 = 0;

                    Sum31 = 0;
                    Sum32 = 0;
                    Sum33 = 0;

                    Sum41 = 0;
                    Sum42 = 0;
                    Sum43 = 0;

                    for (k = 1; k <= Max_Iterations1; k++)
                    {

                        object8.Get_Random_Saaty_Vector1(N, out Random_Vector1);
                        object10.Form_RCP_Matrix1(N, Random_Vector1, out RCP_Matrix0);
                        object11.Form_CDP_Matrix1(N, RCP_Matrix0, out CDP_Matrix0);
                        object4.Derive_Two_CDP_Matrices_from_Single_CDP_Matrix1(CDP_Matrix0, N, out CDP_Matrix1A, out CDP_Matrix1B);



                        object2.Derive_The_Relative_Priorities_from_PC_Matrix1(CDP_Matrix0, N, out Priority_Vector1);
                        object3.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector1, N, out Rankings31);

                        object2.Derive_The_Relative_Priorities_from_PC_Matrix1(CDP_Matrix1A, N, out Priority_Vector3A);
                        object2.Derive_The_Relative_Priorities_from_PC_Matrix1(CDP_Matrix1B, N, out Priority_Vector3B);

                        object3.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector3A, N, out Rankings3A);
                        object3.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector3B, N, out Rankings3B);


                        object13.Compare_Two_Rankings1(Rankings31, Rankings3A, N, out KResult31);

                        object13.Compare_Two_Rankings1(Rankings31, Rankings3B, N, out KResult32);

                        object13.Compare_Two_Rankings1(Rankings3A, Rankings3B, N, out KResult33);





                        goto Label2;
                        
                        if (KResult33 == -9)
                        {
                            Console.WriteLine("   CDP_Matrix0 is here:");
                            pr1.Print_Pairwise_Matrix1(CDP_Matrix0, N);

                            Console.WriteLine("   CDP_Matrix1A is here:");
                            pr1.Print_Pairwise_Matrix1(CDP_Matrix1A, N);

                            Console.WriteLine("   CDP_Matrix1B is here:");
                            pr1.Print_Pairwise_Matrix1(CDP_Matrix1B, N);

                            for (i = 1; i <= N; i++)
                            {
                                Console.WriteLine("  i = " + i + " Vec1 = " + Priority_Vector1[i] + " Ranks1 = " + Rankings31[i] + "   Vec3A = " + Priority_Vector3A[i] + " Ranks3A = " + Rankings3A[i] + "   Vec3B = " + Priority_Vector3B[i] + " Ranks3B = " + Rankings3B[i]);
                            };

                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("   KResult31, KResult32, KResult33  ---> " + KResult31 + "  " + KResult32 + "         " + KResult33);
                            Console.WriteLine();
                        };

                    Label2: i = 9; // A dummy statement!




                        if (KResult31 != 0)
                        {
                            Sum31 = Sum31 + 1;
                        };

                        if (KResult32 != 0)
                        {
                            Sum32 = Sum32 + 1;
                        };

                        if (KResult33 != 0)
                        {
                            Sum33 = Sum33 + 1;
                        };

                        // *** Check for disagreements on the TOP item! 
                        if (KResult31 == -9)
                        {
                            Sum41 = Sum41 + 1;
                        };

                        if (KResult32 == -9)
                        {
                            Sum42 = Sum42 + 1;
                        };

                        if (KResult33 == -9)
                        {
                            Sum43 = Sum43 + 1;
                        };





                        goto Label1;

                        // *** The following code is more like the final version of this method ***

                        // *** Randomly w eget a new permutation vector ***
                        object5.Get_a_New_Permutation1(N, out New_Permutation1);

                        // *** We use the above permutation vector to permutate the original CDP matrix *** 
                        // object6.Use_Permutation_to_Adjust_CDP_Matrix1(N, CDP_Matrix0, New_Permutation1, out Permutated_CDP_Matrix1);

                        object9.Permutate_Real_Vector1(N, New_Permutation1, Random_Vector1, out Permuted_Vector1);

                        object10.Form_RCP_Matrix1(N, Permuted_Vector1, out RCP_Matrix1);
                        object11.Form_CDP_Matrix1(N, RCP_Matrix1, out CDP_Matrix1);




                        object2.Derive_The_Relative_Priorities_from_PC_Matrix1(CDP_Matrix1, N, out Priority_Vector2);





                        // *** We use the permutated CDP matrix to extra two CDP matrices ***
                        object4.Derive_Two_CDP_Matrices_from_Single_CDP_Matrix1(CDP_Matrix1, N, out CDP_Matrix1A, out CDP_Matrix1B);

                        // *** We get the priority vector and after that the Rankings from each matrix CDP_Matrix1A and CDP_Matrix1B  ***
                        object2.Derive_The_Relative_Priorities_from_PC_Matrix1(CDP_Matrix1A, N, out Priority_Vector1A);
                        object2.Derive_The_Relative_Priorities_from_PC_Matrix1(CDP_Matrix1B, N, out Priority_Vector1B);

                        object3.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector1A, N, out Rankings1A);
                        object3.Derive_The_Rankings_from_Priority_Vector1(Priority_Vector1B, N, out Rankings1B);

                        object12.Before_Permutation_Rankings_Vector1(N, New_Permutation1, Rankings1A, out Rankings2A);
                        object12.Before_Permutation_Rankings_Vector1(N, New_Permutation1, Rankings1B, out Rankings2B);


                        // MORE DEBUGGING!!!!  

                        // goto Label3;  

                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine(" >>> Some debugging info is next <<<< ");
                        Console.WriteLine();
                        Console.WriteLine("  The New Permutation Vector is: ");
                        Console.WriteLine("  -----------------------------------");
                        for (i = 1; i <= N; i++)
                        {
                            Console.WriteLine("   i --> " + i + "   New Permutation Vector = " + New_Permutation1[i]);
                        };
                        Console.WriteLine("  -----------------------------------");


                        Console.WriteLine("  Permutated_CDP_Matrix1 is here:");
                        pr1.Print_Pairwise_Matrix1(CDP_Matrix1, N);

                        Console.WriteLine("  After the permutation CDP_Matrix1A is here:");
                        pr1.Print_Pairwise_Matrix1(CDP_Matrix1A, N);

                        Console.WriteLine("  After the permutation CDP_Matrix1B is here:");
                        pr1.Print_Pairwise_Matrix1(CDP_Matrix1B, N);

                        for (i = 1; i <= N; i++)
                        {
                            Console.WriteLine("  i = " + i + "   Vector1A = " + Priority_Vector1A[i] + " Rankings1A = " + Rankings1A[i] + "   Vector1B = " + Priority_Vector1B[i] + " Rankings1B = " + Rankings1B[i]);
                        };
                        Console.WriteLine();
                        Console.WriteLine(" After the re-arrangement due to the permutation we have:  ");
                        Console.WriteLine(" **********************************************************");

                        for (i = 1; i <= N; i++)
                        {
                            Console.WriteLine("  i --> " + i + "   Origl Vectr1 = " + Priority_Vector1[i] + "   After permutation Vectr2 = " + Priority_Vector2[i]);
                        };
                        Console.WriteLine(); Console.WriteLine();
                        for (i = 1; i <= N; i++)
                        {
                            Console.WriteLine("  i = " + i + " Rankings31 ===> " + Rankings31[i] + "   Rankings2A = " + Rankings2A[i] + "    Rankings2B = " + Rankings2B[i]);
                        };

                        // Label3: i = 9;  // *** a dummy statement to jump here!

                        object13.Compare_Two_Rankings1(Rankings31, Rankings2A, N, out KResult1);

                        object13.Compare_Two_Rankings1(Rankings31, Rankings2B, N, out KResult2);

                        object13.Compare_Two_Rankings1(Rankings2A, Rankings2B, N, out KResult3);

                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("   KResult1, KResult2, KResult3  ---> " + KResult1 + "  " + KResult2 + "         " + KResult3);
                        Console.WriteLine();

                        if (KResult1 != 0)
                        {
                            Sum1 = Sum1 + 1;
                        };

                        if (KResult2 != 0)
                        {
                            Sum2 = Sum2 + 1;
                        };

                        if (KResult3 != 0)
                        {
                            Sum3 = Sum3 + 1;
                        };


                        Console.WriteLine(" **************  End of Case ******************");
                        Console.WriteLine(" ");

                    Label1: i = 99; // a dummy statement!




                    };


                    // Console.WriteLine();
                    // Console.WriteLine();
                    // Console.WriteLine("   Sum1, Sum2, Sum3 ---> " + Sum1 + "   " + Sum2 + "        " + Sum3);
                    // Console.WriteLine();



                    // Console.WriteLine();
                    // Console.WriteLine();

                    double Average12, Average412, Average41, Average42, Average43;

                    Average1 = (100.00 * Sum31) / Max_Iterations1;
                    Average2 = (100.00 * Sum32) / Max_Iterations1;
                    Average3 = (100.00 * Sum33) / Max_Iterations1;

                    Average12 = (Average1 + Average2) / 2.0;


                    Average41 = (100.00 * Sum41) / Max_Iterations1;
                    Average42 = (100.00 * Sum42) / Max_Iterations1;
                    Average43 = (100.00 * Sum43) / Max_Iterations1;

                    Average412 = (Average41 + Average42) / 2.0;


                    Console.WriteLine("  " + N + "  " + Average12 + "  " + Average3 + "          " + Average412 + "   " + Average43 );
                    
                    file1.WriteLine("  " + N + "  " + Average12 + "  " + Average3 + "          " + Average412 + "   " + Average43);

                    // Console.WriteLine();


                };

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("  **** The End! ******  " );
                Console.WriteLine();

                file1.WriteLine();
                file1.WriteLine();
                file1.WriteLine("  **** The End! ******  ");
                file1.WriteLine();
                file1.Close(); 







            } // *** End   Method ***
        }; // *** End Class ***
           // *********************************************************************************************************************





        // ************************************************************************************
        public static void Main(string[] args)
        {
            // ************************************ 
            // *** Object declarations section. ***
            // ************************************
            Scan_Values_in_Saaty_Interval_for_reciprocal_Problem1_Demo object1 = new Scan_Values_in_Saaty_Interval_for_reciprocal_Problem1_Demo();
            Explore_Reciprocal_Property_Matrices1_Demo object2 = new Explore_Reciprocal_Property_Matrices1_Demo();
            Explore_Reciprocal_Property_Matrices1a_Demo object2a = new Explore_Reciprocal_Property_Matrices1a_Demo();
            Explore_Rank_Conflicts_PC_Matrices1_Demo object3 = new Explore_Rank_Conflicts_PC_Matrices1_Demo();
            Scan_Interval_for_Reciprocity_Violations1_Demo object4 = new Scan_Interval_for_Reciprocity_Violations1_Demo();
            Analyze_Some_Case_Studies_from_the_Literature1_Demo object5 = new Analyze_Some_Case_Studies_from_the_Literature1_Demo();
            Explore_Rank_Conflicts_Type2_PC_Matrices1_Demo object6 = new Explore_Rank_Conflicts_Type2_PC_Matrices1_Demo();
            Explore_Saaty_Case_Study_for_Rank_Conflicts_Type2_PC_Matrices1_Demo object7 = new Explore_Saaty_Case_Study_for_Rank_Conflicts_Type2_PC_Matrices1_Demo();
            Explore_Ranking_Changes_after_single_CDP_Application1_Demo object8 = new Explore_Ranking_Changes_after_single_CDP_Application1_Demo();
          
            Explore_Saaty_Case_Study_for_Reciprocal_Property_Violations1_Demo object20 = new Explore_Saaty_Case_Study_for_Reciprocal_Property_Violations1_Demo();
            Explore_Stochastic_Nature_via_Simulation_and_Petrubations_of_RCP_Matrices1_Demo object21 = new Explore_Stochastic_Nature_via_Simulation_and_Petrubations_of_RCP_Matrices1_Demo();

            Explore_Saaty_Values_for_Key_Theorem_Paper2_Demo object22 = new Explore_Saaty_Values_for_Key_Theorem_Paper2_Demo();

       
            Explore_Violations_of_Clustering_Trianta_Yanase_Condition1_Demo object23 = new Explore_Violations_of_Clustering_Trianta_Yanase_Condition1_Demo();

            Explore_Permutation_Impact_on_Rankings1_Demo object24 = new Explore_Permutation_Impact_on_Rankings1_Demo();


            Explore_Violations_of_Clustering_Trianta_Yanase_Condition2_Demo object25 = new Explore_Violations_of_Clustering_Trianta_Yanase_Condition2_Demo();


            // ***************************************************************************************************
            // *** With this call we can scan the range [1/9, 9] (i.e., Saaty's Scale numerical values) and    *** 
            // *** detect when the reciprocity property is violated! It turns out it happens aroud 7.34% of    ***
            // *** all possible values!                                                                        ***
            // ***************************************************************************************************
            //
            // object1.Scan_Values_in_Saaty_Interval_for_reciprocal_Problem1();

            // **********************************************************************************************************
            // *** With this call we explore WHAT???....   Van: Check the following one!....  The follwoing one is
            // *** good for TESTS 1 and 2 for EJOR PAPER #1....                                                       *** 
            // **********************************************************************************************************
            //
            // object2.Explore_Reciprocal_Property_Matrices1();
            // object2a.Explore_Reciprocal_Property_Matrices1a();

            // **********************************************************************************************************
            // *** With this call we explore how often CDP matrices exhibit ranking conflicts                         ***
            // *** It is used to explore what happens regarding TESTS 1 and 2 for our EJOR PAPER #1.                  ***
            // *** submitted and revised during the Summer / Fall of 2022                                             ***
            // **********************************************************************************************************
            //
            // object3.Explore_Rank_Conflicts_PC_Matrices1();

            // *** In the paper I developed analytical results.  Much of the follwoing is not needed! 
            //
            // double Limit1, Limit2;
            // Limit1 = 2.00;
            // Limit2 = 4.00;
            // object4.Scan_Interval_for_Reciprocity_Violations1(Limit1, Limit2);
            //
            //         
            // object5.Analyze_Some_Case_Studies_from_the_Literature1(); //*** I could not find anything from Saaty's case studies!!!!!! Why?
            //
            //
            //
            // ***************************************************************
            // ***  This is for TEST 3  Paper 1 summer / fall 2022 ***
            // ***************************************************************
             object6.Explore_Rank_Conflicts_Type2_PC_Matrices1();
            //
            // ***************************************************************
            // ***  This is for TEST 3 Paper 1 summer / fall 2022 ***
            // ***************************************************************
            //object7.Explore_Saaty_Case_Study_for_Rank_Conflicts_Type2_PC_Matrices1();


            // object8.Explore_Ranking_Changes_after_single_CDP_Application1();



            


            // ********************************************************************************************************************
            // *** With this call we explore which if any of the 6-7 Saaty case studies exhibit Reciprocal Property violations  ***
            // *** when we consider the correspodning CDP matrices!                                                             ***
            // ********************************************************************************************************************
            // object20.Explore_Saaty_Case_Study_for_Reciprocal_Property_Violations1(); 




            // ********************************************************************************************************************
            // *** With this call we explore some potentially vey intriguing properties of CDP matrices.   We follow a
            // *** pertrubation approach to see what happens if w econsider slightly different PC matrices.  We check 
            // *** them in terms of consisty values and closeness from the initial CDP matrix.  We also check how close the 
            // *** priority vectors ar eto the real (and thus hidden) priority vector.   
            // *** In this way we can select statistical info on ranking values and priority values.  
            // *** Since a PC-based approach will have to loos esome info when compared to th ereal values, a Monte Carlo-based 
            // *** approach may be the ONLY way to proceed in this business.  This is the colmination of our study on CDP and 
            // *** related topics!   Very exciting stuff, indeed!
            // ***
            // ********************************************************************************************************************
            // 
            // object21.Explore_Stochastic_Nature_via_Simulation_and_Petrubations_of_RCP_Matrices1(); 



            // object22.Explore_Saaty_Values_for_Key_Theorem_Paper2();

            // object23.Explore_Violations_of_Clustering_Trianta_Yanase_Condition1();

            // object24.Explore_Permutation_Impact_on_Rankings1();



            //object25.Explore_Violations_of_Clustering_Trianta_Yanase_Condition2();



        }
        // ** end class Mainprogram ***
    }
}
