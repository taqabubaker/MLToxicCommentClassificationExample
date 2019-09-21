//*****************************************************************************************
//*                                                                                       *
//* This is an auto-generated file by Microsoft ML.NET CLI (Command-Line Interface) tool. *
//*                                                                                       *
//*****************************************************************************************

using Microsoft.ML.Data;

namespace MLCandidateML.Model.DataModels
{
    public class ModelInput
    {
        [ColumnName("clean_comment"), LoadColumn(0)]
        public string Clean_comment { get; set; }


        [ColumnName("Result"), LoadColumn(1)]
        public bool Result { get; set; }


    }
}
