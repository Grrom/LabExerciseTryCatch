using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LabExerciseTryCatch
{
    class StudentInformationClass
    {
        public static long? SetStudentNo;
        public static long? SetContactNo;
        public static int? SetAge;

        public static String SetProgram;
        public static String SetGender;
        public static String SetBirthday;
        public static String SetFullName;

        public static string[] allValues()
        {

            string[] lines =
            {
                "Student No. :"+SetStudentNo.ToString(),
              "FullName :"+ SetFullName,
              "Progran :"+ SetProgram,
              "Gender :"+ SetGender ,
              "Age :"+ SetAge.ToString(),
              "BirthDay :"+ SetBirthday,
              "Contact No :"+ SetContactNo.ToString(),
            };

            return lines;
        }


    }
}
