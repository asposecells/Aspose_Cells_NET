//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.Articles
{
    public class DataValidationRules
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            //Instantiate the workbook from sample Excel file
            Workbook workbook = new Workbook(dataDir+ "sample.xlsx");

            //Access the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            //Access Cell C1
            //Cell C1 has the Decimal Validation applied on it.
            //It can take only the values Between 10 and 20
            Cell cell = worksheet.Cells["C1"];

            //Enter 3 inside this cell
            //Since it is not between 10 and 20, it should fail the validation
            cell.PutValue(3);

            //Check if number 3 satisfies the Data Validation rule applied on this cell
            Console.WriteLine("Is 3 a Valid Value for this Cell: " + cell.GetValidationValue());

            //Enter 15 inside this cell
            //Since it is between 10 and 20, it should succeed the validation
            cell.PutValue(15);

            //Check if number 15 satisfies the Data Validation rule applied on this cell
            Console.WriteLine("Is 15 a Valid Value for this Cell: " + cell.GetValidationValue());

            //Enter 30 inside this cell
            //Since it is not between 10 and 20, it should fail the validation again
            cell.PutValue(30);

            //Check if number 30 satisfies the Data Validation rule applied on this cell
            Console.WriteLine("Is 30 a Valid Value for this Cell: " + cell.GetValidationValue());

            
        }
    }
}